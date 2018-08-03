using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
	class FileUtillity
	{
		/// *******************************************************************
		/// <summary>
		/// ファイルへの書き込み
		/// </summary>
		/// <param name="failePath">ファイル名</param>
		/// <param name="data">書込みデータ</param>
		/// <param name="isAdd">true=追記</param>
		/// *******************************************************************
		public static void WriteTextFile(string failePath, string data, bool isAdd)
		{
			// 文字コードを指定
			Encoding enc = Encoding.GetEncoding( "Shift_JIS" );

			// ファイルを開く
			StreamWriter writer = new StreamWriter( failePath, isAdd, enc );

			// テキストを書き込む
			writer.WriteLine( data );

			// ファイルを閉じる
			writer.Close();
		}
	}
}
