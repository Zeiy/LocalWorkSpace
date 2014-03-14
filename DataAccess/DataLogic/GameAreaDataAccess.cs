using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.DataLogic
{
    public class GameAreaDataAccess
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM GameArea ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public List<GameArea> GameAreaList()
        {
            List<GameArea> gameAreaList = new List<GameArea>();
            DataSet ds = GetList("");
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                GameArea gameArea = new GameArea();
                gameArea.ID = Convert.ToInt32(row["ID"]);
                gameArea.AreaName = Convert.ToString(row["AreaName"]);
                gameAreaList.Add(gameArea);
            }
            return gameAreaList;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GameArea GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, AreaName, GameID  ");
            strSql.Append("  from GameArea ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            GameArea model = new GameArea();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.AreaName = ds.Tables[0].Rows[0]["AreaName"].ToString();
                if (ds.Tables[0].Rows[0]["GameID"].ToString() != "")
                {
                    model.GameID = int.Parse(ds.Tables[0].Rows[0]["GameID"].ToString());
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
