using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Model
{//UserBuyOrder

    public class UserBuyOrder
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
        /// OrderNo
        /// </summary>		
        private string _orderno;

        public string OrderNo
        {
            get { return _orderno; }
            set { _orderno = value; }
        }

        /// <summary>
        /// UserID
        /// </summary>		
        private int _userid;

        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
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
        /// EditDate
        /// </summary>		
        private DateTime _editdate;

        public DateTime EditDate
        {
            get { return _editdate; }
            set { _editdate = value; }
        }

        public OrderStatus OrderStatus { get; set; }
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
        /// Mobile
        /// </summary>		
        private string _mobile;
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// Address
        /// </summary>		
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
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
        /// ShenFenID
        /// </summary>		
        private string _shenfenid;
        public string ShenFenID
        {
            get { return _shenfenid; }
            set { _shenfenid = value; }
        }
    }
}
