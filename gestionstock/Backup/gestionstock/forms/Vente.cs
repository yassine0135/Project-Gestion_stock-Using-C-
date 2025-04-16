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
    public partial class Vente : UserControl
    {
        private static Vente Userclient;
        public static Vente instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new Vente();
                }
                return Userclient;
            }
        }
        public Vente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ajvente frmvent = new ajvente();
            frmvent.ShowDialog();
        }
       
        public void actualiseDGV()
        {

            using (FileStream fs = new FileStream("vente.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    tabclien.Rows.Clear();
                    while (sr.Peek() > -1)
                    {
                        string token = sr.ReadLine();
                        string[] tb = token.Split('#');
                        if (tb.Length >= 8)
                        {
                            tabclien.Rows.Add(false, tb[0], tb[1], tb[2], tb[3],tb[4], tb[5], tb[6],tb[7]);
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

       

        
       
    }
}
