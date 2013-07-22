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
    public partial class SaveAsDialogTest : Form
    {
        public SaveAsDialogTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GrosDialog.SaveAsDialogForm dlgSaveAs = new GrosDialog.SaveAsDialogForm();
            dlgSaveAs.ShowDialog();
        }
    }
}
