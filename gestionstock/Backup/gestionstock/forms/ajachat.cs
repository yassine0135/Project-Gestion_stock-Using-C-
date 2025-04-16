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
    public partial class ajachat : Form
    {
        public ajachat()
        {
            InitializeComponent();
        }
        public void Nouveau()
        {
            ComboBox2.Text = null;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            tabclien.Rows.Clear();
            textBox5.Clear();
            comboBox1.Text = null;
            comboBox3.Text = null;
            ComboBox2.Focus();
            MessageBox.Show("Données réinitialisées avec succès.", "Nouveau", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Nouveau();
        }
        void changeQt(string num, int qt)
        {
            string client2 = "";
            string line = "";
            int nqt = 0;
            using (FileStream fs = new FileStream("Produit.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {

                    while (sr.Peek() > -1)
                    {
                        line = sr.ReadLine();
                        string[] tb = line.Split('#');

                        if (tb[0] != num)
                        {
                            client2 = client2 + line + "\r\n";
                        }
                        else
                        {
                            nqt = int.Parse(tb[1]) + qt;
                            client2 = client2 + tb[0] + '#' + nqt + '#' + tb[2] + "\r\n";
                        }
                    }
                }
            }
            using (FileStream fs = new FileStream("Produit.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(client2);
                }
            }

        }
        void enregistrer()
        {

            string nump;
            int qtp;
            using (FileStream fs = new FileStream("achat.txt", FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    for (int i = 0; i < tabclien.Rows.Count - 1; i++)
                    {
                        sw.WriteLine(ComboBox2.Text + '#' + DateTimePicker1.Text + '#' + comboBox1.Text + '#' + tabclien.Rows[i].Cells[0].Value + '#' + tabclien.Rows[i].Cells[1].Value + '#' + tabclien.Rows[i].Cells[2].Value + '#' + tabclien.Rows[i].Cells[3].Value + '#' + textBox1.Text);
                        nump = tabclien.Rows[i].Cells[0].Value.ToString();
                        qtp = int.Parse(tabclien.Rows[i].Cells[1].Value.ToString());
                        changeQt(nump, qtp);

                    }
                }
            }

            MessageBox.Show("l'achat est bien enregistrer ");
        }









        private void Verifyfournisseur()
        {
            FileStream fs = new FileStream("Fournisseur.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            while (sr.Peek() != -1)
            {
                string[] token = sr.ReadLine().Split('#');
                if (comboBox1.Text == token[2])
                {
                    textBox3.Text = token[0];
                    textBox2.Text = token[1];
                    textBox5.Text = token[3];
                    textBox6.Text = token[4];
                }
            }
            sr.Close();
            fs.Close();
        }


        private void Remplirfournisseur()
        {

            using (FileStream fs = new FileStream("Fournisseur.txt", FileMode.OpenOrCreate, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fs))
            {
                comboBox1.Items.Clear();
                while (sr.Peek() != -1)
                {
                    string[] token = sr.ReadLine().Split('#');
                    comboBox1.Items.Add(token[2]);
                }
            }
        }


        private void Verifyproduit()
        {
            try
            {
                FileStream fm = new FileStream("Produit.txt", FileMode.OpenOrCreate, FileAccess.Read);
                StreamReader sr = new StreamReader(fm);
                int lineNumber = 1;

                while (sr.Peek() != -1)
                {
                    string[] token = sr.ReadLine().Split('#');

                    if (comboBox3.Text == token[0])
                    {

                        textBox7.Text = token[2];


                        break;
                    }

                    lineNumber++;
                }

                sr.Close();
                fm.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de lecture du fichier !!" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Remplirproduit()
        {

            FileStream fm = new FileStream("Produit.txt", FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fm);
            comboBox3.Items.Clear();
            while (sr.Peek() != -1)
            {
                string[] token = sr.ReadLine().Split('#');
                comboBox3.Items.Add(token[0]);
            }
            sr.Close();
            fm.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Verifyfournisseur();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            Remplirfournisseur();
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
            Remplirproduit();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = null;
            Verifyproduit();
        }
        private void Ajouter()
        {
            if (!string.IsNullOrEmpty(comboBox3.Text) && !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(textBox9.Text))
            {
                tabclien.Rows.Add(comboBox3.Text, textBox8.Text, textBox7.Text, textBox9.Text);
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Ajouter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox3.Text = null;
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double valeur1, valeur2;

            if (double.TryParse(textBox7.Text, out valeur1) && double.TryParse(textBox8.Text, out valeur2))
            {
                double resultat = valeur1 * valeur2;
                textBox9.Text = resultat.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez entrer des nombres valides dans les zones de texte.", "Erreur de saisie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double somme = 0.0;

            foreach (DataGridViewRow row in tabclien.Rows)
            {
                if (row.Cells["Column8"].Value != null)
                {
                    double valeur;
                    if (double.TryParse(row.Cells["Column8"].Value.ToString(), out valeur))
                    {
                        somme += valeur;
                    }
                }
            }
            textBox1.Text = somme.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            enregistrer();
        }
        void remplir()
        {


            using (FileStream fs = new FileStream("Achat.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {

                    ComboBox2.Items.Clear();
                    while (sr.Peek() > -1)
                    {
                        string[] tb = sr.ReadLine().Split('#');
                        ComboBox2.Items.Add(tb[0]);
                    }
                }
            }

            List<string> items = new List<string>();

            foreach (string item in ComboBox2.Items)
            {
                if (!items.Contains(item))
                {
                    items.Add(item);
                }
            }

            ComboBox2.Items.Clear();
            ComboBox2.Items.AddRange(items.ToArray());


        }
        void rechercher()
        {
            using (FileStream fs = new FileStream("Achat.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    tabclien.Rows.Clear();
                    while (sr.Peek() > -1)
                    {

                        string[] tb = sr.ReadLine().Split('#');

                        if (tb[0] == ComboBox2.Text)
                        {
                            DateTimePicker1.Text = tb[1];
                            comboBox1.Text = tb[2];
                            tabclien.Rows.Add(tb[3], tb[4], tb[5], tb[6]);
                            textBox1.Text = tb[7];



                        }
                    }
                }
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            rechercher();
        }

        private void ComboBox2_Click(object sender, EventArgs e)
        {
            remplir();
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
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
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 1270, 597);
            pd.DefaultPageSettings.Margins = new Margins(90, 90, 90, 90);

            PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();
            printPreviewDialog1.Document = pd;
            printPreviewDialog1.ShowDialog();
        }

    }
}
