using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VystrelZKanonu
{
    public partial class OknoDeloveKoule : Form
    {
        float Rm; //poloměr v metrech
        float ro;
        float m;
        float ctpi; //čtyři třetiny pí
        float puvRm, puvRo, puvM;
        FyzikalniModel prevodnik;

        private void nastavVychozi()
        {
            Rm = (float)(prevodnik.koefPxM * Properties.Resources.delova_koule.Height * 0.5 * 0.5);
            puvRm = Rm;
            ro = float.Parse(Properties.Resources.HUSTOTA_ZELEZA);
            puvRo = ro;
            m = float.Parse(Properties.Resources.HMOTNOST_DELOVE_KOULE);
            puvM = m;
            this.polickoPolomer.Text = Rm.ToString();
            this.polickoHmotnost.Text = m.ToString();
            this.polickoHustota.Text = ro.ToString();
        }
        public OknoDeloveKoule()
        {
            InitializeComponent();
            prevodnik = new FyzikalniModel();
            nastavVychozi();
            ctpi = (float)((4 / 3) * Math.PI);
           
        }
        public float ziskejR()
        {
            return prevodnik.mNaPx(Rm);
        }

        public float ziskejRo()
        {
            return ro;
        }

        public float ziskejM()
        {
            return m;
        }

        private void koleckoHmotnost_CheckedChanged(object sender, EventArgs e)
        {
            if (koleckoHmotnost.Checked) { polickoHmotnost.Enabled = false; }
            else polickoHmotnost.Enabled = true;
        }

        private void koleckoHustota_CheckedChanged(object sender, EventArgs e)
        {
            if (koleckoHustota.Checked) { polickoHustota.Enabled = false; }
            else polickoHustota.Enabled = true;
        }

        private void koleckoPrumer_CheckedChanged(object sender, EventArgs e)
        {
            if (koleckoPolomer.Checked) { polickoPolomer.Enabled = false; }
            else polickoPolomer.Enabled = true;
        }

        private void polickoHmotnost_Leave(object sender, EventArgs e)
        {
            try {
                m = float.Parse(polickoHmotnost.Text);
                if (!polickoPolomer.Enabled)
                {
                    Rm = (float)Math.Pow(m / (ctpi* ro), 1.0 / 3.0);
                    polickoPolomer.Text = Rm.ToString();
                }
                else if (!polickoHustota.Enabled)
                {
                    ro = m / (ctpi * Rm * Rm * Rm);
                    polickoHustota.Text = ro.ToString();
                }
                        }
            catch {  }
        }

        private void tlacitkoVychozi_Click(object sender, EventArgs e)
        {
            nastavVychozi();
        }

        private void tlacitkoOK_Click(object sender, EventArgs e)
        {
            puvM = m;
            puvRo = ro;
            puvRm = Rm;
        }

        private void OknoDeloveKoule_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible) { }
            else {
                m = puvM;
                ro = puvRo;
                Rm = puvRm;
                polickoHmotnost.Text = m.ToString();
                polickoHustota.Text = ro.ToString();
                polickoPolomer.Text = Rm.ToString();
            }
        }

        private void polickoHustota_Leave(object sender, EventArgs e)
        {
            try
            {
                ro = float.Parse(polickoHustota.Text);
                if (!polickoPolomer.Enabled)
                {
                    Rm = (float)Math.Pow(m / (ctpi* ro), 1.0 / 3.0);
                    polickoPolomer.Text = Rm.ToString();
                }
                else if (!polickoHmotnost.Enabled)
                {
                    m = ctpi * ro * Rm * Rm * Rm;
                    polickoHmotnost.Text = m.ToString();
                }
            }
            catch { }
        }

        private void polickoPolomer_Leave(object sender, EventArgs e)
        {
            try
            {
                Rm = float.Parse(polickoPolomer.Text);
                if (!polickoHmotnost.Enabled)
                {
                    m = ctpi * ro * Rm * Rm * Rm;
                    polickoHmotnost.Text = m.ToString();
                }
                else if (!polickoHustota.Enabled)
                {
                    ro = m / (ctpi * Rm * Rm * Rm);
                    polickoHustota.Text = ro.ToString();
                }
            }
            catch { }
        }
    }
}
