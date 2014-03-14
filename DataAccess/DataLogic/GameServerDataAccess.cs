using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccess.DataLogic
{
    public class GameServerDataAccess
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM GameServer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<GameServer> GetGameServerByGameIDandAreaId(int gameId, int areaId)
        {
            List<GameServer> serverList = new List<GameServer>();
            DataSet ds = GetList("GameID = " + gameId + "and AreaID = " + areaId);
            DataTable dt = ds.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                GameServer gs = new GameServer();
                gs.ServerName = Convert.ToString(item["ServerName"]);
                gs.ID = Convert.ToInt32(item["ID"]);
                gs.AreaID = Convert.ToInt32(item["AreaID"]);
                gs.GameID = Convert.ToInt32(item["GameID"]);
                gs.GameName = Convert.ToString(item["GameName"]);
                gs.AreaName = Convert.ToString(item["AreaName"]);
                serverList.Add(gs);
            }
            return serverList;
        }
        public List<GameServer> GetGameServerByGameNameandAreaName(string gameName, string areaName)
        {
            List<GameServer> serverList = new List<GameServer>();
            DataSet ds = GetList("GameName = '" + gameName + "' and AreaName ='" + areaName+"'");
            DataTable dt = ds.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                GameServer gs = new GameServer();
                gs.ServerName = Convert.ToString(item["ServerName"]);
                gs.ID = Convert.ToInt32(item["ID"]);
                gs.AreaID = Convert.ToInt32(item["AreaID"]);
                gs.GameID = Convert.ToInt32(item["GameID"]);
                gs.GameName = Convert.ToString(item["GameName"]);
                gs.AreaName = Convert.ToString(item["AreaName"]);
                serverList.Add(gs);
            }
            return serverList;
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(GameServer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GameServer(");
            strSql.Append("ServerName,AreaID,GameID,AreaName,GameName");
            strSql.Append(") values (");
            strSql.Append("@ServerName,@AreaID,@GameID,@AreaName,@GameName");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ServerName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@AreaID", SqlDbType.Int,4) ,            
                        new SqlParameter("@GameID", SqlDbType.Int,4) ,            
                        new SqlParameter("@AreaName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GameName", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.ServerName.Trim();
            parameters[1].Value = model.AreaID;
            parameters[2].Value = model.GameID;
            parameters[3].Value = model.AreaName.Trim();
            parameters[4].Value = model.GameName.Trim();

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GameServer ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public GameServer GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, ServerName, AreaID, GameID, AreaName, GameName  ");
            strSql.Append("  from GameServer ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            GameServer model = new GameServer();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
                if (ds.Tables[0].Rows[0]["AreaID"].ToString() != "")
                {
                    model.AreaID = int.Parse(ds.Tables[0].Rows[0]["AreaID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GameID"].ToString() != "")
                {
                    model.GameID = int.Parse(ds.Tables[0].Rows[0]["GameID"].ToString());
                }
                model.AreaName = ds.Tables[0].Rows[0]["AreaName"].ToString();
                model.GameName = ds.Tables[0].Rows[0]["GameName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
