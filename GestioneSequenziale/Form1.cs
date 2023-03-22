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


        public prodotto p;


        public Form1()
        {
            InitializeComponent();
            p = new prodotto();
        }

        public void Crea(string FileName)
        {
            StreamWriter sw = new StreamWriter(FileName, true);
            p.nome = nome_textbox.Text;
            p.prezzo = float.Parse(prezzo_textbox.Text);
            p.quantita = 1;
            sw.WriteLine(p.nome + ";" + p.prezzo + ";" + p.quantita);
            sw.Close();
        }

        public string ProdString(prodotto p)
        {
            return "Nome: " + p.nome + "  Prezzo: " + p.prezzo.ToString() + "  Quantità: " + p.quantita.ToString();
        }



        public void Salva()
        {
            string NomeTemp= "datiTemp.csv";

            StreamReader sr = new StreamReader("dati.csv");
            StreamWriter sw = new StreamWriter(NomeTemp, true);

            bool doppione = false;
            char limite = char.Parse(";");

            string[] words = new string[3];

            string str = sr.ReadLine();

            while (str != null)
            {
                
                
                doppione = false;
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);

                if (p.nome == nome_textbox.Text)
                {
                    
                    doppione = true;
                    p.quantita++;
                }
                sw.WriteLine(p.nome + ";" + p.prezzo + ";" + p.quantita);
                str = sr.ReadLine();
            }

            sw.Close();
            if (!doppione)
            {
                Crea(NomeTemp);
            }

            sr.Close();
            File.Delete("dati.csv");
            File.Move(NomeTemp, "dati.csv");
        }


        public void Leggi()
        {
            StreamReader sr = new StreamReader("dati.csv");

            char limite = char.Parse(";");

            string[] words = new string[2];

            string str = sr.ReadLine();

            output.Items.Clear();

            while (str != null)
            {
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                output.Items.Add(ProdString(p));
                str = sr.ReadLine();
            }

            Console.ReadLine();
            sr.Close();
        }


        public void Cancella()
        {
            StreamReader sr = new StreamReader("dati.csv");
            StreamWriter sw = new StreamWriter("datiTemp.csv", true);

            char limite = char.Parse(";");
            string[] words = new string[3];


            string str = sr.ReadLine();

            while (str != null)
            {
                
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);

                if (p.nome != nomeDaCancellare_textbox.Text)
                {
                    
                    sw.WriteLine(p.nome + ";" + p.prezzo + ";" + p.quantita);
                    
                }
                str = sr.ReadLine();
                
            }
            sw.Close();
            sr.Close();
            File.Delete("dati.csv");
            File.Move("datiTemp.csv", "dati.csv");
        }


        public void Modifica()
        {
            StreamReader sr = new StreamReader("dati.csv");
            StreamWriter sw = new StreamWriter("datiTemp.csv", true);

            char limite = char.Parse(";");
            string[] words = new string[3];


            string str = sr.ReadLine();

            while (str != null)
            {

                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);


                if (p.nome == nomeDaMod_textbox.Text)
                {
                    p.nome = nuovoNome_textbox.Text;
                    p.prezzo = float.Parse(nuovoPrezzo_textbox.Text);
                    p.quantita = 1;
                }

                sw.WriteLine(p.nome + ";" + p.prezzo + ";" + p.quantita);

                str = sr.ReadLine();

            }
            sw.Close();
            sr.Close();
            File.Delete("dati.csv");
            File.Move("datiTemp.csv", "dati.csv");
        }




        private void leggi_button_Click(object sender, EventArgs e)
        {
            Leggi();
        }

        private void salva_button_Click(object sender, EventArgs e)
        {
            Salva();
            Leggi();
        }

        private void cancella_button_Click(object sender, EventArgs e)
        {
            Cancella();
            Leggi();
        }

        private void modifica_button_Click(object sender, EventArgs e)
        {
            Modifica();
            Leggi();

        }
    }
}
