<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountSaleList.aspx.cs" Inherits="_77Trade.AccountSaleList" MasterPageFile="Common.Master" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <link href="Js/JqueryTips/colortip-1.0-jquery.css" rel="stylesheet" />
    <script src="Js/JqueryTips/colortip-1.0-jquery.js"></script>
    <script>
        $.extend(DateInput.DEFAULT_OPTS, {
            // 时间格式
            stringToDate: function (string) {
                var matches;
                if (matches = string.match(/^(\d{4,4})-(\d{2,2})-(\d{2,2})$/)) {
                    return new Date(matches[1], matches[2] - 1, matches[3]);
                } else {
                    return null;
                };
            },

            dateToString: function (date) {
                var month = (date.getMonth() + 1).toString();
                var dom = date.getDate().toString();
                if (month.length == 1) month = "0" + month;
                if (dom.length == 1) dom = "0" + dom;
                return date.getFullYear() + "-" + month + "-" + dom;
            },
            // 中文
            month_names: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"],
            short_month_names: ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"],
            short_day_names: ["一", "二", "三", "四", "五", "六", "日"]
        });
    </script>
    <script type="text/javascript">$($.date_input.initialize);</script>
        <div class="con-main-middle">
        <div class="inner">
    <div class="tab-box tab2">
        <form method="post" runat="server" id="mainForm">
            <div class="trigger">
                <a href="accountInfo.aspx">发布帐号</a>
                <a style="left: -70px; right: 157px;" orderstatus="3" class="cur">审核期</a>
                <a style="left: -150px;" orderstatus="4">公示期</a>
                <a style="left: -210px;" orderstatus="5">出售期</a>
                <a style="left: -290px;" orderstatus="0">出售成功</a>
            </div>
            <div class="tab-list">
                <ul>
                    <li class="cur tabitem">
                        <div class="cntrl-bar">
                            <div class="pop-box time">
                                <!--[if lt IE 7 ]><span style="zoom: 1;"></span><![endif]-->
                                <i></i>
                                <asp:Label runat="server" CssClass="value" ID="labelTimeSpan">2013-11-06至2014-11-13</asp:Label>
                                <div class="inner-pop">
                                    <input type="text" class="date_input" hidden>
                                    <input type="text" class="date_input" hidden>
                                </div>
                            </div>
                        </div>
                        <div class="table-box">
                            <table>
                                <tr>
                                    <th>标题</th>
                                    <th>属性</th>
                                    <th><span class="up" id="OrderNo">单号<i></i></span></th>
                                    <th><span id="price">总价（元）<i></i></span></th>
                                    <th><span id="SubmitTime">日期<i></i></span></th>
                                    <th><span>状态</span></th>
                                </tr>
                                <% foreach (var infoModels in CurrentPageInfoModels)
                                   {%>
                                <tr>
                                    <td><%=infoModels.ProductTitle%> </td>
                                    <td><a href="#"><%=GetAccountPropertyByAccountModel(infoModels) %></a></td>
                                    <td><%=infoModels.OrderNo %><i></i></td>
                                    <td><%=infoModels.Price %> <i></i></td>
                                    <td><%=infoModels.SubmitTime %><i></i></td>
                                    <td><a data-model="tips" title="<%=HttpUtility.HtmlDecode(infoModels.Remark) %>"> <%=GetOrderStatusStr(infoModels.OrderStatus) %> </a><i></i></td>
                                </tr>
                                <% } %>
                            </table>
                        </div>
                        <div class="pagination">
                            <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
                                OnPageChanging="AspNetPager1_PageChanging" OnPageChanged="AspNetPager1_PageChanged" CurrentPageButtonPosition="Center"
                                Width="100%" HorizontalAlign="center" AlwaysShowFirstLastPageNumber="true" PagingButtonSpacing="10" FirstPageText="首页"
                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" CustomInfoHTML="第%CurrentPageIndex%页，共%PageCount%页，每页%PageSize%条" ShowCustomInfoSection="Left" ShowPageIndexBox="Never" UrlPaging="True">
                            </webdiyer:AspNetPager>
                        </div>
                    </li>
                </ul>
            </div>
            <asp:HiddenField runat="server" ID="hiddenOrderStatus" ClientIDMode="Static" />
            <asp:HiddenField runat="server" ID="hiddenTimeSpan"  ClientIDMode="Static"/>
            <asp:HiddenField runat="server" ID="hiddenOrderBy" ClientIDMode="Static"/>
        </form>
    </div>
            </div>
            </div>
    <script type="text/javascript">
        $('[data-model]').colorTip({ color: 'blue' });
    </script>
</asp:Content>
