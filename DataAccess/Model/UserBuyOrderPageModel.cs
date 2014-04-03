using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Model
{
    /// <summary>
    /// UserBuyOrder 表与 AccountDescription表联查询
    /// </summary>
    public class UserBuyOrderPageModel
    {
        public UserBuyOrderPageModel ()
        {

        }

        public string OrderNo { get; set; }
        public string ProductTitle { get; set; }
        public decimal Price { get; set; }
        public int UserID { get; set; }
        public string ProductImgAUrl { get; set; }
        public int AccountInfoID { get; set; }
        public int AccountDescriptionID { get; set; }
        /// <summary>
        /// UserBuyOrder表里的订单状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }
        public DateTime EditDate { get; set; }
    }
}
