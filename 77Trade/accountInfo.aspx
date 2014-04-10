<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountInfo.aspx.cs" Inherits="_77Trade.accountInfo"  MasterPageFile="Common.Master" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <script src="Js/fileupload/jquery.ui.widget.js"></script>
    <script src="Js/fileupload/load-image.min.js"></script>
    <script src="Js/fileupload/canvas-to-blob.min.js"></script>
    <script src="Js/fileupload/bootstrap.min.js"></script>
    <script src="Js/fileupload/jquery.blueimp-gallery.min.js"></script>
    <script src="Js/fileupload/jquery.fileupload.js"></script>
    <script src="Js/fileupload/load-image.min.js"></script>
    <script src="Js/dataVerify.js"></script>
    <!-- header end -->
    <div class="con-main-middle" style="padding:0px">
        <div class="inner" style="overflow: hidden">
                    <div class="page-left">
                        <div class="c1">
                            <h3>交易指南</h3>
                            <ul>
                                <li class="bg2"><a href="#">购买流程</a></li>
                                <li><a href="#">出售流程</a></li>
                                <li class="bg2"><a href="#">发布交易</a></li>
                                <li><a href="#">如何取物</a></li>
                                <li class="bg2"><a href="#">如何提现</a></li>
                                <li><a href="#">我的七七交易</a></li>
                                <li class="bg2"><a href="#">关于登陆</a></li>
                                <li><a href="#">收费规则</a></li>
                            </ul>
                        </div>
                    </div>
                    <!-- left end -->
                    <div class="page-right">
                        <h3>账号信息</h3>
                        <div class="content" style="padding-top: 0px">
                            <div class="tips">请注意：七七交易网不会私下联系您核实帐号资料，请您不要将帐号资料提供给任何人，避免帐号被盗。</div>
                            <div class="info">
                                <form name="form1" method="post" id="form1" enctype="multipart/form-data" runat="server">

                                    <table border="0" width="100%" height="100%" style="border-collapse: collapse">
                                        <tr>
                                            <td width="30%" align="right"><strong>* 游戏选择：</strong></td>
                                            <td width="70%">
                                                <asp:DropDownList runat="server" ClientIDMode="Static" ID="gameName">
                                                    <asp:ListItem Text="请选择游戏"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList runat="server" ClientIDMode="Static" ID="gameArea">
                                                    <asp:ListItem Text="请选择区服"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList runat="server" ClientIDMode="Static" ID="gameServer">
                                                    <asp:ListItem Text="请选择服务器"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="30%" align="right"><strong>* 游戏帐号：</strong></td>
                                            <td width="70%">
                                                <asp:TextBox CssClass="form1" ClientIDMode="Static" ID="gameAccount" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong>* 游戏密码：</strong></td>
                                            <td>
                                                <asp:TextBox CssClass="form1" ClientIDMode="Static" ID="gamePwd" runat="server" TextMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong>* 再次确认游戏密码：</strong></td>
                                            <td>
                                                <asp:TextBox CssClass="form1" ClientIDMode="Static" ID="regamePwd" runat="server" TextMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong>* 游戏角色名：</strong></td>
                                            <td>
                                                <asp:TextBox CssClass="form1" ClientIDMode="Static" ID="gameRoleName" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong>* 身份证号码：</strong></td>
                                            <td>
                                                <asp:TextBox CssClass="form1 shenfen" ClientIDMode="Static" ID="identityCardID" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong>* QQ\手机：</strong></td>
                                            <td>
                                                <asp:TextBox CssClass="form1 mobile" ClientIDMode="Static" ID="qqOrMobile" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong>* 邮箱地址：</strong></td>
                                            <td>
                                                <asp:TextBox CssClass="form1" ClientIDMode="Static" ID="userEmail" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong>* 二级密码：</strong></td>
                                            <td>
                                                <asp:TextBox CssClass="form1" ClientIDMode="Static" ID="levelTwoPwd" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong>* 财产保护密码：</strong></td>
                                            <td>
                                                <asp:TextBox CssClass="form1" ClientIDMode="Static" ID="propertyPwd" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="30%" style="font-size: 14px; padding-top: 20px;" valign="top">游戏密保卡：</td>
                                            <td width="70%">
                                                <table>
                                                    <tr>
                                                        <td colspan="2" style="line-height: 24px; font-size: 14px;">
                                                            <table id="RadioButtonList1" border="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:RadioButton runat="server" ID="isNotBindSecretCard" Text="未绑定" GroupName="bindCard" Checked="true" ClientIDMode="Static"/></td>
                                                                    <td>
                                                                        <asp:RadioButton runat="server" ID="isBindSecretCard" Text="已绑定" GroupName="bindCard" ClientIDMode="Static"/></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr1" style="display: none">
                                                        <td align="right" width="40%" style="line-height: 24px; font-size: 14px;">密保卡序列号：</td>
                                                        <td width="60%">
                                                            <asp:TextBox runat="server" ID="txtSecretNo" ClientIDMode="Static" CssClass="form1"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr2" style="display: none">
                                                        <td colspan="2" style="line-height: 24px; font-size: 14px;">
                                                            <img id="Image3" alt="请确保上传的图片清晰完整" src="global/images/nopic.jpg" style="height: 180px; width: 180px; border: 1px solid #001627;" />

                                                        </td>
                                                    </tr>
                                                    <tr id="tr3" style="display: none">
                                                        <td colspan="2" style="line-height: 24px; font-size: 14px;">
                                                            <input type="file" name="FileSecretCard" id="secretCardImgUpload" style="width: 65px" />&nbsp &nbsp<span id="msgSecretCard">选择上传图片</span>&nbsp &nbsp &nbsp
                                                    <input type="button" name="Button6" value="上传" id="btnUploadSecretCard" style="height: 22px;" />
                                                            <input type="button" value="删除" id="btnSecretCardDelete" style="height: 22px;" />
                                                            <asp:HiddenField runat="server" Value="" ID="SecretCardImg"  ClientIDMode="Static"/>
                                                            <div style="font-size: 12px; margin: 10px 0; color: #ffe27e;">
                                                                如该游戏帐号已在游戏中绑定过密保卡，请上传密保卡信息。<br />
                                                                请确保上传的图片清晰完整；<br />
                                                                *图片尺寸请限在800*800px，大小不要超过1MB；<br />
                                                                *图片格式包括(jpg,gif,bmp)；<br />
                                                                *只允许上传一张。
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tr5" style="display: none">
                                            <td align="right" width="30%" style="line-height: 24px; font-size: 14px;"></td>
                                            <td width="70%"></td>
                                        </tr>
                                        <tr>
                                            <td align="right" width="30%" style="font-size: 14px;" valign="top">上传身份证：</td>
                                            <td width="70%">
                                                <table>
                                                    <tr>
                                                        <td style="line-height: 24px; font-size: 14px;">
                                                            <asp:CheckBox ID="bindIdentityCard" Checked="false" Text="使用身份证" ClientIDMode="Static" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp; 
							<div style="font-size: 12px; margin: 10px 0; color: #ffe27e;">上传注册该游戏帐号所使用的身份证，提高帐号安全等级，利于出售，交易成功后发至买家。</div>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr4" style="display: none">
                                                        <td>
                                                            <table>
                                                                <tr>
                                                                    <td style="font-size: 14px;">
                                                                        <img id="Image1" alt="身份证正面" src="global/images/card1.jpg" style="height: 180px; width: 180px; border: 1px solid #001627;" />
                                                                        <p style="margin-top: 12px;">
                                                                            <input name="ShenFenA" type="file" id="fileuploadIdentityA" style="width: 65px; height: 21px" />&nbsp &nbsp<span id="msgIdentityA">选择上传图片</span>&nbsp &nbsp &nbsp
                                                                    <input type="button" name="Button1" value="上传新图片" id="btnIdentityAUpload" style="height: 22px;" />
                                                                            <input type="button" name="Button7" value="删除" id="Button7" style="height: 22px;" />
                                                                            <asp:HiddenField runat="server" Value="" ID="identityImgA"  ClientIDMode="Static"/>
                                                                        </p>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table>
                                                                <tr>
                                                                    <td>
                                                                        <img id="Image2" alt="身份证反面" src="global/images/card2.jpg" style="height: 180px; width: 180px; border: 1px solid #001627;" />
                                                                        <p style="margin-top: 12px;">
                                                                            <input name="ShenFenB" type="file" id="fileupload" style="width: 65px; height: 21px" />&nbsp &nbsp<span id="msg">选择上传图片</span>&nbsp &nbsp &nbsp
                                                                    <input type="button" name="Button1" value="上传新图片" id="upBegin" style="height: 22px;" />
                                                                            <input type="button" name="Button7" value="删除" id="btnCancleShenB" style="height: 22px;" />
                                                                            <asp:HiddenField runat="server" Value="" ID="identityImgB" ClientIDMode="Static"/>
                                                                        </p>
                                                                        <div style="font-size: 12px; margin: 10px 0; color: #ffe27e;">单张图片需小于512KB，建议为400×250像素，支持jpg、gif、bmp、png格式。</div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right"><strong></strong></td>
                                            <td>
                                                <div>
                                                    <asp:Button runat="server" ID="btnSubmit" ClientIDMode="Static" Text="下一步，填写帐号信息" CssClass="btn" OnClick="btnSubmit_Click" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField runat="server" ID="accountInfoID" />
                                    <asp:HiddenField runat="server" ID="hiddenGameServer" ClientIDMode="Static"/>
                                </form>
                            </div>
                        </div>
                    </div>
                <div class="clear"></div>
            </div>
    </div>
    <!-- main end -->
    <script src="Js/AccountInfoPageJS.js"></script>
</asp:Content>
