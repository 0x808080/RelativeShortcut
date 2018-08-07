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
		/// <summary>ファイル読書き時の文字コード</summary>
		private const string MOJI_CODE = "Shift_JIS";

		/// <summary>アプリデータのセーブファイル</summary>
		private const string SAVE_FILE_NAME = @"C:\Temp\settings.config";

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
			Encoding enc = Encoding.GetEncoding( MOJI_CODE );

			// ファイルを開く
			StreamWriter writer = new StreamWriter( failePath, isAdd, enc );

			// テキストを書き込む
			writer.WriteLine( data );

			// ファイルを閉じる
			writer.Close();
		}

		/// *******************************************************************
		/// <summary>
		/// ファイルからの読込み
		/// </summary>
		/// <param name="filePath">ファイル名</param>
		/// <param name="lineOffset">読込み開始行(0～)</param>
		/// <param name="lineSize">読込む行数(1～)</param>
		/// <returns>読込み結果</returns>
		/// *******************************************************************
		public static string[] ReadTextFile(string filePath, int lineOffset, int lineSize)
		{

			// Shift-JISコードとして開く
			System.IO.StreamReader sr = new System.IO.StreamReader( filePath, System.Text.Encoding.GetEncoding( MOJI_CODE ) );

			string[] str = new string[lineSize];

			int idx = 0;
			int loop = 0;

			// 1行づつ読込み
			while( sr.Peek() > -1 ) {

				if( lineOffset <= loop ) {

					if( lineSize < idx ) {
						break;
					}

					str[idx] = sr.ReadLine();
					idx++;
				}

				loop++;
			}

			// 閉じる
			sr.Close();

			return str;
		}

		/// *******************************************************************
		/// <summary>
		/// パスからファイル名を取得
		/// </summary>
		/// <param name="path">パス</param>
		/// <returns>ファイル名</returns>
		/// *******************************************************************
		public static string GetFileName(string path)
		{
			return System.IO.Path.GetFileName( path );
		}

		/// *******************************************************************
		/// <summary>
		/// パスからディレクトリ名を取得
		/// </summary>
		/// <param name="path">パス</param>
		/// <returns>ディレクトリ名</returns>
		/// *******************************************************************
		public static string GetDirectory(string path)
		{
			return System.IO.Path.GetDirectoryName( path );
		}

		/// *******************************************************************
		/// <summary>
		/// データをセーブ
		/// </summary>
		/// <typeparam name="T">セーブデータのClass</typeparam>
		/// *******************************************************************
		public static void SaveAppData<T>(T obj) where T : class
		{
			// 書き込むオブジェクトの型を指定する
			System.Xml.Serialization.XmlSerializer serializer1 = new System.Xml.Serialization.XmlSerializer( typeof( T ) );

			// ファイルを開く（UTF-8 BOM無し）
			System.IO.StreamWriter sw = new System.IO.StreamWriter( SAVE_FILE_NAME, false, new System.Text.UTF8Encoding( false ) );

			// シリアル化し、XMLファイルに保存する
			serializer1.Serialize( sw, obj );

			// 閉じる
			sw.Close();
		}

		/// *******************************************************************
		/// <summary>
		/// セーブデータからロード
		/// </summary>
		/// <typeparam name="T">セーブデータのClass</typeparam>
		/// <returns></returns>
		/// *******************************************************************
		public static T LoadAppData<T>() where T : class, new()
		{
			// XmlSerializerオブジェクトの作成
			System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer( typeof( T ) );

			T appSettings;
			
			try {
				// ファイルを開く
				System.IO.StreamReader sr = new System.IO.StreamReader( SAVE_FILE_NAME, new System.Text.UTF8Encoding( false ) );

				// XMLファイルから読み込み、逆シリアル化する
				appSettings = (T)serializer2.Deserialize( sr );

				//閉じる
				sr.Close();

			} catch {

				appSettings = new T();
			}

			return appSettings;
		}
	}
}
