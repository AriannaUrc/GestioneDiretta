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
            public bool cancellato;
        }


        public prodotto p;
        public string FileName = "dati.csv";
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
            return ((p.nome + ";" + p.prezzo + ";" + p.quantita + ";" + p.cancellato + ";").PadRight(60) + "##");
        }

        public static void scriviAppend(string content, string filename)
        {
            var fStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(fStream);
            sw.WriteLine(content);
            sw.Close();
        }


        public static prodotto FromString(string votoStringa, string sep = ";")
        {
            prodotto p;
            String[] fields = votoStringa.Split(sep[0]);
            p.nome = fields[0];
            p.prezzo = float.Parse(fields[1]);
            p.quantita = int.Parse(fields[2]);
            p.cancellato = bool.Parse(fields[3]);
            //dalla stringa deve ritornare la variabile Voto v settata con  i valori
            return p;
        }

        public void Crea(string FileName)
        {
            p.nome = nome_textbox.Text;
            p.prezzo = float.Parse(prezzo_textbox.Text);
            p.quantita = 1;
            p.cancellato = false;
            MessageBox.Show(FileString(p));
            scriviAppend(FileString(p), "dati.csv");
        }

        public void Salva()
        {
            String line;
            byte[] br;
            int recordLength = 64;

            var f = new FileStream("dati.csv", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(f);
            BinaryWriter writer = new BinaryWriter(f);


            bool doppione = false;
            char limite = ';';

            string[] words = new string[4];


            while (f.Position < f.Length-2) //????????????
            {

                br = reader.ReadBytes(recordLength);
                //converte in stringa
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                Console.WriteLine(line);
                p = FromString(line);

                if (p.nome == nome_textbox.Text && p.cancellato == false)
                {
                    MessageBox.Show("in if");
                    doppione = true;
                    p.quantita++;
                    f.Seek(-recordLength, SeekOrigin.Current);
                    writer.Write(Encoding.UTF8.GetBytes(FileString(p)));
                }
            }

            writer.Close();
            reader.Close();
            f.Close();

            if (!doppione)
            {
                Crea(FileName); //per qualche motivo aggiunge una > davanti al nome
            }

        }


        public void CancellaLogica()
        {

            /*StreamReader sr = new StreamReader(FileName);
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
            File.Move(NomeTemp, FileName);*/

            String line;
            byte[] br;
            int recordLength = 64;

            var f = new FileStream("dati.csv", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(f);
            BinaryWriter writer = new BinaryWriter(f);

            char limite = ';';

            string[] words = new string[4];


            while (f.Position < f.Length - 2) //????????????
            {

                br = reader.ReadBytes(recordLength);
                //converte in stringa
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                Console.WriteLine(line);
                p = FromString(line);

                if (p.nome == nomeCancLog_textBox.Text && p.cancellato == false)
                {
                    p.cancellato = true;
                    f.Seek(-recordLength, SeekOrigin.Current);
                    writer.Write(Encoding.UTF8.GetBytes(FileString(p)));
                }
            }

            writer.Close();
            reader.Close();
            f.Close();
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
            String line;
            byte[] br;
            int recordLength = 64;//....?

            var f = new FileStream("dati.csv", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(f);


            char limite = char.Parse(";");

            string[] words = new string[4];

            output.Items.Clear();


            while (f.Position < f.Length-4)
            {   
                br = reader.ReadBytes(recordLength);
                //converte in stringa
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                p = FromString(line);

                if (p.cancellato == false)
                output.Items.Add(ProdString(p));
            }

            reader.Close();
            f.Close();

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
            String line;
            byte[] br;
            int recordLength = 64;

            var f = new FileStream("dati.csv", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader reader = new BinaryReader(f);
            BinaryWriter writer = new BinaryWriter(f);

            char limite = ';';

            string[] words = new string[4];


            while (f.Position < f.Length - 2) //????????????
            {

                br = reader.ReadBytes(recordLength);
                //converte in stringa
                line = Encoding.ASCII.GetString(br, 0, br.Length);
                Console.WriteLine(line);
                p = FromString(line);

                if (p.nome == nomeDaMod_textbox.Text && p.cancellato == false)
                {
                    p.nome = nuovoNome_textbox.Text;
                    p.prezzo = float.Parse(nuovoPrezzo_textbox.Text);
                    p.quantita = 1;
                    f.Seek(-recordLength, SeekOrigin.Current);
                    writer.Write(Encoding.UTF8.GetBytes(FileString(p)));
                }
            }

            writer.Close();
            reader.Close();
            f.Close();
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
