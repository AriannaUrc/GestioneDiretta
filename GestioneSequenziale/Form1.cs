﻿using System;
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
            public bool cancellato;
        }


        public prodotto p;
        public string FileName="dati.csv";
        public string NomeTemp = "datiTemp.csv";


        public Form1()
        {
            InitializeComponent();
            p = new prodotto();
            StreamWriter sw = new StreamWriter(FileName, true);
            sw.Close();
        }

        

        public string ProdString(prodotto p)
        {
            return "Nome: " + p.nome + "  Prezzo: " + p.prezzo.ToString() + "  Quantità: " + p.quantita.ToString();
        }

        public string FileString(prodotto p)
        {
            return (p.nome + ";" + p.prezzo + ";" + p.quantita + ";" + p.cancellato+";").PadRight(60) + "##";
        }

        public static void scriviAppend(string content, string filename)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
        }

        public void Crea(string FileName)
        {
            p.nome = nome_textbox.Text;
            p.prezzo = float.Parse(prezzo_textbox.Text);
            p.quantita = 1;
            p.cancellato = false;
            scriviAppend(FileString(p), FileName);
        }

        public void Salva()
        {
            var f = new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(f);

            /*StreamReader sr = new StreamReader(FileName);
            StreamWriter sw = new StreamWriter(NomeTemp, true);*/

            bool doppione = false;
            char limite = char.Parse(";");
            int recordLength = 64;
            byte[] br;

            string[] words = new string[4];

            string str = Convert.ToString(reader.ReadBytes(recordLength));

            while (str != null)
            {
                
                
                doppione = false;
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                p.cancellato= bool.Parse(words[3]);

                if (p.nome == nome_textbox.Text && p.cancellato==false)
                {
                    doppione = true;
                    p.quantita++;
                    br = br = Encoding.ASCII.GetBytes(FileString(p));
                    reader.BaseStream.Write(br, 0, br.Length);
                }


                f.Seek(recordLength, SeekOrigin.Current);
                str = Convert.ToString(reader.ReadBytes(recordLength));
            }

            reader.Close();
            if (!doppione)
            {
                Crea(FileName);
            }

            f.Close();
        }


        public void CancellaLogica()
        {

            StreamReader sr = new StreamReader(FileName);
            StreamWriter sw = new StreamWriter(NomeTemp, true);

            char limite = char.Parse(";");

            string[] words = new string[4];

            string str = sr.ReadLine();

            while (str != null)
            {
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                p.cancellato = bool.Parse(words[3]);

                if (p.nome == nomeCancLog_textBox.Text && p.cancellato == false)
                {
                    p.cancellato = true;
                }

                sw.WriteLine(FileString(p));
                str = sr.ReadLine();
            }

            sw.Close();
            sr.Close();
            File.Delete(FileName);
            File.Move(NomeTemp, FileName);
        }

        public void Ripristino()
        {
            StreamReader sr = new StreamReader(FileName);
            StreamWriter sw = new StreamWriter(NomeTemp, true);

            char limite = char.Parse(";");
            int originale = 0;
            int somma = 0;

            string[] words = new string[4];

            string str = sr.ReadLine();

            while (str != null)
            {
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                p.cancellato = bool.Parse(words[3]);

                if (p.nome == nomeDaRipr_textBox.Text)
                {
                    if (originale == 0)
                    {
                        p.cancellato = false;
                    }
                    originale++;
                    somma = somma + p.quantita;
                }

                sw.WriteLine(FileString(p));
                str = sr.ReadLine();
            }

            sw.Close();
            sr.Close();
            File.Delete(FileName);
            File.Move(NomeTemp, FileName);

            

            if (originale > 1)
            {
                StreamReader sr1 = new StreamReader(FileName);
                StreamWriter sw1 = new StreamWriter(NomeTemp, true);

                sr1.BaseStream.Position = 0;
                str = sr1.ReadLine();

                while (str != null)
                {
                    originale = 0;
                    words = str.Split(limite);
                    p.nome = words[0];
                    p.prezzo = float.Parse(words[1]);
                    p.quantita = int.Parse(words[2]);
                    p.cancellato = bool.Parse(words[3]);

                    if (p.nome == nomeDaRipr_textBox.Text && originale==0)
                    {
                        p.quantita = somma;
                        originale ++;
                    }

                    if (p.nome != nomeDaRipr_textBox.Text || originale==1) 
                    {
                        sw1.WriteLine(FileString(p));
                    }
                    str = sr1.ReadLine();
                }
                sw1.Close();
                sr1.Close();
                File.Delete(FileName);
                File.Move(NomeTemp, FileName);
            }

            
        }

        public void Leggi()
        {
            StreamReader sr = new StreamReader(FileName);

            char limite = char.Parse(";");

            string[] words = new string[4];

            string str = sr.ReadLine();

            output.Items.Clear();

            while (str != null)
            {
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                p.cancellato = bool.Parse(words[3]);

                if (p.cancellato == false)
                {
                    output.Items.Add(ProdString(p));
                }
                str = sr.ReadLine();
            }

            Console.ReadLine();
            sr.Close();
        }


        public void Cancella()
        {
            StreamReader sr = new StreamReader(FileName);
            StreamWriter sw = new StreamWriter(NomeTemp, true);

            char limite = char.Parse(";");
            string[] words = new string[4];


            string str = sr.ReadLine();

            while (str != null)
            {
                
                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                p.cancellato= bool.Parse(words[3]);

                if (p.nome != nomeDaCancellare_textbox.Text || p.cancellato == true)
                {
                    
                    sw.WriteLine(FileString(p));
                    
                }
                str = sr.ReadLine();
                
            }
            sw.Close();
            sr.Close();
            File.Delete(FileName);
            File.Move(NomeTemp, FileName);
        }

        public void Compattazione()
        {
            StreamReader sr = new StreamReader(FileName);
            StreamWriter sw = new StreamWriter(NomeTemp, true);

            char limite = char.Parse(";");
            string[] words = new string[4];


            string str = sr.ReadLine();

            while (str != null)
            {

                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                p.cancellato = bool.Parse(words[3]);

                if (p.cancellato == false)
                {

                    sw.WriteLine(FileString(p));

                }
                str = sr.ReadLine();

            }
            sw.Close();
            sr.Close();
            File.Delete(FileName);
            File.Move(NomeTemp, FileName);
        }


        public void Modifica()
        {
            StreamReader sr = new StreamReader(FileName);
            StreamWriter sw = new StreamWriter(NomeTemp, true);

            char limite = char.Parse(";");
            string[] words = new string[4];


            string str = sr.ReadLine();

            while (str != null)
            {

                words = str.Split(limite);
                p.nome = words[0];
                p.prezzo = float.Parse(words[1]);
                p.quantita = int.Parse(words[2]);
                p.cancellato = bool.Parse(words[3]);


                if (p.nome == nomeDaMod_textbox.Text && p.cancellato == false)
                {
                    p.nome = nuovoNome_textbox.Text;
                    p.prezzo = float.Parse(nuovoPrezzo_textbox.Text);
                    p.quantita = 1;
                }

                sw.WriteLine(FileString(p));

                str = sr.ReadLine();

            }
            sw.Close();
            sr.Close();
            File.Delete(FileName);
            File.Move(NomeTemp, FileName);
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

        private void Canc_logica_button_Click(object sender, EventArgs e)
        {
            CancellaLogica();
            Leggi();
        }

        private void ripristino_button_Click(object sender, EventArgs e)
        {
            Ripristino();
            Leggi();
        }

        private void Compattazione_button_Click(object sender, EventArgs e)
        {
            Compattazione();
            Leggi();
        }
    }
}
