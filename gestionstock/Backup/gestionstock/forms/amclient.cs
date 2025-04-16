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
    public partial class amclient : Form

    {
        public Boolean bl = false;
        
        public amclient()
        {
            InitializeComponent();
            
        }
        //les comp obligatoires
        
        void checkdup()
        {
            using (FileStream fs = new FileStream("client.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                bl = false;
                using (StreamReader sr = new StreamReader(fs))
                {

                    while (sr.Peek() > -1)
                    {

                        string[] tb = sr.ReadLine().Split('#');

                        if (tb[2] == textcin.Text)
                        {
                            bl = true;
                        }
                    }
                }
            }
        }
        
        void enregistrer()
        {
            checkdup();
            if (bl == false)
            {
                using (FileStream fs = new FileStream("client.txt", FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(Textenom.Text + '#' + textpre.Text + '#' + textcin.Text + '#' + texttele.Text + '#' + textadre.Text);
                        MessageBox.Show("le Client est bien enregistrer");
                    }
                }
            }
            else
            {
                MessageBox.Show("ce CIN déja existe");
            }

        }
        private void textpre_Enter(object sender, EventArgs e)
        {
            if (textpre.Text == "Prénom de Client")
            {
                textpre.Text = "";
                textpre.ForeColor = Color.White;
            }

        }

        private void Textenom_Enter(object sender, EventArgs e)
        {

            if (Textenom.Text == "Nom de Client")
            {
                Textenom.Text = "";
                Textenom.ForeColor = Color.White;
            }

        }

        private void textcin_Enter(object sender, EventArgs e)
        {

            if (textcin.Text == "CIN Client")
            {
                textcin.Text = "";
                textcin.ForeColor = Color.White;
            }
        }

        private void texttele_Enter(object sender, EventArgs e)
        {
            if (texttele.Text == "Telephone Client")
            {
                texttele.Text = "";
                texttele.ForeColor = Color.White;
            }

        }

        private void textadre_Enter(object sender, EventArgs e)
        {
            if (textadre.Text == "Adresse Client")
            {
                textadre.Text = "";
                textadre.ForeColor = Color.White;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        internal void showDialog()
        {
            throw new NotImplementedException();
        }

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textcin.Text == "" || Textenom.Text == "" || textpre.Text == "" || texttele.Text == "" || textadre.Text == "")
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

        private void button1_Click(object sender, EventArgs e)
        {
            //vider les textbox
            Textenom.Text = "Nom de Client"; Textenom.ForeColor = Color.Silver;
            textpre.Text = "Prénom de Client"; textpre.ForeColor = Color.Silver;
            textcin.Text = "CIN Client"; textcin.ForeColor = Color.Silver;
            textadre.Text = "Adresse Client"; textadre.ForeColor = Color.Silver;
            texttele.Text = "Telephone Client"; texttele.ForeColor = Color.Silver;
            

        }

       

        

       


        

       
       

        

        

      

        
        

        
     
       
    }
}
