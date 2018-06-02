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
            this.components = new System.ComponentModel.Container();
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
            this.resetujButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.kosztAkcjiNumeric = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.monitorujCheckBox = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.opoznienieNumeric = new System.Windows.Forms.NumericUpDown();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.wymiaryNumeric)).BeginInit();
            this.heurystykaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kosztAkcjiNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.opoznienieNumeric)).BeginInit();
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
            this.szukajButton.Location = new System.Drawing.Point(322, 102);
            this.szukajButton.Name = "szukajButton";
            this.szukajButton.Size = new System.Drawing.Size(94, 55);
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
            this.wymiaryNumeric.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
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
            this.manhattanRadio.Checked = true;
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
            this.euclideanRadio.Text = "Eclidean";
            this.euclideanRadio.UseVisualStyleBackColor = true;
            // 
            // resetujButton
            // 
            this.resetujButton.Location = new System.Drawing.Point(322, 163);
            this.resetujButton.Name = "resetujButton";
            this.resetujButton.Size = new System.Drawing.Size(94, 23);
            this.resetujButton.TabIndex = 9;
            this.resetujButton.Text = "Resetuj";
            this.resetujButton.UseVisualStyleBackColor = true;
            this.resetujButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(422, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Koszt Akcji";
            // 
            // kosztAkcjiNumeric
            // 
            this.kosztAkcjiNumeric.DecimalPlaces = 2;
            this.kosztAkcjiNumeric.Location = new System.Drawing.Point(425, 166);
            this.kosztAkcjiNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.kosztAkcjiNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.kosztAkcjiNumeric.Name = "kosztAkcjiNumeric";
            this.kosztAkcjiNumeric.Size = new System.Drawing.Size(94, 20);
            this.kosztAkcjiNumeric.TabIndex = 11;
            this.kosztAkcjiNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(551, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 300);
            this.panel2.TabIndex = 1;
            // 
            // monitorujCheckBox
            // 
            this.monitorujCheckBox.AutoSize = true;
            this.monitorujCheckBox.Location = new System.Drawing.Point(425, 87);
            this.monitorujCheckBox.Name = "monitorujCheckBox";
            this.monitorujCheckBox.Size = new System.Drawing.Size(107, 17);
            this.monitorujCheckBox.TabIndex = 12;
            this.monitorujCheckBox.Text = "monitoruj ścieżkę";
            this.monitorujCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(322, 216);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 13;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(422, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Opóźnienie kroku (ms)";
            // 
            // opoznienieNumeric
            // 
            this.opoznienieNumeric.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.opoznienieNumeric.Location = new System.Drawing.Point(425, 127);
            this.opoznienieNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.opoznienieNumeric.Name = "opoznienieNumeric";
            this.opoznienieNumeric.Size = new System.Drawing.Size(100, 20);
            this.opoznienieNumeric.TabIndex = 15;
            this.opoznienieNumeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(322, 255);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(429, 213);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "ilosc powodzen";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(322, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "ilosc niepowodzen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(429, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "srednia dlugosc sciezki";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 239);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "ilosc rozwinietych wezlow";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(428, 255);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 23;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 346);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.opoznienieNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.monitorujCheckBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.kosztAkcjiNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resetujButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.kosztAkcjiNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.opoznienieNumeric)).EndInit();
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
        private System.Windows.Forms.Button resetujButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown kosztAkcjiNumeric;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox monitorujCheckBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown opoznienieNumeric;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
    }
}

