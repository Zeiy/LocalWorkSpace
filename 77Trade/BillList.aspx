<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillList.aspx.cs" Inherits="_77Trade.BillList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE HTML>
<html lang="zh-CN">
<head>
    <meta charset="UTF-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
    <title>七七交易网-征途2专区</title>
    <link rel="stylesheet" href="style/base.css" media="all" />
    <link rel="stylesheet" href="style/style.css" media="all" />
    <script src="js/jquery-2.0.3.min.js"></script>
    <script src="js/plugin/date_input/jquery.date_input.js"></script>
    <link rel="stylesheet" href="js/plugin/date_input/date_input.css" media="all"/>
    <script src="Js/common.js"></script>
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
</head>
<body>
    <header></header>
    <!-- content -->
    <section class="content grid1">
        <nav class="menu">
            <ul>
                <li>
                    <a href="Index.aspx"><i class="icon1"></i>专区首页</a>
                </li>
                <li>
                    <a href="2 buyInfo.html"><i class="icon2"></i>求购详情</a>
                </li>
                <li>
                    <a href="3 sellInfo.html"><i class="icon3"></i>出售详情</a>
                </li>
                <li>
                    <a href="accountInfo.aspx"><i class="icon4"></i>发布帐号</a>
                </li>
                <li class="cur">
                    <span>
                        <!--[if lt IE 7 ]><em style="zoom: 1;"></em><![endif]-->
                        <i class="icon5"></i>点卡详情</span>
                </li>
                <li>
                    <a href="6 tradeInfo.html"><i class="icon6"></i>我的七七交易</a>
                </li>
                <li class="last-child">
                    <a href="7 help.html"><i class="icon7"></i>交易指南</a>
                </li>
            </ul>
            <span class="bg" style="width: 157px; left: 500px;"></span>
        </nav>
        <section class="con-main">
            <div class="con-main-top"></div>
            <div class="con-main-middle">
                <div class="inner nobg clearfix">
                    <div class="con-main-sider">
                        <div class="dropbox extend">
                            <h3>
                                <!--[if lt IE 7 ]><span style="zoom: 1;"></span><![endif]-->
                                <i></i>我的账号</h3>
                            <div class="con">
                                <ul>
                                    <li class="cur">点卡订单</li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <form id="mainForm" runat="server">
                    <div class="con-main-main">
                        <h3>
                            <!--[if lt IE 7 ]><span style="zoom: 1;"></span><![endif]-->
                            <i></i>点卡订单</h3>
                        <div class="con">
                            <div class="cntrl-bar">
                                <div class="pop-box">
                                    <!--[if lt IE 7 ]><span style="zoom: 1;"></span><![endif]-->
                                    <i></i>
                                    <asp:Label runat="server" ID="labelGameArea" CssClass="name">服务区</asp:Label>
                                    <div class="inner-pop">
                                        <a class="cur">网通区</a>
                                        <a>电信区</a>
                                        <a>双线区</a>
                                    </div>
                                </div>
                                <div class="pop-box">
                                    <!--[if lt IE 7 ]><span style="zoom: 1;"></span><![endif]-->
                                    <i></i>
                                    <asp:Label runat="server" ID="lableGameServer" CssClass="name">游戏区</asp:Label>
                                    <div class="inner-pop">
                                         <% foreach (var serverItem in CurrentServers)
                                                       {
                                                           if (serverItem.ServerName.Trim() == lableGameServer.Text.Trim())
                                                           { %>
                                                                <a class="cur"><%= serverItem.ServerName %></a>
                                                          <% }
                                                           else
                                                           {%>
                                                                <a><%=serverItem.ServerName %></a>
                                                          <% }
                                                           } %>
                                    </div>
                                </div>
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
                                        <th>订单号</th>
                                        <th>区服</th>
                                        <th>价格<i></i></th>
                                        <th>订单状态<i></i></th>
                                        <th>日期<i></i></th>
                                        <th width="80">操作</th>
                                    </tr>
                                      <% foreach (var infoModels in CurrentPageInfoModels)
                                                   {%>
                                                        <tr>
                                                    <td><%=infoModels.OrderNo %></td>
                                                    <td><a title="<%=GetAccountPropertyByAccountModel(infoModels) %>"><%=GetAccountPropertyByAccountModel(infoModels) %></a></td>
                                                      <td><%=infoModels.Price %> <i></i></td>
                                                            <td><%=GetOrderStatusStr(infoModels.OrderStatus) %></td>
                                                    <td><%=infoModels.SubmitTime %><i></i></td>
                                                    <td><a href="OrderDetail.aspx?acDes=<%=infoModels.ID %>">查看详情</a><i></i></td>
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
                        </div>
                    </div>
                        <asp:HiddenField runat="server" ID="hiddenGameName"/>
                        <asp:HiddenField runat="server" ID="hiddenAreaName"/>
                        <asp:HiddenField runat="server" ID="hiddenServerName"/>
                        <asp:HiddenField runat="server" ID="hiddenTimeSpan"/>
                        <asp:HiddenField runat="server" ID="hiddenOrderStatus"/>
                        <asp:HiddenField runat="server" ID="hiddenOrderBy"/>
                    </form>
                </div>
                <div class="con-main-bottom"></div>
            </div>
        </section>
    </section>
    <!-- /content -->
    <!-- footer -->
    <footer>
        <a href="">
            <img src="style/images/demo/jr.png" height="43" width="113" alt=""></a>
        <a href="">
            <img src="style/images/demo/77.png" height="30" width="134" alt=""></a>
        <p>京ICP备10014751号 京网文[2011]0082-031号 京ICP证100162号 电子商务经营者信息公示 Copyright © 2010 北京易网合纵网络科技有限公司 All Rights Reserved 版权所有 不得转载</p>
    </footer>
    <!-- /footer -->
</body>
    <script type="text/javascript">
        //如果用户未选区服，点击服务器选择的时候
        $(".pop-box").click(function() {
            if ($(".inner-pop a").length <= 0) {
                alert("请选择区服！");
            }
        });
        
    </script>
</html>
