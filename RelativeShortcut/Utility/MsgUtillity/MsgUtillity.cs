using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility
{

	class MsgUtillity
	{
		/// *******************************************************************
		/// <summary>
		/// メッセージボックスの表示
		/// </summary>
		/// <param name="msg">メッセージ</param>
		/// <param name="type">メッセージ種類</param>
		/// *******************************************************************
		public static void ShowMsg(string msg, MsgType type)
		{
			MessageBoxIcon[] iconList = {
				MessageBoxIcon.None,
				MessageBoxIcon.Error,
				MessageBoxIcon.Information,
			};

			string[] headList =
			{
				"",
				"エラー",
				"情報",
			};

			MessageBoxButtons btn = MessageBoxButtons.OK;

			MessageBox.Show( msg, headList[(int)type], btn, iconList[(int)type] );
		}
	}

	public enum MsgType
	{
		NONE,	// 通常
		ERR,	// 異常
		INFO,	// 情報
	}
}
