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
		/// 相対ショートカットの作成
		/// </summary>
		/// <param name="srcPath">参照元のファイル</param>
		/// <param name="dstPath">作成先のディレクトリ</param>
		/// *******************************************************************
		public static void MakeRelativeShortcut(string srcPath, string dstPath)
		{
			// パスからファイル名を取得
			string fileName = FileUtillity.GetFileName( srcPath );

			// ショートカットそのもののパス
			string shortcutPath = dstPath + @"\" + fileName + @".lnk";

			// ショートカットのリンク先(起動するプログラムのパス)
			string targetPath = srcPath;

			// 相対パスを求める
			string directory = FileUtillity.GetDirectory( srcPath );
			string relative = ConvRelativePath( dstPath, directory );

			// WshShellを作成 ショートカットのパスを指定して、WshShortcutを作成
			IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
			IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut( shortcutPath );

			// 相対パス
			string parm = "\".\\" + relative + fileName + "\"";

			// ショートカットファイルのパラメータを設定
			shortcut.TargetPath = "%windir%\\explorer.exe";     // リンク先
			shortcut.Arguments = parm;                          // 引数
			shortcut.WorkingDirectory = "";                     // 作業フォルダ
			shortcut.WindowStyle = 1;                           // 実行時の大きさ 1が通常、3が最大化、7が最小化
			shortcut.Description = "相対パスのショートカット";  // コメント
			shortcut.IconLocation = srcPath + ",0";             // アイコンのパス 自分のEXEファイルのインデックス0のアイコン

			// ショートカットを作成
			shortcut.Save();

			// 後始末
			System.Runtime.InteropServices.Marshal.FinalReleaseComObject( shortcut );
			System.Runtime.InteropServices.Marshal.FinalReleaseComObject( shell );
		}

		/// *******************************************************************
		/// <summary>
		/// 相対パスへの変換
		/// </summary>
		/// <param name="src"></param>
		/// <param name="dst"></param>
		/// <returns></returns>
		/// *******************************************************************
		private static string ConvRelativePath(string src, string dst)
		{
			Uri sPath1 = new Uri( src + @"\" );
			Uri sPath2 = new Uri( dst + @"\" );
			Uri sPath3 = sPath1.MakeRelativeUri( sPath2 );

			string str = sPath3.ToString().Replace( "/", @"\" );

			return str;
		}

		/// *******************************************************************
		/// <summary>
		/// シンボリックリンクの作成(相対リンクは作成しても絶対パスになる)
		/// </summary>
		/// <param name="srcPath">リンク元のファイル(ディレクトリはNG)</param>
		/// <param name="dstPath">リンク先のディレクトリ</param>
		/// *******************************************************************
		public static void MakeSymbolicLink(string srcPath, string dstPath)
		{
			// パスからファイル名を取得
			string fileName = FileUtillity.GetFileName( srcPath );

			// ショートカットそのもののパス
			string shortcutPath = dstPath + @"\" + fileName;

			// ショートカットのリンク先(起動するプログラムのパス)
			string targetPath = srcPath;

			// 相対パスを求める
			string directory = FileUtillity.GetDirectory( srcPath );
			string relative = ConvRelativePath( dstPath, directory );


			//Processオブジェクトを作成
			System.Diagnostics.Process p = new System.Diagnostics.Process();

			p.StartInfo.FileName = "cmd.exe";
			p.StartInfo.Verb = "runas";
			p.StartInfo.UseShellExecute = true;
			//出力を読み取れるようにする
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardInput = false;
			//ウィンドウを表示しないようにする
			p.StartInfo.CreateNoWindow = true;
			//コマンドラインを指定（"/c"は実行後閉じるために必要）
			//p.StartInfo.Arguments = @"/c dir c:\ /w";				// "mklink /D C:\app\log e:\log"
			p.StartInfo.Arguments = @"/c cd " + dstPath + @" & mklink .\" + fileName + "  .\\" + relative + fileName;

			//起動
			p.Start();

			//出力を読み取る
			string results = p.StandardOutput.ReadToEnd();

			//プロセス終了まで待機する
			//WaitForExitはReadToEndの後である必要がある
			//(親プロセス、子プロセスでブロック防止のため)
			p.WaitForExit();
			p.Close();

			//出力された結果を表示
			Console.WriteLine( results );
			DebugUtillity.WriteLogFile( results );
		}
	}
}
