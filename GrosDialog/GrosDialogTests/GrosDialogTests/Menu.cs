using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrosDialogTest
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DecimalPlacesDialogTest frm = new DecimalPlacesDialogTest(); 
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveAsDialogTest frm = new SaveAsDialogTest();
            frm.Show();
        }
    }
}
