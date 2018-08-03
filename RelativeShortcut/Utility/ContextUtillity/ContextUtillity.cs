using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
	class ContextUtillity
	{
		/// <summary>コンテキストメニューに追加する時のタグ</summary>
		const string VERD = "RelativeShortcut";

		/// <summary>コンテキストメニューに追加する対象(*はすべてのファイル)</summary>
		const string TARGET = "*\\shell\\";

		/// *******************************************************************
		/// <summary>
		/// コンテキストメニューに追加
		/// ※管理者権限での実行が必要
		/// </summary>
		/// *******************************************************************
		public static void AddContextMenu()
		{
			// 実行するコマンドライン
			string commandline = "\"" + Application.ExecutablePath + "\" \"%1\"";

			// 説明（エクスプローラのコンテキストメニューに表示される）
			string description = "相対リンクに変換(&L)";

			string verb = VERD;

			//フォルダへの関連付けを行う
			try {
				Microsoft.Win32.RegistryKey cmdkey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey( TARGET + verb + "\\command" );
				cmdkey.SetValue( "", commandline );
				cmdkey.Close();
			} catch {
				MsgUtillity.ShowMsg( "例外が発生しました。(管理者権限で実行してください)", MsgType.ERR );
				return;
			}

			try {
				//説明を書き込む
				Microsoft.Win32.RegistryKey verbkey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey( TARGET + verb );
				verbkey.SetValue( "", description );
				verbkey.Close();
			} catch {
				MsgUtillity.ShowMsg( "例外が発生しました。(管理者権限で実行してください)", MsgType.ERR );
				return;
			}
		}

		/// *******************************************************************
		/// <summary>
		/// コンテキストメニューから削除
		/// ※管理者権限での実行が必要
		/// </summary>
		/// *******************************************************************
		public static void DelContextMenu()
		{
			string verb = VERD;

			//レジストリキーを削除
			try {
				Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree( TARGET + verb );
			} catch {
				MsgUtillity.ShowMsg( "例外が発生しました。(管理者権限で実行してください)", MsgType.ERR );
				return;
			}
		}
	}
}
