using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using DataAccess;
using DataAccess.Model;

namespace _77Trade.Logic
{
    public class UserOrderLogic
    {
        /// <summary>
        /// 生成用户订单
        /// </summary>
        /// <param name="productOrderNo">商品订单号</param>
        /// <param name="userId">当前用户ID</param>
        /// <param name="accountInfoId">订单主表的DI</param>
        /// <returns>0表示失败</returns>
        public int GeneralUserOrder(string productOrderNo,int userId,int accountInfoId)
        {
            //同时修改两个表的OrderStatuso 为7 待付款   写入订单表
            var str1 = "update AccountInfo set OrderStatus = 7 where OrderStatus =5 and ID =" + accountInfoId;
            var str2 = "update AccountDescription set OrderStatus = 7 where OrderStatus =5 and OrderNo = '"+productOrderNo+"'";
            var str3 = "insert into UserBuyOrder (OrderNo,UserID,CreateDate,EditDate) values ('"+productOrderNo+"',"+userId+",'"+DateTime.Now.ToString()+"','"+DateTime.Now.ToString()+"') ;select @@IDENTITY;";
            using (SqlConnection connection=new SqlConnection(DbHelperSQL.connectionString))
            {
                connection.Open();
                using (SqlTransaction sqlTransaction =connection.BeginTransaction() )
                {
                    
                    SqlCommand cmd = connection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = str1;
                    cmd.Transaction = sqlTransaction;
                    int res = cmd.ExecuteNonQuery();
                    if (res != 1)
                    {
                        sqlTransaction.Rollback();
                        return 0;
                    }
                    cmd.CommandText = str2;
                    int res2 = cmd.ExecuteNonQuery();
                    if (res2 != 1)
                    {
                        sqlTransaction.Rollback();
                        return 0;
                    }
                    cmd.CommandText = str3;
                    var res3 =Convert.ToInt32(cmd.ExecuteScalar());
                    if (res3 <=0)
                    {
                        sqlTransaction.Rollback();
                        return 0;
                    }
                    sqlTransaction.Commit();
                    return 1;
                }
            }
            return 3;
        }

        /// <summary>
        /// 根据infoID跟descriptionID改变两个表的订单状态
        /// </summary>
        /// <param name="infoId"></param>
        /// <param name="descriptionId"></param>
        /// <param name="orginOrderStatus">原订单状态</param>
        /// <param name="newOrderStatus">新的订单状态</param>
        /// <returns>1表示修改成功</returns>
        public bool ChangeAccountStatus(int infoId, int descriptionId,OrderStatus orginOrderStatus,OrderStatus newOrderStatus)
        {
            int orginStatuseInt = Convert.ToInt32(orginOrderStatus);
            int newStatusInt = Convert.ToInt32(newOrderStatus);
            string sql1 = "update AccountInfo set OrderStatus =" + newStatusInt + " where ID = " + infoId + " and OrderStatus = " + orginStatuseInt;
            string sql2 = "update AccountDescription set OrderStatus =" + newStatusInt + " where ID =" + descriptionId +
                          " and OrderStatus = " + orginStatuseInt;
            var sqlList = new List<string> {sql1, sql2};
            var result = DbHelperSQL.ExecuteSqlTran(sqlList);
            if (result == 2)
            {
                return true;
            }
            return true;
        }
    }
}