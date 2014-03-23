using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataAccess.Model
{
    /// <summary>
    /// 用户出售的帐号详细说明
    /// </summary>
    public class AccountDescription
    {
        public AccountDescription()
        {
            ProductImgAUrl = "";
            ProductImgBUrl = "";
            ProductImgCUrl = "";
            ProductImgDUrl = "";
            ProductTitle = "";
            GameName = "";
            this.GameArea = "";
            ServerName = "";
            ProductProperty = "";
            SubmitTime = DateTime.Now;
            ProductDescription = "";
            Price = 0;
            UserID = 0;
        }
        public int ID { get; set; }
        /// <summary>
        /// 帐号游戏名称
        /// </summary>
        public string GameName { get; set; }
        /// <summary>
        /// 帐号区服
        /// </summary>
        public string GameArea { get; set; }
        /// <summary>
        /// 帐号所在服务器名
        /// </summary>
        public string ServerName { get; set; }

        /// <summary>
        /// 与此描述信息相关联的帐号信息ID
        /// </summary>
        public int AccountInfoID { get; set; }
        /// <summary>
        /// 商品属性
        /// </summary>
        public string ProductProperty { get; set; }
        /// <summary>
        /// 商品标题
        /// </summary>
        public string ProductTitle { get; set; }
        /// <summary>
        /// 商品信息描述
        /// </summary>
        public string ProductDescription { get; set; }
        /// <summary>
        /// 出售价格
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// 用户上传产品图片地址
        /// </summary>
        public string ProductImgAUrl { get; set; }
        public string ProductImgBUrl { get; set; }
        public string ProductImgCUrl { get; set; }
        public string ProductImgDUrl { get; set; }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime SubmitTime { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// 生成的订单号
        /// </summary>
        public string OrderNo { get; set; }

        public int UserID { get; set; }
    }
}