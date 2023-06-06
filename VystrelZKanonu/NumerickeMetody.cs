using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VystrelZKanonu
{
    public class NumerickeMetody
    {  /*třída k řešení soustavy dif. rovnic ve tvaru (reseni_x(t))' = -K*(reseni_x^2+reseni_y^2)^beta
                                                        (reseni_y(t))' = -g-K*(reseni_x^2+reseni_y^2)^beta*/
        LinkedList<double> reseni_x;
        LinkedList<double> reseni_y;
        LinkedListNode<double> polozkaReseni_x, polozkaReseni_y; //pro procházení seznamy
        float beta, K, g, deltaT, reseni0_x, reseni0_y;
        public enum Metoda { EULER, HEUN, ADAMS_BASHFORTH  };
        Metoda pouzitaMetoda;
        double tKrajni; //nejvyšší čas t, po který je zatím známo řešení(t)
        public NumerickeMetody()
        {
            reseni_x = new LinkedList<double>();
            reseni_y = new LinkedList<double>();
            tKrajni = 0;
            pouzitaMetoda = Metoda.EULER;
        }
        public void nastavKoeficienty(float beta, float K, float g, float deltaT)
        {
            this.beta = beta;
            this.K = K;
            this.g = g;
            this.deltaT = deltaT;
        }
        public void nastavPocatecniPodminku(float reseni0_x, float reseni0_y)
        {
            this.reseni0_x = reseni0_x;
            this.reseni0_y = reseni0_y;
            reseni_x.AddLast(reseni0_x);
            reseni_y.AddLast(reseni0_y);
        }
        public void pouzivejMetodu(Metoda m)
        {
            pouzitaMetoda = m;
        }
        private double f_x(double reseni_x, double reseni_y)
        {//dosazuje do pravé strany 1. diferenciální rovnice
            double pom = Math.Pow(reseni_x * reseni_x + reseni_y * reseni_y, beta);
            return -K * pom;
        }
        private double f_y(double reseni_x, double reseni_y)
        {//dosazuje do pravé strany 2. diferenciální rovnice
            double pom = Math.Pow(reseni_x * reseni_x + reseni_y * reseni_y, beta);
            return -g - K * pom;
        }
        private void najdiReseniVSeznamu(ref double hledaneReseni, LinkedList<double> seznam, double tSec)
        {
            double citacT = 0; //čítač času při procházení spojovým seznamem
            LinkedListNode<double> polozkaSeznamu = seznam.First;
            do
            {
                polozkaSeznamu = polozkaSeznamu.Next;
                citacT += deltaT;
            } while (citacT + deltaT < tSec);
            if ((tSec - citacT) <= (deltaT / 2)) //řešení v čase citacT je nejlepší aproximací řešení v čase tSec
                hledaneReseni = polozkaSeznamu.Value;
            else {
                polozkaSeznamu = polozkaSeznamu.Next;
                hledaneReseni = polozkaSeznamu.Value;
            }
        }
        public float reseniX(double tSec)
        {/*zkontroluje, zda tSec < tKrajni (tehdy vrátí položku seznamu), jinak prodlouží seznam
                                                reseni_x a vrátí odpovídající položku.
                                             */
            double reseni_x_tSec = 77.77777777; //návratová hodnota
            if ((tSec <= tKrajni) || ((tSec - tKrajni) < deltaT / 2))
            {//řešení už je v seznamu, jen se musí najít
                najdiReseniVSeznamu(ref reseni_x_tSec, reseni_x, tSec);
            }
            else if (pouzitaMetoda == Metoda.EULER)
            {
                //generovat nové položky seznamu reseni_x a reseni_y, dokud tKrajni nepřeleze tSec
                polozkaReseni_x = reseni_x.Last;
                polozkaReseni_y = reseni_y.Last;
                double noveReseni_x, noveReseni_y, predchReseni_x, predchReseni_y;
                while (tKrajni < (tSec + deltaT / 2))
                {
                    predchReseni_x = polozkaReseni_x.Value;
                    predchReseni_y = polozkaReseni_y.Value;

                    noveReseni_x = predchReseni_x + deltaT * f_x(predchReseni_x, predchReseni_y);
                    noveReseni_y = predchReseni_y + deltaT * f_y(predchReseni_x, predchReseni_y);
                    reseni_x.AddLast(noveReseni_x);
                    reseni_y.AddLast(noveReseni_y);
                    tKrajni += deltaT;
                    polozkaReseni_x = polozkaReseni_x.Next;
                    polozkaReseni_y = polozkaReseni_y.Next;
                }
                reseni_x_tSec = polozkaReseni_x.Value;
            }
            else if(pouzitaMetoda == Metoda.HEUN)
            {
                polozkaReseni_x = reseni_x.Last;
                polozkaReseni_y = reseni_y.Last;
                double noveReseni_x, noveReseni_y, predchReseni_x, predchReseni_y;
                while (tKrajni < (tSec + deltaT / 2))
                {
                    predchReseni_x = polozkaReseni_x.Value;
                    predchReseni_y = polozkaReseni_y.Value;
                    double q1_x = 0.5 * f_x(predchReseni_x, predchReseni_y);
                    double q1_y = 0.5 * f_y(predchReseni_x, predchReseni_y);
                    double q2_x = 0.5 * f_x(predchReseni_x + 2 * q1_x, predchReseni_y + 2 * q1_y);
                    double q2_y = 0.5 * f_y(predchReseni_x + 2 * q1_x, predchReseni_y + 2 * q1_y);
                    noveReseni_x = predchReseni_x + deltaT * (q1_x + q2_x);
                    noveReseni_y = predchReseni_y + deltaT * (q1_y + q2_y);
                    reseni_x.AddLast(noveReseni_x);
                    reseni_y.AddLast(noveReseni_y);
                    tKrajni += deltaT;
                    polozkaReseni_x = polozkaReseni_x.Next;
                    polozkaReseni_y = polozkaReseni_y.Next;
                }
                reseni_x_tSec = polozkaReseni_x.Value;
            }
            else if(pouzitaMetoda == Metoda.ADAMS_BASHFORTH)
            {
                polozkaReseni_x = reseni_x.Last;
                polozkaReseni_y = reseni_y.Last;
                double noveReseni_x, noveReseni_y, pReseni_x, pReseni_y, ppReseni_x, ppReseni_y;//předchozí a před-předchozí řešení
                //nejprve zajistit, aby seznam řešení měl alespoň dvě položky
                if ((reseni_x.Count < 2)||(reseni_y.Count < 2)) {//1 krok Eulera
                    pReseni_x = polozkaReseni_x.Value;
                    pReseni_y = polozkaReseni_y.Value;

                    noveReseni_x = pReseni_x + deltaT * f_x(pReseni_x, pReseni_y);
                    noveReseni_y = pReseni_y + deltaT * f_y(pReseni_x, pReseni_y);
                    reseni_x.AddLast(noveReseni_x);
                    reseni_y.AddLast(noveReseni_y);
                    tKrajni += deltaT;
                    polozkaReseni_x = polozkaReseni_x.Next;
                    polozkaReseni_y = polozkaReseni_y.Next;
                }
                
                while (tKrajni < (tSec + deltaT / 2))
                {
                    pReseni_x = polozkaReseni_x.Value;
                    pReseni_y = polozkaReseni_y.Value;
                    ppReseni_x = polozkaReseni_x.Previous.Value;
                    ppReseni_y = polozkaReseni_y.Previous.Value;
                    noveReseni_x = pReseni_x + deltaT * (1.5 * f_x(pReseni_x, pReseni_y) - 0.5 * f_x(ppReseni_x, ppReseni_y));
                    noveReseni_y = pReseni_y + deltaT * (1.5 * f_y(pReseni_x, pReseni_y) - 0.5 * f_y(ppReseni_x, ppReseni_y));
                    reseni_x.AddLast(noveReseni_x);
                    reseni_y.AddLast(noveReseni_y);
                    tKrajni += deltaT;
                    polozkaReseni_x = polozkaReseni_x.Next;
                    polozkaReseni_y = polozkaReseni_y.Next;
                }
                reseni_x_tSec = polozkaReseni_x.Value;
            }

            return (float)reseni_x_tSec;
        }
        public float reseniY(double tSec)
        {
            double reseni_y_tSec = 77.77777777777; //návratová hodnota
            if ((tSec <= tKrajni) || ((tSec - tKrajni) < deltaT / 2))
            {//řešení už je v seznamu, jen se musí najít
                najdiReseniVSeznamu(ref reseni_y_tSec, reseni_y, tSec);
            }
            else if (pouzitaMetoda == Metoda.EULER)
            {
                //generovat nové položky seznamu reseni_x a reseni_y, dokud tKrajni nepřeleze tSec
                polozkaReseni_x = reseni_x.Last;
                polozkaReseni_y = reseni_y.Last;
                double noveReseni_x, noveReseni_y, predchReseni_x, predchReseni_y;
                while (tKrajni < (tSec + deltaT / 2))
                {
                    predchReseni_x = polozkaReseni_x.Value;
                    predchReseni_y = polozkaReseni_y.Value;

                    noveReseni_x = predchReseni_x + deltaT * f_x(predchReseni_x, predchReseni_y);
                    noveReseni_y = predchReseni_y + deltaT * f_y(predchReseni_x, predchReseni_y);
                    reseni_x.AddLast(noveReseni_x);
                    reseni_y.AddLast(noveReseni_y);
                    tKrajni += deltaT;
                    polozkaReseni_x = polozkaReseni_x.Next;
                    polozkaReseni_y = polozkaReseni_y.Next;
                }
                reseni_y_tSec = polozkaReseni_y.Value;
            }
            else if (pouzitaMetoda == Metoda.HEUN)
            {
                polozkaReseni_x = reseni_x.Last;
                polozkaReseni_y = reseni_y.Last;
                double noveReseni_x, noveReseni_y, predchReseni_x, predchReseni_y;
                while (tKrajni < (tSec + deltaT / 2))
                {
                    predchReseni_x = polozkaReseni_x.Value;
                    predchReseni_y = polozkaReseni_y.Value;
                    double q1_x = 0.5 * f_x(predchReseni_x, predchReseni_y);
                    double q1_y = 0.5 * f_y(predchReseni_x, predchReseni_y);
                    double q2_x = 0.5 * f_x(predchReseni_x + 2 * q1_x, predchReseni_y + 2 * q1_y);
                    double q2_y = 0.5 * f_y(predchReseni_x + 2 * q1_x, predchReseni_y + 2 * q1_y);
                    noveReseni_x = predchReseni_x + deltaT * (q1_x + q2_x);
                    noveReseni_y = predchReseni_y + deltaT * (q1_y + q2_y);
                    reseni_x.AddLast(noveReseni_x);
                    reseni_y.AddLast(noveReseni_y);
                    tKrajni += deltaT;
                    polozkaReseni_x = polozkaReseni_x.Next;
                    polozkaReseni_y = polozkaReseni_y.Next;
                }
                reseni_y_tSec = polozkaReseni_y.Value;
            }
            else if (pouzitaMetoda == Metoda.ADAMS_BASHFORTH)
            {
                polozkaReseni_x = reseni_x.Last;
                polozkaReseni_y = reseni_y.Last;
                double noveReseni_x, noveReseni_y, pReseni_x, pReseni_y, ppReseni_x, ppReseni_y;//předchozí a před-předchozí řešení
                //nejprve zajistit, aby seznam řešení měl alespoň dvě položky
                if ((reseni_x.Count < 2) || (reseni_y.Count < 2))
                {//1 krok Eulera
                    pReseni_x = polozkaReseni_x.Value;
                    pReseni_y = polozkaReseni_y.Value;

                    noveReseni_x = pReseni_x + deltaT * f_x(pReseni_x, pReseni_y);
                    noveReseni_y = pReseni_y + deltaT * f_y(pReseni_x, pReseni_y);
                    reseni_x.AddLast(noveReseni_x);
                    reseni_y.AddLast(noveReseni_y);
                    tKrajni += deltaT;
                    polozkaReseni_x = polozkaReseni_x.Next;
                    polozkaReseni_y = polozkaReseni_y.Next;
                }

                while (tKrajni < (tSec + deltaT / 2))
                {
                    pReseni_x = polozkaReseni_x.Value;
                    pReseni_y = polozkaReseni_y.Value;
                    ppReseni_x = polozkaReseni_x.Previous.Value;
                    ppReseni_y = polozkaReseni_y.Previous.Value;
                    noveReseni_x = pReseni_x + deltaT * (1.5 * f_x(pReseni_x, pReseni_y) - 0.5 * f_x(ppReseni_x, ppReseni_y));
                    noveReseni_y = pReseni_y + deltaT * (1.5 * f_y(pReseni_x, pReseni_y) - 0.5 * f_y(ppReseni_x, ppReseni_y));
                    reseni_x.AddLast(noveReseni_x);
                    reseni_y.AddLast(noveReseni_y);
                    tKrajni += deltaT;
                    polozkaReseni_x = polozkaReseni_x.Next;
                    polozkaReseni_y = polozkaReseni_y.Next;
                }
                reseni_y_tSec = polozkaReseni_x.Value;
            }

            return (float)reseni_y_tSec;
        }
        public void vymazReseni()
        {
            tKrajni = 0;
            //smazat spojové seznamy
            reseni_x = new LinkedList<double>();
            reseni_y = new LinkedList<double>();
        }
    }
}
