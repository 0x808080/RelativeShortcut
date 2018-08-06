using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Utility
{
	class AdminUtillity
	{
		/// *******************************************************************
		/// <summary>
		/// 管理者権限で自分を起動
		/// </summary>
		/// <param name="arg">起動時のパラメータ</param>
		/// *******************************************************************
		public static void AdminStart(string arg)
		{
			// 管理者として自分自身を起動する
			System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
			// ShellExecuteを使う。デフォルトtrueなので、必要はない。
			psi.UseShellExecute = true;
			// 自分自身のパスを設定する
			psi.FileName = Application.ExecutablePath;
			// 動詞に「runas」をつける
			psi.Verb = "runas";
			// パラメータを設定
			psi.Arguments = arg;

			try {
				// 起動する
				System.Diagnostics.Process.Start( psi );
			} catch( System.ComponentModel.Win32Exception ex ) {
				// 「ユーザーアカウント制御」ダイアログでキャンセルされたなどによって
				// 起動できなかった時
				Console.WriteLine( "起動しませんでした: " + ex.Message );
			}
		}

		[DllImport( "user32.dll" )]
		private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
		private const int BCM_FIRST = 0x1600;
		private const int BCM_SETSHIELD = BCM_FIRST + 0x000C;

		/// *******************************************************************
		/// <summary>
		/// UACの盾アイコンをボタンコントロールに表示（あるいは、非表示）する
		/// </summary>
		/// <param name="targetButton">盾アイコンを表示するボタンコントロール</param>
		/// <param name="showShield">盾アイコンを表示する時はtrue。
		/// 非表示にする時はfalse1。</param>
		/// *******************************************************************
		private static void SetShieldIcon(Button targetButton, bool showShield)
		{
			if( targetButton == null ) {
				throw new ArgumentNullException( "targetButton" );
			}

			// Windows Vista以上か確認する
			if( Environment.OSVersion.Platform != PlatformID.Win32NT ||
				Environment.OSVersion.Version.Major < 6 ) {
				return;
			}

			// FlatStyleをSystemにする
			targetButton.FlatStyle = FlatStyle.System;

			// 盾アイコンを表示（または非表示）にする
			SendMessage( new HandleRef( targetButton, targetButton.Handle ),
				BCM_SETSHIELD,
				IntPtr.Zero,
				showShield ? new IntPtr( 1 ) : IntPtr.Zero );
		}

		/// *******************************************************************
		/// <summary>
		/// UACの盾アイコンをボタンコントロールに表示する
		/// </summary>
		/// <param name="targetButton">盾アイコンを表示するボタンコントロール</param>
		/// *******************************************************************
		public static void SetShieldIcon(Button targetButton)
		{
			SetShieldIcon( targetButton, true );
		}
	}
}
