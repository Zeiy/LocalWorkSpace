using System;
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
        /// 增加一条数据
        /// </summary>
        public int Add(AccountDescription model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AccountDescription(");
            strSql.Append("productImgAUrl,productImgBUrl,ProductImgCUrl,ProductImgDUrl,SubmitTime,OrderStatus,OrderNo,GameName,GameArea,ServerName,AccountInfoID,ProductProperty,ProductTitle,ProductDescription,Price");
            strSql.Append(") values (");
            strSql.Append("@productImgAUrl,@productImgBUrl,@ProductImgCUrl,@ProductImgDUrl,@SubmitTime,@OrderStatus,@OrderNo,@GameName,@GameArea,@ServerName,@AccountInfoID,@ProductProperty,@ProductTitle,@ProductDescription,@Price");
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
                        new SqlParameter("@Price", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.productImgAUrl;
            parameters[1].Value = model.productImgBUrl;
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
                new SqlParameter("@OrderBy",string.IsNullOrEmpty(orderStr)?"order by ID":orderStr), 
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
    }
}
