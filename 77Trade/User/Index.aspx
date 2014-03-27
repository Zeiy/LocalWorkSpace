<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_77Trade.User.Index" %>
<%@ Register Src="~/UserControls/UserCenterLeftNav.ascx" TagPrefix="uc1" TagName="UserCenterLeftNav" %>
<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <uc1:UserCenterLeftNav runat="server" ID="UserCenterLeftNav" />
    <div class="con-main-main">
        <script>
            $(document).ready(function () {
                $('.con-main-sider li').click(function (e, i) {
                    $(this).addClass('cur').siblings('.cur').removeClass('cur');
                    var idx = $(this).index() + $(this).parents(".dropbox").index() * 4;
                    $(".con-main-main .item").eq(idx).addClass('cur').siblings('.cur').removeClass('cur');
                });
            });
        </script>
        <form id="form1" method="post" name="form1">
            <div>
            </div>

            <div>
            </div>
            <div class="item item1 cur">
                <h3>
                    <!--[if lt IE 7 ]><span style="zoom: 1;"></span><![endif]-->
                    <i></i>我的账户信息</h3>
                <div class="con">
                    <div style="padding: 47px 0 0 67px;">
                        <p>欢迎您：<span class="c-main" id="Label5">139****5908</span></p>
                        <p>次登录时间：<span id="Label6">2014-3-23 14:37:19</span></p>
                        <p>账户可用余额：<em><span id="Label7">30.0000</span>元</em></p>
                        <p>
                            <input type="submit" class="btn1-2" id="Button1" value="立即充值" name="Button1"><input type="submit" class="btn2-2" id="Button2" value="立即提现" name="Button2">
                        </p>
                        <p>账户冻结余额：<span id="Label1">0.0000</span>元 </p>
                        <p>账户不可提现金额：<span id="Label2">0.0000</span>元 </p>
                        <p>
                            <input type="submit" class="btn1-2" id="Button3" value="设置密码保护" name="Button3"><input type="submit" class="btn2-2" id="Button4" value="设置消费限制" name="Button4">
                            <input type="submit" class="btn1-2" id="Button5" value="设置IP限制" name="Button5">
                        </p>
                        <p class="last-child"><a target="_blank" href="http://zt2.ztgame.com/index.shtml">征途2官方网站</a><a href=""><img height="62" width="95" alt="" src="/style/images/demo/zt2-2.png"></a><a target="_blank" href="http://bbs.zt2.ztgame.com/">征途2官方论坛</a></p>
                        <script>
                            $(".btn1-2").click(function () {
                                $(".con-main-sider .con li").eq(1).click();
                            });
                            $(".btn2-2").click(function () {
                                $(".con-main-sider .con li").eq(2).click();
                            });
                        </script>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
