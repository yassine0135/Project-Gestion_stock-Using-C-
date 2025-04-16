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
    public partial class client1 : UserControl
    {
        private static client1 Userclient;
        public static client1 instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new client1();
                }
                return Userclient;
            }
        }
        public client1()
        {
            InitializeComponent();
        }
        int selectedRowIndex = -1;

        public void actualiseDGV()
        {
            
            using (FileStream fs = new FileStream("client.txt", FileMode.OpenOrCreate, FileAccess.Read))
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

      

        private void button1_Click(object sender, EventArgs e)
        {
            amclient frmclien = new amclient();
            frmclien.ShowDialog();
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

                // Lire toutes les lignes du fichier "Véhicule.txt"
                List<string> lines = new List<string>();
                using (StreamReader sr = new StreamReader("Client.txt"))
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

                // Écrire le contenu mis à jour dans "Client.txt"
                using (StreamWriter sw = new StreamWriter("Client.txt"))
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

        private void button5_Click(object sender, EventArgs e)
        {
           
            modclient frmclien = new modclient();
            frmclien.ShowDialog();
            
        }

       



       

        

        

        

       

        

        

       
    }
}