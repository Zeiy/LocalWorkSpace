<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Common.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="NetBar.OrderManager.OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul class="breadcrumb">
            <li>
                <a href="#">订单管理</a> <span class="divider">/</span>
            </li>
            <li>
                <a href="#">订单详情</a>
            </li>
        </ul>
    </div>

    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header well" data-original-title>
                <h2><i class="icon-user"></i>订单详情</h2>
                <div class="box-icon">
                    <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                    <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                    <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <form class="form-horizontal" runat="server">
                    <fieldset>
                        <table>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">游戏名称：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.GameName %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">游戏区服：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.GameArea %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">服务器名：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.ServerName %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">联系手机：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.QQMobile %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">Email：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.Email %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">身份证号：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.IdCardNo %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">游戏帐号：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.GameAccount %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">游戏密码：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.GamePassword %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">密保卡序列号：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.SecretCardNo %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">身份证号：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.IdCardNo %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <div class="control-group">
                                        <label class="control-label">密保卡图片：</label>
                                        <div class="controls">
                                            <% if (CurrentAccountInfoModel.SecretCardBind)
                                               { %>
                                            <img src="<%= CurrentAccountInfoModel.SecretCardImgUrl %>" title="密保卡" width="200px" height="200px" alt="密保卡" />
                                            <% }
                                               else
                                               {%>
                                            <img src="#" title="密保卡" width="200px" height="200px" alt="用户未上传" />
                                            <% } %>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">身份证图片：</label>
                                        <div class="controls">
                                            <% if (CurrentAccountInfoModel.IdentityAuth)
                                               { %>
                                            <img src="<%= CurrentAccountInfoModel.IdentityCardAUrl %>" title="身份证A" width="200px" height="200px" alt="身份证A" />
                                            <img src="<%= CurrentAccountInfoModel.IdentityCardBUrl %>" title="身份证B" width="200px" height="200px" />
                                            <% }
                                               else
                                               {%>
                                            <img src="#" title="mibaoka" width="200px" height="200px" alt="用户未上传" />
                                            <img src="#" title="mibaoka" width="200px" height="200px" alt="用户未上传" />
                                            <% } %>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <div class="control-group">
                            <label for="DplOrderStatus" class="control-label">订单状态</label>
                            <div class="controls">
                                <asp:DropDownList runat="server" ID="DplOrderStatus" />
                            </div>
                        </div>

                        <div class="form-actions">
                            <asp:Button runat="server" Text="修改订单状态" CssClass="btn btn-primary" OnClick="Unnamed1_Click" />
                            <asp:Button runat="server" Text="返回" CssClass="btn" OnClick="btnSave_Click" ID="btnSave" />
                        </div>
                    </fieldset>
                    <asp:HiddenField runat="server" ID="hiddenAccountInfoID" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
