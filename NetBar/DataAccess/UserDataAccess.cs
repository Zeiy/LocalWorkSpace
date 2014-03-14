using NetBar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace NetBar.DataAccess
{
    public class UserDataAccess
    {
        private  string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["NetBar"].ToString();
        /// <summary>
        /// 添加新用户，如果添加成功则反回新用户模型，如果添加失败则反回空用户模型
        /// </summary>
        /// <param name="user">要添加的新用户模型</param>
        /// <returns></returns>
        public UserModel CreateUser(UserModel user)
        {
            UserModel newUser = new UserModel();
            //检察用户是否已存在
            bool userExist = CheckUserExist(user);
            if (userExist) {
                return newUser;
            }
            //如果用户不存在则允许添加到数据库
            newUser.UserName = user.UserName;
            newUser.Password = user.Password;
            newUser.Role = user.Role;
            newUser.UserLevel = user.UserLevel;
            //写入数据库
            return newUser;
        }
        /// <summary>
        /// 添加新用户，如果成功刚产生用户ID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserModel InsertUser(UserModel user)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string sqlStr = "use NetBar insert into UserTable (Password,Role,UserLevel,UserName) values (@Password,@Role,@UserLevel,@UserName)";
                SqlCommand cmd = new SqlCommand(sqlStr, connection);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Role", user.Role);
                cmd.Parameters.AddWithValue("@UserLevel", user.UserLevel);
                cmd.Parameters.AddWithValue("@UserName", user.UserName);
                int res  = (int)cmd.ExecuteNonQuery();
                if (res > 0) { 
                //添加成功
                    user = GetUserByName(user.UserName);
                }
                return user;
            }
        }
        /// <summary>
        /// 检察用户名是否已存在
        /// </summary>
        /// <param name="user">需要检察的用户模型</param>
        /// <returns>用户是否存在的Bool</returns>
        public bool CheckUserExist(UserModel user)
        {
            //根据用户名称查找用户信息
            UserModel userTemp = GetUserByName(user.UserName);
            //如果用户ID>0说明用户存在
            if (userTemp.ID > 0)
            {
               return true;
            }
            return false ;
        }
        /// <summary>
        /// 根据用户名查找到用户相关信息，如果用户ID为空则说明用户不存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns>UserModel</returns>
        public UserModel GetUserByName(string userName)
        {
            UserModel user = new UserModel();
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string sqlStr = "use NetBar select ID,Password,Role,UserLevel,UserName from UserTable where UserName = @UserName";
                SqlCommand cmd = new SqlCommand(sqlStr, connection);
                cmd.Parameters.AddWithValue("@UserName", userName);
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.ID =Convert.ToInt32(reader["Id"]);
                        user.Password = Convert.ToString(reader["Password"]);
                        user.Role = Convert.ToString(reader["Role"]);
                        user.UserLevel = Convert.ToInt32(reader["UserLevel"]);
                        user.UserName = Convert.ToString(reader["UserName"]);
                    }
                    return user;
                }
            }
        }
    }
}