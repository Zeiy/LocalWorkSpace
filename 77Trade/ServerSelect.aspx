<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServerSelect.aspx.cs" Inherits="_77Trade.ServerSelect" MasterPageFile="/Common.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <div class="con-main-middle" style="height: 450px">
        <div class="inner">
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
                                <a href="BillList.aspx?serverID=<%=server.ID %>">
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

                                <a href="BillList.aspx?serverID=<%=serverDianxin.ID %>">
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
</asp:Content>
