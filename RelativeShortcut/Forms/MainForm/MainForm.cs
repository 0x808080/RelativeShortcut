using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utility;

namespace RelativeShortcut
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		/// *******************************************************************
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void Form1_Load(object sender, EventArgs e)
		{

		}

		/// *******************************************************************
		/// <summary>
		/// 設定メニュ―のイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// 設定画面の表示
			OptionForm.ShowMiniForm(null);
		}
	}
}
