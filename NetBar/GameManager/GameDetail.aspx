<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GameDetail.aspx.cs" Inherits="NetBar.GameManager.GameDetail" %>

<%@ Register Src="~/CommonUserControl/LeftNavigation.ascx" TagPrefix="uc1" TagName="LeftNavigation" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>管理页面</title>
    <!-- 调用CSS，JS -->
    <link href="/images/style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        <!--
        body {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            font-family: "宋体";
            font-size: 12px;
            color: #333333;
            background-color: #2286C2;
        }
        -->
    </style>
</head>
<body>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="74" colspan="2" background="/images/index1_03.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="33%" rowspan="2">
                            <img src="/images/index1_01.gif" width="253" height="74" /></td>
                        <td width="6%" rowspan="2">&nbsp;</td>
                        <td width="61%" height="38" align="right">
                            <table width="120" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="center">
                                        <img src="/images/index1_06.gif" width="16" height="16" /></td>
                                    <td align="center" class="font2"><a href="#" class="font2"><strong>帮助</strong></a></td>
                                    <td align="center">
                                        <img src="/images/index1_08.gif" width="16" height="16" /></td>
                                    <td align="center" class="font2"><a href="#" class="font2"><strong>退出</strong></a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td align="right" class="font2"><a href="#">
                                        <img src="/images/index1_13.gif" width="84" height="24" border="0" align="absmiddle" /></a>&nbsp;|&nbsp;登陆用户：吴登龙&nbsp;|&nbsp;身份：管理员&nbsp;|&nbsp;界面风格：<a href="#"><img src="/images/index1_16.gif" width="48" height="24" border="0" align="absmiddle" /></a>&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table width="100%" border="0" cellspacing="10" cellpadding="0">
                    <tr>
                        <td width="10%" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="8" height="8">
                                        <img src="/images/index1_23.gif" width="8" height="29" /></td>
                                    <td width="99%" background="/images/index1_24.gif"></td>
                                    <td width="8" height="8">
                                        <img src="/images/index1_26.gif" width="8" height="29" /></td>
                                </tr>
                                <tr>
                                    <td background="/images/index1_45.gif"></td>
                                    <td bgcolor="#FFFFFF" style="padding: 0 2px 0 2px; vertical-align: top; height: 500px;">
                                        <uc1:LeftNavigation runat="server" ID="LeftNavigation" />
                                    </td>
                                    <td background="/images/index1_47.gif"></td>
                                </tr>
                                <tr>
                                    <td width="8" height="8">
                                        <img src="/images/index1_91.gif" width="8" height="8" /></td>
                                    <td background="/images/index1_92.gif"></td>
                                    <td width="8" height="8">
                                        <img src="/images/index1_93.gif" width="8" height="8" /></td>
                                </tr>
                            </table>
                        </td>
                        <td width="70%" valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="8" height="8">
                                        <img src="/images/index1_28.gif" width="8" height="39" /></td>
                                    <td width="99%" background="/images/index1_40.gif">
                                        <table border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table width="90" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="5">
                                                                <img src="/images/index1_35.gif" width="5" height="39" /></td>
                                                            <td align="center" background="/images/index1_36.gif"><a href="#" class="font3"><strong>订单管理</strong></a></td>
                                                            <td width="5">
                                                                <img src="/images/index1_38.gif" width="5" height="39" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table width="80" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="5">
                                                                <img src="/images/index1_29.gif" width="5" height="39" /></td>
                                                            <td align="center" background="/images/index1_30.gif"><a href="#" class="font2"><strong>用户管理</strong></a></td>
                                                            <td width="5">
                                                                <img src="/images/index1_33.gif" width="5" height="39" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table width="80" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="5">
                                                                <img src="/images/index1_29.gif" width="5" height="39" /></td>
                                                            <td align="center" background="/images/index1_30.gif"><a href="#" class="font2"><strong>发件箱</strong></a></td>
                                                            <td width="5">
                                                                <img src="/images/index1_33.gif" width="5" height="39" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td>
                                                    <table width="80" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="5">
                                                                <img src="/images/index1_29.gif" width="5" height="39" /></td>
                                                            <td align="center" background="/images/index1_30.gif"><a href="#" class="font2"><strong>草稿箱</strong></a></td>
                                                            <td width="5">
                                                                <img src="/images/index1_33.gif" width="5" height="39" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="8" height="8">
                                        <img src="/images/index1_43.gif" width="8" height="39" /></td>
                                </tr>
                                <tr>
                                    <td background="/images/index1_45.gif"></td>
                                    <td bgcolor="#FFFFFF" style="height: 490px; vertical-align: top;">
                                        <table width="100%" border="0" cellspacing="10" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#C4E7FB">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellpadding="0" cellspacing="5" bgcolor="#FFFFFF">
                                                                    <tr>
                                                                        <td>&nbsp;<a href="#" class="font1">首页</a> &gt; <a href="#" class="font1">游戏管理</a> &gt; <a href="#" class="font1"><strong>游戏详情</strong></a></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <form runat="server" method="post">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#BBD3EB">
                                                            <tr>
                                                                <td height="26" align="center"   background="/images/index1_72.gif">游戏名：</td>
                                                                <td height="26" align="left" bgcolor="#FFFFFF"><asp:TextBox runat="server" ID="gameName"></asp:TextBox></td>
                                                            </tr>
                                                                   <tr>
                                                                <td height="26" align="center"   background="/images/index1_72.gif">现有区服：</td>
                                                                <td height="26" align="left" bgcolor="#FFFFFF">
                                                                    <asp:DropDownList runat="server" ID="dplArea" AutoPostBack="True" OnSelectedIndexChanged="dplArea_SelectedIndexChanged"><asp:ListItem Text="选择区服"></asp:ListItem></asp:DropDownList>
                                                                    <asp:DropDownList runat="server" ID="dplServers"><asp:ListItem Text="服务器名"></asp:ListItem> </asp:DropDownList>
                                                                    <asp:Button runat="server" ID="btnDelServer" Text="删除区服" OnClick="btnDelServer_Click" />
                                                                </td>
                                                            </tr>
                                                              <tr>
                                                                <td height="26" align="center"   background="/images/index1_72.gif">添加区服：</td>
                                                                <td height="26" align="left" bgcolor="#FFFFFF">
                                                                    <asp:DropDownList runat="server" ID="DplAreaSelect"><asp:ListItem Text="网通大区"></asp:ListItem></asp:DropDownList>
                                                                    <asp:TextBox ID="newServerName" runat="server" Width="90px"></asp:TextBox>
                                                                    <asp:Button runat="server" Text="添加区服" ID="ServerAdd" OnClick="ServerAdd_Click" /></td>
                                                            </tr>
                                                      
                                                        </table>
                                                            <asp:HiddenField ID="hidGameID" runat="server"/>
                                                    </form>
                                                </td>
                                            </tr>
                                            <tr>
                                              <%--  <td><a href="#">
                                                    <img src="/images/index1_86.gif" width="74" height="31" border="0" /></a>&nbsp;<a href="#"><img src="/images/index1_82.gif" width="74" height="31" border="0" /></a>&nbsp;<a href="#"><img src="/images/index1_84.gif" width="74" height="31" border="0" /></a></td>--%>
                                            </tr>
                                        </table>
                                    </td>
                                    <td background="/images/index1_47.gif"></td>
                                </tr>
                                <tr>
                                    <td width="8" height="8">
                                        <img src="/images/index1_91.gif" width="8" height="8" /></td>
                                    <td background="/images/index1_92.gif"></td>
                                    <td width="8" height="8">
                                        <img src="/images/index1_93.gif" width="8" height="8" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>


