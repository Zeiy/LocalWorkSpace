using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataAccess.Model;

namespace DataAccess.DataLogic
{
    public class UserBuyOrderDataAccess
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserBuyOrder");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 根据用户ID检察用户是否已有未付款订单
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool ExistsByUserId(int userId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserBuyOrder");
            strSql.Append(" where ");
            strSql.Append(" UserID = @UserID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = userId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public UserBuyOrder GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, OrderNo, UserID, CreateDate, EditDate  ");
            strSql.Append("  from UserBuyOrder ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            UserBuyOrder model = new UserBuyOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(ds.Tables[0].Rows[0]["EditDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus =(OrderStatus)Enum.Parse(typeof(OrderStatus),ds.Tables[0].Rows[0]["OrderStatus"].ToString(),false);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UserBuyOrder> GetUserBuyOrdersList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM UserBuyOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            List<UserBuyOrder> userBuyOrders = new List<UserBuyOrder>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                UserBuyOrder model = new UserBuyOrder();
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(ds.Tables[0].Rows[0]["EditDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus =
                        (OrderStatus)
                            Enum.Parse(typeof (OrderStatus), ds.Tables[0].Rows[0]["OrderStatus"].ToString(), false);
                }
                userBuyOrders.Add(model);
            }
            return userBuyOrders;
        }

        public UserBuyOrderPageModel GetBuyOrderPageModel(int userId)
        {
            string sql = "select u.OrderNo,u.UserID,a.ProductTitle,a.Price from UserBuyORder u right join AccountDescription a on u.OrderNo=a.OrderNo where u.UserID = @UserID";
            DataSet ds = DbHelperSQL.Query(sql, new SqlParameter[]
            {
                new SqlParameter("@UserID",userId), 
            });
            UserBuyOrderPageModel userBuyOrderPageModel = new UserBuyOrderPageModel();
            if (ds.Tables[0].Rows.Count <= 0)
            {
                return userBuyOrderPageModel;
            }
            if (ds.Tables[0].Rows[0]["OrderNo"].ToString() != "")
            {
                userBuyOrderPageModel.OrderNo = Convert.ToString(ds.Tables[0].Rows[0]["OrderNo"]);
            }
            if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
            {
                userBuyOrderPageModel.Price = Convert.ToDecimal(ds.Tables[0].Rows[0]["Price"]);
            }
            if (ds.Tables[0].Rows[0]["ProductTitle"].ToString() != "")
            {
                userBuyOrderPageModel.ProductTitle = Convert.ToString(ds.Tables[0].Rows[0]["ProductTitle"]);
            }
            return userBuyOrderPageModel;
        }

        /// <summary>
        /// 根据用户ID删除一条数据
        /// </summary>
        public bool Delete(int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserBuyOrder ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = userId;


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
    }
}
