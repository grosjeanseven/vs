using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GrosDialog
{
    /// <summary>
    /// 名前を付けて保存ダイアログを提供します。
    /// </summary>
    public class SaveAsDialog
    {
        /// <summary>
        /// Field を表すコレクションオブジェクトを格納します。
        /// </summary>
        public List<GrosDialog.SaveAsField> Fields { get; private set; }

        /// <summary>
        /// <see cref="GrosDialog.SaveAsDialog"/>
        /// クラスの新しいインスタンスを初期化します。
        /// </summary>
        public SaveAsDialog()
        {
            this.Fields = new List<GrosDialog.SaveAsField>();
        }

        /// <summary>
        /// モーダル ダイアログ ボックスとしてフォームを示します。
        /// </summary>
        /// <returns>System.Windows.Forms.DialogResult 値の 1 つ。</returns>
        public DialogResult ShowDialog()
        {
            // パラメータチェック
            if (!isErrorInProperties()) { return DialogResult.Cancel; }
            // フォーム設定
            SaveAsDialogForm frm = new SaveAsDialogForm();
            frm.tlpMain.RowCount = this.Fields.Count;
            for (int i = 0; i < this.Fields.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = this.Fields[i].Caption;
                frm.tlpMain.Controls.Add(lbl, 0, i);
                switch (this.Fields[i].Type)
                {
                    case SaveAsField.Types.String:
                        TextBox txt = new TextBox();
                        txt.MaxLength = this.Fields[i].Maximum;
                        frm.tlpMain.Controls.Add(txt, 1, i);
                        break;
                    case SaveAsField.Types.Number:
                        GrosDialog.Parts.NumericTextBox ntb = new GrosDialog.Parts.NumericTextBox();
                        ntb.MaxLength = this.Fields[i].Maximum.ToString().Length;
                        frm.tlpMain.Controls.Add(ntb, 1, i);
                        break;
                    default:
                        break;
                }
            }
            // 表示
            DialogResult result = frm.ShowDialog();
            if (result == DialogResult.OK)
            {
                // TODO 値の受け取りテスト
                //this.Value = (Int32)frm.mainNum.Value;
            }
            return result;
        }

        /// <summary>
        /// このインスタンスのプロパティにエラーがあるかを判定します。
        /// </summary>
        /// <returns>エラーがある場合、true。それ以外は false を返します。</returns>
        private Boolean isErrorInProperties()
        {

            // ↓コピーしてきた。作成中
            //if (this.Maximum < this.Minimum)
            //{
            //    throw new ArgumentException("Minimum 以上の値を設定してください。" + this.Maximum.ToString(), "Maximum");
            //}
            //if ((this.Value < this.Minimum) || (this.Maximum < this.Value))
            //{
            //    throw new ArgumentOutOfRangeException("Value", "Minimum 未満の値か、Maximum より大きい値です。" + this.Value.ToString());
            //}

            return true;
        }
    }
}
