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

        private void SaveAsDialogTest_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.tlpMain.Controls)
            {
                if (item.GetType() == typeof(ComboBox)) {
                    ComboBox cmb = (ComboBox)item;
                    cmb.DataSource = Enum.GetValues(typeof(GrosDialog.SaveAsField.Types));
                    cmb.SelectedIndex = 0;
                    cmb.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GrosDialog.SaveAsDialog dlg = new GrosDialog.SaveAsDialog();
            for (int i = 0; i < this.tlpMain.RowCount; i++)
            {
                using (GrosDialog.SaveAsField field = new GrosDialog.SaveAsField()) {
                    ComboBox cmbType = (ComboBox)this.tlpMain.GetControlFromPosition(0, i);
                    field.Type = (GrosDialog.SaveAsField.Types)cmbType.SelectedItem;
                    field.Caption = ((TextBox)this.tlpMain.GetControlFromPosition(1, i)).Text;
                    field.Value = ((TextBox)this.tlpMain.GetControlFromPosition(2, i)).Text;
                    field.Minimum = (int)((NumericUpDown)this.tlpMain.GetControlFromPosition(3, i)).Value;
                    field.Maximum = (int)((NumericUpDown)this.tlpMain.GetControlFromPosition(4, i)).Value;
                    dlg.Fields.Add(field);
                }
            }
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            int i = this.tlpMain.GetRow(cmb);
            switch ((GrosDialog.SaveAsField.Types)cmb.SelectedItem)
            {
                case GrosDialog.SaveAsField.Types.String:
                    ((TextBox)tlpMain.GetControlFromPosition(2, i)).Text = "Value";
                    ((NumericUpDown)tlpMain.GetControlFromPosition(4, i)).Value = 50;
                    break;
                case GrosDialog.SaveAsField.Types.Number:
                    ((TextBox)tlpMain.GetControlFromPosition(2, i)).Text = "5";
                    ((NumericUpDown)tlpMain.GetControlFromPosition(4, i)).Value = 9999;
                    break;
                default:
                    break;
            }
        }

    }
}
