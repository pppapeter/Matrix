using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:shop_info
	/// </summary>
	public partial class shop_info
	{
		public shop_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("autoid", "shop_info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int autoid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from shop_info");
			strSql.Append(" where autoid=@autoid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@autoid", MySqlDbType.Int32)
			};
			parameters[0].Value = autoid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Maticsoft.Model.shop_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into shop_info(");
			strSql.Append("name,address,tel,logo,detail,lat,lon,owner,systime)");
			strSql.Append(" values (");
			strSql.Append("@name,@address,@tel,@logo,@detail,@lat,@lon,@owner,@systime)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@address", MySqlDbType.VarChar,45),
					new MySqlParameter("@tel", MySqlDbType.VarChar,45),
					new MySqlParameter("@logo", MySqlDbType.VarChar,45),
					new MySqlParameter("@detail", MySqlDbType.VarChar,45),
					new MySqlParameter("@lat", MySqlDbType.VarChar,45),
					new MySqlParameter("@lon", MySqlDbType.VarChar,45),
					new MySqlParameter("@owner", MySqlDbType.VarChar,45),
					new MySqlParameter("@systime", MySqlDbType.DateTime)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.address;
			parameters[2].Value = model.tel;
			parameters[3].Value = model.logo;
			parameters[4].Value = model.detail;
			parameters[5].Value = model.lat;
			parameters[6].Value = model.lon;
			parameters[7].Value = model.owner;
			parameters[8].Value = model.systime;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.shop_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update shop_info set ");
			strSql.Append("name=@name,");
			strSql.Append("address=@address,");
			strSql.Append("tel=@tel,");
			strSql.Append("logo=@logo,");
			strSql.Append("detail=@detail,");
			strSql.Append("lat=@lat,");
			strSql.Append("lon=@lon,");
			strSql.Append("owner=@owner,");
			strSql.Append("systime=@systime");
			strSql.Append(" where autoid=@autoid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45),
					new MySqlParameter("@address", MySqlDbType.VarChar,45),
					new MySqlParameter("@tel", MySqlDbType.VarChar,45),
					new MySqlParameter("@logo", MySqlDbType.VarChar,45),
					new MySqlParameter("@detail", MySqlDbType.VarChar,45),
					new MySqlParameter("@lat", MySqlDbType.VarChar,45),
					new MySqlParameter("@lon", MySqlDbType.VarChar,45),
					new MySqlParameter("@owner", MySqlDbType.VarChar,45),
					new MySqlParameter("@systime", MySqlDbType.DateTime),
					new MySqlParameter("@autoid", MySqlDbType.Int32,11)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.address;
			parameters[2].Value = model.tel;
			parameters[3].Value = model.logo;
			parameters[4].Value = model.detail;
			parameters[5].Value = model.lat;
			parameters[6].Value = model.lon;
			parameters[7].Value = model.owner;
			parameters[8].Value = model.systime;
			parameters[9].Value = model.autoid;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int autoid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from shop_info ");
			strSql.Append(" where autoid=@autoid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@autoid", MySqlDbType.Int32)
			};
			parameters[0].Value = autoid;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string autoidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from shop_info ");
			strSql.Append(" where autoid in ("+autoidlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.shop_info GetModel(int autoid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select autoid,name,address,tel,logo,detail,lat,lon,owner,systime from shop_info ");
			strSql.Append(" where autoid=@autoid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@autoid", MySqlDbType.Int32)
			};
			parameters[0].Value = autoid;

			Maticsoft.Model.shop_info model=new Maticsoft.Model.shop_info();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.shop_info DataRowToModel(DataRow row)
		{
			Maticsoft.Model.shop_info model=new Maticsoft.Model.shop_info();
			if (row != null)
			{
				if(row["autoid"]!=null && row["autoid"].ToString()!="")
				{
					model.autoid=int.Parse(row["autoid"].ToString());
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["tel"]!=null)
				{
					model.tel=row["tel"].ToString();
				}
				if(row["logo"]!=null)
				{
					model.logo=row["logo"].ToString();
				}
				if(row["detail"]!=null)
				{
					model.detail=row["detail"].ToString();
				}
				if(row["lat"]!=null)
				{
					model.lat=row["lat"].ToString();
				}
				if(row["lon"]!=null)
				{
					model.lon=row["lon"].ToString();
				}
				if(row["owner"]!=null)
				{
					model.owner=row["owner"].ToString();
				}
				if(row["systime"]!=null && row["systime"].ToString()!="")
				{
					model.systime=DateTime.Parse(row["systime"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select autoid,name,address,tel,logo,detail,lat,lon,owner,systime ");
			strSql.Append(" FROM shop_info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM shop_info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.autoid desc");
			}
			strSql.Append(")AS Row, T.*  from shop_info T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "shop_info";
			parameters[1].Value = "autoid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

