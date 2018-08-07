using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

namespace RelativeShortcut
{
	enum ICON_TYPE
	{
		ICON_SYSTEM		= 57,	// システム
		ICON_WARNING	= 77,	// 警告
		ICON_INFO		= 277,	// 情報
	}

	class IconUtillity
	{
		/// *******************************************************************
		/// <summary>
		/// アイコン取得関数.
		/// </summary>
		/// <param name="file"></param>
		/// <param name="index"></param>
		/// <param name="largeIconHandle"></param>
		/// <param name="smallIconHandle"></param>
		/// <param name="icons"></param>
		/// <returns></returns>
		/// *******************************************************************
		[DllImport( "shell32.dll", EntryPoint = "ExtractIconEx", CharSet = CharSet.Auto )]
		public static extern int ExtractIconEx([MarshalAs( UnmanagedType.LPTStr )] string file, int index, out IntPtr largeIconHandle, out IntPtr smallIconHandle, int icons);

		/// *******************************************************************
		/// <summary>
		/// アイコン破棄関数.
		/// </summary>
		/// <param name="hIcon"></param>
		/// <returns></returns>
		/// *******************************************************************
		[DllImport( "User32.dll" )]
		private static extern bool DestroyIcon(IntPtr hIcon);

		/// *******************************************************************
		/// <summary>
		/// アイコンの取得
		/// </summary>
		/// <param name="path"></param>
		/// <param name="iconIndex"></param>
		/// <param name="iconSize"></param>
		/// <returns></returns>
		/// *******************************************************************
		private static Icon GetIconImage(string path, int iconIndex, bool iconSize)
		{
			try {
				Icon[] icons = new Icon[2];
				IntPtr largeIconHandle = IntPtr.Zero;
				IntPtr smallIconHandle = IntPtr.Zero;
				ExtractIconEx( path, iconIndex, out largeIconHandle, out smallIconHandle, 1 );
				icons[0] = (Icon)Icon.FromHandle( largeIconHandle ).Clone();
				icons[1] = (Icon)Icon.FromHandle( smallIconHandle ).Clone();
				DestroyIcon( largeIconHandle );
				DestroyIcon( smallIconHandle );

				if( iconSize ) {
					return icons[0];
				} else {
					return icons[1];
				}
			} catch( Exception ) {
			}

			return null;
		}

		/// *******************************************************************
		/// <summary>
		/// ボタンにアイコンの設定
		/// </summary>
		/// <param name="btn">設定するボタン</param>
		/// <param name="type">設定するアイコンインデックス</param>
		/// *******************************************************************
		public static void SetIconImage(Button btn, ICON_TYPE type)
		{
			string shell32Path = "C:\\Windows\\System32\\Shell32.dll";
			Icon icon = GetIconImage( shell32Path, (int)type, true );
			btn.Image = icon.ToBitmap();
			btn.TextImageRelation = TextImageRelation.ImageAboveText;
		}
	}
}
