using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
	class DebugUtillity
	{
		/// <summary>ログファイル保存先</summary>
		private static string LogFile = null;

		/// *******************************************************************
		/// <summary>
		/// ログファイルの保存先設定
		/// </summary>
		/// <param name="path">ログファイル名</param>
		/// *******************************************************************
		public static void SetLogFilePath(string path)
		{
			LogFile = path;
		}

		/// *******************************************************************
		/// <summary>
		/// 時刻を追加しlogファイルへの書き込み
		/// </summary>
		/// <param name="data">書込みデータ</param>
		/// *******************************************************************
		public static void WriteLogFile(string data)
		{
			// 保存先が設定されていない場合は何もしない
			if(LogFile == null ) {
				return;
			}

			DateTime dt = DateTime.Now;
			string str = dt.ToString();
			string log = str + "\t" + data;

			FileUtillity.WriteTextFile(LogFile, log, true);
		}

	}
}
