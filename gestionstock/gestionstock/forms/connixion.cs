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
    public partial class connixion : Form
    {
        private Form frmmenu;
        public connixion( Form Menus)
        {
            InitializeComponent();
            this.frmmenu = Menus;
        }
        string testobli()
        {
            if (txtnom.Text == "" || txtnom.Text == "Nom d'utilisateur")
            {
                return "Entrer Votre Nom";
            }
            if (txtmot.Text == "" || txtmot.Text == "Mot de Passe")
            {
                return "Entrer Votre Mot de Passe";
            }
            return null;

        }

        void rechercher()
        {
            using (FileStream fs = new FileStream("user.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {

                    while (sr.Peek() > -1)
                    {

                        string[] tb = sr.ReadLine().Split('#');

                        if (tb[0] == txtnom.Text && tb[1] == txtmot.Text)
                        {
                            MessageBox.Show(("Connexion à réussi"), "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            (frmmenu as  Menu).activer();
                            this.Close();


                        }
                        else
                        {
                            MessageBox.Show(("Connexion à échoué"), "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btns_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void txtnom_Enter(object sender, EventArgs e)
        {
            if (txtnom.Text == "Nom d'utilisateur")
            {
                txtnom.Text = "";
                txtnom.ForeColor = Color.Black;

            }
        }

        private void txtmot_Enter(object sender, EventArgs e)
        {
            if (txtmot.Text == "Mot de Passe")
            {
                txtmot.Text = "";
                txtmot.ForeColor = Color.Black;

        }
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if (testobli() == null)
            {
                rechercher();
            }
            else
            {
                MessageBox.Show(testobli(), "obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

       
       

       
}
}