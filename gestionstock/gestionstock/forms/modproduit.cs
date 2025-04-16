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
    public partial class modproduit : Form
    {
        public modproduit()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        string testobligatoire()
        {
            if (textref.Text == "" || textref.Text == "Réference de Produit")
            {
                return "Entrer Réference de Produit";
            }
            return null;
        }
        void modifier()
        {
            string prod2 = "";
            string line = "";
            if (testobligatoire() != null)
            {
                MessageBox.Show(testobligatoire(), "obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                using (FileStream fs = new FileStream("Produit.txt", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {

                        while (sr.Peek() > -1)
                        {
                            line = sr.ReadLine();
                            string[] tb = line.Split('#');

                            if (tb[0] != textref.Text)
                            {
                                prod2 = prod2 + line + "\r\n";
                            }
                            else
                            {
                                prod2 = prod2 + textref.Text + '#' + textquan.Text + '#' + textprix.Text + "\r\n";
                            }
                        }
                    }
                }
            using (FileStream fs = new FileStream("Produit.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(prod2);
                }
            }
            MessageBox.Show("le Produit est bien modifier", "Modifier");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            modifier();
        }

        private void Texterecherche_Enter(object sender, EventArgs e)
        {
            if (Texterecherche.Text == "Rechercher")
            {
                Texterecherche.Text = "";
                Texterecherche.ForeColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] st;
            FileStream fs = new FileStream("Produit.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            bool found = false;

            if (string.IsNullOrEmpty(Texterecherche.Text))
            {
                MessageBox.Show("Remplir la zone de texte !!!", "Erreur");
            }

            while (sr.Peek() != -1)
            {
                st = sr.ReadLine().Split('#');
                if (Texterecherche.Text == st[0])
                {
                    textref.Text = st[0];
                    textquan.Text = st[1];
                    textprix.Text = st[2];


                    found = true;
                    break;
                }
            }

            if (!found)
            {
                MessageBox.Show("Aucun résultat ne correspond à votre recherche !!!", "REF_PRODUIT");
                Texterecherche.Text = string.Empty;
                Texterecherche.Focus();
            }

            sr.Close();
            fs.Close();
        }

        private void textref_TextChanged(object sender, EventArgs e)
        {

        }

        private void modproduit_Load(object sender, EventArgs e)
        {

        }

        

       
    }
}
