using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;

namespace GrosDialog.Parts
{
    /// <summary>
    /// 数値専用のテキストボックスを提供します。
    /// </summary>
    public class NumericTextBox : TextBox
    {

        /// <summary>
        /// <see cref="NumericTextBox"/>
        /// の新しいインスタンスを初期化します。
        /// </summary>
        public NumericTextBox()
        {
            base.TextAlign = HorizontalAlignment.Right;
            this.AllowSpace = false;
        }

        /// <summary>
        /// <see cref="System.Windows.Forms.Control.KeyPress"/>
        /// イベントを発生させます。
        /// </summary>
        /// <param name="e">イベント データを格納している
        /// <see cref="System.Windows.Forms.KeyPressEventArgs"/>。</param>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();

            if (Char.IsDigit(e.KeyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
             keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (e.KeyChar == '\b')
            {
                // Backspace key is OK
            }
            //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
            //    {
            //     // Let the edit control handle control and alt key combinations
            //    }
            else if (this.AllowSpace && e.KeyChar == ' ')
            {

            }
            else
            {
                // Swallow this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
        }

        /// <summary>
        /// 現在の値を取得します。
        /// </summary>
        public int Value
        {
            set
            {
                this.Text = value.ToString();
            }
            get
            {
                return Int32.Parse(this.Text);
            }
        }

        /// <summary>
        /// スペースの入力を許す
        /// かどうかを示す値を取得または設定します。
        /// </summary>
        private bool AllowSpace { set; get;}

    }
}
