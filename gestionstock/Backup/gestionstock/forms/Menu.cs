using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gestionstock.forms
{
    public partial class Menu : Form
    {
        

        public Menu()
        {
            InitializeComponent();
            pnlpa.Visible = false;
            panel1.Size = new Size(178, 420);

        }
        public void desactiver()
        {
            btnc.Enabled = false;
            btnf.Enabled = false;
            btnp.Enabled = false;
            btna.Enabled = false;
            btnv.Enabled = false;
            btnde.Enabled = false;
            pnlbut.Enabled = false;
            btnco.Enabled = true;

        }
        public void activer()
        {
            btnc.Enabled = true;
            btnf.Enabled = true;
            btnp.Enabled = true;
            btna.Enabled = true;
            btnv.Enabled = true;
            btnde.Enabled = true;
            pnlbut.Enabled = true;
            btnco.Enabled = false;
            pnlpa.Visible=false;

        }


      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnc.Top;
            if (!panelcl.Controls.Contains(client1.instance))
            {
                panelcl.Controls.Add(client1.instance);
                client1.instance.Dock = DockStyle.Fill;
                client1.instance.BringToFront();

            }
            else
            {
                client1.instance.BringToFront();
            }
        }

        private void btnf_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnf.Top;
            if (!panelcl.Controls.Contains(fournisseur.instance))
            {
                panelcl.Controls.Add(fournisseur.instance);
                fournisseur.instance.Dock = DockStyle.Fill;
                fournisseur.instance.BringToFront();

            }
            else
            {
                fournisseur.instance.BringToFront();
            }
        }

        private void btnp_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnp.Top;
            if (!panelcl.Controls.Contains(produit.instance))
            {
                panelcl.Controls.Add(produit.instance);
                produit.instance.Dock = DockStyle.Fill;
                produit.instance.BringToFront();
                
            }
            else
            {
                produit.instance.BringToFront();
            }
        }

        private void btna_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btna.Top;
            if (!panelcl.Controls.Contains(Achat.instance))
            {
                panelcl.Controls.Add(Achat.instance);
                Achat.instance.Dock = DockStyle.Fill;
                Achat.instance.BringToFront();

            }
            else
            {
                Achat.instance.BringToFront();
            }
            
        }

        private void btnv_Click(object sender, EventArgs e)
        {
            pnlbut.Top = btnv.Top;
            if (!panelcl.Controls.Contains(Vente.instance))
            {
                panelcl.Controls.Add(Vente.instance);
                Vente.instance.Dock = DockStyle.Fill;
                Vente.instance.BringToFront();

            }
            else
            {
                Vente.instance.BringToFront();
            }
            
            
        }

       

       

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel1.Width == 178)
            {
                panel1.Size = new Size(56, 420);
            }
            else
            {
                panel1.Size = new Size(178, 420);
            }
        }

        private void btneteindre_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnparametre_Click(object sender, EventArgs e)
        {
            pnlpa.Size = new Size(234, 86);
            pnlpa.Visible = !pnlpa.Visible;

        }

       

        private void Menu_Load(object sender, EventArgs e)
        {
            desactiver();
        }

        private void btnde_Click(object sender, EventArgs e)
        {
           
            desactiver();
 
            if (!panelcl.Controls.Contains(formuldec.instance))
            {
                panelcl.Controls.Add(formuldec.instance);
                formuldec.instance.Dock = DockStyle.Fill;
                formuldec.instance.BringToFront();

            }
            else
            {
                formuldec.instance.BringToFront();
            }

        }

        private void btnco_Click(object sender, EventArgs e)
        {
            if (!panelcl.Controls.Contains(formulc.instance))
            {
                panelcl.Controls.Add(formulc.instance);
                formulc.instance.Dock = DockStyle.Fill;
                formulc.instance.BringToFront();

            }
            else
            {
                formulc.instance.BringToFront();
            }

            connixion frmco = new connixion(this);
            frmco.ShowDialog();
        }

        

       

        

        

        
       

       
       

       

      

       

       

        

       

      
      

       
    }
}
