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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.leggi_button);
            this.Controls.Add(this.modifica_button);
            this.Controls.Add(this.cancella_button);
            this.Controls.Add(this.salva_button);
            this.Controls.Add(this.output);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView output;
        private System.Windows.Forms.Button salva_button;
        private System.Windows.Forms.Button cancella_button;
        private System.Windows.Forms.Button modifica_button;
        private System.Windows.Forms.Button leggi_button;
    }
}

