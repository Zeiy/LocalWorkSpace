<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="_77Trade.OrderDetail" MasterPageFile="Common.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <script src="global/js/jquery.touchSlider.js" type="text/javascript"></script>
    <div class="con-main-middle">
        <!-- header end -->
        <form runat="server">
            <div style="overflow: hidden">
                <div class="show-product">
                    <h3>商品展示</h3>
                    <div class="info">
                        <div style="float: left; width: 200px">
                            <img src="<%=CurrentAccountDescription.ProductImgAUrl %>" style="border: 1px solid #001627; padding: 1px;" align="right" width="200px" height="300px" />
                        </div>
                        <div style="margin-left: 200px">
                            <table width="815" height="300" style="border-collapse: collapse">
                                <tr>

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
                                    <td valign="top"><%=GetOrderStatusStr(CurrentAccountDescription.OrderStatus) %><span style="color: red" id="timeWait">(1天10小时25分56秒后可购买)</span></td>
                                </tr>
                                <tr>
                                    <td valign="top" width="83" align="right">发布时间：</td>
                                    <td valign="top"><%=CurrentAccountDescription.SubmitTime %></td>
                                </tr>
                                <tr>
                                    <td valign="top" width="83" align="right">&nbsp;</td>
                                    <td valign="top">
                                        <asp:LinkButton runat="server" Text="购买商品" CssClass="btn1" ID="buyProduct" ClientIDMode="Static" OnClick="buyProduct_Click"></asp:LinkButton>
                                        <asp:LinkButton runat="server" Text="收藏商品" CssClass="btn2" ID="btnShouChang"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
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
            <asp:HiddenField runat="server" ID="descriptionID" />
        </form>
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

            //如果订单处于公示期则添加倒计时
            var timeContainer = $("#timeWait");
            var now = new Date(<%=DateTime.Now.Year%>,<%=DateTime.Now.Month%>-1,<%=DateTime.Now.Day%>,<%=DateTime.Now.Hour%>,<%=DateTime.Now.Minute%>,<%=DateTime.Now.Second%>); 
            var endDate = new Date(<%=CurrentAccountDescription.EditDate.Year%>,<%=CurrentAccountDescription.EditDate.Month%>-1,<%=CurrentAccountDescription.EditDate.Day%>+3,<%=CurrentAccountDescription.EditDate.Hour%>,<%=CurrentAccountDescription.EditDate.Minute%>,<%=CurrentAccountDescription.EditDate.Second%>); 
            var leftTime=endDate.getTime()-now.getTime();
            if (leftTime < 0) {
                timeContainer.hide();
            } else {
                $("#buyProduct").click(function() {
                    alert("进入公示期订单三天以后才可以购买。请耐心等待！");
                    return false;
                });
                setInterval(reNewTime,1000); 
            }

            function reNewTime() {
                leftTime = leftTime - 1000;
                var leftsecond = parseInt(leftTime/1000); 
                var day1=Math.floor(leftsecond/(60*60*24)); 
                var hour=Math.floor((leftsecond-day1*24*60*60)/3600); 
                var minute=Math.floor((leftsecond-day1*24*60*60-hour*3600)/60); 
                var second=Math.floor(leftsecond-day1*24*60*60-hour*3600-minute*60); 
                $(timeContainer).text("("+day1 + "天" + hour + "小时" + minute + "分" + second + "秒可购买)");
                
            }
        });
    </script>
</asp:Content>
