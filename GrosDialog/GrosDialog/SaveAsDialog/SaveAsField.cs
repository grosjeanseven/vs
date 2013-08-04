using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrosDialog
{
    /// <summary>
    /// <see cref="GrosDialog.SaveAsDialog"/>
    /// で使用する項目を表すオブジェクトを提供します。
    /// </summary>
    public class SaveAsField : IDisposable
    {
        /// <summary>
        /// 表示名称を取得または設定します。
        /// </summary>
        public string Caption { get; set; }
        /// <summary>
        /// データ型を表す識別子を指定します。
        /// </summary>
        public enum Types {
            /// <summary>文字型</summary>
            String,
            /// <summary>数値型</summary>
             Number
        };
        /// <summary>
        /// データ型を取得または設定します。
        /// </summary>
        public Types Type { get; set; }
        /// <summary>
        /// データを取得または設定します。
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 最小文字数または最小値を取得または設定します。
        /// </summary>
        public int Minimum { get; set; }
        /// <summary>
        /// 最大文字数または最大値を取得または設定します。
        /// </summary>
        public int Maximum { get; set; }

        /// <summary>
        /// <see cref="SaveAsField"/>
        /// クラスの新しいインスタンスを初期化します。
        /// </summary>
        public SaveAsField()
        {
            this.Caption = string.Empty;
            this.Type = Types.String;
            this.Value = null;
            this.Minimum = 0;
            this.Maximum = 99;
        }
        /// <summary>
        /// 引数を指定して、
        /// <see cref="SaveAsField"/>
        /// クラスの新しいインスタンスを初期化します。
        /// </summary>
        public SaveAsField(string caption, Types type) : this()
        {
            this.Caption = caption;
            this.Type = type;
        }

        /// <summary>
        /// アンマネージ リソースの解放およびリセットに関連付けられているアプリケーション定義のタスクを実行します。
        /// </summary>
        public void Dispose()
        {
        }

    }
}
