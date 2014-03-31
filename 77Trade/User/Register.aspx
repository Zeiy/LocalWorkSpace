<%@ Page Title="" Language="C#" MasterPageFile="~/Common.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="_77Trade.User.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <div class="con-main-middle" style="margin: auto">
        <div class="inner">
            <div style="margin: 0 250px">
            <form id="mainForm" runat="server">
                <table>
                    <tbody>
                        <tr>
                            <td align="center" colspan="2">用户注册</td>
                        </tr>
                        <tr>
                            <td class="lab">手机号码：</td>
                            <td>
                                <asp:TextBox runat="server" Width="150px" ID="userMobile" ClientIDMode="Static" CssClass=""></asp:TextBox><div>请使用您的手机号码注册为七七交易网帐号</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="lab">登录密码：</td>
                            <td>
                                <asp:TextBox runat="server" Width="150px" TextMode="Password" ClientIDMode="Static" ID="userPwd"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="lab">确认登录密码：</td>
                            <td>
                                <asp:TextBox runat="server" ID="rePwd" Width="150px" ClientIDMode="Static" TextMode="Password"></asp:TextBox><div>请使用8-20位数字字母，字母开头的字符</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="lab">支付密码：</td>
                            <td>
                                <asp:TextBox runat="server" Width="150px" ClientIDMode="Static" TextMode="Password" ID="payPwd"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="lab">确认支付密码：</td>
                            <td>
                                <asp:TextBox runat="server" Width="150px" ClientIDMode="Static" TextMode="Password" ID="rePayPwd"></asp:TextBox><div>登录密码和支付密码不能相同</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="lab">密保问题：</td>
                            <td>
                                <asp:DropDownList ID="secretQuestion" ClientIDMode="Static" runat="server">
                                    <asp:ListItem Selected="True">请选择密保问题</asp:ListItem>
                                    <asp:ListItem>您配偶的生日是？</asp:ListItem>
                                    <asp:ListItem>您的学号（或工号）是？</asp:ListItem>
                                    <asp:ListItem>您母亲的生日是？</asp:ListItem>
                                    <asp:ListItem>您高中班主任的名字是？</asp:ListItem>
                                    <asp:ListItem>您小学班主任的名字是？</asp:ListItem>
                                    <asp:ListItem>您父亲的生日是？</asp:ListItem>
                                    <asp:ListItem>您初中班主任的名字是？</asp:ListItem>
                                    <asp:ListItem>您最熟悉的童年好友名字是？</asp:ListItem>
                                    <asp:ListItem>您最熟悉的学校宿舍室友名字是？</asp:ListItem>
                                    <asp:ListItem>对您影响最大的人名字是？</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="lab">密保答案：</td>
                            <td>
                                <asp:TextBox runat="server" Width="264px" ID="secretAnswer" ClientIDMode="Static"></asp:TextBox><div>请填写答案字符不能超过10个</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="lab">电子邮箱：</td>
                            <td>
                                <asp:TextBox runat="server" ClientIDMode="Static" Width="150px" ID="userEmail" CssClass="email"></asp:TextBox><div>请填写您常用电子邮箱</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="lab"></td>
                            <td>
                                <asp:CheckBox runat="server" Checked="True" ClientIDMode="Static" Text="[同意协议内容]" ID="agreeMent" />
                            </td>
                        </tr>
                        <tr>
                            <td class="lab"></td>
                            <td>
                                <asp:Button runat="server" ID="btnSubmit" ClientIDMode="Static" Text="同意协议，我要完成注册" CssClass="btn1-4" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </form>
                </div>
        </div>
    </div>
    <script type="text/javascript">
        //页面加载完成后，加载JS对用户输入字段进行检察
        $(document).ready(function () {
            var userMobile = $("#userMobile");
            var userPwd = $("#userPwd");
            var userRePwd = $("#rePwd");
            var payPwd = $("#payPwd");
            var rePayPwd = $("#rePayPwd");
            var secretQuestion = $("#secretQuestion");
            var secretAnswer = $("#secretAnswer");
            var userEmail = $("#userEmail");
            //添加页面检察
            dataVerify.BeginVerify();
            $("#btnSubmit").click(function () {
                if (userMobile.val() == "") {
                    alert("用户手机号码不能为空！");
                    userMobile.next().css("color", "red");
                    userMobile.focus();
                    return false;
                } else {
                    userMobile.next().css("color", "white");
                }
                if (!dataVerify.regexMobli.test(userMobile.val())) {
                    alert("用户手机号码有误，请重新输！");
                    userMobile.next().css("color", "red");
                    userMobile.focus();
                    return false;
                } else {
                    userMobile.next().css("color", "white");
                }
                if (userPwd.val() == "") {
                    alert("用户密码不能为空！");
                    userPwd.focus();
                    return false;
                }
                if (!dataVerify.secretReg.test(userPwd.val())) {
                    alert("密码格式不正确，请重试！");
                    userPwd.focus();
                    userRePwd.next().css("color", "red");
                    return false;
                } else {
                    userRePwd.next().css("color", "white");
                }
                if (userPwd.val() != userRePwd.val()) {
                    alert("两次输入密码不一致，请重新输入！");
                    userRePwd.focus();
                    return false;
                }
                if (payPwd.val() == "") {
                    alert("用户支付密码不能为空！");
                    payPwd.focus();
                    return false;
                }
                if (payPwd.val() != rePayPwd.val()) {
                    alert("两次输入支付密码不一致，请重新输入！");
                    payPwd.focus();
                    return false;
                }
                if (userPwd.val() == payPwd.val()) {
                    alert("用户支付密码不能与登陆密码相同，请重新输入！");
                    $(rePayPwd).next().css("color", "red");
                    payPwd.focus();
                    return false;
                } else {
                    $(rePayPwd).next().css("color", "white");
                }
                if (secretQuestion.val() == "请选择密保问题") {
                    alert("请选择密保问题！");
                    secretQuestion.focus();
                    return false;
                }
                if (secretAnswer.val() == "") {
                    alert("密保答案不能为空！");
                    secretAnswer.focus();
                    return false;
                }
                if (secretAnswer.val().length > 10) {
                    alert("密保答案不能超过10个字符！");
                    secretAnswer.next().css("color", "red");
                    return false;
                } else {
                    secretAnswer.next().css("color", "white");
                }
                if (userEmail.val() == "") {
                    alert("用户邮箱不能为空！");
                    userEmail.focus();
                    return false;
                }
                if (!dataVerify.regexEmail.test(userEmail.val())) {
                    alert("用户邮箱格式不正确，请重新输入！");
                    userEmail.focus();
                    return false;
                }
                //if (!$("#agreeMent").attr("checked")==true) {
                //    alert("请选择同意协义！");
                //    return false;
                //}
            });
        });
    </script>
</asp:Content>
