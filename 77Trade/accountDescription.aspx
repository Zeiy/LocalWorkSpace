<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountDescription.aspx.cs" Inherits="_77Trade.accountDescription" %>
<%@ Register Src="~/UserControls/NavigateTop.ascx" TagPrefix="uc1" TagName="NavigateTop" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>账号信息2</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link type="text/css" href="global/css/style.css" rel="stylesheet" />
    <script src="global/js/jquery.min.js" type="text/javascript"></script>
    <!--[if IE 6]>
<script type="text/javascript" src="global/js/ie6_png.js"></script>
<script type="text/javascript">
DD_belatedPNG.fix(".header, bg");
DD_belatedPNG.fix(".logo h1, bg");
DD_belatedPNG.fix(".fl img");
</script>
<![endif]-->
    <script type="text/javascript">
        function radioShow() {
            var myradio = document.getElementsByName("radio");
            var div = document.getElementById("c").getElementsByTagName("div");
            for (i = 0; i < div.length; i++) {
                if (myradio[i].checked) {
                    div[i].style.display = "block";
                }
                else {
                    div[i].style.display = "none";
                }
            }
        }
    </script>
</head>
<body>
    <div class="header bg2 center">
        <div class="logo">
            <h1><a href="/" title="巨人网络">巨人网络</a></h1>
        </div>
        <div class="clear"></div>
        <uc1:NavigateTop runat="server" id="NavigateTop" />
        <div class="clear"></div>
    </div>
    <!-- header end -->

    <div class="main">
        <div class="box">
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
                <h3>添加帐号描述信息</h3>
                <div class="content">
                    <div class="tips">请务必正确填写以下信息，否则无法通过信息审核</div>
                    <div class="info2">
                        <form runat="server" method="post" enctype="multipart/form-data">
                            <table align="center" width="100%" cellspacing="10" cellpadding="5" border="0" style="margin-top: 0;" class="centfont">
                                <tbody>
                                    <tr>
                                        <td align="right" width="20%" style="line-height: 24px; font-size: 14px;">商品属性：</td>
                                        <td width="80%">
                                            <asp:TextBox ID="productProperty" CssClass="form1" ClientIDMode="Static" runat="server"></asp:TextBox>
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="20%" style="line-height: 24px; font-size: 14px;">商品标题：</td>
                                        <td width="80%"><strong>
                                              <asp:TextBox ID="productTitle" CssClass="form1" ClientIDMode="Static" runat="server"></asp:TextBox>
                                        </strong></td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="20%" style="line-height: 24px; font-size: 14px;">商品单价：</td>
                                        <td width="80%"><strong>
                                               <asp:TextBox ID="productPrice" CssClass="form1" ClientIDMode="Static" runat="server" width="80px"></asp:TextBox>
                                        </strong>元<span id="sxf" style="display: none"><span id="Label10"></span></span>
                                            （<span id="Label7">5</span>%手续费，最低收取<span id="Label8">5</span>元，最高收取<span id="Label9">1000</span>元）
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="20%" valign="top" style="line-height: 24px; font-size: 14px;">商品描述：</td>
                                        <td width="80%">
                                            <p style="color: #ffe27e">
                                                请您将不出售的商品转移出帐号，如未转移，则视为赠品一起赠送给买家。 为了您的交易安全，请不要在此留下任何联系方式。
                                            </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="20%" valign="top" style="line-height: 24px; font-size: 14px;"></td>
                                        <td width="80%">
                                            <asp:TextBox runat="server" CssClass="form2" Rows="2" Columns="20" ID="pdDescription" TextMode="MultiLine"></asp:TextBox>
                                    </tr>
                                    <tr>
                                        <td align="right" width="20%" style="line-height: 24px; font-size: 14px;">商品图片：</td>
                                        <td width="80%">
                                            <p style="color: #ffe27e;">上传图片，可以提高商品的关注度并利于出售。</p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center"></td>
                                        <td>

                                            <div style="margin-left: 10px;">
                                                <table width="509" style="border-collapse: collapse">
                                                    <tr>
                                                        <td height="190">
                                                            <img src="global/images/nopic2.gif" style="height: 180px; width: 180px; border: 1px solid #001627;" /></td>
                                                        <td>
                                                            <img src="global/images/nopic2.gif" style="height: 180px; width: 180px; border: 1px solid #001627;" /></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="35">
                                                            <input name="File1" type="file" id="File1" style="width: 138px; height: 21px" />
                                                            <input type="submit" name="Button1" value="上传" id="Button1" style="height: 22px;" />
                                                            <input type="submit" name="Button7" value="删除" id="Button7" style="height: 22px;" />
                                                        </td>
                                                        <td>
                                                            <input name="File1" type="file" id="File1" style="width: 135px; height: 21px" />
                                                            <input type="submit" name="Button1" value="上传" id="Button1" style="height: 22px;" />
                                                            <input type="submit" name="Button7" value="删除" id="Button7" style="height: 22px;" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td height="190">
                                                            <img src="global/images/nopic2.gif" style="height: 180px; width: 180px; border: 1px solid #001627;" /></td>
                                                        <td>
                                                            <img src="global/images/nopic2.gif" style="height: 180px; width: 180px; border: 1px solid #001627;" /></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="35">
                                                            <input name="File1" type="file" id="File1" style="width: 135px; height: 21px" />
                                                            <input type="submit" name="Button1" value="上传" id="Button1" style="height: 22px;" />
                                                            <input type="submit" name="Button7" value="删除" id="Button7" style="height: 22px;" />
                                                        </td>
                                                        <td>
                                                            <input name="File1" type="file" id="File1" style="width: 135px; height: 21px" />
                                                            <input type="submit" name="Button1" value="上传" id="Button1" style="height: 22px;" />
                                                            <input type="submit" name="Button7" value="删除" id="Button7" style="height: 22px;" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">
                                            <p style="color: #ffe27e">
                                                单张图片需小于512k，不能带有人物角色名，支持jpg、gif、bmp、png格式。
                                            </p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button Text="确认，提交审核" ID="btnSubmit" runat="server" CssClass="btn" OnClick="btnSubmit_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                                <asp:HiddenField ID="accountInfoID" runat ="server" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <!-- main end -->
    <div class="footer">
        <div class="fl">
            <img src="global/images/foot_logo1.png" width="113" height="43" />
            <img src="global/images/foot_logo2.png" width="140" height="43" /></div>
        <div class="fr">
            <p>
                京ICP备10014751号 京ICP证100162号&nbsp; 京网文[2011]0082-031号&nbsp; 
		电子商务经营者信息公示<br />
                Copyright © 2010 北京易网合纵网络科技有限公司 All Rights Reserved 
		版权所有 不得转载
            </p>
        </div>
    </div>
</body>
</html>
