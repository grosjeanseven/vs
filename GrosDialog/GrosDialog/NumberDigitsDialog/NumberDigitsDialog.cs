using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GrosDialog
{
    /// <summary>
    /// 桁数設定用のダイアログを提供します。
    /// </summary>
    public class NumberDigitsDialog
    {
        #region "プロパティ"
        /// <summary>
        /// 親画面名称を取得または設定します。
        /// </summary>
        public string ParentName { get; set; }
        /// <summary>
        /// 桁数を取得または設定します。
        /// </summary>
        /// <exception cref="System.ArgumentException">指定された値が 0 未満です。</exception>
        public int Value
        {
            get { return _Value; }
            set
            {
                if (value < 0) { throw new ArgumentException("指定された値が 0 未満です。", "Value"); }
                _Value = value;
            }
        }
        private int _Value;
        /// <summary>
        /// 桁数の範囲の最小値を取得または設定します。
        /// </summary>
        /// <returns>範囲の最小値。既定値は 0 です。</returns>
        /// <exception cref="System.ArgumentException">指定された値が 0 未満です。</exception>
        public int Minimum
        {
            get { return _Minimum; }
            set
            {
                if (value < 0) { throw new ArgumentException("指定された値が 0 未満です。", "Minimum"); }
                _Minimum = value;
            }
        }
        private int _Minimum;
        /// <summary>
        /// 桁数の範囲の最大値を取得または設定します。
        /// </summary>
        /// <returns>範囲の最大値。既定値は 11 です。</returns>
        /// <exception cref="System.ArgumentException">指定された値が 0 未満です。</exception>
        public int Maximum
        {
           get { return _Maximum; }
           set
           {
               if (value < 0) { throw new ArgumentException("指定された値が 0 未満です。", "Maximum"); }
               _Maximum = value;
           } 
        }
        private int _Maximum;
        /// <summary>
        /// タイトルを取得または設定します。
        /// </summary>
        /// <returns>タイトルバーに表示される名称。既定値は NumberDigits です。</returns>
        protected string Title { get; set; }
        private readonly string TitleDefault = "NumberDigits";
        /// <summary>
        /// ラベルに表示するテキストを取得または設定します。
        /// </summary>
        /// <returns>既定値は NumberDigits です。</returns>
        protected string LabelCaption { get; set; }
        private readonly string LabelCaptionDefault = "NumberDigits";
        #endregion
        /// <summary>
        /// GrosDialog.NumberDigitsDialog クラスの新しいインスタンスを初期化します。
        /// </summary>
        public NumberDigitsDialog()
        {
            // プロパティの初期化
            this.ParentName = string.Empty;
            this.Value = 0;
            this.Minimum = 0;
            this.Maximum = 11;
            this.Title = this.TitleDefault;
            this.LabelCaption = this.LabelCaptionDefault;
        }

        /// <summary>
        /// モーダル ダイアログ ボックスとしてフォームを示します。
        /// </summary>
        /// <returns>System.Windows.Forms.DialogResult 値の 1 つ。</returns>
        public DialogResult ShowDialog()
        {
            if (! isErrorInProperties()) { return DialogResult.Cancel; }
            // フォーム設定
            NumberDigitsDialogForm frm = new NumberDigitsDialogForm();
            frm.Text = this.Title + "(" + this.ParentName + ")";
            frm.mainLabel.Text = this.LabelCaption + " :";
            frm.mainNum.Minimum = this.Minimum;
            frm.mainNum.Maximum = this.Maximum;
            frm.mainNum.Value = this.Value;
            // 表示
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK) {
                this.Value = (Int32)frm.mainNum.Value;
            }
            return result;
        }

        /// <summary>
        /// このインスタンスのプロパティにエラーがあるかを判定します。
        /// </summary>
        /// <returns>エラーがある場合、true。それ以外は false を返します。</returns>
        private Boolean isErrorInProperties()
        {
            if (this.Maximum < this.Minimum)
            {
                throw new ArgumentException("Minimum 以上の値を設定してください。" + this.Maximum.ToString(), "Maximum");
            }
            if ((this.Value < this.Minimum) || (this.Maximum < this.Value))
            {
                throw new ArgumentOutOfRangeException("Value", "Minimum 未満の値か、Maximum より大きい値です。" + this.Value.ToString());
            }
            return true;
        }

    }
}
