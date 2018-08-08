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

		/// <summary>モニターの監視間隔</summary>
		public const int MONITOR_INTERVAL = 2000;

		/// <summary>ロードしたセーブデータ</summary>
		public static AppSaveData SaveData = null;

		/// *******************************************************************
		/// <summary>
		/// アプリの初期設定
		/// </summary>
		/// *******************************************************************
		public static void AppInitialize()
		{
			// ログファイルの保存先を設定
			DebugUtillity.SetLogFilePath( LOG_FILE_NAME );

			// アプリデータのロード
			SaveData = FileUtillity.LoadAppData<AppSaveData>();
		}

		/// *******************************************************************
		/// <summary>
		/// 起動時の引数を取得
		/// </summary>
		/// <returns>取得した引数</returns>
		/// *******************************************************************
		private static string[] GetCmdPram()
		{
			// コマンドライン引数を配列で取得する
			string[] cmds = System.Environment.GetCommandLineArgs();

			return cmds;
		}
	}
}
