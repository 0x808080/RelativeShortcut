using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
	class UdpUtillity
	{
		/// <summary>イベントハンドラのデリゲート</summary>
		public delegate void UdpRecvEventHandler(UdpRecvEventArgs e);

		/// <summary>呼び出し元へ伝えるイベントハンドラ</summary>
		public event UdpRecvEventHandler UdpRecvEvent;

		/// <summary>送信先のエンドポイント</summary>
		private readonly IPEndPoint _endpoint;

		/// <summary>受信待機中のUDPオブジェクト</summary>
		private UdpClient udpClient = null;

		/// *******************************************************************
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="port">受信ポート番号</param>
		/// *******************************************************************
		public UdpUtillity(int port)
		{
			_endpoint = new IPEndPoint( IPAddress.Any, port );
		}

		/// *******************************************************************
		/// <summary>
		/// 非同期受信の開始
		/// </summary>
		/// *******************************************************************
		public void ReceiveStart()
		{
			// UdpClientを作成しバインド
			udpClient = new UdpClient( _endpoint );

			// 非同期的なデータ受信を開始
			udpClient.BeginReceive( ReceiveCallback, udpClient );
		}

		/// *******************************************************************
		/// <summary>
		/// 受信コールバック
		/// </summary>
		/// <param name="ar"></param>
		/// *******************************************************************
		private void ReceiveCallback(IAsyncResult ar)
		{
			UdpClient udp = (UdpClient)ar.AsyncState;
			IPEndPoint remoteEP = null;
			byte[] rcvBytes;

			// 受信データを取得
			try {
				rcvBytes = udp.EndReceive( ar, ref remoteEP );
			} catch( SocketException ex ) {
				string msg = string.Format( "{0}/{1}", ex.Message, ex.ErrorCode );
				MsgUtillity.ShowMsg( msg, MsgType.ERR );
				return;
			} catch( ObjectDisposedException ex ) {
				MsgUtillity.ShowMsg( ex.Message, MsgType.ERR );
				return;
			}

			// 呼び出し元へ通知
			UdpRecvEvent( new UdpRecvEventArgs( rcvBytes ) );

			// 非同期受信を再開
			udp.BeginReceive( ReceiveCallback, udp );
		}


		/// *******************************************************************
		/// <summary>
		/// UDP受信コールバックで渡すクラス
		/// </summary>
		/// *******************************************************************
		public class UdpRecvEventArgs : EventArgs
		{
			/// <summary>呼び出し元へのパラメータ</summary>
			private readonly byte[] _TestNumValue;

			/// *******************************************************************
			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="TestNumValue"></param>
			/// *******************************************************************
			public UdpRecvEventArgs(byte[] recvData)
			{
				_TestNumValue = recvData;
			}

			/// <summary>結果</summary>
			public byte[] Result { get { return _TestNumValue; } }
		}
	}
}
