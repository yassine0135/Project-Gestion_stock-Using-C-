using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace gestionstock.forms
{
    public partial class formulc : UserControl
    {
        private static formulc Userclient;
        public static formulc instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new formulc();
                }
                return Userclient;
            }
        }
        public formulc()
        {
            InitializeComponent();
        }
   
       
    }
}
