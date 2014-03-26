using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DataAccess.Model;
using System.Data.SqlClient;

namespace DataAccess.DataLogic
{
    public class GameInfoDataAccess
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM GameInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<GameInfo> GameInfoList()
        {
            List<GameInfo> gameList = new List<GameInfo>();
            DataSet ds = GetList("");
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                GameInfo gameInfo = new GameInfo();
                gameInfo.ID = Convert.ToInt32(row["ID"]);
                gameInfo.GameName = Convert.ToString(row["GameName"]);
                gameInfo.AddTime = Convert.ToDateTime(row["AddTime"]);
                gameList.Add(gameInfo);
            }
            return gameList;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GameInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GameInfo(");
            strSql.Append("GameName,OperationName,AddTime");
            strSql.Append(") values (");
            strSql.Append("@GameName,@OperationName,@AddTime");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@GameName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@OperationName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@AddTime", SqlDbType.Date,3)             
              
            };

            parameters[0].Value = model.GameName;
            parameters[1].Value = model.OperationName;
            parameters[2].Value = model.AddTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 得到一个对象实体
        /// </summary>
        public GameInfo GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, GameName, OperationName, AddTime  ");
            strSql.Append("  from GameInfo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            GameInfo model = new GameInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.GameName = ds.Tables[0].Rows[0]["GameName"].ToString();
                model.OperationName = ds.Tables[0].Rows[0]["OperationName"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
