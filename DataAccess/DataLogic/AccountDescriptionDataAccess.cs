﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataAccess.Model;

namespace DataAccess.DataLogic
{
    public class AccountDescriptionDataAccess
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AccountDescription");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 检察订单是否存在
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public bool Exists(string orderNo)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AccountDescription");
            strSql.Append(" where ");
            strSql.Append(" OrderNo = @OrderNo  ");
            SqlParameter[] parameters = {
					new SqlParameter("@OrderNo", SqlDbType.VarChar,255)
			};
            parameters[0].Value = orderNo;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AccountDescription ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public List<AccountDescription> GetModelList(string where)
        {
            List<AccountDescription> list = new List<AccountDescription>();
            DataSet dataSet = GetList(where);
            DataTable dtTable = dataSet.Tables[0];
            foreach (DataRow dataRow in dtTable.Rows)
            {
                AccountDescription accountdescription = new AccountDescription();
                accountdescription.ID = Convert.ToInt32(dataRow["ID"]);
                accountdescription.OrderNo = Convert.ToString(dataRow["OrderNo"]);
                list.Add(accountdescription);
            }
            return list;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(AccountDescription model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AccountDescription(");
            strSql.Append("productImgAUrl,productImgBUrl,ProductImgCUrl,ProductImgDUrl,SubmitTime,OrderStatus,OrderNo,GameName,GameArea,ServerName,AccountInfoID,ProductProperty,ProductTitle,ProductDescription,Price,UserID,Remark,EditDate");
            strSql.Append(") values (");
            strSql.Append("@productImgAUrl,@productImgBUrl,@ProductImgCUrl,@ProductImgDUrl,@SubmitTime,@OrderStatus,@OrderNo,@GameName,@GameArea,@ServerName,@AccountInfoID,@ProductProperty,@ProductTitle,@ProductDescription,@Price,@UserID,@Remark,@EditDate");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@productImgAUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@productImgBUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@ProductImgCUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@ProductImgDUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SubmitTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@OrderStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrderNo", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@GameName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@GameArea", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@ServerName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@AccountInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductProperty", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@ProductTitle", SqlDbType.NChar,255) ,            
                        new SqlParameter("@ProductDescription", SqlDbType.NChar,255) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9)      ,
                        new SqlParameter("@UserID",SqlDbType.Int),
                        new SqlParameter("@Remark",SqlDbType.VarChar,500),
                        new SqlParameter("@EditDate",SqlDbType.DateTime), 
              
            };

