namespace VystrelZKanonu
{
    partial class OknoDeloveKoule
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
            this.skupinaKolecek = new System.Windows.Forms.GroupBox();
            this.polickoPolomer = new System.Windows.Forms.TextBox();
            this.polickoHustota = new System.Windows.Forms.TextBox();
            this.polickoHmotnost = new System.Windows.Forms.TextBox();
            this.koleckoPolomer = new System.Windows.Forms.RadioButton();
            this.koleckoHustota = new System.Windows.Forms.RadioButton();
            this.koleckoHmotnost = new System.Windows.Forms.RadioButton();
            this.tlacitkoOK = new System.Windows.Forms.Button();
            this.tlacitkoVychozi = new System.Windows.Forms.Button();
            this.skupinaKolecek.SuspendLayout();
            this.SuspendLayout();
            // 
            // skupinaKolecek
            // 
            this.skupinaKolecek.Controls.Add(this.tlacitkoVychozi);
            this.skupinaKolecek.Controls.Add(this.tlacitkoOK);
            this.skupinaKolecek.Controls.Add(this.polickoPolomer);
            this.skupinaKolecek.Controls.Add(this.polickoHustota);
            this.skupinaKolecek.Controls.Add(this.polickoHmotnost);
            this.skupinaKolecek.Controls.Add(this.koleckoPolomer);
            this.skupinaKolecek.Controls.Add(this.koleckoHustota);
            this.skupinaKolecek.Controls.Add(this.koleckoHmotnost);
            this.skupinaKolecek.Location = new System.Drawing.Point(40, 52);
            this.skupinaKolecek.Name = "skupinaKolecek";
            this.skupinaKolecek.Size = new System.Drawing.Size(508, 289);
            this.skupinaKolecek.TabIndex = 0;
            this.skupinaKolecek.TabStop = false;
            // 
            // polickoPolomer
            // 
            this.polickoPolomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.polickoPolomer.Location = new System.Drawing.Point(144, 138);
            this.polickoPolomer.Name = "polickoPolomer";
            this.polickoPolomer.Size = new System.Drawing.Size(100, 30);
            this.polickoPolomer.TabIndex = 5;
            this.polickoPolomer.Leave += new System.EventHandler(this.polickoPolomer_Leave);
            // 
            // polickoHustota
            // 
            this.polickoHustota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.polickoHustota.Location = new System.Drawing.Point(144, 93);
            this.polickoHustota.Name = "polickoHustota";
            this.polickoHustota.Size = new System.Drawing.Size(100, 30);
            this.polickoHustota.TabIndex = 4;
            this.polickoHustota.Text = "7870";
            this.polickoHustota.Leave += new System.EventHandler(this.polickoHustota_Leave);
            // 
            // polickoHmotnost
            // 
            this.polickoHmotnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.polickoHmotnost.Location = new System.Drawing.Point(144, 41);
            this.polickoHmotnost.Name = "polickoHmotnost";
            this.polickoHmotnost.Size = new System.Drawing.Size(100, 30);
            this.polickoHmotnost.TabIndex = 3;
            this.polickoHmotnost.Text = "111";
            this.polickoHmotnost.Leave += new System.EventHandler(this.polickoHmotnost_Leave);
            // 
            // koleckoPolomer
            // 
            this.koleckoPolomer.AutoSize = true;
            this.koleckoPolomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.koleckoPolomer.Location = new System.Drawing.Point(25, 139);
            this.koleckoPolomer.Name = "koleckoPolomer";
            this.koleckoPolomer.Size = new System.Drawing.Size(103, 29);
            this.koleckoPolomer.TabIndex = 2;
            this.koleckoPolomer.TabStop = true;
            this.koleckoPolomer.Text = "poloměr";
            this.koleckoPolomer.UseVisualStyleBackColor = true;
            this.koleckoPolomer.CheckedChanged += new System.EventHandler(this.koleckoPrumer_CheckedChanged);
            // 
            // koleckoHustota
            // 
            this.koleckoHustota.AutoSize = true;
            this.koleckoHustota.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.koleckoHustota.Location = new System.Drawing.Point(25, 94);
            this.koleckoHustota.Name = "koleckoHustota";
            this.koleckoHustota.Size = new System.Drawing.Size(97, 29);
            this.koleckoHustota.TabIndex = 1;
            this.koleckoHustota.TabStop = true;
            this.koleckoHustota.Text = "hustota";
            this.koleckoHustota.UseVisualStyleBackColor = true;
            this.koleckoHustota.CheckedChanged += new System.EventHandler(this.koleckoHustota_CheckedChanged);
            // 
            // koleckoHmotnost
            // 
            this.koleckoHmotnost.AutoSize = true;
            this.koleckoHmotnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.koleckoHmotnost.Location = new System.Drawing.Point(25, 42);
            this.koleckoHmotnost.Name = "koleckoHmotnost";
            this.koleckoHmotnost.Size = new System.Drawing.Size(113, 29);
            this.koleckoHmotnost.TabIndex = 0;
            this.koleckoHmotnost.TabStop = true;
            this.koleckoHmotnost.Text = "hmotnost";
            this.koleckoHmotnost.UseVisualStyleBackColor = true;
            this.koleckoHmotnost.CheckedChanged += new System.EventHandler(this.koleckoHmotnost_CheckedChanged);
            // 
            // tlacitkoOK
            // 
            this.tlacitkoOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.tlacitkoOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tlacitkoOK.Location = new System.Drawing.Point(181, 227);
            this.tlacitkoOK.Name = "tlacitkoOK";
            this.tlacitkoOK.Size = new System.Drawing.Size(75, 45);
            this.tlacitkoOK.TabIndex = 6;
            this.tlacitkoOK.Text = "OK";
            this.tlacitkoOK.UseVisualStyleBackColor = true;
            this.tlacitkoOK.Click += new System.EventHandler(this.tlacitkoOK_Click);
            // 
            // tlacitkoVychozi
            // 
            this.tlacitkoVychozi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tlacitkoVychozi.Location = new System.Drawing.Point(279, 227);
            this.tlacitkoVychozi.Name = "tlacitkoVychozi";
            this.tlacitkoVychozi.Size = new System.Drawing.Size(104, 45);
            this.tlacitkoVychozi.TabIndex = 6;
            this.tlacitkoVychozi.Text = "Výchozí";
            this.tlacitkoVychozi.UseVisualStyleBackColor = true;
            this.tlacitkoVychozi.Click += new System.EventHandler(this.tlacitkoVychozi_Click);
            // 
            // OknoDeloveKoule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 382);
            this.Controls.Add(this.skupinaKolecek);
            this.MaximizeBox = false;
            this.Name = "OknoDeloveKoule";
            this.Text = "Vlastnosti dělové koule";
            this.VisibleChanged += new System.EventHandler(this.OknoDeloveKoule_VisibleChanged);
            this.skupinaKolecek.ResumeLayout(false);
            this.skupinaKolecek.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox skupinaKolecek;
        private System.Windows.Forms.RadioButton koleckoPolomer;
        private System.Windows.Forms.RadioButton koleckoHustota;
        private System.Windows.Forms.RadioButton koleckoHmotnost;
        private System.Windows.Forms.TextBox polickoPolomer;
        private System.Windows.Forms.TextBox polickoHustota;
        private System.Windows.Forms.TextBox polickoHmotnost;
        private System.Windows.Forms.Button tlacitkoOK;
        private System.Windows.Forms.Button tlacitkoVychozi;
    }
}