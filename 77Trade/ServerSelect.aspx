<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerSelect.aspx.cs" Inherits="_77Trade.ServerSelect" %>

<!DOCTYPE html>
<html lang="zh-CN">
<!--<![endif]-->
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <title>七七交易网-征途2专区</title>
    <link rel="stylesheet" href="style/base.css" media="all" />
    <link rel="stylesheet" href="style/style.css" media="all" />
    <script src="Js/jquery-1.11.0.min.js"></script>
</head>
<body>
    <header></header>
    <!-- content -->
    <section class="content grid1">
        <nav class="menu nologin">
            <ul>
                <li>
                    <a href="index.aspx">
                        <!--[if lt IE 7 ]><em style="zoom: 1;"></em><![endif]-->
                        <i class="icon1"></i>专区首页</a>
                </li>
                <li>
                    <a href="2 buyInfo.html"><i class="icon2"></i>求购查询</a>
                </li>
                <li>
                    <a href="3 sellInfo.html"><i class="icon3"></i>出售查询</a>
                </li>
                <li>
                    <a href="accountInfo.aspx"><i class="icon4"></i>发布帐号</a>
                </li>
                <li>
                    <a href="5 bill.html"><i class="icon5"></i>点卡查询</a>
                </li>
                <li>
                    <a href="6 tradeInfo.html"><i class="icon6"></i>我的七七交易</a>
                </li>
                <li class="last-child">
                    <a href="7 help.html"><i class="icon7"></i>交易指南</a>
                </li>
            </ul>
            <span class="bg" style="left: 0; width: 157px;"></span>
        </nav>
        <section class="con-main">
            <div class="con-main-top"></div>
            <div class="con-main-middle">
                <div class="inner clearfix">
                    <div class="tab-box tab1">
                        <div class="trigger">
                            <a class="cur">网通区</a>
                            <a style="left: -30px;">电信区</a>
                            <a style="left: -60px;">双线区</a>
                        </div>
                        <div class="tab-list">
                            <ul>
                                <%foreach (var item in GameAreasList)
                                  {
                                      if (item.AreaName.Trim() == "双线区")
                                      {%>
                                <li class="tabitem">
                                    <div class="list">
                                        <% foreach (var server in item.ServerList)
                                           {%>
                                        <a href="AccountSaleList.aspx?serverID=<%=server.ID %>">
                                            <%=server.ServerName %>

                                        </a>
                                        <%   }%>
                                    </div>
                                </li>
                                <% } %>
                                <%if (item.AreaName.Trim() == "电信区")
                                  {%>
                                <li class="tabitem">
                                    <div class="list">
                                        <% foreach (var serverDianxin in item.ServerList)
                                           {%>

                                        <a href="AccountSaleList.aspx?serverID=<%=serverDianxin.ID %>">
                                            <%=serverDianxin.ServerName %>
                                        </a>
                                        <% }%>
                                    </div>
                                </li>
                                <% }  
                                   if (item.AreaName.Trim() == "网通区")
                                  {%>
                                <li class="cur tabitem">
                                    <div class="list">
                                        <%foreach (var wangtongserver in item.ServerList)
                                          {%>
                                        <a href="BillList.aspx?serverID=<%=wangtongserver.ID %>">
                                            <%=wangtongserver.ServerName %>
                                        </a>
                                        <% }%>
                                    </div>
                                </li>
                                <%  }
                                  }  %>
                            </ul>
                            <script>
                                $(document).ready(function () {
                                    //Tab选项卡切换
                                    $(".trigger a").click(function () {
                                        $(this).addClass("cur").siblings().removeClass("cur");
                                        $(".tabitem").eq($(this).index()).show().siblings().hide();
                                    });

                                    $(".tab1 .tab-list a").click(function () {
                                        $(this).addClass('cur').siblings('.cur').removeClass('cur');
                                    });
                                });
                            </script>
                        </div>
                    </div>

                </div>
            </div>
            <div class="con-main-bottom"></div>
        </section>
    </section>
    <!-- /content -->
    <!-- footer -->
    <footer>
        <a href="#">
            <img src="style/images/demo/jr.png" height="43" width="113" alt=""></a>
        <a href="#">
            <img src="style/images/demo/77.png" height="30" width="134" alt=""></a>
        <p>京ICP备10014751号 京网文[2011]0082-031号 京ICP证100162号 电子商务经营者信息公示 Copyright © 2010 北京易网合纵网络科技有限公司 All Rights Reserved 版权所有 不得转载</p>
    </footer>
    <!-- /footer -->
</body>
</html>
