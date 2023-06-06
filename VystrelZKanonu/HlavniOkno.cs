using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace VystrelZKanonu
{
    public partial class HlavniOkno : Form
    {
        Graphics g, bg; //bg kreslí na bitmapu
        Bitmap bitmapa;
        bool poprve;
        bool provedenReset;
        float FPS;
        double interval;
        bool hlavenOtacena;//indikátor toho, že hlaveň děla je otáčena
        Point refBodOtaceni; //referenční bod otáčení hlavně; bod, v němž se nacházel kurzor při zahájení otáčení (souřadnice s počátkem vlevo nahoře)
        int dx, dy; //posun kurzoru vůči ref. bodu otáčení
        float dkVychX, dkVychY; //výchozí pozice dělové koule při startu aplikace
        float dkVHlavniX, dkVHlavniY; //souřadnice dělové koule, když je v hlavni před výstřelem
        FyzikalniModel fyz;
        PohyblivyObjekt delovaKoule;
        PohyblivyObjekt stojan, hlaven;
        //PohyblivyObjekt stojan2, hlaven2;
        SpravceAnimace spravceAnimace;
        OknoOdporu oknoOdporu;
        OknoDeloveKoule oknoDeloveKoule;

        public HlavniOkno()
        {
            InitializeComponent();
            spravceAnimace = new SpravceAnimace(SpravceAnimace.Stav.NEANIMUJE);
            poprve = true;
            provedenReset = true;
            spravceAnimace.nastavFPS(30.0f);
            fyz = new FyzikalniModel();
            fyz.nastavTihoveZrychleni(1635f); //normální tíhové zrychlení převedené na px/s^2
            fyz.nastavOdpor(FyzikalniModel.Odpor.LAMINARNI);
            fyz.nastavKrokNumReseni(1/float.Parse(Properties.Resources.VYCHOZI_FPS));
            oknoOdporu = new OknoOdporu();
            oknoOdporu.Visible = false;
            oknoDeloveKoule = new OknoDeloveKoule();
            oknoDeloveKoule.Visible = false;
            hlavenOtacena = false;
        }
        
        private void animacniSmycka()
        {
            long ted = 0; //teď v milisekundách
            long predtim = 0; //taky v milisekundách
            interval = 1000 / spravceAnimace.FPS; // interval, po jakém se má animace aktualizovat [ms]
            Stopwatch meric = new Stopwatch();
            long uplynulyCas = 0;
            bool zahajeniAnimace = true; //příznak zahájení po pauze nebo při novém pouštění od začátku
            while (!IsDisposed)
            { //toto je hlavní smyčka, kde se odehrává celý program, dokud neskončí
                Application.DoEvents();
                SpravceAnimace.Stav stav = spravceAnimace.ziskejStav();
                if (stav == SpravceAnimace.Stav.ANIMUJE)
                {
                    if (zahajeniAnimace)
                    {
                        meric.Start();
                        ted = meric.ElapsedMilliseconds;
                        predtim = ted;
                        zahajeniAnimace = false;
                    }
                    else ted = meric.ElapsedMilliseconds;
                    if (ted >= predtim + interval)
                    { 
                        //uplynulyCas = ted - predtim;
                        spravceAnimace.prekresliVCase(bg, ted);                        
                        vykreslovaciPlocha.Invalidate();
                        napisPoloha.Text = "Poloha: " + Math.Round(fyz.pxNaM(delovaKoule.x), 2, MidpointRounding.AwayFromZero) + 
                            ", " + Math.Round(fyz.pxNaM(delovaKoule.y), 2, MidpointRounding.AwayFromZero);
                        predtim = ted;
                        if (spravceAnimace.jeNaZemi(delovaKoule)) {
                            delovaKoule.nastavPozici(delovaKoule.x, SpravceAnimace.VYSKA_ZEME);
                            spravceAnimace.nastavStav(SpravceAnimace.Stav.MECHANICKA_ROVNOVAHA);
                            tlacitkoPrehrat.Enabled = false;
                        }
                    }
                }
                else if(stav == SpravceAnimace.Stav.MECHANICKA_ROVNOVAHA)
                {
                    if (meric.IsRunning) meric.Reset();
                    delovaKoule.uvestDoKlidu();
                    spravceAnimace.prekresliVCase(bg, ted);
                    vykreslovaciPlocha.Invalidate();
                    napisPoloha.Text = "Poloha: " + Math.Round(fyz.pxNaM(delovaKoule.x), 2, MidpointRounding.AwayFromZero) +
                        ", " + Math.Round(fyz.pxNaM(delovaKoule.y), 2, MidpointRounding.AwayFromZero);
                    zahajeniAnimace = true;
                    }
                else {
                    if(meric.IsRunning) meric.Stop(); //pauza
                    if (spravceAnimace.ziskejStav() == SpravceAnimace.Stav.NEANIMUJE) {
                        spravceAnimace.nakresliVychoziStav(bg);
                        vykreslovaciPlocha.Invalidate();
                        if (!provedenReset)
                        {
                            meric.Reset(); //stop
                            uplynulyCas = 0;
                            ted = 0;
                            predtim = 0;
                            float nove_v0_y = 0, nove_v0_x = 0;
                            try
                            {
                                nove_v0_x = float.Parse(polickoPocRychX.Text) / fyz.koefPxM;
                                nove_v0_y = float.Parse(polickoPocRychY.Text) / fyz.koefPxM;
                            }
                            catch { }
                            delovaKoule.nastavKinematickeVeliciny((float)dkVHlavniX, dkVHlavniY, (int) Math.Round(dkVHlavniX+delovaKoule.sirka()/2), (int)Math.Round(vykreslovaciPlocha.Height - delovaKoule.vyska()/2 - dkVHlavniY), nove_v0_x, nove_v0_y, 0, 0);
                            provedenReset = true;
                        }
                    }
                    zahajeniAnimace = true;
                }

                Thread.Sleep(1);
            }
        }

        private void HlavniOkno_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            UpdateStyles();
            bitmapa = new Bitmap(vykreslovaciPlocha.Width, vykreslovaciPlocha.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            bg = Graphics.FromImage(bitmapa);
            stojan = new PohyblivyObjekt(Properties.Resources.stojan, 0, SpravceAnimace.VYSKA_ZEME, 0, 0);
            stojan.nastavZvetseni(0.5f);
            dkVychX = (float)(30 + 0.5 * (Properties.Resources.hlaven.Width - Properties.Resources.delova_koule.Width));
            dkVychY = 25 + SpravceAnimace.VYSKA_ZEME;
            dkVHlavniX = dkVychX;
            dkVHlavniY = dkVychY;
            delovaKoule = new PohyblivyObjekt(Properties.Resources.delova_koule, dkVychX, dkVychY, 700, 1000);
            delovaKoule.nastavHmotnost(float.Parse(Properties.Resources.HMOTNOST_DELOVE_KOULE));
            delovaKoule.nastavZvetseni(0.5f);
            delovaKoule.nastavKresleniTrajektorie(true);
            hlaven = new PohyblivyObjekt(Properties.Resources.hlaven, 30, 20 + SpravceAnimace.VYSKA_ZEME, 0, 0);
            hlaven.nastavZvetseni(0.5f);
            hlaven.nastavStredOtaceni(50, 67);
            //stojan2 = new PohyblivyObjekt(Properties.Resources.stojan2, 600, SpravceAnimace.VYSKA_ZEME, 0, 0);
            //stojan2.nastavZvetseni(0.5f);
            Image otocenaHlaven = new Bitmap(Properties.Resources.hlaven);
            otocenaHlaven.RotateFlip(RotateFlipType.RotateNoneFlipX);
            //hlaven2 = new PohyblivyObjekt(otocenaHlaven, 550, 20 + SpravceAnimace.VYSKA_ZEME, 0, 0);
            //hlaven2.nastavZvetseni(0.5f);
            spravceAnimace.pridejAnimovanyObjekt(delovaKoule);
            spravceAnimace.pridejAnimovanyObjekt(stojan);
            spravceAnimace.pridejAnimovanyObjekt(hlaven);
            //spravceAnimace.pridejAnimovanyObjekt(stojan2);
            //spravceAnimace.pridejAnimovanyObjekt(hlaven2);
            spravceAnimace.nastavFyzikalniModel(fyz);
            spravceAnimace.nastavBitmapu(bitmapa);
            spravceAnimace.nakresliVychoziStav(bg);
            delovaKoule.minX = 30;
            delovaKoule.minY = vykreslovaciPlocha.Height - 30;
            double stredX = hlaven.x_0 + hlaven.ziskejZvetseni() * hlaven.stredOtaceni.X;
            double stredY = hlaven.y_0 + hlaven.ziskejZvetseni() * hlaven.stredOtaceni.Y;
            otocHlaven((float)(180 / Math.PI * Math.Atan(delovaKoule.v0_y / delovaKoule.v0_x)), stredX, stredY);
        }

        private void tlacitkoPrehrat_Click(object sender, EventArgs e)
        {
            spravceAnimace.prepniPauzu();
            if (spravceAnimace.ziskejStav() == SpravceAnimace.Stav.ANIMUJE)
            {
                if (tlacitkoPrehrat.Text == "Přehrát") delovaKoule.nastavKinematickeVeliciny(delovaKoule.x, delovaKoule.y, delovaKoule.minX, delovaKoule.minY, delovaKoule.v0_x, delovaKoule.v0_y, delovaKoule.v0_x, delovaKoule.v0_y);
                tlacitkoPrehrat.Text = "Pauza";
                tlacitkoStop.Enabled = true;

            }
            else tlacitkoPrehrat.Text = "Pokračovat";
            ctverecekTrajektorie.Enabled = false;
        }

        private void tlacitkoStop_Click(object sender, EventArgs e)
        {
            spravceAnimace.nastavStav(SpravceAnimace.Stav.NEANIMUJE);
            tlacitkoStop.Enabled = false;
            tlacitkoPrehrat.Enabled = true;
            tlacitkoPrehrat.Text = "Přehrát";
            napisPoloha.Text = "Poloha";
            provedenReset = false;
            ctverecekTrajektorie.Enabled = true;
        }

        private void HlavniOkno_Activated(object sender, EventArgs e)
        {
            if (poprve)
            {
                poprve = false;
                animacniSmycka();
            }
        }

        private void polickoFPS_Leave(object sender, EventArgs e)
        {
            bool hodnotaPlatna = zmenaCiselnehoPolicka(polickoFPS, double.Parse(Properties.Resources.MAX_FPS), ref FPS, 1);
            if (hodnotaPlatna)
            {
                interval = 1000 / FPS;
                fyz.nastavKrokNumReseni((float)interval/1000);//krok je v sekundách
            }
        }

        private void ctverecekOdpor_CheckedChanged(object sender, EventArgs e)
        {
            if (ctverecekOdpor.Checked)
            {
                tlacitkoOdpor.Enabled = true;
                fyz.nastavOdpor(oknoOdporu.ziskejNastavenyOdpor());
            }
            else {
                tlacitkoOdpor.Enabled = false;
                fyz.nastavOdpor(FyzikalniModel.Odpor.BEZ_ODPORU);
            }
        }

        private void tlacitkoOdpor_Click(object sender, EventArgs e)
        {
            if (oknoOdporu.ShowDialog() == DialogResult.OK)
            {
                FyzikalniModel.Odpor nastavenyOdpor = oknoOdporu.ziskejNastavenyOdpor();
                fyz.nastavOdpor(nastavenyOdpor);
                fyz.nastavEmpOdpSilu(oknoOdporu.ziskejB(), oknoOdporu.ziskejAlfa());
                fyz.pouzivejNumMetodu(oknoOdporu.ziskejNumMetodu());
                fyz.nastavDynamickouViskozitu(oknoOdporu.ziskejMy());
                fyz.nastavHustotuProstredi(oknoOdporu.ziskejRo());
            }
        }
        private bool zmenaCiselnehoPolicka(TextBox policko, double maxCislo, ref float menenyParametr, float koef)
        {//hodnota přečtená z pole se přenásobí koeficientem koef
            double hodnota;
            bool dosloKZmene = false;
            try
            {
                hodnota = Double.Parse(policko.Text)*koef;
            }
            catch
            {
                hodnota = -1;
            }
            if ((hodnota > 0) && (hodnota < maxCislo))
            {
                menenyParametr = (float)hodnota;
                dosloKZmene = true;
            }
            else policko.Text = (menenyParametr/ koef).ToString();
            //ladění
            //MessageBox.Show("koef " + koef + "hodnota " + hodnota + "menenyParametr" + menenyParametr + " " + dosloKZmene + " " + delovaKoule.v0_x);
            return dosloKZmene;
        }

        private void polickoPocRychX_Leave(object sender, EventArgs e)
        {
            zmenaCiselnehoPolicka(polickoPocRychX, double.Parse(Properties.Resources.MAX_V_X), ref delovaKoule.v0_x, 1/fyz.koefPxM);
            double stredX = hlaven.x_0 + hlaven.ziskejZvetseni() * hlaven.stredOtaceni.X;
            double stredY = hlaven.y_0 + hlaven.ziskejZvetseni() * hlaven.stredOtaceni.Y;
            otocHlaven((float)(180/Math.PI*Math.Atan(delovaKoule.v0_y / delovaKoule.v0_x)), stredX, stredY);
        }

        private void polickoPocRychY_Leave(object sender, EventArgs e)
        {
            zmenaCiselnehoPolicka(polickoPocRychY, double.Parse(Properties.Resources.MAX_V_Y), ref delovaKoule.v0_y, 1/fyz.koefPxM);
            double stredX = hlaven.x_0 + hlaven.ziskejZvetseni() * hlaven.stredOtaceni.X;
            double stredY = hlaven.y_0 + hlaven.ziskejZvetseni() * hlaven.stredOtaceni.Y;
            otocHlaven((float)(180/Math.PI*Math.Atan(delovaKoule.v0_y / delovaKoule.v0_x)), stredX, stredY);
        }

        private void polickoG_Leave(object sender, EventArgs e)
        {
            zmenaCiselnehoPolicka(polickoG, double.Parse(Properties.Resources.MAX_G),  ref fyz.g, 1/fyz.koefPxM);
        }

        private double eukleidNorma(double a, double b)
        {
            return Math.Sqrt(a * a + b * b);
        }
        private void otocHlaven(float uhel, double stredX, double stredY)
        {
            if ((uhel >= 0) && (uhel <= 90))
            {
                hlaven.otoc(-uhel);
                float rx = (float)(dkVychX + delovaKoule.sirka() / 2 - stredX);
                float ry = (float)(dkVychY + delovaKoule.vyska() / 2 - stredY);
                double uhelRad = uhel / 360 * 2 * Math.PI;
                double cos = Math.Cos(uhelRad);
                double sin = Math.Sin(uhelRad);
                dkVHlavniX = (float)(stredX + rx * cos - ry * sin - delovaKoule.sirka() / 2);
                dkVHlavniY = (float)(stredY + rx * sin + ry * cos - delovaKoule.vyska() / 2);
                delovaKoule.nastavVychoziPozici(dkVHlavniX, dkVHlavniY);
                float ramenoRych = (float)eukleidNorma(delovaKoule.v0_x, delovaKoule.v0_y);
                float nove_v0_x = (float)(ramenoRych * cos);
                float nove_v0_y = (float)(ramenoRych * sin);
                delovaKoule.v0_x = nove_v0_x;
                delovaKoule.v0_y = nove_v0_y;
                if (spravceAnimace.ziskejStav() == SpravceAnimace.Stav.NEANIMUJE)
                {
                    delovaKoule.nastavPozici(dkVHlavniX, dkVHlavniY);
                }
            }
        }

        private void ctverecekTrajektorie_CheckedChanged(object sender, EventArgs e)
        {
            delovaKoule.nastavKresleniTrajektorie(ctverecekTrajektorie.Checked);
        }

        private void vykreslovaciPlocha_MouseMove(object sender, MouseEventArgs e)
        {
            if (hlaven.obsahujeBod(e.X, vykreslovaciPlocha.Height - e.Y))
            {
                vykreslovaciPlocha.Cursor = Cursors.Hand;
            }
            else vykreslovaciPlocha.Cursor = DefaultCursor;
            if (hlavenOtacena)
            {
                /*dx = e.X - hlaven.stredOtaceni.X;
                dy = e.Y - refBodOtaceni.Y;
                double prepona = Math.Sqrt(dx * dx + dy * dy);
                float uhel = (float)(180 / Math.PI * Math.Asin(dy / prepona));
                hlaven.otoc(uhel);*/
                double eY = vykreslovaciPlocha.Height - e.Y;
                double stredX = hlaven.x_0 + hlaven.ziskejZvetseni() * hlaven.stredOtaceni.X;
                double stredY = hlaven.y_0 + hlaven.ziskejZvetseni() * hlaven.stredOtaceni.Y;
                double rameno1 = eukleidNorma(stredX - refBodOtaceni.X, stredY - refBodOtaceni.Y);
                double posuvKurzoru = eukleidNorma(e.X - refBodOtaceni.X, eY - refBodOtaceni.Y);
                double rameno2 = eukleidNorma(stredX - e.X, stredY - eY);
                float uhel;
                if (eY >= (refBodOtaceni.Y-stredY) / (refBodOtaceni.X - stredX) * (e.X - stredX) + stredY) 
                    uhel = (float)(180 / Math.PI * Math.Acos((rameno2*rameno2+rameno1*rameno1-posuvKurzoru*posuvKurzoru)/(2*rameno2* rameno1)));
                else uhel = (float)(360 - 180 / Math.PI * Math.Acos((rameno2 * rameno2 + rameno1 * rameno1 - posuvKurzoru * posuvKurzoru) / (2 * rameno2 * rameno1)));
                otocHlaven(uhel, stredX, stredY);
                polickoPocRychX.Text = fyz.pxNaM(delovaKoule.v0_x).ToString();
                polickoPocRychY.Text = fyz.pxNaM(delovaKoule.v0_y).ToString();
            }
        }

        private void tlacitkoDeloveKoule_Click(object sender, EventArgs e)
        {
            if (oknoDeloveKoule.ShowDialog() == DialogResult.OK)
            {
                delovaKoule.nastavHmotnost(oknoDeloveKoule.ziskejM());
                float zvetseni = 2 * oknoDeloveKoule.ziskejR() / Properties.Resources.delova_koule.Height;
                delovaKoule.nastavZvetseni(zvetseni);
                stojan.nastavZvetseni(zvetseni);
                hlaven.nastavZvetseni(zvetseni);
                hlaven.nastavVychoziPozici(5 / 37.0f * stojan.sirka(), SpravceAnimace.VYSKA_ZEME + stojan.vyska() / 12.0f);
                dkVHlavniX = hlaven.x_0 + hlaven.sirka() - delovaKoule.sirka();
                dkVHlavniY = SpravceAnimace.VYSKA_ZEME + stojan.vyska() / 12.0f + 5.0f / 133 * hlaven.vyska();
                //dkVHlavniX *= zvetseni;
                //dkVHlavniY = zvetseni * (dkVHlavniY - SpravceAnimace.VYSKA_ZEME) + SpravceAnimace.VYSKA_ZEME;
                delovaKoule.nastavVychoziPozici(dkVHlavniX, dkVHlavniY);

            }
            }

        private void vykreslovaciPlocha_MouseDown(object sender, MouseEventArgs e)
        {
            if (hlaven.obsahujeBod(e.X, vykreslovaciPlocha.Height - e.Y))
            {
                hlavenOtacena = true;
                refBodOtaceni = new Point(e.X, vykreslovaciPlocha.Height - e.Y);
                dy = 0;
            }
        }

        private void vykreslovaciPlocha_MouseUp(object sender, MouseEventArgs e)
        {
            hlavenOtacena = false;
        }

        private void HlavniOkno_Resize(object sender, EventArgs e)
        {
            if ((spravceAnimace != null)&&(WindowState != FormWindowState.Minimized))
            {
                bitmapa = new Bitmap(vykreslovaciPlocha.Width, vykreslovaciPlocha.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                bg = Graphics.FromImage(bitmapa);
                spravceAnimace.nastavBitmapu(bitmapa);
            }
        }

        private void vykreslovaciPlocha_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //existuje cosi jako g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawImage(bitmapa, 0, 0, bitmapa.Width, bitmapa.Height);
        }

    }
}
