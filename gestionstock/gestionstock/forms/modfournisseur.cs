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
    public partial class modfournisseur : Form
    {
        public modfournisseur()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] st;
            FileStream fs = new FileStream("Fournisseur.txt", FileMode.OpenOrCreate, FileAccess.Read);
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
                    textnumf.Text = st[2];
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
        string testobligatoire()
        {
            if (textnumf.Text == "" || textnumf.Text == "Numéro de Fournisseur")
            {
                return "Entrer Numéro de Fournisseur";
            }
            return null;
        }
        void modifier()
        {
            string fourni2 = "";
            string line = "";
            if (testobligatoire() != null)
            {
                MessageBox.Show(testobligatoire(), "obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                using (FileStream fs = new FileStream("Fournisseur.txt", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {

                        while (sr.Peek() > -1)
                        {
                            line = sr.ReadLine();
                            string[] tb = line.Split('#');

                            if (tb[2] != textnumf.Text)
                            {
                                fourni2 = fourni2 + line + "\r\n";
                            }
                            else
                            {
                                fourni2 = fourni2 + Textenom.Text + '#' + textpre.Text + '#' + textnumf.Text + '#' + texttele.Text + '#' + textadre.Text + "\r\n";
                            }
                        }
                    }
                }
            using (FileStream fs = new FileStream("Fournisseur.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(fourni2);
                }
            }
            MessageBox.Show("le Fournisseur est bien modifier", "Modifier");
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


        
        
    }
}
