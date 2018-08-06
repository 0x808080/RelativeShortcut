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
			// 引数をログファイルへ保存
			foreach(string cmd in args ) {
				AppInfo.WriteLogFile( cmd );
			}

			// 引数の確認
			if(args.Length > 1 ) {

				switch( args[1] ) {
				case ContextUtillity.CONTEXT_CMD_01:
					AppInfo.WriteTempFile( args[0] );
					break;

				case ContextUtillity.CONTEXT_CMD_02:
					string src = AppInfo.ReadTempFile();
					ShortcutUtillity.MakeShortcut( src, args[0] );
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
