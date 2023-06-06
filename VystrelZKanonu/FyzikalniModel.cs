using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VystrelZKanonu
{
    public class FyzikalniModel
    {
        public float g;//tíhové zrychlení v px/s^2
        private float my; //mý je dynamická viskozita prostředí
        private float ro; //hustota prostředí v kg/m^3
        private double b; //koeficient odporové síly
        private double alfa; //exponent ve vzorci pro empirickou odporovou sílu
        private float deltaT; //velikost kroku numerické metody
        public float koefPxM; //kolika metrům odpovídá jeden pixel
        NumerickeMetody nmetody;
        public enum Odpor { LAMINARNI, TURBULENTNI, EMPIRICKY, BEZ_ODPORU };
        public const float C_KOULE = 0.5f; //součinitel odporu koule
        public Odpor odpor;
        bool vypocetProbehl; //příznak toho, že pro danou simulaci již proběhl numerický výpočet 
        public FyzikalniModel()
        {
            koefPxM = 0.006f;//50 px je 30 cm
            my = (float) Double.Parse(Properties.Resources.VYCHOZI_MY, System.Globalization.NumberStyles.Float);//vzduch
            ro = float.Parse(Properties.Resources.VYCHOZI_RO_PROSTREDI);
            odpor = Odpor.BEZ_ODPORU;
            nmetody = new NumerickeMetody();
        }
        public void aplikujTihoveZrychleni(PohyblivyObjekt poh, long t)
        { //t… uplynulá doba v sekundách
            if (odpor == Odpor.BEZ_ODPORU)
            {
                float tSec = (float)t / 1000;
                poh.y = (float)(poh.y - 0.5 * g * tSec * tSec);
            }
        }
        public void aplikujOdpor(PohyblivyObjekt poh, float C, float R, long t)
        {
            //C… součinitel odporu
            //R… poloměr tělesa v px
            //tSec… uplynulá doba v sekundách
            double tSec = (double)t / 1000;
            if (odpor == Odpor.LAMINARNI)
            {
                float Rm = R * koefPxM; //poloměr tělesa v metrech
                b = 6 * Math.PI * my * Rm;
                //b *= 100000; //pro účely ladění
                poh.v_x = (float) (poh.v0_x * Math.Exp((float)(-(b/poh.m)*tSec)));
                float mezivypocet = (float) (poh.m * g / b);
                poh.v_y = (float) (-mezivypocet + (poh.v0_y + mezivypocet) * Math.Exp((float)(-(b / poh.m) * tSec)));
            }
            else if (odpor == Odpor.TURBULENTNI)
            {
                float Rm = R * koefPxM; //poloměr tělesa v metrech
                float S = (float)(Math.PI * Rm * Rm); //obsah průřezu tělesa
                b = 0.5 * C * ro * S;
                if (!vypocetProbehl)
                {
                    nmetody.vymazReseni();
                    nmetody.nastavPocatecniPodminku(poh.v0_x*koefPxM, poh.v0_y*koefPxM);
                    //nmetody.pouzivejMetodu(NumerickeMetody.Metoda.EULER);
                    nmetody.nastavKoeficienty(0.5f, (float) b / poh.m, g*koefPxM, deltaT);
                    vypocetProbehl = true;
                }
                
                poh.v_x = nmetody.reseniX(tSec)/koefPxM;
                poh.v_y = nmetody.reseniY(tSec)/koefPxM;
            }
            else if(odpor == Odpor.EMPIRICKY)
            {
                if (!vypocetProbehl)
                {
                    nmetody.vymazReseni();
                    nmetody.nastavPocatecniPodminku(poh.v0_x * koefPxM, poh.v0_y * koefPxM);
                    //nmetody.pouzivejMetodu(NumerickeMetody.Metoda.EULER);
                    nmetody.nastavKoeficienty((float)(alfa-1)/2, (float) b / poh.m, g * koefPxM, deltaT);
                    vypocetProbehl = true;
                }

                poh.v_x = nmetody.reseniX(tSec) / koefPxM;
                poh.v_y = nmetody.reseniY(tSec) / koefPxM;
            }
        }
        public void nastavOdpor(Odpor odpor)
        {
            this.odpor = odpor;
            vypocetProbehl = false;
        }
        public void nastavTihoveZrychleni(float g)
        {
            this.g = g;
            vypocetProbehl = false;
        }
        public void nastavHustotuProstredi(float ro)
        {
            this.ro = ro;
            vypocetProbehl = false;
        }
        public void nastavDynamickouViskozitu(float my)
        {
            this.my = my;
            vypocetProbehl = false;
        }
        public void nastavKrokNumReseni(float deltaT)
        {
            this.deltaT = deltaT;
        }
        public void nastavEmpOdpSilu(double b, double alfa)
        {
            this.b = b;
            this.alfa = alfa;
        }
        public void pouzivejNumMetodu(NumerickeMetody.Metoda m)
        {
            nmetody.pouzivejMetodu(m);
            vypocetProbehl = false;
        }
        public float hustotaProstredi() { return ro; }
        public float dynamickaViskozita() { return my; }
        public float tihoveZrychleni() { return g; }
        public float pxNaM(float pocetPx)
        {
            float pocetM = pocetPx * koefPxM;
            return pocetM;
        }
        public float mNaPx(float pocetM)
        {
            float pocetPx = pocetM / koefPxM;
            return pocetPx;
        }
    }
}
