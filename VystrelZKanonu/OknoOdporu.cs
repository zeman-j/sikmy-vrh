using System.Windows.Forms;

namespace VystrelZKanonu
{
    public partial class OknoOdporu : Form
    {
        FyzikalniModel.Odpor nastavenyOdpor;
        RadioButton puvVybraneKolecko; //původní vybrané kolečko – to, které bylo zaškrtnuté při zviditelnění okna
        float puvB, puvAlfa, puvMy, puvRo;
        float b, alfa, my, ro;
        NumerickeMetody.Metoda pouzitaMetoda;
        NumerickeMetody.Metoda puvPouzitaMetoda;
        private void nastavVychozi()
        {
            nastavenyOdpor = FyzikalniModel.Odpor.LAMINARNI; //protože koleckoLaminarni je zaškrtnuté
            puvVybraneKolecko = koleckoLaminarni;
            pouzitaMetoda = NumerickeMetody.Metoda.EULER;
            puvPouzitaMetoda = NumerickeMetody.Metoda.EULER;
            b = 1;
            alfa = 1.75f;
            puvB = 1;
            puvAlfa = 1.75f;
            my = (float)double.Parse(Properties.Resources.VYCHOZI_MY, System.Globalization.NumberStyles.Float);
            ro = (float)double.Parse(Properties.Resources.VYCHOZI_RO_PROSTREDI, System.Globalization.NumberStyles.Float);
        }
        public OknoOdporu()
        {
            InitializeComponent();
            nastavVychozi();
        }
        
        private void aktualizujPuvVybraneKolecko()
        {
            if (koleckoLaminarni.Checked) puvVybraneKolecko = koleckoLaminarni;
            else if (koleckoTurbulentni.Checked) puvVybraneKolecko = koleckoTurbulentni;
            else if (koleckoEmpiricka.Checked) puvVybraneKolecko = koleckoEmpiricka;
        }
        private void aktualizujPuvEmpSilu()
        {
            puvAlfa = alfa;
            puvB = b;
            puvMy = my;
            puvRo = ro;
            puvPouzitaMetoda = pouzitaMetoda;  
        }
        private void koleckoLaminarni_CheckedChanged(object sender, System.EventArgs e)
        {
            if (koleckoLaminarni.Checked) nastavenyOdpor = FyzikalniModel.Odpor.LAMINARNI;
        }

        private void koleckoTurbulentni_CheckedChanged(object sender, System.EventArgs e)
        {
            if (koleckoTurbulentni.Checked) nastavenyOdpor = FyzikalniModel.Odpor.TURBULENTNI;
        }

        private void koleckoEmpiricka_CheckedChanged(object sender, System.EventArgs e)
        {
            if (koleckoEmpiricka.Checked) nastavenyOdpor = FyzikalniModel.Odpor.EMPIRICKY;
        }
        public FyzikalniModel.Odpor ziskejNastavenyOdpor()
        {
            return nastavenyOdpor;
        }

        public float ziskejB()
        {
            return b;
        }
        public float ziskejAlfa()
        {
            return alfa;
        }
        public float ziskejRo()
        {
            return ro;
        }
        public float ziskejMy()
        {
            return my;
        }

        private void polickoMy_Leave(object sender, System.EventArgs e)
        {
            try { my = float.Parse(polickoMy.Text); }
            catch { }
        }

        private void polickoRo_Leave(object sender, System.EventArgs e)
        {
            try { ro = float.Parse(polickoRo.Text); }
            catch { }
        }

        private void tlacitkoVychozi_Click(object sender, System.EventArgs e)
        {
            nastavVychozi();
            koleckoLaminarni.Checked = true;

            polickoAlfa.Value = new decimal(new int[] {
            175, 0, 0, 131072});
            polickoMy.Text = Properties.Resources.VYCHOZI_MY;
            polickoRo.Text = Properties.Resources.VYCHOZI_RO_PROSTREDI;
        }

        public NumerickeMetody.Metoda ziskejNumMetodu()
        {
            return pouzitaMetoda;
        }
        private void OknoOdporu_VisibleChanged(object sender, System.EventArgs e)
        {
            if (Visible)
            {
                aktualizujPuvVybraneKolecko();
                aktualizujPuvEmpSilu();
            }
            else {
                puvVybraneKolecko.Checked = true;
                alfa = puvAlfa;
                b = puvB;
                my = puvMy;
                ro = puvRo;
                polickoB.Text = b.ToString();
                polickoAlfa.Value = (decimal)alfa;
                polickoMy.Text = my.ToString();
                polickoRo.Text = ro.ToString();
                roletkaNumMetoda.SelectedIndex = (int)puvPouzitaMetoda;
                pouzitaMetoda = puvPouzitaMetoda;
            }
        }

        private void polickoB_Leave(object sender, System.EventArgs e)
        {
            try { b = float.Parse(polickoB.Text);
            }
            catch { }

        }

        private void polickoAlfa_Leave(object sender, System.EventArgs e)
        {
            try
            {
                alfa = float.Parse(polickoAlfa.Text);
            }
            catch { }
        }

        private void roletkaNumMetoda_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            pouzitaMetoda = (NumerickeMetody.Metoda) roletkaNumMetoda.SelectedIndex;
        }

        private void tlacitkoOK_Click(object sender, System.EventArgs e)
        {
            aktualizujPuvVybraneKolecko();
            aktualizujPuvEmpSilu();
        }
    }
}
