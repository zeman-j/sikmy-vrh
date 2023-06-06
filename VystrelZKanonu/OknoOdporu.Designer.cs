namespace VystrelZKanonu
{
    partial class OknoOdporu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.koleckoLaminarni = new System.Windows.Forms.RadioButton();
            this.koleckoTurbulentni = new System.Windows.Forms.RadioButton();
            this.koleckoEmpiricka = new System.Windows.Forms.RadioButton();
            this.skupinaKolecek = new System.Windows.Forms.GroupBox();
            this.roletkaNumMetoda = new System.Windows.Forms.ComboBox();
            this.napisRo = new System.Windows.Forms.Label();
            this.napisMy = new System.Windows.Forms.Label();
            this.napisNumMetoda = new System.Windows.Forms.Label();
            this.napisAlfa = new System.Windows.Forms.Label();
            this.polickoAlfa = new System.Windows.Forms.NumericUpDown();
            this.napisB = new System.Windows.Forms.Label();
            this.polickoMy = new System.Windows.Forms.TextBox();
            this.polickoRo = new System.Windows.Forms.TextBox();
            this.polickoB = new System.Windows.Forms.TextBox();
            this.tlacitkoOK = new System.Windows.Forms.Button();
            this.tlacitkoVychozi = new System.Windows.Forms.Button();
            this.skupinaKolecek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polickoAlfa)).BeginInit();
            this.SuspendLayout();
            // 
            // koleckoLaminarni
            // 
            this.koleckoLaminarni.AutoSize = true;
            this.koleckoLaminarni.Checked = true;
            this.koleckoLaminarni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.koleckoLaminarni.Location = new System.Drawing.Point(6, 31);
            this.koleckoLaminarni.Name = "koleckoLaminarni";
            this.koleckoLaminarni.Size = new System.Drawing.Size(305, 29);
            this.koleckoLaminarni.TabIndex = 0;
            this.koleckoLaminarni.TabStop = true;
            this.koleckoLaminarni.Text = "laminární obtékání dělové koule";
            this.koleckoLaminarni.UseVisualStyleBackColor = true;
            this.koleckoLaminarni.CheckedChanged += new System.EventHandler(this.koleckoLaminarni_CheckedChanged);
            // 
            // koleckoTurbulentni
            // 
            this.koleckoTurbulentni.AutoSize = true;
            this.koleckoTurbulentni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.koleckoTurbulentni.Location = new System.Drawing.Point(6, 66);
            this.koleckoTurbulentni.Name = "koleckoTurbulentni";
            this.koleckoTurbulentni.Size = new System.Drawing.Size(317, 29);
            this.koleckoTurbulentni.TabIndex = 1;
            this.koleckoTurbulentni.Text = "turbulentní obtékání dělové koule";
            this.koleckoTurbulentni.UseVisualStyleBackColor = true;
            this.koleckoTurbulentni.CheckedChanged += new System.EventHandler(this.koleckoTurbulentni_CheckedChanged);
            // 
            // koleckoEmpiricka
            // 
            this.koleckoEmpiricka.AutoSize = true;
            this.koleckoEmpiricka.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.koleckoEmpiricka.Location = new System.Drawing.Point(6, 101);
            this.koleckoEmpiricka.Name = "koleckoEmpiricka";
            this.koleckoEmpiricka.Size = new System.Drawing.Size(237, 29);
            this.koleckoEmpiricka.TabIndex = 2;
            this.koleckoEmpiricka.Text = "empirická odporová síla";
            this.koleckoEmpiricka.UseVisualStyleBackColor = true;
            this.koleckoEmpiricka.CheckedChanged += new System.EventHandler(this.koleckoEmpiricka_CheckedChanged);
            // 
            // skupinaKolecek
            // 
            this.skupinaKolecek.Controls.Add(this.roletkaNumMetoda);
            this.skupinaKolecek.Controls.Add(this.napisRo);
            this.skupinaKolecek.Controls.Add(this.napisMy);
            this.skupinaKolecek.Controls.Add(this.napisNumMetoda);
            this.skupinaKolecek.Controls.Add(this.napisAlfa);
            this.skupinaKolecek.Controls.Add(this.polickoAlfa);
            this.skupinaKolecek.Controls.Add(this.napisB);
            this.skupinaKolecek.Controls.Add(this.polickoMy);
            this.skupinaKolecek.Controls.Add(this.polickoRo);
            this.skupinaKolecek.Controls.Add(this.polickoB);
            this.skupinaKolecek.Controls.Add(this.koleckoEmpiricka);
            this.skupinaKolecek.Controls.Add(this.koleckoLaminarni);
            this.skupinaKolecek.Controls.Add(this.koleckoTurbulentni);
            this.skupinaKolecek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.skupinaKolecek.Location = new System.Drawing.Point(12, 25);
            this.skupinaKolecek.Name = "skupinaKolecek";
            this.skupinaKolecek.Size = new System.Drawing.Size(397, 356);
            this.skupinaKolecek.TabIndex = 3;
            this.skupinaKolecek.TabStop = false;
            this.skupinaKolecek.Text = "Zvolte druh odporu";
            // 
            // roletkaNumMetoda
            // 
            this.roletkaNumMetoda.FormattingEnabled = true;
            this.roletkaNumMetoda.Items.AddRange(new object[] {
            "Eulerova",
            "Heunova",
            "Adams-Bashforthova"});
            this.roletkaNumMetoda.Location = new System.Drawing.Point(216, 239);
            this.roletkaNumMetoda.Name = "roletkaNumMetoda";
            this.roletkaNumMetoda.Size = new System.Drawing.Size(121, 33);
            this.roletkaNumMetoda.TabIndex = 8;
            this.roletkaNumMetoda.Text = "Eulerova";
            this.roletkaNumMetoda.SelectedIndexChanged += new System.EventHandler(this.roletkaNumMetoda_SelectedIndexChanged);
            // 
            // napisRo
            // 
            this.napisRo.AutoSize = true;
            this.napisRo.Location = new System.Drawing.Point(6, 318);
            this.napisRo.Name = "napisRo";
            this.napisRo.Size = new System.Drawing.Size(45, 25);
            this.napisRo.TabIndex = 7;
            this.napisRo.Text = "ρ = ";
            // 
            // napisMy
            // 
            this.napisMy.AutoSize = true;
            this.napisMy.Location = new System.Drawing.Point(6, 283);
            this.napisMy.Name = "napisMy";
            this.napisMy.Size = new System.Drawing.Size(45, 25);
            this.napisMy.TabIndex = 7;
            this.napisMy.Text = "μ = ";
            // 
            // napisNumMetoda
            // 
            this.napisNumMetoda.AutoSize = true;
            this.napisNumMetoda.Location = new System.Drawing.Point(6, 242);
            this.napisNumMetoda.Name = "napisNumMetoda";
            this.napisNumMetoda.Size = new System.Drawing.Size(181, 25);
            this.napisNumMetoda.TabIndex = 7;
            this.napisNumMetoda.Text = "Numerická metoda:";
            // 
            // napisAlfa
            // 
            this.napisAlfa.AutoSize = true;
            this.napisAlfa.Location = new System.Drawing.Point(65, 190);
            this.napisAlfa.Name = "napisAlfa";
            this.napisAlfa.Size = new System.Drawing.Size(40, 25);
            this.napisAlfa.TabIndex = 6;
            this.napisAlfa.Text = "α =";
            // 
            // polickoAlfa
            // 
            this.polickoAlfa.DecimalPlaces = 2;
            this.polickoAlfa.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.polickoAlfa.Location = new System.Drawing.Point(129, 188);
            this.polickoAlfa.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.polickoAlfa.Name = "polickoAlfa";
            this.polickoAlfa.Size = new System.Drawing.Size(100, 30);
            this.polickoAlfa.TabIndex = 5;
            this.polickoAlfa.Value = new decimal(new int[] {
            175,
            0,
            0,
            131072});
            this.polickoAlfa.Leave += new System.EventHandler(this.polickoAlfa_Leave);
            // 
            // napisB
            // 
            this.napisB.AutoSize = true;
            this.napisB.Location = new System.Drawing.Point(65, 139);
            this.napisB.Name = "napisB";
            this.napisB.Size = new System.Drawing.Size(40, 25);
            this.napisB.TabIndex = 4;
            this.napisB.Text = "b =";
            // 
            // polickoMy
            // 
            this.polickoMy.Location = new System.Drawing.Point(216, 280);
            this.polickoMy.Name = "polickoMy";
            this.polickoMy.Size = new System.Drawing.Size(100, 30);
            this.polickoMy.TabIndex = 3;
            this.polickoMy.Text = "1,8369247E-5";
            this.polickoMy.Leave += new System.EventHandler(this.polickoMy_Leave);
            // 
            // polickoRo
            // 
            this.polickoRo.Location = new System.Drawing.Point(216, 315);
            this.polickoRo.Name = "polickoRo";
            this.polickoRo.Size = new System.Drawing.Size(100, 30);
            this.polickoRo.TabIndex = 3;
            this.polickoRo.Text = "1,2759";
            this.polickoRo.Leave += new System.EventHandler(this.polickoRo_Leave);
            // 
            // polickoB
            // 
            this.polickoB.Location = new System.Drawing.Point(129, 136);
            this.polickoB.Name = "polickoB";
            this.polickoB.Size = new System.Drawing.Size(100, 30);
            this.polickoB.TabIndex = 3;
            this.polickoB.Text = "1";
            this.polickoB.Leave += new System.EventHandler(this.polickoB_Leave);
            // 
            // tlacitkoOK
            // 
            this.tlacitkoOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.tlacitkoOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tlacitkoOK.Location = new System.Drawing.Point(166, 387);
            this.tlacitkoOK.Name = "tlacitkoOK";
            this.tlacitkoOK.Size = new System.Drawing.Size(75, 45);
            this.tlacitkoOK.TabIndex = 4;
            this.tlacitkoOK.Text = "OK";
            this.tlacitkoOK.UseVisualStyleBackColor = true;
            this.tlacitkoOK.Click += new System.EventHandler(this.tlacitkoOK_Click);
            // 
            // tlacitkoVychozi
            // 
            this.tlacitkoVychozi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.tlacitkoVychozi.Location = new System.Drawing.Point(253, 387);
            this.tlacitkoVychozi.Name = "tlacitkoVychozi";
            this.tlacitkoVychozi.Size = new System.Drawing.Size(75, 45);
            this.tlacitkoVychozi.TabIndex = 4;
            this.tlacitkoVychozi.Text = "Výchozí";
            this.tlacitkoVychozi.UseVisualStyleBackColor = true;
            this.tlacitkoVychozi.Click += new System.EventHandler(this.tlacitkoVychozi_Click);
            // 
            // OknoOdporu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.tlacitkoVychozi);
            this.Controls.Add(this.tlacitkoOK);
            this.Controls.Add(this.skupinaKolecek);
            this.Location = new System.Drawing.Point(20, 20);
            this.MaximizeBox = false;
            this.Name = "OknoOdporu";
            this.Text = "Nastavení odporu prostředí";
            this.VisibleChanged += new System.EventHandler(this.OknoOdporu_VisibleChanged);
            this.skupinaKolecek.ResumeLayout(false);
            this.skupinaKolecek.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.polickoAlfa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton koleckoLaminarni;
        private System.Windows.Forms.RadioButton koleckoTurbulentni;
        private System.Windows.Forms.RadioButton koleckoEmpiricka;
        private System.Windows.Forms.GroupBox skupinaKolecek;
        private System.Windows.Forms.Button tlacitkoOK;
        private System.Windows.Forms.TextBox polickoB;
        private System.Windows.Forms.Label napisB;
        private System.Windows.Forms.Label napisAlfa;
        private System.Windows.Forms.NumericUpDown polickoAlfa;
        private System.Windows.Forms.ComboBox roletkaNumMetoda;
        private System.Windows.Forms.Label napisNumMetoda;
        private System.Windows.Forms.Label napisRo;
        private System.Windows.Forms.Label napisMy;
        private System.Windows.Forms.TextBox polickoMy;
        private System.Windows.Forms.TextBox polickoRo;
        private System.Windows.Forms.Button tlacitkoVychozi;
    }
}