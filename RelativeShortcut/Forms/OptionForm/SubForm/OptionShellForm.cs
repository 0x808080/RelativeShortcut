using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility;

namespace RelativeShortcut
{
	public partial class OptionShellForm : Form
	{
		public OptionShellForm()
		{
			InitializeComponent();

			// 管理者権限が必要なボタンに盾マークを追加
			AdminUtillity.SetShieldIcon( AddShellBtn );
			AdminUtillity.SetShieldIcon( DelShellBtn );
		}

		/// *******************************************************************
		/// <summary>
		/// シェル統合ボタンイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void AddShellBtn_Click(object sender, EventArgs e)
		{
			// 管理者権限で自分を起動(引数にシュル拡張コマンドを指定)
			AdminUtillity.AdminStart( ContextUtillity.START_PRAM_ADD );
		}

		/// *******************************************************************
		/// <summary>
		/// シェル統合解除ボタンイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void DelShellBtn_Click(object sender, EventArgs e)
		{
			// 管理者権限で自分を起動(引数にシュル拡張解除コマンドを指定)
			AdminUtillity.AdminStart( ContextUtillity.START_PRAM_DEL );
		}
	}
}
