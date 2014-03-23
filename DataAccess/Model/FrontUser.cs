using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Model
{
    public class FrontUser
    {
        /// <summary>
        /// ID
        /// </summary>		
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// UserName
        /// </summary>		
        private string _username;
        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }
        /// <summary>
        /// Password
        /// </summary>		
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// PayPassword
        /// </summary>		
        private string _paypassword;
        public string PayPassword
        {
            get { return _paypassword; }
            set { _paypassword = value; }
        }
        /// <summary>
        /// SecretQuestion
        /// </summary>		
        private string _secretquestion;
        public string SecretQuestion
        {
            get { return _secretquestion; }
            set { _secretquestion = value; }
        }
        /// <summary>
        /// SecretAnswer
        /// </summary>		
        private string _secretanswer;
        public string SecretAnswer
        {
            get { return _secretanswer; }
            set { _secretanswer = value; }
        }
        /// <summary>
        /// Email
        /// </summary>		
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// Mobile
        /// </summary>		
        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// UserRoleName
        /// </summary>		
        private string _userrolename;
        public string UserRoleName
        {
            get { return _userrolename; }
            set { _userrolename = value; }
        }
        /// <summary>
        /// UserStatus
        /// </summary>		
        private UserStatus _userstatus;
        public UserStatus UserStatus
        {
            get { return _userstatus; }
            set { _userstatus = value; }
        }
        /// <summary>
        /// CreateDate
        /// </summary>		
        private DateTime _createdate;
        public DateTime CreateDate
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// Account
        /// </summary>		
        private decimal _account;
        public decimal Account
        {
            get { return _account; }
            set { _account = value; }
        }        
    }
}
