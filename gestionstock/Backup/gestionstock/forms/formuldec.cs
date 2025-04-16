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
    public partial class formuldec : UserControl
    {
        private static formuldec Userclient;
        public static formuldec instance
        {
            get
            {
                if (Userclient == null)
                {
                    Userclient = new formuldec();
                }
                return Userclient;
            }
        }
        public formuldec()
        {
            InitializeComponent();
        }

        

        
    }
}
