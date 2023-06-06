using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Drawing;

namespace VystrelZKanonu
{
    class SpravceAnimace
    {
        public enum Stav { ANIMUJE, PAUZA, MECHANICKA_ROVNOVAHA, NEANIMUJE };
        //mechanická rovnováha znamená stav, kdy nemusí probíhat animace, protože pohyblivé objekty přišly o svou kinetickou energii (např. koule dopadla na zem)
        public const int VYSKA_ZEME = 10;
        private Stav stav;
        private FyzikalniModel fyz;
        private Bitmap bitmapa;
        private Graphics trajg; //pro vykreslení trajektorie pohyblivého objektu
        private Pen trajPero; //kreslí trajektorii
        private Bitmap bitmapaTrajektorie; //v bitmapě trajektorie se uchovává trajektorie dělové koule, nic víc
        public float FPS; //počet snímků za sekundu
        LinkedList<PohyblivyObjekt> seznamAnimovanych;
        public SpravceAnimace(Stav stav)
        {
            this.stav = stav;
            seznamAnimovanych = new LinkedList<PohyblivyObjekt>();
        }
        public void nastavFPS(float FPS)
        {
            this.FPS = FPS;
        }


        public void nakresliVychoziStav(Graphics g)
        {//nutné přísně vystajlovat pro víc objektů než 1 dělová koule
            g.Clear(Color.White);
            nakresliZemi(g);
            foreach (PohyblivyObjekt poh in seznamAnimovanych)
            {
                g.DrawImage(poh.obrazek(), poh.x, bitmapa.Height - poh.vyska() - poh.y, poh.sirka(), poh.vyska());
               
                //g.DrawRectangle(Pens.Black, poh.x, bitmapa.Height - poh.vyska() - poh.y, poh.sirka(), poh.vyska()); 
            }
        }
        private void nakresliZemi(Graphics g)
        {
            Rectangle obdelnik = new Rectangle(0, bitmapa.Height - VYSKA_ZEME, bitmapa.Width, VYSKA_ZEME);
            Brush stetec = new SolidBrush(Color.ForestGreen);
            g.FillRectangle(stetec, obdelnik);
        }
        public bool jeNaZemi(PohyblivyObjekt poh)
        {
            return (poh.y <= VYSKA_ZEME);
        }
        public void prepniPauzu()
        {
            if (stav == Stav.ANIMUJE) stav = Stav.PAUZA;
            else stav = Stav.ANIMUJE;
        }
        public void pridejAnimovanyObjekt(PohyblivyObjekt poh)
        {
            if (!seznamAnimovanych.Contains(poh)) seznamAnimovanych.AddLast(poh);
        }

        //dvojice velmi podobných metod
        public void prekresliVCase(Graphics g, long t)
        {//překreslí pohyblivé objekty na jejich pozicích x(t), y(t)
            g.Clear(Color.White);
            foreach (PohyblivyObjekt poh in seznamAnimovanych)
            {
                if (!poh.jeVKlidu())
                {   poh.pohniSeVCase(t);
                    fyz.aplikujTihoveZrychleni(poh, t);
                    fyz.aplikujOdpor(poh, FyzikalniModel.C_KOULE, poh.vyska() / 2, t);
                }
                int x = (int)Math.Round(poh.x);
                int y = (int)Math.Round(bitmapa.Height - poh.vyska() - poh.y);
                if (poh.chceKreslitTrajektorii())
                {
                    int uprostredH = poh.sirka() / 2;//uprostřed poh horizontálně
                    int uprostredV = poh.vyska() / 2;//uprostřed poh vertikálně
                    trajg.DrawLine(trajPero, poh.minX, poh.minY, x + uprostredH, y + uprostredV); //přikreslit kousek trajektorie
                    poh.minX = x + uprostredH;
                    poh.minY = y + uprostredV;
                    g.DrawImage(bitmapaTrajektorie, 0, 0);
                }
                g.DrawImage(poh.obrazek(), x, y, poh.sirka(), poh.vyska());
                //g.DrawRectangle(Pens.Black, x, y, poh.sirka(), poh.vyska()); //ladění
            }
            nakresliZemi(g);
        }
        public void prekresliPoDobe(long dt)
        {//aktualizuje pohyblivé objekty po uplynulé době dt

        }
        public void nastavFyzikalniModel(FyzikalniModel fyz)
        {
            this.fyz = fyz;
        }
        public void nastavBitmapu(Bitmap bitmapa)
        {
            this.bitmapa = bitmapa;
            bitmapaTrajektorie = new Bitmap(bitmapa.Width, bitmapa.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            trajg = Graphics.FromImage(bitmapaTrajektorie);
            trajg.Clear(Color.White);
            trajPero = new Pen(Color.Blue, 1);
        }
        public void nastavStav(Stav stav)
        {
            this.stav = stav;
            if(stav == Stav.NEANIMUJE)
            {
                trajg.Clear(Color.White);
            }
        }
        public Stav ziskejStav()
        {
            return stav;
        }
    }
}
