using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utility;

namespace RelativeShortcut
{
	public partial class Form1 : Form
	{

		/// *******************************************************************
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// *******************************************************************
		public Form1()
		{
			InitializeComponent();

			// 自身を最大化
			this.WindowState = FormWindowState.Maximized;

			// ボタンへアイコンを設定
			IconUtillity.SetIconImage( SysBtn, ICON_TYPE.ICON_SYSTEM );
			IconUtillity.SetIconImage( InfoBtn, ICON_TYPE.ICON_INFO );
			IconUtillity.SetIconImage( WarningBtn, ICON_TYPE.ICON_WARNING );
		}

		/// *******************************************************************
		/// <summary>
		/// 設定メニュ―のイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void OptionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// 設定画面の表示
			OptionForm.ShowMiniForm( null );
		}

		/// *******************************************************************
		/// <summary>
		/// 終了ボタンのイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void ExitStripMenuItem_Click(object sender, EventArgs e)
		{
			// アプリの終了
			Application.Exit();
		}

		/// *******************************************************************
		/// <summary>
		/// システムボタンイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void SysBtn_Click(object sender, EventArgs e)
		{

		}

		/// *******************************************************************
		/// <summary>
		/// 情報ボタンイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void InfoBtn_Click(object sender, EventArgs e)
		{

		}

		/// *******************************************************************
		/// <summary>
		/// 異常ボタンイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void WarningBtn_Click(object sender, EventArgs e)
		{
			this.IsMdiContainer = true;
			MdiUtil.LoadProcessInControl( @"D:\work\NS__SVN\01-資料\01-提供資料\20180222-01_打合せ時提供物\FTPツール\MAI\MAI.exe", MdiUtil.GetMdiClient( this ) );
		}



		public static class MdiUtil
		{
			[DllImport( "user32.dll", SetLastError = true )]
			private static extern uint SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

			public static void LoadProcessInControl(string filename, Control ctrl)
			{
				Process p = Process.Start( filename );
				p.WaitForInputIdle();

				System.Threading.Thread.Sleep(1000);

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
}
