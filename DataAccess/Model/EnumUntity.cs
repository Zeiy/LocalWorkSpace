namespace DataAccess.Model
{
    public enum OrderStatus
    {
        /// <summary>
        /// 订单出售成功
        /// </summary>
        SaleSuccess = 0,
        /// <summary>
        /// 订单未生成完成,用户还没有上传帐号详细说明信息，只进行了第一步
        /// </summary>
        NotComplete=1,
        /// <summary>
        /// 订单完成生成
        /// </summary>
        Complete = 2,
        /// <summary>
        /// 订单生成完成，进入人工审核期
        /// </summary>
        ShenHe =3,
        /// <summary>
        /// 订单审核通过后进入公示期
        /// </summary>
        GongShi=4,
        /// <summary>
        /// 订单公示期过后进入出售期
        /// </summary>
        ChuShou = 5,
        /// <summary>
        /// 订单审核失败
        /// </summary>
        ShenHeFail =6,
    }

    public enum UserStatus
    {
        /// <summary>
        /// 正常帐户
        /// </summary>
        Normal = 0,
        /// <summary>
        /// 帐户冻结
        /// </summary>
        Frozen =1
    }
}