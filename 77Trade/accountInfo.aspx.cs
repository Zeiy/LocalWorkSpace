using DataAccess.DataLogic;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace _77Trade
{
    public partial class accountInfo : System.Web.UI.Page
    {
        readonly GameInfoDataAccess _gameInfoAccess = new GameInfoDataAccess();
        readonly GameAreaDataAccess _gameAreaDataAccess = new GameAreaDataAccess();
        readonly AccountInfoDataAccess _accountInfoDataAccess = new AccountInfoDataAccess();
        private readonly GameServerDataAccess _gameServerDataAccess = new GameServerDataAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果第一次加载页面，填充游戏的下拉选框 包含大区
            if (!IsPostBack)
            {
                //游戏下拉框
                List<GameInfo> gameList = new List<GameInfo>();
                gameList = _gameInfoAccess.GameInfoList();
                foreach (var item in gameList)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = item.GameName;
                    listItem.Value = Convert.ToString(item.ID);
                    gameName.Items.Add(listItem);
                }
                //大区下拉选框
                List<GameArea> areaList = new List<GameArea>();
                areaList = _gameAreaDataAccess.GameAreaList();
                gameArea.Items.Clear();
                foreach (var item in areaList)
                {
                    ListItem listItem = new ListItem();
                    listItem.Text = item.AreaName;
                    listItem.Value = Convert.ToString(item.ID);
                    gameArea.Items.Add(listItem);
                }
            }
            //todo: 查看当前用户有没有未完成的订单，如果有则拿订单渲染面页信息
        }
        /// <summary>
        /// 用户选择大区时，更新大区服务器列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gameArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetServerListByGameIdAndAreaId();
        }

        protected void gameName_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetServerListByGameIdAndAreaId();
        }

        private void GetServerListByGameIdAndAreaId()
        {
            string gameId = gameName.SelectedValue;
            string areaId = gameArea.SelectedValue;
            int intGameId, intAreaId;
            if (!int.TryParse(gameId, out intGameId))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('请选择游戏名称！')</script>");
                return;
            }
            if (!int.TryParse(areaId, out intAreaId))
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('请选择区服！')</script>");
                return;
            }
            List<GameServer> serverList = _gameServerDataAccess.GetGameServerByGameIDandAreaId(intGameId, intAreaId);
            gameServer.Items.Clear();
            if (serverList.Count <= 0)
            {
                ListItem listItem = new ListItem();
                listItem.Text = "服务器列表空";
                listItem.Value = "服务器列表空";
                gameServer.Items.Add(listItem);
            }
            foreach (var item in serverList)
            {
                ListItem listItem = new ListItem();
                listItem.Text = item.ServerName;
                listItem.Value = Convert.ToString(item.ID);
                gameServer.Items.Add(listItem);
            }
        }
        /// <summary>
        /// 用户确认提交帐户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //收集用户信息
            string gameNameStr = gameName.SelectedItem.Text;
            string gameAreaStr = gameArea.SelectedItem.Text;
            string gameServerName = gameServer.SelectedItem.Text;
            string gameAccountStr = gameAccount.Text;
            //验证两次输入是否一样
            string gamePwdStr = gamePwd.Text;
            string regamePwdStr = regamePwd.Text;
            string gameRoleNameStr = gameRoleName.Text;
            string identityCardIdStr = identityCardID.Text;
            string qqMobileStr = qqOrMobile.Text;
            string emailStr = userEmail.Text;
            string secondLevelPwdStr = levelTwoPwd.Text;
            string propertyPwdStr = propertyPwd.Text;
            //如果选择图片上传 上传成功Url写入Hidden filed
            bool isBindSecretCardBool = isBindSecretCard.Checked;
            bool bindIdentityCardBool = bindIdentityCard.Checked;
            #region 数据验证
            int gameId, areaId, serverId;
            if(!int.TryParse(gameName.SelectedValue,out gameId)){
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('游戏名称选择有误，请重新选择！')</script>");
                return;
            }
            if(!int.TryParse(gameArea.SelectedValue,out areaId)){
            ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('游戏所属大区选择有误，请重新选择！')</script>");
                return;
            }
            if (!int.TryParse(gameServer.SelectedValue, out serverId))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('游戏所在属大区无服务器！')</script>");
                return;
            }
            if (gamePwdStr != regamePwdStr) {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('两次输入游戏密码不一致，请重新输入！')</script>");
                return;
            }
            if (string.IsNullOrEmpty(gameAccountStr) || string.IsNullOrEmpty(gamePwdStr) || string.IsNullOrEmpty(gameRoleNameStr) || string.IsNullOrEmpty(identityCardIdStr) || string.IsNullOrEmpty(qqMobileStr) || string.IsNullOrEmpty(emailStr) || string.IsNullOrEmpty(secondLevelPwdStr) || string.IsNullOrEmpty(propertyPwdStr))
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('所有标星号的为必真字段，不能为空！')</script>");
                return;
            }
            //对所有字段进行验证
            #endregion
            AccountInfoModel accountModel = new AccountInfoModel();
            accountModel.GameName = gameNameStr;
            accountModel.GameArea = gameAreaStr;
            accountModel.ServerName = gameServerName;
            accountModel.GameAccount = gameAccountStr;
            accountModel.GamePassword = gamePwdStr;
            accountModel.AccountRoleName = gameRoleNameStr;
            accountModel.IdCardNo = identityCardIdStr;
            accountModel.QQMobile = qqMobileStr;
            accountModel.Email = emailStr;
            accountModel.LevelTwoPwd = secondLevelPwdStr;
            accountModel.PropertyPwd = propertyPwdStr;
            accountModel.IdentityAuth = bindIdentityCardBool;
            accountModel.SecretCardBind = isBindSecretCardBool;
            //指定订单状态未完成
            accountModel.OrderStatus = OrderStatus.NotComplete;
            //指定用户ID为0 后续处理用户登陆问题
            accountModel.UserID = 0;
            int res =  _accountInfoDataAccess.Add(accountModel);
            if (res > 0)
            {
                //用户未生成完成的订单号传递给帐号详细页面
                Response.Redirect("/accountDescription.aspx?infoId=" + res);
            }
            else {
                ClientScript.RegisterClientScriptBlock(GetType(), "alert", "<script>alert('帐号发布出错，请重试！')</script>");
            }
        }
    }
}