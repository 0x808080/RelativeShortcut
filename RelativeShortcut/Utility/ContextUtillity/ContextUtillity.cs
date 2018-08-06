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
		private const string VERD_01 = "RelativeShortcut_01";
		private const string VERD_02 = "RelativeShortcut_02";

		/// <summary>コンテキストメニューに追加する対象</summary>
		private const string DST_TARGET = "Directory\\Background\\shell\\";
		private const string SRC_TARGET = "*\\shell\\";

		public const string CONTEXT_CMD_01 = "/l";
		public const string CONTEXT_CMD_02 = "/c";
		public const string START_PRAM_ADD = "/add";
		public const string START_PRAM_DEL = "/del";

		/// *******************************************************************
		/// <summary>
		/// コンテキストメニューに追加
		/// ※管理者権限での実行が必要
		/// </summary>
		/// *******************************************************************
		public static void AddContextMenu()
		{
			// 実行するコマンドライン
			string commandline_01 = "\"" + Application.ExecutablePath + "\" \"" + CONTEXT_CMD_01 + "\" \"%1\"";
			string commandline_02 = "\"" + Application.ExecutablePath + "\" \"" + CONTEXT_CMD_02 + "\" \"%V\"";

			// 説明（エクスプローラのコンテキストメニューに表示される）
			string description_01 = "リンク対象に選択(&L)";
			string description_02 = "相対リンクに変換(&C)";

			string verb_01 = VERD_01;
			string verb_02 = VERD_02;

			//フォルダへの関連付けを行う
			try {
				Microsoft.Win32.RegistryKey cmdkey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey( SRC_TARGET + verb_01 + "\\command" );
				cmdkey.SetValue( "", commandline_01 );
				cmdkey.Close();

				//説明を書き込む
				Microsoft.Win32.RegistryKey verbkey = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey( SRC_TARGET + verb_01 );
				verbkey.SetValue( "", description_01 );
				verbkey.Close();

				Microsoft.Win32.RegistryKey cmdkey_02 = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey( DST_TARGET + verb_02 + "\\command" );
				cmdkey_02.SetValue( "", commandline_02 );
				cmdkey_02.Close();

				//説明を書き込む
				Microsoft.Win32.RegistryKey verbkey_02 = Microsoft.Win32.Registry.ClassesRoot.CreateSubKey( DST_TARGET + verb_02 );
				verbkey_02.SetValue( "", description_02 );
				verbkey_02.Close();
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
			string verb_01 = VERD_01;
			string verb_02 = VERD_02;

			//レジストリキーを削除
			try {
				Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree( SRC_TARGET + verb_01 );
				Microsoft.Win32.Registry.ClassesRoot.DeleteSubKeyTree( DST_TARGET + verb_02 );
			} catch {
				MsgUtillity.ShowMsg( "例外が発生しました。(管理者権限で実行してください)", MsgType.ERR );
				return;
			}
		}
	}
}
