<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Common.Master" AutoEventWireup="true" CodeBehind="GameDetail.aspx.cs" Inherits="NetBar.ServerManager.GameDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul class="breadcrumb">
            <li>
                <a href="/Index.aspx">主页</a> <span class="divider">/</span>
            </li>
            <li>
                <a href="#">游戏服务器管理</a>
            </li>
        </ul>
    </div>
    <div class="row-fluid sortable ui-sortable">
        <div class="box span12">
            <div data-original-title="" class="box-header well">
                <h2><i class="icon-edit"></i>添加新服务器</h2>
                <div class="box-icon">
                    <a class="btn btn-setting btn-round" href="#"><i class="icon-cog"></i></a>
                    <a class="btn btn-minimize btn-round" href="#"><i class="icon-chevron-up"></i></a>
                    <a class="btn btn-close btn-round" href="#"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <form class="form-horizontal" runat="server">
                    <fieldset>
                        <div class="control-group">
                            <label for="focusedInput" class="control-label">游戏名</label>
                            <div class="controls">
                                <asp:TextBox runat="server" ID="gameName" CssClass="input-xlarge uneditable-input"></asp:TextBox>
                            </div>
                        </div>
                        <table>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label for="selectError3" class="control-label">现有服务器</label>
                                        <div class="controls">
                                            <asp:DropDownList runat="server" ID="DplAreaSelect" AutoPostBack="True" OnSelectedIndexChanged="dplArea_SelectedIndexChanged" >
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <div class="controls" style="margin-left: 0">
                                            <asp:DropDownList runat="server" ID="dplServers" />
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <asp:LinkButton runat="server" CssClass="btn btn-danger" Text="删除" OnClick="btnDelServer_Click"><i class="icon-trash icon-white"></i>删除选中服务器</asp:LinkButton>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group" style="margin-bottom: 0px">
                                        <label for="selectError3" class="control-label">添加新服务器</label>
                                        <div class="controls">
                                            <asp:DropDownList runat="server" ID="dplArea" />
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group" style="margin-bottom: 0">
                                        <div class="controls" style="margin-left: 0px">
                                            <asp:TextBox runat="server" CssClass="input-xlarge focused" ID="newServerName"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <asp:LinkButton runat="server" CssClass="btn btn-success" Text="添加新服务器" OnClick="ServerAdd_Click"><i class="icon icon-color icon-add icon-white"></i>添加新增服务器</asp:LinkButton></td>
                            </tr>
                        </table>
                    </fieldset>
                    <asp:HiddenField runat="server" ID="hidGameID" />
                </form>
            </div>
        </div>
        <!--/span-->
    </div>
</asp:Content>
