using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace RelativeShortcut
{
	static class AppInfo
	{
		/// <summary>ログファイルのパス</summary>
		public const string LOG_FILE_NAME = "C:\\Temp\\log.log";

		/// <summary>一時データファイルのパス</summary>
		public const string TEMP_FILE_NAME = "C:\\Temp\\temp.log";

		/// *******************************************************************
		/// <summary>
		/// 時刻を追加しlogファイルへの書き込み
		/// </summary>
		/// <param name="data">書込みデータ</param>
		/// *******************************************************************
		public static void WriteLogFile(string data)
		{
			DateTime dt = DateTime.Now;
			string str = dt.ToString();
			string log = str + "\t" + data;

			FileUtillity.WriteTextFile(LOG_FILE_NAME, log, true);
		}

		/// *******************************************************************
		/// <summary>
		/// 一時データとして保存
		/// </summary>
		/// <param name="path">書込みデータ</param>
		/// *******************************************************************
		public static void WriteTempFile(string path)
		{
			FileUtillity.WriteTextFile(TEMP_FILE_NAME, path, false);
		}

		/// *******************************************************************
		/// <summary>
		/// 一時データから読み取り
		/// </summary>
		/// <returns>読取り結果</returns>
		/// *******************************************************************
		public static string ReadTempFile()
		{
			string[] str = FileUtillity.ReadTextFile( TEMP_FILE_NAME, 0, 1 );
			return str[0];
		}

		/// *******************************************************************
		/// <summary>
		/// 管理者権限で自分を起動
		/// </summary>
		/// <param name="arg">起動時のパラメータ</param>
		/// *******************************************************************
		public static void AdminStart(string arg)
		{
			// 管理者として自分自身を起動する
			System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
			// ShellExecuteを使う。デフォルトtrueなので、必要はない。
			psi.UseShellExecute = true;
			// 自分自身のパスを設定する
			psi.FileName = Application.ExecutablePath;
			// 動詞に「runas」をつける
			psi.Verb = "runas";
			// パラメータを設定
			psi.Arguments = arg;

			try {
				// 起動する
				System.Diagnostics.Process.Start( psi );
			} catch( System.ComponentModel.Win32Exception ex ) {
				// 「ユーザーアカウント制御」ダイアログでキャンセルされたなどによって
				// 起動できなかった時
				Console.WriteLine( "起動しませんでした: " + ex.Message );
			}
		}
	}
}
