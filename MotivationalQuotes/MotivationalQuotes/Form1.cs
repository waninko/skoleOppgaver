using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //For å lese .txt fil
using System.Drawing.Text;
using System.Net.Mime;

//for å assigne custom font

namespace MotivationalQuotes
{
    public partial class Form1 : Form
    {
        int totalLines; //For å se hvor mange linjer som er lasta inn
        PrivateFontCollection pfc = new PrivateFontCollection(); //For å bruke custom font

        public Form1()
        {
            InitializeComponent();
            pfc.AddFontFile("Text.ttf"); //Finne og laste inn fonten
        }

        private void browseFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //default location for dialogbox
            openFileDialog1.InitialDirectory = @"C:\";
            //dialogbox tittel
            openFileDialog1.Title = "Browse Text Files";

            //både fil og sti må finnes i systemet
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            //sette opp filtype - her kun .txt 
            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            //sette opp til readonly
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            //om fil er selected og OK er trykket
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //sett inn fil navn & sti i dialogbox
                textBox1.Text = openFileDialog1.FileName;
                //tømme info i ListBox
                listBox1.Items.Clear();
                //lese fil
                readFile();
            }

        }

        private void viewQuotes(object sender, EventArgs e) //er koblet til selected item via EventArgs - tittel i label1
        {
            //still labelwidth i forhold til quote - unngå overlapping i view'et
            label1.MaximumSize = new Size(textView.Width + 5,0);
            label1.AutoSize = true;

            //kliss på ny font og still størrelse & stil
            label1.Font = new Font(pfc.Families[0], 20, FontStyle.Bold);

            //vis selecta item i labelen (tittel)
            label1.Text = listBox1.SelectedItem.ToString();
        }


        private void readFile() //last inn text fra fil i label2
        {
            string[] lines; //array til å holde quotes
            var list = new List<string>(); 

            //åpne og les fil
            var fileStream = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read);

            //loop gjennom og legg inn linjer quotes i liste og push i array
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                //sett readline til line sålenge den ikke er tom
                while ((line = streamReader.ReadLine()) != null)
                {
                    //legg isåfall (den ikke-tomme) line til i lista
                    list.Add(line);
                    //legg til én til på total lines telleren
                    totalLines++;
                }

                lines = list.ToArray(); //gjør om til array

                //loop gjennom antall linjer i lines
                for (int i = 0; i < lines.Length; i++)
                {
                    //legg til en og en i listBox
                    listBox1.Items.Add(lines[i]);
                }
                //vis hvor mange quotes som er lasta inn
                label2.Text = "Total Lines Loaded " + totalLines;
            }
        } 
    }
}
