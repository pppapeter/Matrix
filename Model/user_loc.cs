using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// user_loc:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class user_loc
	{
		public user_loc()
		{}
		#region Model
		private int _autoid;
		private string _userid;
		private string _lat;
		private string _lon;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int autoid
		{
			set{ _autoid=value;}
			get{return _autoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lat
		{
			set{ _lat=value;}
			get{return _lat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string lon
		{
			set{ _lon=value;}
			get{return _lon;}
		}
		#endregion Model

	}
}

