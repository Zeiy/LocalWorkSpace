<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="MyBuyOrder.aspx.cs" Inherits="_77Trade.User.MyBuyOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <%@ Register Src="~/UserControls/UserCenterLeftNav.ascx" TagPrefix="uc1" TagName="UserCenterLeftNav" %>
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
            <div class="item item1 cur">
                <h3>
                    <i></i>我购买的订单</h3>
                <div class="con">
                    <div class="table-box">
                        <table>
                            <tr>
                                <th>订单号
                                </th>
                                <th>商品名称</th>
                                <th>价格
                                </th>
                                <th>操作
                                </th>
                            </tr>
                            <tr>
                                <td>ZT234345623245354235</td>
                                <td>征途电信测试3 </td>
                                <td>2342.2</td>
                                <td>
                                    <a href="#">立即付款</a>
                                     <a href="#">删除订单</a>
                                </td>
                            </tr>
                        </table>
                    </div>
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
        </form>
    </div>
</asp:Content>
