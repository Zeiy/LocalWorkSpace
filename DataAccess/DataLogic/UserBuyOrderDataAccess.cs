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
        /// 检察用户是否存在相应状态的订单
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="orderStatus">订单状态</param>
        /// <returns></returns>
        public bool ExistsByUserIdAndOrderStatus(int userId, OrderStatus orderStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserBuyOrder");
            strSql.Append(" where ");
            strSql.Append(" UserID = @UserID and OrderStatus = @OrderStatus ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@OrderStatus",SqlDbType.Int), 
			};
            parameters[0].Value = userId;
            parameters[1].Value = Convert.ToInt32(orderStatus);
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检察用户是否有符合状态的ID
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="orderStatus"></param>
        /// <returns></returns>
        public bool ExistsByUserIdAndStatus(int userId, OrderStatus orderStatus)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from UserBuyOrder");
            strSql.Append(" where ");
            strSql.Append(" UserID = @UserID and OrderStatus = " + Convert.ToInt32(orderStatus));
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
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
            strSql.Append("select ID, Email, ShenFenID, OrderNo, UserID, CreateDate, EditDate, OrderStatus, UserName, Mobile, Address  ");
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
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.ShenFenID = ds.Tables[0].Rows[0]["ShenFenID"].ToString();
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
                    model.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), ds.Tables[0].Rows[0]["OrderStatus"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.Address = ds.Tables[0].Rows[0]["Address"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(UserBuyOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update UserBuyOrder set ");

            strSql.Append(" Email = @Email , ");
            strSql.Append(" ShenFenID = @ShenFenID , ");
            strSql.Append(" OrderNo = @OrderNo , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" OrderStatus = @OrderStatus , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" Address = @Address  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Email", SqlDbType.NChar,30) ,            
                        new SqlParameter("@ShenFenID", SqlDbType.NChar,30) ,            
                        new SqlParameter("@OrderNo", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@EditDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@OrderStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserName", SqlDbType.NChar,50) ,            
                        new SqlParameter("@Mobile", SqlDbType.NChar,20) ,            
                        new SqlParameter("@Address", SqlDbType.NChar,50)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.Email;
            parameters[2].Value = model.ShenFenID;
            parameters[3].Value = model.OrderNo;
            parameters[4].Value = model.UserID;
            parameters[5].Value = model.CreateDate;
            parameters[6].Value = DateTime.Now;
            parameters[7].Value = (int)model.OrderStatus;
            parameters[8].Value = model.UserName;
            parameters[9].Value = model.Mobile;
            parameters[10].Value = model.Address;
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
        /// 根据当前用户ID得到一个对象实体
        /// </summary>
        public UserBuyOrder GetModelByUserId(int userId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, OrderNo, UserID,OrderStatus, CreateDate, EditDate  ");
            strSql.Append("  from UserBuyOrder ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4)
			};
            parameters[0].Value = userId;


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
                    model.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), ds.Tables[0].Rows[0]["OrderStatus"].ToString(), false);
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
                            Enum.Parse(typeof(OrderStatus), ds.Tables[0].Rows[0]["OrderStatus"].ToString(), false);
                }
                userBuyOrders.Add(model);
            }
            return userBuyOrders;
        }

        public List<UserBuyOrderPageModel> GetBuyOrderPageModel(int userId, OrderStatus? orderStatus)
        {
            string sql;
            DataSet ds;
            if (orderStatus != null)
            {
                sql =
                    "select u.OrderNo,u.UserID,a.ProductTitle,a.Price,a.productImgAUrl,a.ID,a.AccountInfoID,u.OrderStatus,a.EditDate from UserBuyORder u right join AccountDescription a on u.OrderNo=a.OrderNo where u.UserID = @UserID and u.OrderStatus=@OrderStatus";
             ds = DbHelperSQL.Query(sql, new SqlParameter[]
            {
                new SqlParameter("@UserID",userId), new SqlParameter("@OrderStatus",Convert.ToInt32(orderStatus)), 
            });
            }
            else
            {
                sql = "select u.OrderNo,u.UserID,a.ProductTitle,a.Price,a.productImgAUrl,a.ID,a.AccountInfoID,u.OrderStatus,a.EditDate from UserBuyORder u right join AccountDescription a on u.OrderNo=a.OrderNo where u.UserID = @UserID";
             ds = DbHelperSQL.Query(sql, new SqlParameter[]
            {
                new SqlParameter("@UserID",userId), 
            });
            }
            List<UserBuyOrderPageModel> userBuyOrderPageModelList =new List<UserBuyOrderPageModel>();
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                UserBuyOrderPageModel userBuyOrderPageModel = new UserBuyOrderPageModel();
                if (dataRow["OrderNo"].ToString() != "")
                {
                    userBuyOrderPageModel.OrderNo = Convert.ToString(dataRow["OrderNo"]);
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    userBuyOrderPageModel.Price = Convert.ToDecimal(dataRow["Price"]);
                }
                if (dataRow["ProductTitle"].ToString() != "")
                {
                    userBuyOrderPageModel.ProductTitle = Convert.ToString(dataRow["ProductTitle"]);
                }
                if (dataRow["productImgAUrl"].ToString() != "")
                {
                    userBuyOrderPageModel.ProductImgAUrl = Convert.ToString(dataRow["productImgAUrl"]);
                }
                if (dataRow["ID"].ToString() != "")
                {
                    userBuyOrderPageModel.AccountDescriptionID = Convert.ToInt32(dataRow["ID"]);
                }
                if (dataRow["AccountInfoID"].ToString() != "")
                {
                    userBuyOrderPageModel.AccountInfoID = Convert.ToInt32(dataRow["AccountInfoID"]);
                }
                if (dataRow["OrderStatus"].ToString() != "")
                {
                    userBuyOrderPageModel.OrderStatus = (OrderStatus)Convert.ToInt32(dataRow["OrderStatus"]);
                }
                if (dataRow["EditDate"].ToString() != "")
                {
                    userBuyOrderPageModel.EditDate = Convert.ToDateTime(dataRow["EditDate"]);
                }
                userBuyOrderPageModelList.Add(userBuyOrderPageModel);
            }
           
            return userBuyOrderPageModelList;
        }

        /// <summary>
        /// 根据用户ID删除一条数据
        /// </summary>
        public bool Delete(int userId,OrderStatus orderStatus)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from UserBuyOrder ");
            strSql.Append(" where UserID=@UserID and OrderStatus=@OrderStatus");
            SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.Int,4),
                    new SqlParameter("@OrderStatus",SqlDbType.Int), 
			};
            parameters[0].Value = userId;
            parameters[1].Value = Convert.ToInt32(orderStatus);

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
