namespace VystrelZKanonu
{
    partial class HlavniOkno
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
            this.vykreslovaciPlocha = new System.Windows.Forms.PictureBox();
            this.ovladaciPanel = new System.Windows.Forms.Panel();
            this.tlacitkoDeloveKoule = new System.Windows.Forms.Button();
            this.tlacitkoOdpor = new System.Windows.Forms.Button();
            this.ctverecekOdpor = new System.Windows.Forms.CheckBox();
            this.tlacitkoStop = new System.Windows.Forms.Button();
            this.napisG = new System.Windows.Forms.Label();
            this.napisPocRychY = new System.Windows.Forms.Label();
            this.napisPocRychX = new System.Windows.Forms.Label();
            this.napisFPS = new System.Windows.Forms.Label();
            this.polickoG = new System.Windows.Forms.TextBox();
            this.polickoPocRychY = new System.Windows.Forms.TextBox();
            this.polickoPocRychX = new System.Windows.Forms.TextBox();
            this.polickoFPS = new System.Windows.Forms.TextBox();
            this.tlacitkoPrehrat = new System.Windows.Forms.Button();
            this.napisPoloha = new System.Windows.Forms.Label();
            this.ctverecekTrajektorie = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.vykreslovaciPlocha)).BeginInit();
            this.ovladaciPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vykreslovaciPlocha
            // 
            this.vykreslovaciPlocha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vykreslovaciPlocha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.vykreslovaciPlocha.Location = new System.Drawing.Point(1, 1);
            this.vykreslovaciPlocha.Name = "vykreslovaciPlocha";
            this.vykreslovaciPlocha.Size = new System.Drawing.Size(630, 533);
            this.vykreslovaciPlocha.TabIndex = 0;
            this.vykreslovaciPlocha.TabStop = false;
            this.vykreslovaciPlocha.Paint += new System.Windows.Forms.PaintEventHandler(this.vykreslovaciPlocha_Paint);
            this.vykreslovaciPlocha.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vykreslovaciPlocha_MouseDown);
            this.vykreslovaciPlocha.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vykreslovaciPlocha_MouseMove);
            this.vykreslovaciPlocha.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vykreslovaciPlocha_MouseUp);
            // 
            // ovladaciPanel
            // 
            this.ovladaciPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ovladaciPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ovladaciPanel.Controls.Add(this.tlacitkoDeloveKoule);
            this.ovladaciPanel.Controls.Add(this.tlacitkoOdpor);
            this.ovladaciPanel.Controls.Add(this.ctverecekTrajektorie);
            this.ovladaciPanel.Controls.Add(this.ctverecekOdpor);
            this.ovladaciPanel.Controls.Add(this.tlacitkoStop);
            this.ovladaciPanel.Controls.Add(this.napisG);
            this.ovladaciPanel.Controls.Add(this.napisPocRychY);
            this.ovladaciPanel.Controls.Add(this.napisPocRychX);
            this.ovladaciPanel.Controls.Add(this.napisFPS);
            this.ovladaciPanel.Controls.Add(this.polickoG);
            this.ovladaciPanel.Controls.Add(this.polickoPocRychY);
            this.ovladaciPanel.Controls.Add(this.polickoPocRychX);
            this.ovladaciPanel.Controls.Add(this.polickoFPS);
            this.ovladaciPanel.Controls.Add(this.tlacitkoPrehrat);
            this.ovladaciPanel.Controls.Add(this.napisPoloha);
            this.ovladaciPanel.Location = new System.Drawing.Point(636, 0);
            this.ovladaciPanel.Name = "ovladaciPanel";
            this.ovladaciPanel.Size = new System.Drawing.Size(294, 532);
            this.ovladaciPanel.TabIndex = 1;
            // 
            // tlacitkoDeloveKoule
            // 
            this.tlacitkoDeloveKoule.Location = new System.Drawing.Point(89, 415);
            this.tlacitkoDeloveKoule.Name = "tlacitkoDeloveKoule";
            this.tlacitkoDeloveKoule.Size = new System.Drawing.Size(125, 45);
            this.tlacitkoDeloveKoule.TabIndex = 8;
            this.tlacitkoDeloveKoule.Text = "Dělová koule";
            this.tlacitkoDeloveKoule.UseVisualStyleBackColor = true;
            this.tlacitkoDeloveKoule.Click += new System.EventHandler(this.tlacitkoDeloveKoule_Click);
            // 
            // tlacitkoOdpor
            // 
            this.tlacitkoOdpor.Location = new System.Drawing.Point(49, 315);
            this.tlacitkoOdpor.Name = "tlacitkoOdpor";
            this.tlacitkoOdpor.Size = new System.Drawing.Size(125, 45);
            this.tlacitkoOdpor.TabIndex = 8;
            this.tlacitkoOdpor.Text = "Nastavení odporu";
            this.tlacitkoOdpor.UseVisualStyleBackColor = true;
            this.tlacitkoOdpor.Click += new System.EventHandler(this.tlacitkoOdpor_Click);
            // 
            // ctverecekOdpor
            // 
            this.ctverecekOdpor.AutoSize = true;
            this.ctverecekOdpor.Checked = true;
            this.ctverecekOdpor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctverecekOdpor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctverecekOdpor.Location = new System.Drawing.Point(10, 280);
            this.ctverecekOdpor.Name = "ctverecekOdpor";
            this.ctverecekOdpor.Size = new System.Drawing.Size(164, 29);
            this.ctverecekOdpor.TabIndex = 7;
            this.ctverecekOdpor.Text = "odpor prostředí";
            this.ctverecekOdpor.UseVisualStyleBackColor = true;
            this.ctverecekOdpor.CheckedChanged += new System.EventHandler(this.ctverecekOdpor_CheckedChanged);
            // 
            // tlacitkoStop
            // 
            this.tlacitkoStop.Enabled = false;
            this.tlacitkoStop.Location = new System.Drawing.Point(163, 39);
            this.tlacitkoStop.Name = "tlacitkoStop";
            this.tlacitkoStop.Size = new System.Drawing.Size(75, 45);
            this.tlacitkoStop.TabIndex = 6;
            this.tlacitkoStop.Text = "● Stop";
            this.tlacitkoStop.UseVisualStyleBackColor = true;
            this.tlacitkoStop.Click += new System.EventHandler(this.tlacitkoStop_Click);
            // 
            // napisG
            // 
            this.napisG.AutoSize = true;
            this.napisG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.napisG.Location = new System.Drawing.Point(5, 238);
            this.napisG.Name = "napisG";
            this.napisG.Size = new System.Drawing.Size(45, 25);
            this.napisG.TabIndex = 5;
            this.napisG.Text = "g = ";
            // 
            // napisPocRychY
            // 
            this.napisPocRychY.AutoSize = true;
            this.napisPocRychY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.napisPocRychY.Location = new System.Drawing.Point(5, 199);
            this.napisPocRychY.Name = "napisPocRychY";
            this.napisPocRychY.Size = new System.Drawing.Size(119, 25);
            this.napisPocRychY.TabIndex = 3;
            this.napisPocRychY.Text = "Poč. rych. y:";
            // 
            // napisPocRychX
            // 
            this.napisPocRychX.AutoSize = true;
            this.napisPocRychX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.napisPocRychX.Location = new System.Drawing.Point(5, 160);
            this.napisPocRychX.Name = "napisPocRychX";
            this.napisPocRychX.Size = new System.Drawing.Size(119, 25);
            this.napisPocRychX.TabIndex = 3;
            this.napisPocRychX.Text = "Poč. rych. x:";
            // 
            // napisFPS
            // 
            this.napisFPS.AutoSize = true;
            this.napisFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.napisFPS.Location = new System.Drawing.Point(5, 120);
            this.napisFPS.Name = "napisFPS";
            this.napisFPS.Size = new System.Drawing.Size(57, 25);
            this.napisFPS.TabIndex = 3;
            this.napisFPS.Text = "FPS:";
            // 
            // polickoG
            // 
            this.polickoG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.polickoG.Location = new System.Drawing.Point(138, 235);
            this.polickoG.MaxLength = 15;
            this.polickoG.Name = "polickoG";
            this.polickoG.Size = new System.Drawing.Size(100, 30);
            this.polickoG.TabIndex = 5;
            this.polickoG.Text = "9,81";
            this.polickoG.Leave += new System.EventHandler(this.polickoG_Leave);
            // 
            // polickoPocRychY
            // 
            this.polickoPocRychY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.polickoPocRychY.Location = new System.Drawing.Point(138, 196);
            this.polickoPocRychY.MaxLength = 15;
            this.polickoPocRychY.Name = "polickoPocRychY";
            this.polickoPocRychY.Size = new System.Drawing.Size(100, 30);
            this.polickoPocRychY.TabIndex = 4;
            this.polickoPocRychY.Text = "6";
            this.polickoPocRychY.Leave += new System.EventHandler(this.polickoPocRychY_Leave);
            // 
            // polickoPocRychX
            // 
            this.polickoPocRychX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.polickoPocRychX.Location = new System.Drawing.Point(138, 157);
            this.polickoPocRychX.MaxLength = 15;
            this.polickoPocRychX.Name = "polickoPocRychX";
            this.polickoPocRychX.Size = new System.Drawing.Size(100, 30);
            this.polickoPocRychX.TabIndex = 3;
            this.polickoPocRychX.Text = "4,2";
            this.polickoPocRychX.Leave += new System.EventHandler(this.polickoPocRychX_Leave);
            // 
            // polickoFPS
            // 
            this.polickoFPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.polickoFPS.Location = new System.Drawing.Point(138, 117);
            this.polickoFPS.MaxLength = 4;
            this.polickoFPS.Name = "polickoFPS";
            this.polickoFPS.Size = new System.Drawing.Size(100, 30);
            this.polickoFPS.TabIndex = 2;
            this.polickoFPS.Text = "30";
            this.polickoFPS.Leave += new System.EventHandler(this.polickoFPS_Leave);
            // 
            // tlacitkoPrehrat
            // 
            this.tlacitkoPrehrat.Location = new System.Drawing.Point(10, 39);
            this.tlacitkoPrehrat.Name = "tlacitkoPrehrat";
            this.tlacitkoPrehrat.Size = new System.Drawing.Size(127, 45);
            this.tlacitkoPrehrat.TabIndex = 1;
            this.tlacitkoPrehrat.Text = "Přehrát";
            this.tlacitkoPrehrat.UseVisualStyleBackColor = true;
            this.tlacitkoPrehrat.Click += new System.EventHandler(this.tlacitkoPrehrat_Click);
            // 
            // napisPoloha
            // 
            this.napisPoloha.AutoSize = true;
            this.napisPoloha.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.napisPoloha.Location = new System.Drawing.Point(4, 4);
            this.napisPoloha.Name = "napisPoloha";
            this.napisPoloha.Size = new System.Drawing.Size(98, 31);
            this.napisPoloha.TabIndex = 0;
            this.napisPoloha.Text = "Poloha";
            // 
            // ctverecekTrajektorie
            // 
            this.ctverecekTrajektorie.AutoSize = true;
            this.ctverecekTrajektorie.Checked = true;
            this.ctverecekTrajektorie.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ctverecekTrajektorie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ctverecekTrajektorie.Location = new System.Drawing.Point(10, 380);
            this.ctverecekTrajektorie.Name = "ctverecekTrajektorie";
            this.ctverecekTrajektorie.Size = new System.Drawing.Size(166, 29);
            this.ctverecekTrajektorie.TabIndex = 7;
            this.ctverecekTrajektorie.Text = "kreslit trajektorii";
            this.ctverecekTrajektorie.UseVisualStyleBackColor = true;
            this.ctverecekTrajektorie.CheckedChanged += new System.EventHandler(this.ctverecekTrajektorie_CheckedChanged);
            // 
            // HlavniOkno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 534);
            this.Controls.Add(this.ovladaciPanel);
            this.Controls.Add(this.vykreslovaciPlocha);
            this.Name = "HlavniOkno";
            this.Text = "„Výstřel z kanónu“";
            this.Activated += new System.EventHandler(this.HlavniOkno_Activated);
            this.Load += new System.EventHandler(this.HlavniOkno_Load);
            this.Resize += new System.EventHandler(this.HlavniOkno_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.vykreslovaciPlocha)).EndInit();
            this.ovladaciPanel.ResumeLayout(false);
            this.ovladaciPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox vykreslovaciPlocha;
        private System.Windows.Forms.Panel ovladaciPanel;
        private System.Windows.Forms.Label napisPoloha;
        private System.Windows.Forms.Button tlacitkoPrehrat;
        private System.Windows.Forms.Label napisFPS;
        private System.Windows.Forms.TextBox polickoFPS;
        private System.Windows.Forms.Label napisPocRychY;
        private System.Windows.Forms.Label napisPocRychX;
        private System.Windows.Forms.TextBox polickoPocRychY;
        private System.Windows.Forms.TextBox polickoPocRychX;
        private System.Windows.Forms.Label napisG;
        private System.Windows.Forms.TextBox polickoG;
        private System.Windows.Forms.Button tlacitkoStop;
        private System.Windows.Forms.Button tlacitkoOdpor;
        private System.Windows.Forms.CheckBox ctverecekOdpor;
        private System.Windows.Forms.Button tlacitkoDeloveKoule;
        private System.Windows.Forms.CheckBox ctverecekTrajektorie;
    }
}

