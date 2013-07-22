using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GrosDialog;

namespace GrosDialogTest
{
    public partial class DecimalPlacesDialogTest : Form
    {
        public DecimalPlacesDialogTest()
        {
            InitializeComponent();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            try
            {
                GrosDialog.DecimalPlacesDialog numDlg = new GrosDialog.DecimalPlacesDialog();
                numDlg.ParentName = "Test01";
                numDlg.Minimum = int.Parse(this.minTextBox.Text);
                numDlg.Maximum = int.Parse(this.maxTextBox.Text);
                numDlg.Value = int.Parse(this.valueTextBox.Text);

                if (numDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.valueTextBox.Text = numDlg.Value.ToString();
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "NumberDegitsDialog Is Error");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "NumberDegitsDialog Is Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "NumberDegitsDialog Is Error");
            }
        }
    
    }
}
