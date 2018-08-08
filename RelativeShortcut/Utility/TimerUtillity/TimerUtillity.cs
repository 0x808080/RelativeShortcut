using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using TM = System.Timers;

namespace RelativeShortcut
{
	// ＜使用方法＞
	// timerUtillity = new TimerUtillity();
	// timerUtillity.TimerEvent += new TimerUtillity.TimerEventHandler( func );		// 引数に実行したいメソッドを渡す(※1)
	// timerUtillity.StartTimer( 1000 );											// 引数に実行間隔(ms)を渡す
	//
	// void func(TimerUtillity.TimerEventArgs e)									// ※1:戻り値なし、引数の型は「TimerUtillity.TimerEventArgs」固定
	// {
	//     int ret = e.Result;														// タイマクラスからの戻り値(未使用のため0固定)
	//
	//     /* ユーザー処理 */
	// }

	/// <summary>
	/// タイマー制御クラス
	/// </summary>
	class TimerUtillity
	{
		/// <summary>イベントハンドラのデリゲート</summary>
		public delegate void TimerEventHandler(TimerEventArgs e);

		/// <summary>呼び出し元へ伝えるイベントハンドラ</summary>
		public event TimerEventHandler TimerEvent;

		/// *******************************************************************
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// *******************************************************************
		public TimerUtillity()
		{
			
		}
		
		/// *******************************************************************
		/// <summary>
		/// タイマー開始
		/// </summary>
		/// <param name="time">タイマーイベント間隔(ms)</param>
		/// *******************************************************************
		public void StartTimer(int time)
		{
			TM.Timer timer = new TM.Timer();
			timer.Elapsed += new TM.ElapsedEventHandler( SendTimeEvent );
			timer.Interval = time;
			timer.AutoReset = true;
			timer.Enabled = true;
		}

		/// *******************************************************************
		/// <summary>
		/// タイマーイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// *******************************************************************
		private void SendTimeEvent(object sender, EventArgs e)
		{
			TimerEvent( new TimerEventArgs( 0 ) );
		}

		// 渡せるイベントデータ引数、EventArgsを継承したクラスを拡張
		public class TimerEventArgs : EventArgs
		{
			/// <summary>呼び出し元へのパラメータ</summary>
			private readonly int _TestNumValue;

			/// *******************************************************************
			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="TestNumValue"></param>
			/// *******************************************************************
			public TimerEventArgs(int TestNumValue)
			{
				_TestNumValue = TestNumValue;
			}

			/// <summary>結果</summary>
			public int Result { get { return _TestNumValue; } }
		}
	}
}
