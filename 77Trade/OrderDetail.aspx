<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="_77Trade.OrderDetail" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="“X-UA-Compatible”" content="IE=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>商品展示</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link type="text/css" href="global/css/style.css" rel="stylesheet" />
    <script src="global/js/jquery.min.js" type="text/javascript"></script>
    <script src="global/js/jquery.touchSlider.js" type="text/javascript"></script>
</head>
<body>
    <div class="header bg2 center">
        <div class="logo">
            <h1><a href="/" title="巨人网络">巨人网络</a></h1>
        </div>
        <div class="clear"></div>
        <div class="nav">
            <ul>
                <li><a href="Index.aspx">专区首页</a></li>
                <li><a href="#">求购查询</a></li>
                <li><a href="#">出售查询</a></li>
                <li><a href="accountInfo.aspx">帐号发布</a></li>
                <li><a href="#">点卡查询</a></li>
                <li><a href="#">我的七七交易</a></li>
                <li style="background: none;"><a href="#">交易指南</a></li>
            </ul>
        </div>
        <div class="clear"></div>
    </div>
    <!-- header end -->
    <form runat="server">
        <div class="main">
            <div class="box">
                <div class="show-product">
                    <h3>商品展示</h3>
                    <div class="info">
                        <table width="875" height="300" style="border-collapse: collapse">
                            <tr>
                                <td height="300" width="210" valign="top" style="margin: 30px 15px; padding: 10px;" rowspan="9">
                                    <img src="<%=CurrentAccountDescription.ProductImgAUrl %>" style="border: 1px solid #001627; padding: 1px;" align="right" width="200px" height="300px" />
                                </td>
                                <td valign="top" width="83" align="right" style="padding: 10px 0;">
                                    <p align="center">
                                        <font color="#FFFFFF">
		<strong style="color:#ffe27e">物品名称：</strong></font>
                                </td>
                                <td valign="top" style="padding: 10px 0;">
                                    <strong style="color: #ffe27e;"><%=CurrentAccountDescription.ProductTitle %></strong></td>
                            </tr>
                            <tr>
                                <td valign="top" width="83" align="right">订单编号：</td>
                                <td valign="top"><%=CurrentAccountDescription.OrderNo %></td>
                            </tr>
                            <tr>
                                <td valign="top" width="83" align="right">区<span class="b13">/</span>服：</td>
                                <td valign="top"><%=GetAccountPropertyByAccountModel(CurrentAccountDescription) %></td>
                            </tr>
                            <tr>
                                <td valign="top" width="83" align="right">总<span class="b14"></span>价：</td>
                                <td valign="top"><%=CurrentAccountDescription.Price %>元 </td>
                            </tr>
                            <tr>
                                <td valign="top" width="83" align="right">状<span class="b14"></span>态：</td>
                                <td valign="top"><%=GetOrderStatusStr(CurrentAccountDescription.OrderStatus) %></td>
                            </tr>
                            <tr>
                                <td valign="top" width="83" align="right">发布时间：</td>
                                <td valign="top"><%=CurrentAccountDescription.SubmitTime %></td>
                            </tr>
                            <tr>
                                <td valign="top" width="83" align="right">&nbsp;</td>
                                <td valign="top">
                                    <asp:LinkButton runat="server" Text="购买商品" CssClass="btn1" ID="buyProduct" OnClick="buyProduct_Click"></asp:LinkButton>
                                    <asp:LinkButton runat="server" Text="收藏商品" CssClass="btn2" ID="btnShouChang"></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="product-content">
                        <h4>商品描述</h4>
                        <p><%=CurrentAccountDescription.ProductDescription %></p>
                    </div>
                    <div class="product-img">
                        <div class="focus" id="focus">
                            <div class="main_visual">
                                <div class="flicking_con">
                                    <div class="flicking_inner">
                                        <a href="#"></a>
                                        <a href="#"></a>
                                        <a href="#"></a>
                                        <a href="#"></a>
                                    </div>
                                </div>
                                <div class="main_image">
                                    <ul>
                                        <li class="img_1"><span>
                                            <img src="<%=CurrentAccountDescription.ProductImgAUrl %>" />
                                        </span></li>
                                        <li class="img_2"><span>
                                            <img src="<%=CurrentAccountDescription.ProductImgBUrl %>" />
                                        </span></li>
                                        <li class="img_3"><span>
                                            <img src="<%=CurrentAccountDescription.ProductImgCUrl %>" />
                                        </span></li>
                                        <li class="img_4"><span>
                                            <img src="<%=CurrentAccountDescription.ProductImgDUrl %>" /></span></li>
                                    </ul>
                                    <a href="javascript:;" id="btn_prev"></a>
                                    <a href="javascript:;" id="btn_next"></a>
                                </div>
                            </div>

                            <div class="clear"></div>
                        </div>
                        <!-- bannd end -->
                    </div>
                </div>
            </div>
            <div class="clear"></div>
        </div>
        <asp:HiddenField runat="server" ID="descriptionID"/>
    </form>

    <!-- main end -->

    <div class="footer">
        <div class="fl">
            <img src="global/images/foot_logo1.png" width="113" height="43" />
            <img src="global/images/foot_logo2.png" width="140" height="43" />
        </div>
        <div class="fr">
            <p>
                京ICP备10014751号 京ICP证100162号&nbsp; 京网文[2011]0082-031号&nbsp; 
		电子商务经营者信息公示<br />
                Copyright © 2010 北京易网合纵网络科技有限公司 All Rights Reserved 
		版权所有 不得转载
            </p>
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $(".main_visual").hover(function () {
                $("#btn_prev,#btn_next").fadeIn()
            }, function () {
                $("#btn_prev,#btn_next").fadeOut()
            });
            $dragBln = false;
            $(".main_image").touchSlider({
                flexible: true,
                speed: 200,
                btn_prev: $("#btn_prev"),
                btn_next: $("#btn_next"),
                paging: $(".flicking_con a"),
                counter: function (e) {
                    $(".flicking_con a").removeClass("on").eq(e.current - 1).addClass("on");
                }
            });
            $(".main_image").bind("mousedown", function () {
                $dragBln = false;
            });
            $(".main_image").bind("dragstart", function () {
                $dragBln = true;
            });
            $(".main_image a").click(function () {
                if ($dragBln) {
                    return false;
                }
            });
            timer = setInterval(function () { $("#btn_next").click(); }, 4000);
            $(".main_visual").hover(function () {
                clearInterval(timer);
            }, function () {
                timer = setInterval(function () { $("#btn_next").click(); }, 4000);
            });
            $(".main_image").bind("touchstart", function () {
                clearInterval(timer);
            }).bind("touchend", function () {
                timer = setInterval(function () { $("#btn_next").click(); }, 4000);
            });
        });
    </script>
</body>
</html>
