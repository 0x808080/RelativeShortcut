using System;
using System.Collections;
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
	public partial class OptionForm : Form
	{
		/// <summary>終了時の戻り値</summary>
		public string ReturnValue;

		/// <summary>開始時の引数</summary>
		public object ShowData;

		/// <summary>最後に表示したフォーム</summary>
		private Form lastSelForm;

		/// <summary>フォームのハッシュテーブル</summary>
		private Hashtable formHashTbl = new Hashtable();

		/// *******************************************************************
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// *******************************************************************
		public OptionForm()
		{
			InitializeComponent();

			// サブフォームの追加
			AddSubForm<OptionShellForm>();
			AddSubForm<OptionNetworkForm>();
		}

		/// *******************************************************************
		/// <summary>
		/// フォーム作成開始
		/// </summary>
		/// <param name="data">表示情報</param>
		/// <returns>フォーム終了時の戻り値</returns>
		/// *******************************************************************
		static public string ShowMiniForm(object data)
		{
			OptionForm f = new OptionForm();
			f.ShowData = data;
			f.ShowDialog();
			string receiveText = f.ReturnValue;
			f.Dispose();

			return receiveText;
		}

		/// *******************************************************************
		/// <summary>
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void OptionForm_Load(object sender, EventArgs e)
		{

		}

		/// *******************************************************************
		/// <summary>
		/// サブフォームの追加
		/// </summary>
		/// *******************************************************************
		private void AddSubForm<T>() where T : Form, new()
		{
			// サブフォームの作成
			var f = new T();
			f.TopLevel = false;

			// 親フォームのPanel2(右側)に追加
			splitContainer1.Panel2.Controls.Add( f );
			f.Show();
			f.BringToFront();
			f.Visible = false;

			// サブフォームに対応するTreeViewとハッシュテーブルを作成
			string formName = f.Text;
			OptionTreeView.Nodes.Add( formName );
			formHashTbl[formName] = f;
		}

		/// *******************************************************************
		/// <summary>
		/// TreeViewの選択イベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void OptionTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			// 表示中のフォームがあれば非表示
			if( lastSelForm != null ) {
				lastSelForm.Visible = false;
			}

			// ハッシュテーブルから選択されたフォームを取得し表示
			Form f = (Form)formHashTbl[e.Node.Text];
			f.Visible = true;

			// 表示中のフォームとして保持
			lastSelForm = f;
		}
	}
}
