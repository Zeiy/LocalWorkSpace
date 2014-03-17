using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.DataLogic
{
    public class AccountInfoDataAccess
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM AccountInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 拿到所有数据
        /// </summary>
        /// <returns></returns>
        public List<AccountInfoModel> GetAllData()
        {
            List<AccountInfoModel> listMode = new List<AccountInfoModel>();
            DataSet ds = GetList("");
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                AccountInfoModel mode = new AccountInfoModel();
                mode.ID = Convert.ToInt32(dr["ID"]);
                mode.GameName = Convert.ToString(dr["GameName"]);
                mode.GameArea = Convert.ToString(dr["GameArea"]);
                mode.ServerName = Convert.ToString(dr["ServerName"]);
                mode.AccountRoleName = Convert.ToString(dr["AccountRoleName"]);
                mode.SubmitTime = Convert.ToDateTime(Convert.IsDBNull(dr["SubmitTime"]) ? DateTime.MinValue : dr["SubmitTime"]);
                mode.OrderStatus = (OrderStatus)dr["OrderStatus"];
                listMode.Add(mode);
            }
            return listMode;

        }
        /// <summary>
        /// 根据ID拿到订单Model
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public  AccountInfoModel GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, QQMobile, Email, LevelTwoPwd, PropertyPwd, SecretCardBind, SecretCardNo, SecretCardImgUrl, IdentityAuth, IdentityCardAUrl, IdentityCardBUrl, UserID, OrderStatus, SubmitTime, GameName, GameArea, ServerName, GameAccount, GamePassword, AccountRoleName, IdCardNo  ");
            strSql.Append("  from AccountInfo ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


            AccountInfoModel model = new AccountInfoModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.QQMobile = ds.Tables[0].Rows[0]["QQMobile"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.LevelTwoPwd = ds.Tables[0].Rows[0]["LevelTwoPwd"].ToString();
                model.PropertyPwd = ds.Tables[0].Rows[0]["PropertyPwd"].ToString();
                if (ds.Tables[0].Rows[0]["SecretCardBind"].ToString() != "")
                {
                    model.SecretCardBind =Convert.ToBoolean(ds.Tables[0].Rows[0]["SecretCardBind"]);
                }
                model.SecretCardNo = ds.Tables[0].Rows[0]["SecretCardNo"].ToString();
                model.SecretCardImgUrl = ds.Tables[0].Rows[0]["SecretCardImgUrl"].ToString();
                if (ds.Tables[0].Rows[0]["IdentityAuth"].ToString() != "")
                {
                    model.IdentityAuth = Convert.ToBoolean(ds.Tables[0].Rows[0]["IdentityAuth"]);
                }
                model.IdentityCardAUrl = ds.Tables[0].Rows[0]["IdentityCardAUrl"].ToString();
                model.IdentityCardBUrl = ds.Tables[0].Rows[0]["IdentityCardBUrl"].ToString();
                if (ds.Tables[0].Rows[0]["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderStatus"].ToString() != "")
                {
                    model.OrderStatus = (OrderStatus)(int.Parse(ds.Tables[0].Rows[0]["OrderStatus"].ToString()));
                }
                if (ds.Tables[0].Rows[0]["SubmitTime"].ToString() != "")
                {
                    model.SubmitTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubmitTime"].ToString());
                }
                model.GameName = ds.Tables[0].Rows[0]["GameName"].ToString();
                model.GameArea = ds.Tables[0].Rows[0]["GameArea"].ToString();
                model.ServerName = ds.Tables[0].Rows[0]["ServerName"].ToString();
                model.GameAccount = ds.Tables[0].Rows[0]["GameAccount"].ToString();
                model.GamePassword = ds.Tables[0].Rows[0]["GamePassword"].ToString();
                model.AccountRoleName = ds.Tables[0].Rows[0]["AccountRoleName"].ToString();
                model.IdCardNo = ds.Tables[0].Rows[0]["IdCardNo"].ToString();

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
        public bool Update(AccountInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AccountInfo set ");

            strSql.Append(" QQMobile = @QQMobile , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" LevelTwoPwd = @LevelTwoPwd , ");
            strSql.Append(" PropertyPwd = @PropertyPwd , ");
            strSql.Append(" SecretCardBind = @SecretCardBind , ");
            strSql.Append(" SecretCardNo = @SecretCardNo , ");
            strSql.Append(" SecretCardImgUrl = @SecretCardImgUrl , ");
            strSql.Append(" IdentityAuth = @IdentityAuth , ");
            strSql.Append(" IdentityCardAUrl = @IdentityCardAUrl , ");
            strSql.Append(" IdentityCardBUrl = @IdentityCardBUrl , ");
            strSql.Append(" UserID = @UserID , ");
            strSql.Append(" OrderStatus = @OrderStatus , ");
            strSql.Append(" SubmitTime = @SubmitTime , ");
            strSql.Append(" GameName = @GameName , ");
            strSql.Append(" GameArea = @GameArea , ");
            strSql.Append(" ServerName = @ServerName , ");
            strSql.Append(" GameAccount = @GameAccount , ");
            strSql.Append(" GamePassword = @GamePassword , ");
            strSql.Append(" AccountRoleName = @AccountRoleName , ");
            strSql.Append(" IdCardNo = @IdCardNo  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@QQMobile", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@LevelTwoPwd", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@PropertyPwd", SqlDbType.NChar,255) ,            
                        new SqlParameter("@SecretCardBind", SqlDbType.Int,4) ,            
                        new SqlParameter("@SecretCardNo", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SecretCardImgUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@IdentityAuth", SqlDbType.Int,4) ,            
                        new SqlParameter("@IdentityCardAUrl", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@IdentityCardBUrl", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrderStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@SubmitTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@GameName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@GameArea", SqlDbType.NChar,255) ,            
                        new SqlParameter("@ServerName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@GameAccount", SqlDbType.NChar,255) ,            
                        new SqlParameter("@GamePassword", SqlDbType.NChar,255) ,            
                        new SqlParameter("@AccountRoleName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@IdCardNo", SqlDbType.NChar,255)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.QQMobile;
            parameters[2].Value = model.Email;
            parameters[3].Value = model.LevelTwoPwd;
            parameters[4].Value = model.PropertyPwd;
            parameters[5].Value = model.SecretCardBind;
            parameters[6].Value = model.SecretCardNo;
            parameters[7].Value = model.SecretCardImgUrl;
            parameters[8].Value = model.IdentityAuth;
            parameters[9].Value = model.IdentityCardAUrl;
            parameters[10].Value = model.IdentityCardBUrl;
            parameters[11].Value = model.UserID;
            parameters[12].Value = model.OrderStatus;
            parameters[13].Value = model.SubmitTime;
            parameters[14].Value = model.GameName;
            parameters[15].Value = model.GameArea;
            parameters[16].Value = model.ServerName;
            parameters[17].Value = model.GameAccount;
            parameters[18].Value = model.GamePassword;
            parameters[19].Value = model.AccountRoleName;
            parameters[20].Value = model.IdCardNo;
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
        /// 增加一条数据
        /// </summary>
        public int Add(AccountInfoModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AccountInfo(");
            strSql.Append("QQMobile,Email,LevelTwoPwd,PropertyPwd,SecretCardBind,SecretCardNo,SecretCardImgUrl,IdentityAuth,IdentityCardAUrl,IdentityCardBUrl,UserID,OrderStatus,SubmitTime,GameName,GameArea,ServerName,GameAccount,GamePassword,AccountRoleName,IdCardNo");
            strSql.Append(") values (");
            strSql.Append("@QQMobile,@Email,@LevelTwoPwd,@PropertyPwd,@SecretCardBind,@SecretCardNo,@SecretCardImgUrl,@IdentityAuth,@IdentityCardAUrl,@IdentityCardBUrl,@UserID,@OrderStatus,@SubmitTime,@GameName,@GameArea,@ServerName,@GameAccount,@GamePassword,@AccountRoleName,@IdCardNo");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@QQMobile", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@LevelTwoPwd", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@PropertyPwd", SqlDbType.NChar,255) ,            
                        new SqlParameter("@SecretCardBind", SqlDbType.Int,4) ,            
                        new SqlParameter("@SecretCardNo", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SecretCardImgUrl", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@IdentityAuth", SqlDbType.Int,4) ,            
                        new SqlParameter("@IdentityCardAUrl", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@IdentityCardBUrl", SqlDbType.NVarChar,255) ,            
                        new SqlParameter("@UserID", SqlDbType.Int,4) ,            
                        new SqlParameter("@OrderStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@SubmitTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@GameName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@GameArea", SqlDbType.NChar,255) ,            
                        new SqlParameter("@ServerName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@GameAccount", SqlDbType.NChar,255) ,            
                        new SqlParameter("@GamePassword", SqlDbType.NChar,255) ,            
                        new SqlParameter("@AccountRoleName", SqlDbType.NChar,255) ,            
                        new SqlParameter("@IdCardNo", SqlDbType.NChar,255)             
              
            };

            parameters[0].Value = model.QQMobile;
            parameters[1].Value = model.Email;
            parameters[2].Value = model.LevelTwoPwd;
            parameters[3].Value = model.PropertyPwd;
            parameters[4].Value = model.SecretCardBind;
            parameters[5].Value = model.SecretCardNo;
            parameters[6].Value = model.SecretCardImgUrl;
            parameters[7].Value = model.IdentityAuth;
            parameters[8].Value = model.IdentityCardAUrl;
            parameters[9].Value = model.IdentityCardBUrl;
            parameters[10].Value = model.UserID;
            parameters[11].Value = model.OrderStatus;
            parameters[12].Value = model.SubmitTime;
            parameters[13].Value = model.GameName;
            parameters[14].Value = model.GameArea;
            parameters[15].Value = model.ServerName;
            parameters[16].Value = model.GameAccount;
            parameters[17].Value = model.GamePassword;
            parameters[18].Value = model.AccountRoleName;
            parameters[19].Value = model.IdCardNo;

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

        public List<AccountInfoModel> GetPagedAccountInfoModelsByProc(int pageIndex, int pageSize,string whereStr, out int rowCount,
            out int pageCount)
        {
            List<AccountInfoModel> modelsList = new List<AccountInfoModel>();
                rowCount = 0;
            pageCount = 0;
            IDataParameter[] sqlParameters =
            {
                new SqlParameter("TableName","AccountInfo"), 
                new SqlParameter("IDName","ID"), 
                new SqlParameter("PageIndex",pageIndex), 
                new SqlParameter("PageSize",pageSize),
                new SqlParameter("Where",whereStr), 
                new SqlParameter("OrderBy",""), 
                new SqlParameter("RowCount",rowCount), 
                new SqlParameter("PageCount",pageCount), 
            };
            SqlDataReader dataReader = DbHelperSQL.RunProcedure("sp_GetPageDataOutRowPageCount", sqlParameters);
            using (dataReader)
            {
                while (dataReader.Read())
                {
                    AccountInfoModel infoModel = new AccountInfoModel();
                    
                    infoModel.ID = Convert.ToInt32(dataReader["ID"]);
                    infoModel.SubmitTime = Convert.ToDateTime(Convert.IsDBNull(dataReader["SubmitTime"]) ? DateTime.MinValue : dataReader["SubmitTime"]);
                    infoModel.GameArea = Convert.ToString(dataReader["GameArea"]);
                    infoModel.GameName = Convert.ToString(dataReader["GameName"]);
                    infoModel.ServerName = Convert.ToString(dataReader["ServerName"]);
                    modelsList.Add(infoModel);
                }
            }
            return modelsList;
        }

        public List<AccountInfoModel> GetPagedAccountInfoModelsByProc(int pageIndex, int pageSize, string whereStr)
        {
            int rowCount = 0;
            int pageCount = 0;
            return GetPagedAccountInfoModelsByProc(pageIndex, pageSize, "", out rowCount, out pageCount);

        }
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AccountInfo");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
    }
}
