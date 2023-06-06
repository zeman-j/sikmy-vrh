using System.Drawing;
using System;
namespace VystrelZKanonu
{
    public class PohyblivyObjekt
    {
        public float x, y; //souřadnice levého dolního rohu objektu ve vykreslovací ploše, počátek je v levém dolním rohu
        public float v_x, v_y; //rychlost objektu v pixelech za sekundu
        public float v0_x, v0_y; //počáteční rychlost objektu v px/s
        public float x_0, y_0;
        public int minX, minY; //minulé pozice v px, na nichž byl objekt vykreslen
        public bool kreslitTrajektorii;
        public Point stredOtaceni;//počátek soustavy souřadnic je vlevo dole
        float zvetseni; //koeficient, kterým se při vykreslování násobí všechny rozměry
        public float m; //hmotnost objektu v kg
        private Image obr;
        private Image obrZaloha; //normálně prázdný, ale při geom. transformacích se do něj zálohuje pův. obrázek
        public PohyblivyObjekt(Image obr, float x, float y, float v_x, float v_y)
        {
            this.obr = obr;
            this.x = x;
            this.y = y;
            this.x_0 = x;
            this.y_0 = y;
            this.v0_x = v_x;
            this.v0_y = v_y;
            v_x = 0;
            v_y = 0;
            zvetseni = 1;
            kreslitTrajektorii = false;
            obrZaloha = null;
        }
        public int vyska()
        {
            return (int)Math.Round(obr.Height * zvetseni);
        }
        public int sirka()
        {
            return (int)Math.Round(obr.Width * zvetseni);
        }

        //dvojice podobných metod, i když druhou možná smažu
        public void pohniSePoDobe(long uplynulyCas)
        {//uplynulyCas je v milisekundách
            float dtSec = (float)uplynulyCas / 1000; //uplynulý čas v sekundách
            x += v_x * dtSec;
            y += v_y * dtSec;
        }

        public void pohniSeVCase(long t)
        {
            float tSec = (float)t / 1000;
            x = x_0 + v_x * tSec;
            y = y_0 + v_y * tSec;
        }
        public Image obrazek()
        {
            return obr;
        }
        public void nastavHmotnost(float hmotnost)
        {
            m = hmotnost;
        }
        public bool chceKreslitTrajektorii()
        {
            return kreslitTrajektorii;
        }
        public void nastavKresleniTrajektorie(bool kreslit)
        {
            kreslitTrajektorii = kreslit;
        }
        public void nastavKinematickeVeliciny(float x, float y, int minX, int minY, float v0_x, float v0_y, float v_x, float v_y)
        {
            this.x = x;
            this.y = y;
            this.minX = minX;
            this.minY = minY;
            if ((v0_x > 0) && (v0_x < float.Parse(Properties.Resources.MAX_V_X))) this.v0_x = v0_x;
            if ((v0_y > 0) && (v0_y < float.Parse(Properties.Resources.MAX_V_Y))) this.v0_y = v0_y;
            if ((v_x > 0) && (v_x < float.Parse(Properties.Resources.MAX_V_X))) this.v_x = v_x;
            if ((v_y > 0) && (v_y < float.Parse(Properties.Resources.MAX_V_Y))) this.v_y = v_y;
        }
        public void nastavPozici(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public void nastavVychoziPozici(float x_0, float y_0)
        {
            this.x_0 = x_0;
            this.y_0 = y_0;
        }
        public void uvestDoKlidu()
        {
            v_x = 0;
            v_y = 0;
        }
        public void nastavZvetseni(float zvetseni)
        {
            this.zvetseni = zvetseni;
        }
        public bool jeVKlidu()
        {
            return (v_x == 0) && (v_y == 0);
        }
        public bool obsahujeBod(int x, int y)
        {//bod [x, y] je zadán v souřadnicích s počátkem v levém dolním rohu
            return ((x >= this.x) && (x <= (this.x + this.sirka())) && (y >= this.y) && (y <= (this.y + this.vyska())));
        }
        public void nastavStredOtaceni(int X, int Y)
        {
            //nastaví (nezmenšenému) obrázku pohyblivého objektu střed otáčení (počátek souřadnic vlevo dole)
            if (stredOtaceni == null) { stredOtaceni = new Point((int)x, (int)y); }
            else { stredOtaceni.X = X; stredOtaceni.Y = Y; }
        }
        private double eukleidNorma(double a, double b)
        {
            return Math.Sqrt(a * a + b * b);
        }
        public void otoc(float theta)
        {
            //otočí obrázek obr daného pohyblivého objektu o úhel theta (ve stupních) po směru hod. ručiček 
            //okolo bodu stred v rámci přísl. obrázku (počátek souř. systému vpravo nahoře)
            if (obrZaloha == null) { obrZaloha = obr; }
            obr = obrZaloha;
            double thetaRad = theta / 360 * 2 * Math.PI;
            double sin = Math.Abs(Math.Sin(thetaRad));
            double cos = Math.Abs(Math.Cos(thetaRad));
            int rozmerX = (int)(obr.Width * cos + obr.Height * sin);
            int rozmerY = (int)(obr.Width * sin + obr.Height * cos);
            Bitmap bmp = new Bitmap(rozmerX, rozmerY); //občas hází chybu
            bmp.SetResolution(obr.HorizontalResolution, obr.VerticalResolution);
            Graphics g = Graphics.FromImage(bmp);
            g.TranslateTransform((float)(rozmerX - obr.Width) / 2, (float)(rozmerY - obr.Height) / 2);
            g.TranslateTransform((float)obr.Width / 2, (float)obr.Height / 2);
            g.RotateTransform(theta);
            g.TranslateTransform((float)-obr.Width / 2, (float)-obr.Height / 2);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(obr, 0, 0);
            /*Font ft = new Font("Helvetica", 18, FontStyle.Italic);
            g.DrawString("theta[°] = " + theta, ft, Brushes.Black, 0, 0);
            Rectangle pomObd = new Rectangle(stredOtaceni.X - 5, stredOtaceni.Y - 5, 7, 7);
            g.FillEllipse(Brushes.OrangeRed, pomObd); 
            g.Dispose();
            //posunout pohyblivý objekt
            if (thetaRad <= 0)
            {*/
            sin = Math.Sin(-thetaRad);
            cos = Math.Cos(-thetaRad);
                x = (float)(x_0 + zvetseni * (-obrZaloha.Height * sin - stredOtaceni.X * cos + stredOtaceni.Y * sin + stredOtaceni.X));
                y = (float)(y_0 + zvetseni * (-stredOtaceni.X * sin - stredOtaceni.Y * cos + stredOtaceni.Y));
           /* }
            else
            {
                x = (float)(x_0 + zvetseni * (-stredOtaceni.X * Math.Cos(thetaRad) - stredOtaceni.Y * Math.Sin(thetaRad) + stredOtaceni.X));
                y = (float)(y_0 + zvetseni * (-(obrZaloha.Width - stredOtaceni.X) * Math.Sin(thetaRad) - stredOtaceni.Y * cos + stredOtaceni.Y));
            }*/
            obr = bmp;
        }
        public float ziskejZvetseni()
        {
            return zvetseni;
        }
    }
}
