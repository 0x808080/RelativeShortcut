using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
	class DebugUtillity
	{
		/// <summary>ログファイル保存先</summary>
		private static string LogFile = null;

		/// *******************************************************************
		/// <summary>
		/// ログファイルの保存先設定
		/// </summary>
		/// <param name="path">ログファイル名</param>
		/// *******************************************************************
		public static void SetLogFilePath(string path)
		{
			LogFile = path;
		}

		/// *******************************************************************
		/// <summary>
		/// 時刻を追加しlogファイルへの書き込み
		/// </summary>
		/// <param name="data">書込みデータ</param>
		/// *******************************************************************
		public static void WriteLogFile(string data)
		{
			// 保存先が設定されていない場合は何もしない
			if( LogFile == null ) {
				return;
			}

			DateTime dt = DateTime.Now;
			string str = dt.ToString();
			string log = str + "\t" + data;

			FileUtillity.WriteTextFile( LogFile, log, true );
		}

		/// <summary>CPUパフォーマンスカウンター</summary>
		private static PerformanceCounter _CPUCounter = null;
		/// <summary>メモリパフォーマンスカウンター</summary>
		private static PerformanceCounter _MemoryCounter = null;
		/// <summary>HDDパフォーマンスカウンター</summary>
		private static PerformanceCounter _HDDCounter = null;

		/// *******************************************************************
		/// <summary>
		/// 共通で使用するメンバのnullチェック
		/// </summary>
		/// *******************************************************************
		private static void PMCounterNullCheck()
		{
			if( _CPUCounter == null ) {
				_CPUCounter = new PerformanceCounter( "Processor", "% Processor Time", "_Total" );
			}

			if( _MemoryCounter == null ) {
				_MemoryCounter = new PerformanceCounter( "Memory", "Available Mbytes", string.Empty );
			}

			if( _HDDCounter == null ) {
				_HDDCounter = new PerformanceCounter( "PhysicalDisk", "% Disk Time", "_Total" );
			}
		}

		/// *******************************************************************
		/// <summary>
		/// CPUの使用率を取得
		/// ※最初の値は不定値
		/// </summary>
		/// <returns></returns>
		/// *******************************************************************
		public static float GetCPUMonitor()
		{
			PMCounterNullCheck();

			float cpu = _CPUCounter.NextValue();

			// 小数点を切り上げ
			//int ret1 = (int)Math.Ceiling(cpu);

			return cpu;
		}

		/// *******************************************************************
		/// <summary>
		/// HDDの使用量を取得
		/// </summary>
		/// <returns></returns>
		/// *******************************************************************
		public static float GetHDDMonitor()
		{
			PMCounterNullCheck();

			float hdd = _HDDCounter.NextValue();

			return hdd;
		}

		/// *******************************************************************
		/// <summary>
		/// メモリの使用量を取得
		/// </summary>
		/// <returns></returns>
		/// *******************************************************************
		public static float GetMemoryMonitor()
		{
			PMCounterNullCheck();

			float memory = _MemoryCounter.NextValue();

			return memory;
		}

		/// *******************************************************************
		/// <summary>
		/// 実装されているメモリ最大サイズを取得
		/// </summary>
		/// <returns>最大メモリサイズ(MB)</returns>
		/// *******************************************************************
		public static int GetMaxMemorySize()
		{
			Microsoft.VisualBasic.Devices.ComputerInfo info = new Microsoft.VisualBasic.Devices.ComputerInfo();

			// 取得値がbyteなのでMBへ変換
			int maxSize = (int)(info.TotalPhysicalMemory / 1000000);

			return maxSize;
		}
	}
}
