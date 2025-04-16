using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace gestionstock.forms
{
    public partial class modclient : Form
    {
        public modclient()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string[] st;
            FileStream fs = new FileStream("Client.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            bool found = false;

            if (string.IsNullOrEmpty(Texterecherche.Text))
            {
                MessageBox.Show("Remplir la zone de texte !!!", "Erreur");
            }

            while (sr.Peek() != -1)
            {
                st = sr.ReadLine().Split('#');
                if (Texterecherche.Text == st[2])
                {
                    Textenom.Text = st[0];
                    textpre.Text = st[1];
                    textcin.Text = st[2];
                    texttele.Text = st[3];
                    textadre.Text = st[4];

                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Aucun résultat ne correspond à votre recherche !!!", "CIN_Client");
                Texterecherche.Text = string.Empty;
                Texterecherche.Focus();
            }

            sr.Close();
            fs.Close();
        }
       
        void modifier()
        {
            string client2 = "";
            string line = "";
            
                using (FileStream fs = new FileStream("client.txt", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {

                        while (sr.Peek() > -1)
                        {
                            line = sr.ReadLine();
                            string[] tb = line.Split('#');

                            if (tb[2] != textcin.Text)
                            {
                                client2 = client2 + line + "\r\n";
                            }
                            else
                            {
                                client2 = client2 + Textenom.Text + '#' + textpre.Text + '#' + textcin.Text + '#' + texttele.Text + '#' + textadre.Text + "\r\n";
                            }
                        }
                    }
                }
            using (FileStream fs = new FileStream("Client.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(client2);
                }
            }
            MessageBox.Show("le client est bien modifier", "Modifier");
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            modifier();
        }
       

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Texterecherche_Enter(object sender, EventArgs e)
        {
            if (Texterecherche.Text == "Rechercher")
            {
                Texterecherche.Text = "";
                Texterecherche.ForeColor = Color.White;
            }
        }

      
        

    }
}
