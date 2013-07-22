using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrosDialog
{
    internal partial class NumberDigitsDialogForm : Form
    {
        public NumberDigitsDialogForm()
        {
            InitializeComponent();
        }
        private void NumberDegitsDialogForm_Load(object sender, EventArgs e)
        {
            this.mainTextBox.MaxLength = this.mainNum.Maximum.ToString().Length;
        }
        private void NumberDegitsDialogForm_Shown(object sender, EventArgs e)
        {
            this.mainTextBox.Focus();
        }

        private void mainNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            // NumericUpDown と TextBox を同期。
            this.mainTextBox.Text = this.mainNum.Value.ToString();
        }

        #region Validator
        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            this.mainTextBox.Text = this.mainTextBox.Text.Trim();       // トリム
            if (!isNumeric(this.mainTextBox.Text))
            {
                this.mainTextBox.Text = this.mainNum.Value.ToString();
            }
            this.mainTextBox.SelectionStart = this.mainTextBox.TextLength;
        }
        private void mainTextBox_Validated(object sender, EventArgs e)
        {
            try
            {
                this.mainNum.Value = int.Parse(this.mainTextBox.Text);
            }
            catch (ArgumentException)
            {
                // 範囲外
                this.mainTextBox.Text = this.mainNum.Value.ToString();
            }
        }
        #endregion

        #region okButton, cancelButton
        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region Increment(up, down)
        private void NumberDegitsDialogForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                this.mainNum.UpButton();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                this.mainNum.DownButton();
                e.Handled = true;
            }

        }
        private void upButton_Click(object sender, EventArgs e)
        {
            this.mainNum.UpButton();
        }
        private void downButton_Click(object sender, EventArgs e)
        {
            this.mainNum.DownButton();
        }
        private void updownButton_PreviewKeyDown(object sender,PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Up, Down キーの動作をカスタマイズする。
                case Keys.Up:
                case Keys.Down:
                    e.IsInputKey = true;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 文字列が数値として評価できるかどうかを示す Boolean 値を返します。 
        /// </summary>
        /// <param name="value"></param>
        /// <returns>数値として評価できる場合、true。それ以外は false。</returns>
        private bool isNumeric(String value)
        {
            try
            {
                int i = 0;
                bool result = int.TryParse(value, out i);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
