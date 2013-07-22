using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GrosDialog
{
    /// <summary>
    /// 小数桁数設定用のダイアログを提供します。
    /// </summary>
    public class DecimalPlacesDialog : NumberDigitsDialog
    {
        /// <summary>
        /// GrosDialog.DecimalPlaces クラスの新しいインスタンスを初期化します。
        /// </summary>
        public DecimalPlacesDialog()
        {
            this.Title = "DecimalPlaces";
            this.LabelCaption = "Places";
        }
    }
}
