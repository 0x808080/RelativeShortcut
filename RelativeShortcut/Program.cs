using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utility;

namespace RelativeShortcut
{
	static class Program
	{
		/// *******************************************************************
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		/// *******************************************************************
		[STAThread]
		static void Main(string[] args)
		{
			// アプリの初期化
			AppInfo.AppInitialize();

			// 引数をログファイルへ保存
			foreach( string cmd in args ) {
				DebugUtillity.WriteLogFile( cmd );
			}

			// 引数の確認
			if( args.Length > 0 ) {

				// ロードしたアプリデータを参照
				AppSaveData saveData = AppInfo.SaveData;

				switch( args[0] ) {
				case ContextUtillity.CONTEXT_CMD_01:
					// リンク元ファイルのパスを保存
					saveData.SrcPath = args[1];
					FileUtillity.SaveAppData<AppSaveData>(saveData);
					break;

				case ContextUtillity.CONTEXT_CMD_02:
					// 保存したリンク元ファイルと指定されたリンク先とのリンク
					saveData.DstPath = args[1];
					FileUtillity.SaveAppData<AppSaveData>(saveData);
					ShortcutUtillity.MakeRelativeShortcut( saveData.SrcPath, saveData.DstPath );
					break;

				case ContextUtillity.START_PRAM_ADD:
					// コンテキストメニューへの登録
					ContextUtillity.AddContextMenu();
					break;

				case ContextUtillity.START_PRAM_DEL:
					// コンテキストメニューへの解除
					ContextUtillity.DelContextMenu();
					break;
				}

			} else {

				// 通常起動の場合はフォームを表示
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault( false );
				Application.Run( new Form1() );
			}
		}
	}
}
