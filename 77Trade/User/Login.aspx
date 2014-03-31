<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_77Trade.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <div class="con-main-middle">
        <div class="inner" style="height: 450px">
            <div class="post-box">
                <img height="342" width="241" alt="" src="/style/images/demo/zt2.png" />
            </div>
            <form id="form1" runat="server" method="post">
                <div class="fill-list fill-list2">
                    <table>
                        <tbody>
                            <tr>
                                <td class="lab"></td>
                                <td>
                                    <div>
                                        会员登陆
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="lab">用户名：</td>
                                <td>
                                    <div>
                                        <asp:TextBox runat="server" Width="130px" ID="UserName"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="lab">密码：</td>
                                <td>
                                    <div>
                                        <asp:TextBox runat="server" ID="Password" Width="130px" TextMode="Password"></asp:TextBox>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="lab"></td>
                                <td>
                                    <div>
                                        <div class="btn-box">
                                            <asp:Button runat="server" CssClass="btn1-2" Text="登 陆" OnClick="Unnamed1_Click" />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="lab"></td>
                                <td>
                                    <div>
                                        <a href="/User/Register.aspx">立即注册</a><a href="#">密码找回</a>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
