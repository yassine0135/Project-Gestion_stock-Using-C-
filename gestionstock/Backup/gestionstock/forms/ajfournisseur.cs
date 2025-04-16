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
    public partial class ajfournisseur : Form
    {
        public Boolean bl = false;
        public ajfournisseur()
        {
            InitializeComponent();
        }
       
        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void showDialog()
        {
            throw new NotImplementedException();
        }

        void checkdup()
        {
            using (FileStream fs = new FileStream("Fournisseur.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                bl = false;
                using (StreamReader sr = new StreamReader(fs))
                {

                    while (sr.Peek() > -1)
                    {

                        string[] tb = sr.ReadLine().Split('#');

                        if (tb[2] == textnumf.Text)
                        {
                            bl = true;
                        }
                    }
                }
            }
        }
        
        private void textpre_Enter(object sender, EventArgs e)
        {
            if (textpre.Text == "Prénom de Fournisseur")
            {
                textpre.Text = "";
                textpre.ForeColor = Color.White;
            }
        }

        private void Textenom_Enter(object sender, EventArgs e)
        {
            if (Textenom.Text == "Nom de Fournisseur")
            {
                Textenom.Text = "";
                Textenom.ForeColor = Color.White;
            }
        }

        private void textnumf_Enter(object sender, EventArgs e)
        {
            if (textnumf.Text == "Numéro de Fournisseur")
            {
                textnumf.Text = "";
                textnumf.ForeColor = Color.White;
            }
        }

        private void texttele_Enter(object sender, EventArgs e)
        {
            if (texttele.Text == "Telephone Fournisseur")
            {
                texttele.Text = "";
                texttele.ForeColor = Color.White;
            }
        }

        private void textadre_Enter(object sender, EventArgs e)
        {
            if (textadre.Text == "Adresse Fournisseur")
            {
                textadre.Text = "";
                textadre.ForeColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Textenom.Text = "Nom de Fournisseur"; Textenom.ForeColor = Color.Silver;
           
            textpre.Text = "Prenom de Fournisseur"; textpre.ForeColor = Color.Silver;
            
            textnumf.Text = "Numéro Fournisseur"; textnumf.ForeColor = Color.Silver;
           
            textadre.Text = "Adresse Fournisseur"; textadre.ForeColor = Color.Silver;
          
            texttele.Text = "Telephone Fournisseur"; texttele.ForeColor = Color.Silver;
           

        }
        void enregistrer()
        {
            checkdup();
            if (bl == false)
            {
                using (FileStream fs = new FileStream("Fournisseur.txt", FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(Textenom.Text + '#' + textpre.Text + '#' + textnumf.Text + '#' + texttele.Text + '#' + textadre.Text);
                        MessageBox.Show("le Fournisseur est bien enregistrer");
                    }
                }
            }
            else
            {
                MessageBox.Show("ce numéro déja existe");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textnumf.Text == "" || Textenom.Text == "" || textpre.Text == "" || texttele.Text == "" || textadre.Text == "")
            {
                MessageBox.Show("remplir tous les zones de textes");
            }
            else
            {
                try
                {
                    enregistrer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
        //les comp obligatoires
        
        private void texttele_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;

            }
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                }
            }
        }
  
    }
}
