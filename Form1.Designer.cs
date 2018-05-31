namespace IDAStar
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.generujButton = new System.Windows.Forms.Button();
            this.szukajButton = new System.Windows.Forms.Button();
            this.wymiaryLabel = new System.Windows.Forms.Label();
            this.wymiaryNumeric = new System.Windows.Forms.NumericUpDown();
            this.heurystykaLabel = new System.Windows.Forms.Label();
            this.manhattanRadio = new System.Windows.Forms.RadioButton();
            this.heurystykaPanel = new System.Windows.Forms.Panel();
            this.chebyshevRadio = new System.Windows.Forms.RadioButton();
            this.euclideanRadio = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.wymiaryNumeric)).BeginInit();
            this.heurystykaPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 300);
            this.panel1.TabIndex = 0;
            // 
            // generujButton
            // 
            this.generujButton.Location = new System.Drawing.Point(425, 57);
            this.generujButton.Name = "generujButton";
            this.generujButton.Size = new System.Drawing.Size(75, 23);
            this.generujButton.TabIndex = 1;
            this.generujButton.Text = "Generuj";
            this.generujButton.UseVisualStyleBackColor = true;
            this.generujButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // szukajButton
            // 
            this.szukajButton.Location = new System.Drawing.Point(322, 96);
            this.szukajButton.Name = "szukajButton";
            this.szukajButton.Size = new System.Drawing.Size(94, 45);
            this.szukajButton.TabIndex = 3;
            this.szukajButton.Text = "Wyznacz Ścieżkę";
            this.szukajButton.UseVisualStyleBackColor = true;
            this.szukajButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // wymiaryLabel
            // 
            this.wymiaryLabel.AutoSize = true;
            this.wymiaryLabel.Location = new System.Drawing.Point(422, 12);
            this.wymiaryLabel.Name = "wymiaryLabel";
            this.wymiaryLabel.Size = new System.Drawing.Size(123, 13);
            this.wymiaryLabel.TabIndex = 4;
            this.wymiaryLabel.Text = "Wymiary Labiryntu (NxN)";
            // 
            // wymiaryNumeric
            // 
            this.wymiaryNumeric.Location = new System.Drawing.Point(425, 31);
            this.wymiaryNumeric.Name = "wymiaryNumeric";
            this.wymiaryNumeric.Size = new System.Drawing.Size(71, 20);
            this.wymiaryNumeric.TabIndex = 5;
            // 
            // heurystykaLabel
            // 
            this.heurystykaLabel.AutoSize = true;
            this.heurystykaLabel.Location = new System.Drawing.Point(3, 0);
            this.heurystykaLabel.Name = "heurystykaLabel";
            this.heurystykaLabel.Size = new System.Drawing.Size(60, 13);
            this.heurystykaLabel.TabIndex = 6;
            this.heurystykaLabel.Text = "Heurystyka";
            // 
            // manhattanRadio
            // 
            this.manhattanRadio.AutoSize = true;
            this.manhattanRadio.Location = new System.Drawing.Point(6, 15);
            this.manhattanRadio.Name = "manhattanRadio";
            this.manhattanRadio.Size = new System.Drawing.Size(76, 17);
            this.manhattanRadio.TabIndex = 7;
            this.manhattanRadio.TabStop = true;
            this.manhattanRadio.Text = "Manhattan";
            this.manhattanRadio.UseVisualStyleBackColor = true;
            // 
            // heurystykaPanel
            // 
            this.heurystykaPanel.Controls.Add(this.chebyshevRadio);
            this.heurystykaPanel.Controls.Add(this.euclideanRadio);
            this.heurystykaPanel.Controls.Add(this.heurystykaLabel);
            this.heurystykaPanel.Controls.Add(this.manhattanRadio);
            this.heurystykaPanel.Location = new System.Drawing.Point(322, 12);
            this.heurystykaPanel.Name = "heurystykaPanel";
            this.heurystykaPanel.Size = new System.Drawing.Size(94, 84);
            this.heurystykaPanel.TabIndex = 8;
            // 
            // chebyshevRadio
            // 
            this.chebyshevRadio.AutoSize = true;
            this.chebyshevRadio.Location = new System.Drawing.Point(6, 61);
            this.chebyshevRadio.Name = "chebyshevRadio";
            this.chebyshevRadio.Size = new System.Drawing.Size(78, 17);
            this.chebyshevRadio.TabIndex = 10;
            this.chebyshevRadio.TabStop = true;
            this.chebyshevRadio.Text = "Chebyshev";
            this.chebyshevRadio.UseVisualStyleBackColor = true;
            // 
            // euclideanRadio
            // 
            this.euclideanRadio.AutoSize = true;
            this.euclideanRadio.Location = new System.Drawing.Point(6, 38);
            this.euclideanRadio.Name = "euclideanRadio";
            this.euclideanRadio.Size = new System.Drawing.Size(66, 17);
            this.euclideanRadio.TabIndex = 8;
            this.euclideanRadio.TabStop = true;
            this.euclideanRadio.Text = "Eclidean";
            this.euclideanRadio.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 346);
            this.Controls.Add(this.heurystykaPanel);
            this.Controls.Add(this.wymiaryNumeric);
            this.Controls.Add(this.wymiaryLabel);
            this.Controls.Add(this.szukajButton);
            this.Controls.Add(this.generujButton);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "IDA*";
            ((System.ComponentModel.ISupportInitialize)(this.wymiaryNumeric)).EndInit();
            this.heurystykaPanel.ResumeLayout(false);
            this.heurystykaPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button generujButton;
        private System.Windows.Forms.Button szukajButton;
        private System.Windows.Forms.Label wymiaryLabel;
        private System.Windows.Forms.NumericUpDown wymiaryNumeric;
        private System.Windows.Forms.Label heurystykaLabel;
        private System.Windows.Forms.RadioButton manhattanRadio;
        private System.Windows.Forms.Panel heurystykaPanel;
        private System.Windows.Forms.RadioButton chebyshevRadio;
        private System.Windows.Forms.RadioButton euclideanRadio;
    }
}

