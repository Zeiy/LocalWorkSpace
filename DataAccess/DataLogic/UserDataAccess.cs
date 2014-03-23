using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DataAccess.Model;

namespace DataAccess.DataLogic
{
    public class UserDataAccess
    {
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from User");
            strSql.Append(" where ");
            strSql.Append(" ID = @ID  ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public bool CheckExistByUserName(string userName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FrontUser");
            strSql.Append(" where ");
            strSql.Append(" UserName = @UserName  ");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,255)
			};
            parameters[0].Value = userName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add( FrontUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FrontUser(");
            strSql.Append("UserStatus,CreateDate,Account,UserName,Password,PayPassword,SecretQuestion,SecretAnswer,Email,Mobile,UserRoleName");
            strSql.Append(") values (");
            strSql.Append("@UserStatus,@CreateDate,@Account,@UserName,@Password,@PayPassword,@SecretQuestion,@SecretAnswer,@Email,@Mobile,@UserRoleName");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@UserStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Account", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Password", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@PayPassword", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SecretQuestion", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SecretAnswer", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Mobile", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@UserRoleName", SqlDbType.VarChar,255)             
              
            };

            parameters[0].Value = model.UserStatus;
            parameters[1].Value = DateTime.Now;
            parameters[2].Value = model.Account;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.Password;
            parameters[5].Value = model.PayPassword;
            parameters[6].Value = model.SecretQuestion;
            parameters[7].Value = model.SecretAnswer;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.Mobile;
            parameters[10].Value = model.UserRoleName;

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
        public bool Update( FrontUser model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update User set ");

            strSql.Append(" UserStatus = @UserStatus , ");
            strSql.Append(" CreateDate = @CreateDate , ");
            strSql.Append(" Account = @Account , ");
            strSql.Append(" UserName = @UserName , ");
            strSql.Append(" Password = @Password , ");
            strSql.Append(" PayPassword = @PayPassword , ");
            strSql.Append(" SecretQuestion = @SecretQuestion , ");
            strSql.Append(" SecretAnswer = @SecretAnswer , ");
            strSql.Append(" Email = @Email , ");
            strSql.Append(" Mobile = @Mobile , ");
            strSql.Append(" UserRoleName = @UserRoleName  ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ID", SqlDbType.Int,4) ,            
                        new SqlParameter("@UserStatus", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@Account", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Password", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@PayPassword", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SecretQuestion", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@SecretAnswer", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Email", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@Mobile", SqlDbType.VarChar,255) ,            
                        new SqlParameter("@UserRoleName", SqlDbType.VarChar,255)             
              
            };

            parameters[0].Value = model.ID;
            parameters[1].Value = model.UserStatus;
            parameters[2].Value = model.CreateDate;
            parameters[3].Value = model.Account;
            parameters[4].Value = model.UserName;
            parameters[5].Value = model.Password;
            parameters[6].Value = model.PayPassword;
            parameters[7].Value = model.SecretQuestion;
            parameters[8].Value = model.SecretAnswer;
            parameters[9].Value = model.Email;
            parameters[10].Value = model.Mobile;
            parameters[11].Value = model.UserRoleName;
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User ");
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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from User ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public  FrontUser GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, UserStatus, CreateDate, Account, UserName, Password, PayPassword, SecretQuestion, SecretAnswer, Email, Mobile, UserRoleName  ");
            strSql.Append("  from User ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;


             FrontUser model = new  Model.FrontUser();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserStatus"].ToString() != "")
                {
                    model.UserStatus = (UserStatus)Enum.Parse(typeof(UserStatus),ds.Tables[0].Rows[0]["UserStatus"].ToString(),false);
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Account"].ToString() != "")
                {
                    model.Account = decimal.Parse(ds.Tables[0].Rows[0]["Account"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.PayPassword = ds.Tables[0].Rows[0]["PayPassword"].ToString();
                model.SecretQuestion = ds.Tables[0].Rows[0]["SecretQuestion"].ToString();
                model.SecretAnswer = ds.Tables[0].Rows[0]["SecretAnswer"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.UserRoleName = ds.Tables[0].Rows[0]["UserRoleName"].ToString();

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
        public FrontUser GetFrontUserByUserName(string userName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID, UserStatus, CreateDate, Account, UserName, Password, PayPassword, SecretQuestion, SecretAnswer, Email, Mobile, UserRoleName  ");
            strSql.Append("  from FrontUser ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,255)
			};
            parameters[0].Value = userName;


            FrontUser model = new Model.FrontUser();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UserStatus"].ToString() != "")
                {
                    model.UserStatus = (UserStatus)Enum.Parse(typeof(UserStatus), ds.Tables[0].Rows[0]["UserStatus"].ToString(), false);
                }
                if (ds.Tables[0].Rows[0]["CreateDate"].ToString() != "")
                {
                    model.CreateDate = DateTime.Parse(ds.Tables[0].Rows[0]["CreateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Account"].ToString() != "")
                {
                    model.Account = decimal.Parse(ds.Tables[0].Rows[0]["Account"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Password = ds.Tables[0].Rows[0]["Password"].ToString();
                model.PayPassword = ds.Tables[0].Rows[0]["PayPassword"].ToString();
                model.SecretQuestion = ds.Tables[0].Rows[0]["SecretQuestion"].ToString();
                model.SecretAnswer = ds.Tables[0].Rows[0]["SecretAnswer"].ToString();
                model.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                model.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                model.UserRoleName = ds.Tables[0].Rows[0]["UserRoleName"].ToString();

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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM User ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
