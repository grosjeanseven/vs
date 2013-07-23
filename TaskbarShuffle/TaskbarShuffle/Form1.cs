using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        // コールバックメソッドのデリゲート
        private delegate int EnumerateWindowsCallback(IntPtr hWnd, int lParam);

        // EnumWindows API関数の宣言
        [DllImport("user32.dll", EntryPoint = "EnumWindows")]
        private static extern int EnumWindows(EnumerateWindowsCallback lpEnumFunc, int lParam);

        // GetWindowText API関数の宣言
        [DllImport("user32.dll", EntryPoint = "GetWindowText", CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCoun);

        // IsWindowVisible API関数の宣言
        [DllImport("user32.dll", EntryPoint = "IsWindowVisible")]
        private static extern int IsWindowVisible(IntPtr hWnd);

        /// <summary>
        /// ウィンドウの表示状態を設定します。
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        // ウィンドウを列挙するためのコールバックメソッド
        private int EnumerateWindows(IntPtr hWnd, int lParam)
        {
            const int BUFFER_SIZE = 0x1000;
            StringBuilder sb = new StringBuilder(BUFFER_SIZE);

            // ウィンドウが可視の場合
            if (IsWindowVisible(hWnd) != 0)
            {
                // ウィンドウのキャプションを取得
                if (GetWindowText(hWnd, sb, BUFFER_SIZE) != 0)
                {
                    DataRow row = _table.NewRow();
                    row.SetField("ID", hWnd);
                    row.SetField("NAME", sb);
//                    row.ItemArray = new object[] { hWnd, sb };
                    _table.Rows.Add(row);
//                    Console.WriteLine(hWnd + " : " + sb);
                }
            }
            // 列挙を継続するには0以外を返す必要がある
            return 1;
        }
        
        public Form1()
        {
            InitializeComponent();
            this.notifyIcon1.Icon = Properties.Resources._1374604172_61522;
            this.notifyIcon1.Text = this.Text;
        }

        private DataTable _table; 

        private void button1_Click(object sender, EventArgs e)
        {
            _table = new DataTable();
            _table.Columns.Add("ID", typeof(IntPtr));
            _table.Columns.Add("NAME", typeof(string));
            this.comboBox1.DataSource = _table;
            this.comboBox1.DisplayMember = "NAME";
            this.comboBox1.ValueMember = "ID";

            // ウィンドウを列挙します。
            EnumWindows(new EnumerateWindowsCallback(EnumerateWindows), 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IntPtr handle = new IntPtr( int.Parse(this.comboBox1.SelectedValue.ToString()));

            ShowWindow(handle, SW_HIDE);
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    System.Threading.Thread.Sleep(10);
                    Application.DoEvents();
                }
            }
            finally
            {
                ShowWindow(handle, SW_SHOW);
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }
    }
}
