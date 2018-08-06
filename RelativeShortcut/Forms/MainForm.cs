using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
			// 管理者権限が必要なボタンに盾マークを追加
			AdminUtillity.SetShieldIcon( button1 );
			AdminUtillity.SetShieldIcon( button2 );
		}

		/// *******************************************************************
		/// <summary>
		/// 時刻を追加しlogファイルへの書き込み
		/// </summary>
		/// <param name="data">書込みデータ</param>
		/// *******************************************************************
		private void WriteLogFile(string data)
		{
			DateTime dt = DateTime.Now;
			string str = dt.ToString();
			string log = str + "\t" + data;

			FileUtillity.WriteTextFile( AppInfo.LOG_FILE_NAME, log, true );
		}

		/// *******************************************************************
		/// <summary>
		/// シェル拡張ボタンのイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void Button1_Click(object sender, EventArgs e)
		{
			// 管理者権限で自分を起動(引数にシュル拡張コマンドを指定)
			AdminUtillity.AdminStart( ContextUtillity.START_PRAM_ADD );
		}

		/// *******************************************************************
		/// <summary>
		/// シェル拡張解除ボタンのイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void Button2_Click(object sender, EventArgs e)
		{
			// 管理者権限で自分を起動(引数にシュル拡張解除コマンドを指定)
			AdminUtillity.AdminStart( ContextUtillity.START_PRAM_DEL );
		}
	}
}
