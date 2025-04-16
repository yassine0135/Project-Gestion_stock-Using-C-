using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace gestionstock.forms
{
    public partial class ajproduit : Form
    {
        public Boolean bl = false;
        public ajproduit()
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
            using (FileStream fs = new FileStream("Produit.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                bl = false;
                using (StreamReader sr = new StreamReader(fs))
                {

                    while (sr.Peek() > -1)
                    {

                        string[] tb = sr.ReadLine().Split('#');

                        if (tb[0] == textref.Text)
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
                using (FileStream fs = new FileStream("Produit.txt", FileMode.Append, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine(textref.Text + '#' + textquan.Text + '#' + textprix.Text + '#' + pictureBox1.Image);
                        MessageBox.Show("le Produit est bien enregistrer");
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
            if (textref.Text == "" || textquan.Text == "" || textprix.Text == "" )
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
            
            textref.Text = "Réference de Produit"; textref.ForeColor = Color.Silver;
            
            textquan.Text= "Quantité de Produit"; textquan.ForeColor = Color.Silver;
            
            textprix.Text = "Prix de Produit"; textprix.ForeColor = Color.Silver;
            pictureBox1.Image = null;
            
        }

        private void textref_Enter(object sender, EventArgs e)
        {
            if (textref.Text == "Réference de Produit")
            {
                textref.Text = "";
                textref.ForeColor = Color.White;
            }
        }

        private void textquan_Enter(object sender, EventArgs e)
        {
            if (textquan.Text == "Quantité de Produit")
            {
                textquan.Text = "";
                textquan.ForeColor = Color.White;
            }
        }

        private void textprix_Enter(object sender, EventArgs e)
        {
            if (textprix.Text == "Prix de Produit")
            {
                textprix.Text = "";
                textprix.ForeColor = Color.White;
            }
        }

        private void textquan_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textprix_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "|*.JPG;*.PNG;*.GIF;*.BMP";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
            }

        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            using (Bitmap imge = new Bitmap(this.Width, this.Height))
            {
                this.DrawToBitmap(imge, new Rectangle(Point.Empty, this.Size));
                e.Graphics.DrawImage(imge, new Point(0, -90));
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(printDocument2_PrintPage);

            // Définir la taille du papier (8,5 x 11 pouces pour une feuille au format lettre)
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 778, 245);
            pd.DefaultPageSettings.Margins = new Margins(90, 90, 90, 90);
            

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
        }

       

        

       

        
    }
}
