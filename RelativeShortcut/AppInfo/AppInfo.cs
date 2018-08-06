using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	}
}
