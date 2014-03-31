using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Model
{
    public class UserBuyOrderPageModel
    {
        public string OrderNo { get; set; }
        public string ProductTitle { get; set; }
        public decimal Price { get; set; }
        public int UserID { get; set; }
    }
}
