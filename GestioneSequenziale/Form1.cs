using System;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace GestioneSequenziale
{
    public partial class Form1 : Form
    {

        public struct prodotto
        {
            public string nome;
            public float prezzo;
            public int quantita;
        }


        public prodotto p = new prodotto();


        public Form1()
        {
            InitializeComponent();
        }


        public string ProdString(prodotto p)
        {
            return "Nome: " + p.nome + "  Prezzo: " + p.prezzo.ToString() + "  Quantità: " + p.quantita.ToString();
        }

        private void leggi_button_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("dati.csv");
            sr.BaseStream.Seek(0, SeekOrigin.Begin);


            char limite = char.Parse(";");

            string[] words = new string[2];

            string str = sr.ReadLine();


            while (str != null)
            {
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                output.Items.Add(ProdString(p));
                str = sr.ReadLine();
            }

            Console.ReadLine();
            sr.Close();
        }

        private void salva_button_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("dati.csv", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(nome_textbox.Text + ";" + prezzo_textbox.Text);
            
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
