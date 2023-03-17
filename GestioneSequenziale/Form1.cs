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

        public void Crea()
        {
            p.nome = nome_textbox.Text;
            p.prezzo = float.Parse(prezzo_textbox.Text);
            p.quantita = 1;
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
            StreamWriter sw = new StreamWriter("datiTemp.csv", true);
            StreamReader sr = new StreamReader("dati.csv");

            bool doppione = false;
            char limite = char.Parse(";");

            string[] words = new string[3];

            string str = sr.ReadLine();

            while (str != null)
            {
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);

                if (p.nome == nome_textbox.Text)
                {
                    p.quantita++;
                    doppione = true;
                }
                sw.WriteLine(p.nome + ";" + p.prezzo + ";" + p.quantita);
                str = sr.ReadLine();
            }

            if (!doppione)
            {
                Crea();
            }
            
            sw.Close();
            sr.Close();
            File.Move("datiTemp.csv", "dati.csv");
        }

        private void cancella_button_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("dati.csv");

            char limite = char.Parse(";");
            string[] words = new string[3];


            string str = sr.ReadLine();

            while (str != null)
            {
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                if (p.nome!=nomeDaCancellare_textbox.Text)
                {
                    StreamWriter sw = new StreamWriter("datiTemp.csv", true);
                    sw.WriteLine(p.nome + ";" + p.prezzo + ";"+p.quantita);
                    sw.Close();
                }
                str = sr.ReadLine();
            }
            sr.Close();
            File.Move("datiTemp.csv", "dati.csv");
            
        }
    }
}
