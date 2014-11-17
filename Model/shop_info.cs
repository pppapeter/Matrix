using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// shop_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class shop_info
	{
		public shop_info()
		{}
		#region Model
		private int _autoid;
		private string _name;
		private string _address;
		private string _tel;
		private string _logo;
		private string _detail;
		private string _lat;
		private string _lon;
		private string _owner;
		private DateTime? _systime;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string logo
		{
			set{ _logo=value;}
			get{return _logo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string detail
		{
			set{ _detail=value;}
			get{return _detail;}
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
		/// <summary>
		/// 
		/// </summary>
		public string owner
		{
			set{ _owner=value;}
			get{return _owner;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? systime
		{
			set{ _systime=value;}
			get{return _systime;}
		}
		#endregion Model

	}
}

