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

		/// <summary>受信時のエンドポイント</summary>
		private IPEndPoint _endpoint;

		/// <summary>受信待機中のUDPオブジェクト</summary>
		private UdpClient udpClient = null;

		/// *******************************************************************
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// *******************************************************************
		public UdpUtillity()
		{

		}

		/// *******************************************************************
		/// <summary>
		/// 非同期受信の開始
		/// </summary>
		/// <param name="recvPort">受信ポート番号</param>
		/// *******************************************************************
		public void ReceiveStart(int recvPort)
		{
			_endpoint = new IPEndPoint( IPAddress.Any, recvPort );

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
			UdpRecvEvent?.Invoke( new UdpRecvEventArgs( rcvBytes, remoteEP ) );

			// 非同期受信を再開
			udp.BeginReceive( ReceiveCallback, udp );
		}

		/// *******************************************************************
		/// <summary>
		/// IPアドレスとポートからエンドポイントの作成
		/// </summary>
		/// <param name="ipaddr">IPアドレス</param>
		/// <param name="port">ポート番号</param>
		/// <returns>エンドポイント</returns>
		/// *******************************************************************
		public IPEndPoint GetEndPoint(string ipaddr, int port)
		{
			IPAddress addr = null;

			try {
				addr = IPAddress.Parse( ipaddr );
			} catch( FormatException e ) {
				MsgUtillity.ShowMsg( e.Message, MsgType.ERR );
				return null;
			}

			IPEndPoint endPoint = new IPEndPoint( addr, port );

			return endPoint;
		}

		/// *******************************************************************
		/// <summary>
		/// 送信開始
		/// </summary>
		/// <param name="sendData">送信データ</param>
		/// *******************************************************************
		public void SendStart(byte[] sendData, IPEndPoint endPoint)
		{
			// UdpClientを作成する
			if( udpClient == null ) {
				udpClient = new UdpClient();
			}

			//非同期的にデータを送信する
			udpClient.BeginSend( sendData, sendData.Length, endPoint, SendCallback, udpClient );
		}

		/// *******************************************************************
		/// <summary>
		/// 送信完了コールバック
		/// </summary>
		/// <param name="ar"></param>
		/// *******************************************************************
		private void SendCallback(IAsyncResult ar)
		{
			UdpClient udp = (UdpClient)ar.AsyncState;

			// 非同期送信を終了する
			try {
				udp.EndSend( ar );
			} catch( SocketException ex ) {
				Console.WriteLine( "送信エラー({0}/{1})", ex.Message, ex.ErrorCode );
			} catch( ObjectDisposedException ex ) {
				//すでに閉じている時は終了
				Console.WriteLine( "Socketは閉じられています。" );
			}
		}

		/// *******************************************************************
		/// <summary>
		/// ソケットを
		/// </summary>
		/// *******************************************************************
		public void SocektStop()
		{
			//UdpClientを閉じる
			if( udpClient != null ) {
				udpClient.Close();
			}
		}

		/// *******************************************************************
		/// <summary>
		/// UDP受信コールバックで渡すクラス
		/// </summary>
		/// *******************************************************************
		public class UdpRecvEventArgs : EventArgs
		{
			/// <summary>呼び出し元へのパラメータ(受信データ)</summary>
			private readonly byte[] _recvData;
			/// <summary>呼び出し元へのパラメータ(送信元の情報)</summary>
			private readonly IPEndPoint _endPoint;

			/// *******************************************************************
			/// <summary>
			/// コンストラクタ
			/// </summary>
			/// <param name="TestNumValue"></param>
			/// *******************************************************************
			public UdpRecvEventArgs(byte[] recvData, IPEndPoint endPoint)
			{
				_recvData = recvData;
				_endPoint = endPoint;
			}

			/// <summary>受信データ</summary>
			public byte[] Data { get { return _recvData; } }
			/// <summary>送信元情報</summary>
			public IPEndPoint SrcIndo { get { return _endPoint; } }
		}
	}
}
