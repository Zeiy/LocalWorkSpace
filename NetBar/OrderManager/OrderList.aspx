<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Common.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="NetBar.OrderManager.OrderList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul class="breadcrumb">
            <li>
                <a href="#">订单管理</a> <span class="divider">/</span>
            </li>
            <li>
                <a href="#">订单列表</a>
            </li>
        </ul>
    </div>

    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header well" data-original-title>
                <h2><i class="icon-user"></i>订单列表</h2>
                <div class="box-icon">
                    <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                    <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                    <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                </div>
            </div>
            <form runat="server" method="post">
            <div class="box-content">
                <table class="table table-striped table-bordered bootstrap-datatable ">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>游戏名称</th>
                            <th>游戏大区</th>
                            <th>服务器名</th>
                            <th>角色名</th>
                            <th>提交时间</th>
                            <th>状态</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (var item in AccountList)
                           {%>
                        <tr>
                            <td><%=item.ID %></td>
                            <td class="center"><%=item.GameName %></td>
                            <td class="center"><%=item.GameArea %></td>
                            <td class="center"><%=item.ServerName %></td>
                            <td class="center"><%=item.AccountRoleName %></td>
                            <td class="center"><%=item.SubmitTime %></td>
                            <td class="center">
                                <span class="label label-success">Active</span>
                            </td>
                            <td class="center">
                                <a class="btn btn-success" href="OrderDetail.aspx?InfoID=<%=item.ID %>">
                                    <i class="icon-zoom-in icon-white"></i>
                                    View                                            
                                </a>
                                <a class="btn btn-info" href="OrderDetail.aspx?InfoID=<%=item.ID %>">
                                    <i class="icon-edit icon-white"></i>
                                    Edit                                            
                                </a>
                         <%--       <a class="btn btn-danger" href="#">
                                    <i class="icon-trash icon-white"></i>
                                    Delete
                                </a>--%>
                            </td>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
                <div class="dataTables_paginate paging_bootstrap pagination">
                   <webdiyer:AspNetPager ID="AspNetPager1" runat="server"
                                           CurrentPageButtonPosition="Center"
                                                Width="100%" HorizontalAlign="center" AlwaysShowFirstLastPageNumber="true" PagingButtonSpacing="0px" FirstPageText="首页"
                                                LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" CustomInfoHTML="共%PageCount%页，当前为第%CurrentPageIndex%页" ShowCustomInfoSection="Left" ShowPageIndexBox="Never" ScrollBars="None" NavigationButtonType="Text" CurrentPageButtonClass="active" CurrentPageButtonTextFormatString="&lt;li class =&quot;active&quot;&gt;&lt;a href=&quot;#&quot;&gt;当前页&lt;/a&gt;&lt;/li&gt;" CustomInfoSectionWidth="20%" PagingButtonLayoutType="UnorderedList" Wrap="False" OnPageChanged="AspNetPager1_PageChanged" UrlPaging="True">
                  </webdiyer:AspNetPager>
                    </div>
            </div>
            </form>
        </div>
        <!--/span-->

    </div>
    <!--/row-->
</asp:Content>
