<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Common.Master" AutoEventWireup="true" CodeBehind="GameList.aspx.cs" Inherits="NetBar.ServerManager.GameList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div>
        <ul class="breadcrumb">
            <li>
                <a href="/Index.aspx">主页</a> <span class="divider">/</span>
            </li>
            <li>
                <a href="#">游戏管理</a>
            </li>
        </ul>
    </div>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div data-original-title="" class="box-header well">
                <h2><i class="icon-edit"></i>游戏列表</h2>
                <div class="box-icon">
                    <a class="btn btn-setting btn-round" href="#"><i class="icon-cog"></i></a>
                    <a class="btn btn-minimize btn-round" href="#"><i class="icon-chevron-up"></i></a>
                    <a class="btn btn-close btn-round" href="#"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <table class="table table-striped table-bordered bootstrap-datatable ">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>游戏名称</th>
                            <th>提交时间</th>
                            <th>状态</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (var item in GameInfoList)
                           {%>
                        <tr>
                            <td><%=item.ID %></td>
                            <td class="center"><%=item.GameName %></td>
                            <td class="center"><%=item.AddTime %></td>
                            <td class="center">状态</td>
                            <td class="center"><a href="/ServerManager/GameDetail.aspx?gameID=<%=item.ID %>">查看详细</a></td>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
                <div class="dataTables_paginate paging_bootstrap pagination">
                   <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
                                           CurrentPageButtonPosition="Center"
                                                Width="100%" HorizontalAlign="center" AlwaysShowFirstLastPageNumber="true" PagingButtonSpacing="0px" FirstPageText="首页"
                                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页" ShowCustomInfoSection="Left" ShowPageIndexBox="Never" ScrollBars="None" NavigationButtonType="Text" CurrentPageButtonClass="active" CurrentPageButtonTextFormatString="&lt;li class =&quot;active&quot;&gt;&lt;a href=&quot;#&quot;&gt;当前页&lt;/a&gt;&lt;/li&gt;" CustomInfoSectionWidth="20%" PagingButtonLayoutType="UnorderedList" Wrap="False" UrlPaging="True">
                  </webdiyer:AspNetPager>
                    </div>
            </div>
        </div>
        <!--/span-->
    </div>
</asp:Content>
