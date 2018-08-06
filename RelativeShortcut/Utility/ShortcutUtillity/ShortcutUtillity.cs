using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{
	class ShortcutUtillity
	{
		/// *******************************************************************
		/// <summary>
		/// ショートカットの作成
		/// </summary>
		/// <param name="srcPath">参照元のファイル</param>
		/// <param name="dstPath">作成先のディレクトリ</param>
		/// *******************************************************************
		public static void MakeShortcut(string srcPath, string dstPath)
		{
			// ショートカットそのもののパス
			string shortcutPath = dstPath + @"\" + FileUtillity.GetFileName( srcPath ) + @".lnk";

			// ショートカットのリンク先(起動するプログラムのパス)
			string targetPath = srcPath;

			// WshShellを作成
			IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
			// ショートカットのパスを指定して、WshShortcutを作成
			IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut( shortcutPath );
			// ①リンク先
			shortcut.TargetPath = targetPath;
			// ②引数
			shortcut.Arguments = "/a /b /c";
			// ③作業フォルダ
			shortcut.WorkingDirectory = Application.StartupPath;
			// ④実行時の大きさ 1が通常、3が最大化、7が最小化
			shortcut.WindowStyle = 1;
			// ⑤コメント
			shortcut.Description = "テストのアプリケーション";
			// ⑥アイコンのパス 自分のEXEファイルのインデックス0のアイコン
			shortcut.IconLocation = Application.ExecutablePath + ",0";

			// ショートカットを作成
			shortcut.Save();

			// 後始末
			System.Runtime.InteropServices.Marshal.FinalReleaseComObject( shortcut );
			System.Runtime.InteropServices.Marshal.FinalReleaseComObject( shell );
		}
	}
}
