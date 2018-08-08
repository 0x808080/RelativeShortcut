using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Utility;

namespace RelativeShortcut
{
	/// <summary>
	/// メインフォーム
	/// </summary>
	public partial class Form1 : Form
	{
		/// <summary>タイマー管理Class</summary>
		private TimerUtillity timerUtillity = null;

		/// <summary>UDP通信クラス</summary>
		private UdpUtillity udpUtillity = null;

		/// <summary>搭載されているメモリ量(MB)</summary>
		private int MaxMemorySize = 0;

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
		/// フォームロードイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void Form1_Load(object sender, EventArgs e)
		{
			// 周期タイマー起動
			if( timerUtillity == null ) {
				timerUtillity = new TimerUtillity();
				timerUtillity.TimerEvent += new TimerUtillity.TimerEventHandler( ShowCPUInfo );     // CPU
				timerUtillity.TimerEvent += new TimerUtillity.TimerEventHandler( ShowMemoryInfo );  // メモリ
				timerUtillity.TimerEvent += new TimerUtillity.TimerEventHandler( ShowHDDInfo );		// HDD
				timerUtillity.StartTimer( AppInfo.MONITOR_INTERVAL );
			}

			MaxMemorySize = DebugUtillity.GetMaxMemorySize();
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

		}

		/// *******************************************************************
		/// <summary>
		/// CPU使用率の表示
		/// </summary>
		/// <param name="e"></param>
		/// *******************************************************************
		private void ShowCPUInfo(TimerUtillity.TimerEventArgs e)
		{
			int val = (int)DebugUtillity.GetCPUMonitor();

			this.Invoke( (Action)(() =>
			{
				//StripStatusCPU.Text = "　CPU使用率: " + val.ToString() + @"%";
				StripProgressCPU.Maximum = 101;
				StripProgressCPU.Value = val;
			}) );
		}

		/// *******************************************************************
		/// <summary>
		/// メモリ使用量の表示
		/// </summary>
		/// <param name="e"></param>
		/// *******************************************************************
		private void ShowMemoryInfo(TimerUtillity.TimerEventArgs e)
		{
			if( MaxMemorySize == 0 ) {
				return;
			}

			int val = (int)DebugUtillity.GetMemoryMonitor();

			int useSize = MaxMemorySize - val;

			this.Invoke( (Action)(() =>
			{
				StripStatusMemory.Text = "　メモリ使用量" + useSize.ToString() + "MB";
				StripProgressMemory.Maximum = MaxMemorySize;
				StripProgressMemory.Value = useSize;
			}) );
		}

		/// *******************************************************************
		/// <summary>
		/// HDD使用率の表示
		/// </summary>
		/// <param name="e"></param>
		/// *******************************************************************
		private void ShowHDDInfo(TimerUtillity.TimerEventArgs e)
		{
			int val = (int)DebugUtillity.GetHDDMonitor();

			if( val > 100 ) {
				val = 100;
			}

			this.Invoke( (Action)(() =>
			{
				StripProgressCPU.Value = val;
			}) );
		}
	}
}
