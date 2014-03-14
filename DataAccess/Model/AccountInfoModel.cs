using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    /// <summary>
    /// 用户帐号信息类
    /// </summary>
    public class AccountInfoModel
    {
        public AccountInfoModel()
        {
            IdentityCardAUrl = "";
            IdentityCardBUrl = "";
            SecretCardNo = "";
            SecretCardImgUrl = "";
            SubmitTime = DateTime.Now;
        }
        public int ID { get; set; }
        /// <summary>
        /// 与此帐号相关的用户ID标识
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 些帐号所属的游戏名称
        /// </summary>
        public string GameName { get; set; }
        /// <summary>
        /// 帐号所在的游戏大区，网通，电信，或双线
        /// </summary>
        public string GameArea { get; set; }
        /// <summary>
        /// 帐号所属的服务器名
        /// </summary>
        public string ServerName { get; set; }
        /// <summary>
        /// 游戏帐号
        /// </summary>
        public string GameAccount { get; set; }
        /// <summary>
        /// 游戏密码
        /// </summary>
        public string GamePassword { get; set; }
        /// <summary>
        /// 游戏角色名称
        /// </summary>
        public string AccountRoleName { get; set; }
        /// <summary>
        /// 用户身份证号码
        /// </summary>
        public string IdCardNo { get; set; }
        /// <summary>
        /// 联系电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 用户的QQ或手机联系方式
        /// </summary>
        public string QQMobile { get; set; }
        /// <summary>
        /// 二级密码
        /// </summary>
        public string LevelTwoPwd { get; set; }
        /// <summary>
        /// 财产保护密码
        /// </summary>
        public string PropertyPwd { get; set; }
        /// <summary>
        /// 是否绑定密保卡
        /// </summary>
        public bool SecretCardBind { get; set; }
        /// <summary>
        /// 密保卡序列号
        /// </summary>
        public string SecretCardNo { get; set; }
        /// <summary>
        /// 密保卡上传图片的Url
        /// </summary>
        public string SecretCardImgUrl { get; set; }
        /// <summary>
        /// 是否使用身份证
        /// </summary>
        public bool IdentityAuth { get; set; }
        /// <summary>
        /// 用户上传身份证正面图片地址
        /// </summary>
        public string IdentityCardAUrl { get; set; }
        /// <summary>
        /// 用户上传身份证反面图片地址
        /// </summary>
        public string IdentityCardBUrl { get; set; }
        /// <summary>
        /// 订单状态
        /// </summary>
        public OrderStatus OrderStatus { get; set; }
        /// <summary>
        /// 订单提交时间
        /// </summary>

        public DateTime SubmitTime { get; set; }
        /// <summary>
        /// 订单详细信息
        /// </summary>
        public AccountDescription Description { get; set; }

    }
}
