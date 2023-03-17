namespace GestioneSequenziale
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.output = new System.Windows.Forms.ListView();
            this.salva_button = new System.Windows.Forms.Button();
            this.cancella_button = new System.Windows.Forms.Button();
            this.modifica_button = new System.Windows.Forms.Button();
            this.leggi_button = new System.Windows.Forms.Button();
            this.nome_textbox = new System.Windows.Forms.TextBox();
            this.prezzo_textbox = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.prezzo_label = new System.Windows.Forms.Label();
            this.nome_label = new System.Windows.Forms.Label();
            this.nomeDaCancellare_label = new System.Windows.Forms.Label();
            this.nuovoPrezzo_label = new System.Windows.Forms.Label();
            this.nuovoNome_label = new System.Windows.Forms.Label();
            this.nomeDaMod_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.HideSelection = false;
            this.output.Location = new System.Drawing.Point(494, 12);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(294, 426);
            this.output.TabIndex = 0;
            this.output.UseCompatibleStateImageBehavior = false;
            // 
            // salva_button
            // 
            this.salva_button.Location = new System.Drawing.Point(60, 37);
            this.salva_button.Name = "salva_button";
            this.salva_button.Size = new System.Drawing.Size(75, 23);
            this.salva_button.TabIndex = 1;
            this.salva_button.Text = "Salva";
            this.salva_button.UseVisualStyleBackColor = true;
            this.salva_button.Click += new System.EventHandler(this.salva_button_Click);
            // 
            // cancella_button
            // 
            this.cancella_button.Location = new System.Drawing.Point(60, 84);
            this.cancella_button.Name = "cancella_button";
            this.cancella_button.Size = new System.Drawing.Size(75, 23);
            this.cancella_button.TabIndex = 2;
            this.cancella_button.Text = "Cancella";
            this.cancella_button.UseVisualStyleBackColor = true;
            // 
            // modifica_button
            // 
            this.modifica_button.Location = new System.Drawing.Point(60, 132);
            this.modifica_button.Name = "modifica_button";
            this.modifica_button.Size = new System.Drawing.Size(75, 23);
            this.modifica_button.TabIndex = 3;
            this.modifica_button.Text = "Modifica";
            this.modifica_button.UseVisualStyleBackColor = true;
            // 
            // leggi_button
            // 
            this.leggi_button.Location = new System.Drawing.Point(60, 181);
            this.leggi_button.Name = "leggi_button";
            this.leggi_button.Size = new System.Drawing.Size(75, 23);
            this.leggi_button.TabIndex = 4;
            this.leggi_button.Text = "Leggi";
            this.leggi_button.UseVisualStyleBackColor = true;
            this.leggi_button.Click += new System.EventHandler(this.leggi_button_Click);
            // 
            // nome_textbox
            // 
            this.nome_textbox.Location = new System.Drawing.Point(156, 39);
            this.nome_textbox.Name = "nome_textbox";
            this.nome_textbox.Size = new System.Drawing.Size(100, 20);
            this.nome_textbox.TabIndex = 5;
            // 
            // prezzo_textbox
            // 
            this.prezzo_textbox.Location = new System.Drawing.Point(277, 39);
            this.prezzo_textbox.Name = "prezzo_textbox";
            this.prezzo_textbox.Size = new System.Drawing.Size(100, 20);
            this.prezzo_textbox.TabIndex = 6;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(277, 134);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(86, 20);
            this.textBox3.TabIndex = 8;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(156, 134);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 7;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(375, 134);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(76, 20);
            this.textBox5.TabIndex = 9;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(156, 86);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 10;
            // 
            // prezzo_label
            // 
            this.prezzo_label.AutoSize = true;
            this.prezzo_label.Location = new System.Drawing.Point(306, 23);
            this.prezzo_label.Name = "prezzo_label";
            this.prezzo_label.Size = new System.Drawing.Size(39, 13);
            this.prezzo_label.TabIndex = 12;
            this.prezzo_label.Text = "Prezzo";
            // 
            // nome_label
            // 
            this.nome_label.AutoSize = true;
            this.nome_label.Location = new System.Drawing.Point(188, 23);
            this.nome_label.Name = "nome_label";
            this.nome_label.Size = new System.Drawing.Size(35, 13);
            this.nome_label.TabIndex = 11;
            this.nome_label.Text = "Nome";
            // 
            // nomeDaCancellare_label
            // 
            this.nomeDaCancellare_label.AutoSize = true;
            this.nomeDaCancellare_label.Location = new System.Drawing.Point(154, 70);
            this.nomeDaCancellare_label.Name = "nomeDaCancellare_label";
            this.nomeDaCancellare_label.Size = new System.Drawing.Size(102, 13);
            this.nomeDaCancellare_label.TabIndex = 16;
            this.nomeDaCancellare_label.Text = "Nome da cancellare";
            // 
            // nuovoPrezzo_label
            // 
            this.nuovoPrezzo_label.AutoSize = true;
            this.nuovoPrezzo_label.Location = new System.Drawing.Point(378, 118);
            this.nuovoPrezzo_label.Name = "nuovoPrezzo_label";
            this.nuovoPrezzo_label.Size = new System.Drawing.Size(73, 13);
            this.nuovoPrezzo_label.TabIndex = 19;
            this.nuovoPrezzo_label.Text = "Nuovo prezzo";
            // 
            // nuovoNome_label
            // 
            this.nuovoNome_label.AutoSize = true;
            this.nuovoNome_label.Location = new System.Drawing.Point(286, 118);
            this.nuovoNome_label.Name = "nuovoNome_label";
            this.nuovoNome_label.Size = new System.Drawing.Size(68, 13);
            this.nuovoNome_label.TabIndex = 18;
            this.nuovoNome_label.Text = "Nuovo nome";
            // 
            // nomeDaMod_label
            // 
            this.nomeDaMod_label.AutoSize = true;
            this.nomeDaMod_label.Location = new System.Drawing.Point(155, 118);
            this.nomeDaMod_label.Name = "nomeDaMod_label";
            this.nomeDaMod_label.Size = new System.Drawing.Size(101, 13);
            this.nomeDaMod_label.TabIndex = 17;
            this.nomeDaMod_label.Text = "Nome da modificare";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nuovoPrezzo_label);
            this.Controls.Add(this.nuovoNome_label);
            this.Controls.Add(this.nomeDaMod_label);
            this.Controls.Add(this.nomeDaCancellare_label);
            this.Controls.Add(this.prezzo_label);
            this.Controls.Add(this.nome_label);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.prezzo_textbox);
            this.Controls.Add(this.nome_textbox);
            this.Controls.Add(this.leggi_button);
            this.Controls.Add(this.modifica_button);
            this.Controls.Add(this.cancella_button);
            this.Controls.Add(this.salva_button);
            this.Controls.Add(this.output);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView output;
        private System.Windows.Forms.Button salva_button;
        private System.Windows.Forms.Button cancella_button;
        private System.Windows.Forms.Button modifica_button;
        private System.Windows.Forms.Button leggi_button;
        private System.Windows.Forms.TextBox nome_textbox;
        private System.Windows.Forms.TextBox prezzo_textbox;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label prezzo_label;
        private System.Windows.Forms.Label nome_label;
        private System.Windows.Forms.Label nomeDaCancellare_label;
        private System.Windows.Forms.Label nuovoPrezzo_label;
        private System.Windows.Forms.Label nuovoNome_label;
        private System.Windows.Forms.Label nomeDaMod_label;
    }
}

