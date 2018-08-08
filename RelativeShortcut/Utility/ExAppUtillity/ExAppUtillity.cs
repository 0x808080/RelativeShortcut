using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace RelativeShortcut.Utility.ExAppUtillity
{
	/// <summary>
	/// 外部アプリ制御用クラス
	/// </summary>
	class ExAppUtillity
	{
		// 使用方法
		//	this.IsMdiContainer = true;
		//	MdiUtil.LoadProcessInControl( @"D:\work\NS__SVN\01-資料\01-提供資料\20180222-01_打合せ時提供物\FTPツール\MAI\MAI.exe", MdiUtil.GetMdiClient( this ) );


		[DllImport( "user32.dll", SetLastError = true )]
		private static extern uint SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

		public static void LoadProcessInControl(string filename, Control ctrl)
		{
			Process p = Process.Start( filename );
			p.WaitForInputIdle();

			System.Threading.Thread.Sleep( 1000 );

			SetParent( p.MainWindowHandle, ctrl.Handle );
		}

		public static MdiClient GetMdiClient(Form form)
		{
			foreach( Control c in form.Controls ) {
				if( c is MdiClient ) {
					return (MdiClient)c;
				}
			}

			return null;
		}
	}
}
