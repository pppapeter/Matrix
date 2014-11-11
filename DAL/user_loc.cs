using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:user_loc
    /// </summary>
    public partial class user_loc
    {
        public user_loc()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("autoid", "user_loc");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int autoid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from user_loc");
            strSql.Append(" where autoid=@autoid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@autoid", MySqlDbType.Int32)
			};
            parameters[0].Value = autoid;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Maticsoft.Model.user_loc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into user_loc(");
            strSql.Append("userid,lat,lon,systime)");
            strSql.Append(" values (");
            strSql.Append("@userid,@lat,@lon,@systime)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@userid", MySqlDbType.VarChar,45),
					new MySqlParameter("@lat", MySqlDbType.VarChar,45),
					new MySqlParameter("@lon", MySqlDbType.VarChar,45),
					new MySqlParameter("@systime", MySqlDbType.DateTime)};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.lat;
            parameters[2].Value = model.lon;
            parameters[3].Value = model.systime;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(Maticsoft.Model.user_loc model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update user_loc set ");
            strSql.Append("userid=@userid,");
            strSql.Append("lat=@lat,");
            strSql.Append("lon=@lon,");
            strSql.Append("systime=@systime");
            strSql.Append(" where autoid=@autoid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@userid", MySqlDbType.VarChar,45),
					new MySqlParameter("@lat", MySqlDbType.VarChar,45),
					new MySqlParameter("@lon", MySqlDbType.VarChar,45),
					new MySqlParameter("@systime", MySqlDbType.DateTime),
					new MySqlParameter("@autoid", MySqlDbType.Int32,11)};
            parameters[0].Value = model.userid;
            parameters[1].Value = model.lat;
            parameters[2].Value = model.lon;
            parameters[3].Value = model.systime;
            parameters[4].Value = model.autoid;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user_loc ");
            strSql.Append(" where autoid=@autoid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@autoid", MySqlDbType.Int32)
			};
            parameters[0].Value = autoid;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string autoidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from user_loc ");
            strSql.Append(" where autoid in (" + autoidlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public Maticsoft.Model.user_loc GetModel(int autoid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select autoid,userid,lat,lon,systime from user_loc ");
            strSql.Append(" where autoid=@autoid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@autoid", MySqlDbType.Int32)
			};
            parameters[0].Value = autoid;

            Maticsoft.Model.user_loc model = new Maticsoft.Model.user_loc();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Maticsoft.Model.user_loc DataRowToModel(DataRow row)
        {
            Maticsoft.Model.user_loc model = new Maticsoft.Model.user_loc();
            if (row != null)
            {
                if (row["autoid"] != null && row["autoid"].ToString() != "")
                {
                    model.autoid = int.Parse(row["autoid"].ToString());
                }
                if (row["userid"] != null)
                {
                    model.userid = row["userid"].ToString();
                }
                if (row["lat"] != null)
                {
                    model.lat = row["lat"].ToString();
                }
                if (row["lon"] != null)
                {
                    model.lon = row["lon"].ToString();
                }
                if (row["systime"] != null && row["systime"].ToString() != "")
                {
                    model.systime = DateTime.Parse(row["systime"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select autoid,userid,lat,lon,systime ");
            strSql.Append(" FROM user_loc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere, DateTime time, string timespan)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select autoid,userid,lat,lon,systime ");
            strSql.Append(" FROM user_loc ");
            strSql.Append(" WHERE 1=1 ");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" AND " + strWhere);

                if (!string.IsNullOrEmpty(timespan))
                {
                    strSql.Append(" AND systime > DATE_SUB('" + time + "',INTERVAL " + timespan + " SECOND) ");
                }
            }
           
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM user_loc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.autoid desc");
            }
            strSql.Append(")AS Row, T.*  from user_loc T ");
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
            parameters[0].Value = "user_loc";
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