            parameters[0].Value = model.ProductImgAUrl;
            parameters[1].Value = model.ProductImgBUrl;
            parameters[2].Value = model.ProductImgCUrl;
            parameters[3].Value = model.ProductImgDUrl;
            parameters[4].Value = model.SubmitTime;
            parameters[5].Value = model.OrderStatus;
            parameters[6].Value = model.OrderNo;
            parameters[7].Value = model.GameName;
            parameters[8].Value = model.GameArea;
            parameters[9].Value = model.ServerName;
            parameters[10].Value = model.AccountInfoID;
            parameters[11].Value = model.ProductProperty;
            parameters[12].Value = model.ProductTitle;
            parameters[13].Value = model.ProductDescription;
            parameters[14].Value = model.Price;
            parameters[15].Value = model.UserID;
            parameters[16].Value = model.Remark;
            parameters[17].Value = model.EditDate;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(AccountDescription model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AccountDescription set ");

            strSql.Append(" productImgAUrl = @productImgAUrl , ");
            strSql.Append(" productImgBUrl = @productImgBUrl , ");
            strSql.Append(" ProductImgCUrl = @ProductImgCUrl , ");
            strSql.Append(" ProductImgDUrl = @ProductImgDUrl , ");
            strSql.Append(" SubmitTime = @SubmitTime , ");
            strSql.Append(" OrderStatus = @OrderStatus , ");
            strSql.Append(" OrderNo = @OrderNo , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" EditDate = @EditDate , ");
            strSql.Append(" GameName = @GameName , ");
            strSql.Append(" EditUser = @EditUser , ");
            strSql.Append(" GameArea = @GameArea , ");
            strSql.Append(" ServerName = @ServerName , ");
            strSql.Append(" AccountInfoID = @AccountInfoID , ");
            strSql.Append(" ProductProperty = @ProductProperty , ");
            strSql.Append(" ProductTitle = @ProductTitle , ");
            strSql.Append(" ProductDescription = @ProductDescription , ");
            strSql.Append(" Price = @Price  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@productImgAUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@productImgBUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@ProductImgCUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@ProductImgDUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SubmitTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@OrderStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrderNo", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@EditDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@GameName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@EditUser", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GameArea", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ServerName", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@AccountInfoID", SqlDbType.Int,4) ,            
                        new SqlParameter("@ProductProperty", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@ProductTitle", SqlDbType.NChar,255) ,            
                        new SqlParameter("@ProductDescription", SqlDbType.NChar,255) ,            
                        new SqlParameter("@Price", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.ProductImgAUrl;
            parameters[2].Value = model.ProductImgBUrl;
            parameters[3].Value = model.ProductImgCUrl;
            parameters[4].Value = model.ProductImgDUrl;
            parameters[5].Value = model.SubmitTime;
            parameters[6].Value = model.OrderStatus;
            parameters[7].Value = model.OrderNo;
            parameters[8].Value = model.UserID;
            parameters[9].Value = model.Remark;
            parameters[10].Value = model.EditDate;
            parameters[11].Value = model.GameName;
            parameters[12].Value = model.EditUser;
            parameters[13].Value = model.GameArea;
            parameters[14].Value = model.ServerName;
            parameters[15].Value = model.AccountInfoID;
            parameters[16].Value = model.ProductProperty;
            parameters[17].Value = model.ProductTitle;
            parameters[18].Value = model.ProductDescription;
            parameters[19].Value = model.Price;
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

        public List<AccountDescription> GetPagedAccountDescriptionsModelsByProc(int pageIndex, int pageSize, string whereStr,string orderStr, out int rowCount,
          out int pageCount)
        {
            List<AccountDescription> modelsList = new List<AccountDescription>();
            rowCount = 0;
            pageCount = 0;
            IDataParameter[] sqlParameters =
            {
                new SqlParameter("@TableName","AccountDescription"), 
                new SqlParameter("@IDName","ID"), 
                new SqlParameter("@PageIndex",pageIndex), 
                new SqlParameter("@PageSize",pageSize),
                new SqlParameter("@Where",string.IsNullOrEmpty(whereStr)?"":whereStr), 
                new SqlParameter("@OrderBy",string.IsNullOrEmpty(orderStr)?"order by ID":"order by "+orderStr), 
                new SqlParameter("@RowCount",SqlDbType.Int,25), 
                new SqlParameter("@PageCount",SqlDbType.Int,25), 
            };
            sqlParameters[6].Direction =ParameterDirection.Output;
            sqlParameters[6].Value = DBNull.Value;
            sqlParameters[7].Direction = ParameterDirection.Output;
            sqlParameters[7].Value = DBNull.Value;
          
            //SqlDataReader dataReader = DbHelperSQL.RunProcedure("sp_GetPageDataOutRowPageCount", sqlParameters);
            using (SqlConnection connection = new SqlConnection(DbHelperSQL.connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = connection;
                cmd.Parameters.AddRange(sqlParameters);
                cmd.CommandText = "sp_GetPageDataOutRowPageCount";
                SqlDataReader dataReader = cmd.ExecuteReader();
                using (dataReader)
                {
                    while (dataReader.Read())
                    {
                        AccountDescription infoModel = new AccountDescription();

                        infoModel.ID = Convert.ToInt32(dataReader["ID"]);
                        infoModel.SubmitTime =
                            Convert.ToDateTime(Convert.IsDBNull(dataReader["SubmitTime"])
                                ? DateTime.MinValue
                                : dataReader["SubmitTime"]);
                        infoModel.ProductTitle = Convert.ToString(dataReader["ProductTitle"]);
                        infoModel.ProductProperty = Convert.ToString(dataReader["ProductProperty"]);
                        infoModel.Price = Convert.ToDecimal(dataReader["Price"]);
                        infoModel.AccountInfoID = Convert.ToInt32(dataReader["AccountInfoID"]);
                        infoModel.ServerName = Convert.ToString(dataReader["ServerName"]);
                        infoModel.GameName = Convert.ToString(dataReader["GameName"]);
                        infoModel.GameArea = Convert.ToString(dataReader["GameArea"]);
                        infoModel.OrderNo = Convert.ToString(dataReader["OrderNo"]);
                        infoModel.OrderStatus = (OrderStatus) dataReader["OrderStatus"];
                        infoModel.UserID =Convert.IsDBNull(dataReader["UserID"])?0:Convert.ToInt32(dataReader["UserID"]);
                        infoModel.Remark = Convert.IsDBNull(dataReader["Remark"])
                            ? ""
                            : Convert.ToString(dataReader["Remark"]);
                        modelsList.Add(infoModel);
                    }
                }
                //只有在DataReader关闭后才能拿到输出参数！重要，重要
                rowCount = Convert.ToInt32(cmd.Parameters["@RowCount"].Value);
                pageCount = Convert.ToInt32(cmd.Parameters["@PageCount"].Value);
            }
            return modelsList;
        }

        public List<AccountDescription> GetPagedAccountDescriptionsModelsByProc(int pageIndex, int pageSize, string whereStr)
        {
            int rowCount = 0;
            int pageCount = 0;
            return GetPagedAccountDescriptionsModelsByProc(pageIndex, pageSize, whereStr,null, out rowCount, out pageCount);
        }

        public AccountDescription GetAccountDescriptionByAccountInfoID(int accountInfoID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, productImgAUrl, productImgBUrl, ProductImgCUrl, ProductImgDUrl, SubmitTime, OrderStatus, OrderNo, GameName, GameArea, ServerName, AccountInfoID, ProductProperty, ProductTitle, ProductDescription, Price,UserID  ");
            strSql.Append("  from AccountDescription ");
            strSql.Append(" where AccountInfoID=@accountInfoID");
            SqlParameter[] parameters = {
					new SqlParameter("@AccountInfoID", SqlDbType.Int,4)
			};
            parameters[0].Value = accountInfoID;


            AccountDescription model = new AccountDescription();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ProductImgAUrl = ds.Tables[0].Rows[0]["productImgAUrl"].ToString();
                model.ProductImgBUrl = ds.Tables[0].Rows[0]["productImgBUrl"].ToString();
                model.ProductImgCUrl = ds.Tables[0].Rows[0]["ProductImgCUrl"].ToString();
                model.ProductImgDUrl = ds.Tables[0].Rows[0]["ProductImgDUrl"].ToString();
                if (ds.Tables[0].Rows[0]["SubmitTime"].ToString() != "")
                {
                    model.SubmitTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubmitTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), ds.Tables[0].Rows[0]["OrderStatus"].ToString(), true);
                }
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                model.GameName = ds.Tables[0].Rows[0]["GameName"].ToString();
                model.GameArea = ds.Tables[0].Rows[0]["GameArea"].ToString();
                model.ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
                if (ds.Tables[0].Rows[0]["AccountInfoID"].ToString() != "")
                {
                    model.AccountInfoID = int.Parse(ds.Tables[0].Rows[0]["AccountInfoID"].ToString());
                }
                model.ProductProperty = ds.Tables[0].Rows[0]["ProductProperty"].ToString();
                model.ProductTitle = ds.Tables[0].Rows[0]["ProductTitle"].ToString();
                model.ProductDescription = ds.Tables[0].Rows[0]["ProductDescription"].ToString();
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                model.UserID = Convert.IsDBNull(ds.Tables[0].Rows[0]["UserID"]) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public AccountDescription GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, productImgAUrl, productImgBUrl, ProductImgCUrl, ProductImgDUrl, SubmitTime, OrderStatus, OrderNo, GameName, GameArea, ServerName, AccountInfoID, ProductProperty, ProductTitle, ProductDescription, Price,UserID,Remark,EditDate,EditUser ");
            strSql.Append("  from AccountDescription ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


             AccountDescription model = new  AccountDescription();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ProductImgAUrl = ds.Tables[0].Rows[0]["productImgAUrl"].ToString();
                model.ProductImgBUrl = ds.Tables[0].Rows[0]["productImgBUrl"].ToString();
                model.ProductImgCUrl = ds.Tables[0].Rows[0]["ProductImgCUrl"].ToString();
                model.ProductImgDUrl = ds.Tables[0].Rows[0]["ProductImgDUrl"].ToString();
                if (ds.Tables[0].Rows[0]["SubmitTime"].ToString() != "")
                {
                    model.SubmitTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubmitTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus),ds.Tables[0].Rows[0]["OrderStatus"].ToString(),true);
                }
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                model.GameName = ds.Tables[0].Rows[0]["GameName"].ToString();
                model.GameArea = ds.Tables[0].Rows[0]["GameArea"].ToString();
                model.ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
                if (ds.Tables[0].Rows[0]["AccountInfoID"].ToString() != "")
                {
                    model.AccountInfoID = int.Parse(ds.Tables[0].Rows[0]["AccountInfoID"].ToString());
                }
                model.ProductProperty = ds.Tables[0].Rows[0]["ProductProperty"].ToString();
                model.ProductTitle = ds.Tables[0].Rows[0]["ProductTitle"].ToString();
                model.ProductDescription = ds.Tables[0].Rows[0]["ProductDescription"].ToString();
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                model.UserID = Convert.IsDBNull(ds.Tables[0].Rows[0]["UserID"]) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                model.EditDate = Convert.IsDBNull(ds.Tables[0].Rows[0]["EditDate"])
                    ? DateTime.MinValue
                    : Convert.ToDateTime(ds.Tables[0].Rows[0]["EditDate"]);
                model.Remark = Convert.IsDBNull(ds.Tables[0].Rows[0]["Remark"])
                    ? ""
                    : Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                model.EditUser = Convert.IsDBNull(ds.Tables[0].Rows[0]["EditUser"])
                    ? ""
                    : Convert.ToString(ds.Tables[0].Rows[0]["EditUser"]);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据AccountInfoID 拿到 AccountDescription
        /// </summary>
        /// <param name="accountInfoId"></param>
        /// <returns></returns>
        public AccountDescription GetModelByAccountInfoId(int accountInfoId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, productImgAUrl, productImgBUrl, ProductImgCUrl, ProductImgDUrl, SubmitTime, OrderStatus, OrderNo, GameName, GameArea, ServerName, AccountInfoID, ProductProperty, ProductTitle, ProductDescription, Price,UserID,Remark,EditDate,EditUser ");
            strSql.Append("  from AccountDescription ");
            strSql.Append(" where AccountInfoID=@AccountInfoID");
            SqlParameter[] parameters = {
					new SqlParameter("@AccountInfoID", SqlDbType.Int,4)
			};
            parameters[0].Value = accountInfoId;


            AccountDescription model = new AccountDescription();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.ProductImgAUrl = ds.Tables[0].Rows[0]["productImgAUrl"].ToString();
                model.ProductImgBUrl = ds.Tables[0].Rows[0]["productImgBUrl"].ToString();
                model.ProductImgCUrl = ds.Tables[0].Rows[0]["ProductImgCUrl"].ToString();
                model.ProductImgDUrl = ds.Tables[0].Rows[0]["ProductImgDUrl"].ToString();
                if (ds.Tables[0].Rows[0]["SubmitTime"].ToString() != "")
                {
                    model.SubmitTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubmitTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = (OrderStatus)Enum.Parse(typeof(OrderStatus), ds.Tables[0].Rows[0]["OrderStatus"].ToString(), true);
                }
                model.OrderNo = ds.Tables[0].Rows[0]["OrderNo"].ToString();
                model.GameName = ds.Tables[0].Rows[0]["GameName"].ToString();
                model.GameArea = ds.Tables[0].Rows[0]["GameArea"].ToString();
                model.ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
                if (ds.Tables[0].Rows[0]["AccountInfoID"].ToString() != "")
                {
                    model.AccountInfoID = int.Parse(ds.Tables[0].Rows[0]["AccountInfoID"].ToString());
                }
                model.ProductProperty = ds.Tables[0].Rows[0]["ProductProperty"].ToString();
                model.ProductTitle = ds.Tables[0].Rows[0]["ProductTitle"].ToString();
                model.ProductDescription = ds.Tables[0].Rows[0]["ProductDescription"].ToString();
                model.UserID = Convert.IsDBNull(ds.Tables[0].Rows[0]["UserID"]) ? 0 : Convert.ToInt32(ds.Tables[0].Rows[0]["UserID"]);
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = Convert.ToString(ds.Tables[0].Rows[0]["Remark"]);
                }
                if (ds.Tables[0].Rows[0]["EditUser"].ToString() != "")
                {
                    model.EditUser = Convert.ToString(ds.Tables[0].Rows[0]["EditUser"]);
                }
                if (ds.Tables[0].Rows[0]["EditDate"].ToString() != "")
                {
                    model.EditDate = DateTime.Parse(ds.Tables[0].Rows[0]["EditDate"].ToString());
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
