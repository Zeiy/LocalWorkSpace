<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Common.Master" AutoEventWireup="true" CodeBehind="GameAdd.aspx.cs" Inherits="NetBar.ServerManager.GameAdd" %>

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
                <h2><i class="icon-edit"></i>添加新游戏</h2>
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
								<label for="focusedInput" class="control-label">添加新游戏</label>
								<div class="controls">
								    <asp:TextBox runat="server" ID="gameName" CssClass="input-xlarge focused"></asp:TextBox>
								</div>
							  </div>
                        <div class="form-actions">
                             <asp:LinkButton runat="server" CssClass="btn btn-success" Text="添加游戏" OnClick="Unnamed1_Click"><i class="icon icon-color icon-add icon-white"></i>添加新增服务器</asp:LinkButton>
                            <a href="/Index.aspx" class="btn btn-info"><i class="icon icon-color icon-undo icon-white"></i> 反回首页</a>
                        </div>
                    </fieldset>
                </form>
            </div>
        </div>
        <!--/span-->
    </div>
</asp:Content>
