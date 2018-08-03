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
		/// <summary>ログファイルのパス</summary>
		const string LOG_FILE_NAME = "log.log";

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
			GetCmdPram();
		}

		/// *******************************************************************
		/// <summary>
		/// 起動時の引数を取得
		/// </summary>
		/// <returns>取得した引数</returns>
		/// *******************************************************************
		private string[] GetCmdPram()
		{
			// コマンドライン引数を表示する
			Console.WriteLine( System.Environment.CommandLine );

			// コマンドライン引数を配列で取得する
			string[] cmds = System.Environment.GetCommandLineArgs();

			// コマンドライン引数を列挙する
			foreach( string cmd in cmds ) {
				Console.WriteLine( cmd );
			}

			return cmds;
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

			FileUtillity.WriteTextFile(LOG_FILE_NAME, log, true);
		}
	}
}
