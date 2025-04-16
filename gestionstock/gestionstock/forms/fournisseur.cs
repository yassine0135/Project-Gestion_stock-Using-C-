using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace gestionstock.forms
{
    public partial class fournisseur : UserControl
    {
        private static fournisseur Userclient;
        public static fournisseur instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new fournisseur();
                }
                return Userclient;
            }
        }
        public fournisseur()
        {
            InitializeComponent();
        }
        int selectedRowIndex = -1;

      

        private void button1_Click(object sender, EventArgs e)
        {
            ajfournisseur frmfourni = new ajfournisseur();
            frmfourni.ShowDialog();
        }

       
        public void actualiseDGV()
        {

            using (FileStream fs = new FileStream("Fournisseur.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    tabclien.Rows.Clear();
                    while (sr.Peek() > -1)
                    {
                        string token = sr.ReadLine();
                        string[] tb = token.Split('#');
                        if (tb.Length >= 5)
                        {
                            tabclien.Rows.Add(false, tb[0], tb[1], tb[2], tb[3], tb[4]);
                        }
                        else
                        {
                            // Gérer le cas où il n'y a pas suffisamment d'éléments dans "parts".
                            // Par exemple, vous pouvez ignorer cette ligne ou afficher un message d'erreur.
                            // Ici, nous allons simplement ignorer cette ligne.
                            Console.WriteLine("Ignoré : " + token); // Vous pouvez également afficher la ligne ignorée dans la console.
                        }

                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                actualiseDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex >= 0)
            {
                // Supprimer la ligne sélectionnée du DataGridView1
                tabclien.Rows.RemoveAt(selectedRowIndex);

                // Lire toutes les lignes du fichier "fourniseur.txt"
                List<string> lines = new List<string>();
                using (StreamReader sr = new StreamReader("Fournisseur.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine());
                    }
                }

                // Supprimer la ligne correspondante du fichier en utilisant l'indice
                if (selectedRowIndex >= 0 && selectedRowIndex < lines.Count)
                {
                    lines.RemoveAt(selectedRowIndex);
                }

                // Écrire le contenu mis à jour dans "Fournisseur.txt"
                using (StreamWriter sw = new StreamWriter("Fournisseur.txt"))
                {
                    foreach (string line in lines)
                    {
                        sw.WriteLine(line);
                    }
                }

                // Informer l'utilisateur de la suppression réussie
                MessageBox.Show("Les informations ont été supprimées avec succès.");
            }
            else
            {
                MessageBox.Show("Aucune ligne sélectionnée.");
            }
        }

        private void tabclien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < tabclien.Rows.Count)
            {
                // Mettre à jour la variable selectedRowIndex lorsque l'utilisateur clique sur une cellule
                selectedRowIndex = e.RowIndex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            modfournisseur frmclien = new modfournisseur();
            frmclien.ShowDialog();
        }

        
        

       

        
      

       


       
    }
}
