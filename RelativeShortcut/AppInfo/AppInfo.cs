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
		/// アプリの初期設定
		/// </summary>
		/// *******************************************************************
		public static void AppInitialize()
		{
			DebugUtillity.SetLogFilePath( LOG_FILE_NAME );
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
	}
}
