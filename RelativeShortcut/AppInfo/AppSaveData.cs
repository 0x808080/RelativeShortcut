using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelativeShortcut
{
	public class AppSaveData
	{
		public AppSaveData()
		{

		}

		private string _SrcPath;
		private string _DstPath;

		// 自動プロパティ
		public string SrcPath { get { return _SrcPath; } set { _SrcPath = value; } }
		public string DstPath { get { return _DstPath; } set { _DstPath = value; } }
	}
}
