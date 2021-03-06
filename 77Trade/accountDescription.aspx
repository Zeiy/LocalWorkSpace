﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountDescription.aspx.cs" Inherits="_77Trade.accountDescription" MasterPageFile="Common.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
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
    <script src="Js/fileupload/jquery.ui.widget.js"></script>
    <script src="Js/fileupload/jquery.fileupload.js"></script>
        <script src="Js/fileupload/load-image.min.js"></script>

    <div class="con-main-middle" style="padding: 0px">
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
                <h3>添加帐号描述信息</h3>
                <div class="content" style="padding-top: 0">
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
                                            <asp:TextBox ID="productPrice" CssClass="form1" ClientIDMode="Static" runat="server" Width="80px"></asp:TextBox>
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
                                            <asp:TextBox runat="server" ClientIDMode="Static" CssClass="form2" Rows="2" Columns="20" ID="pdDescription" TextMode="MultiLine"></asp:TextBox>
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
                                                            <img src="global/images/nopic2.gif" id="imggameImgA" style="height: 180px; width: 180px; border: 1px solid #001627;" /></td>
                                                        <td>
                                                            <img src="global/images/nopic2.gif" id="imggameImgB" style="height: 180px; width: 180px; border: 1px solid #001627;" /></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="35">
                                                            <input name="gameImg" type="file" id="gameImgA" style="width: 65px; height: 21px" />&nbsp &nbsp<span id="msgImgA">选择上传图片</span>&nbsp &nbsp &nbsp
                                                               <input type="button" name="Button1" value="上传" style="height: 22px;" />
                                                            <input type="button" name="Button7" value="删除" onclick="javascript: window.location.reload();" style="height: 22px; display: none" />
                                                            <asp:HiddenField runat="server" Value="" ID="hiddenimggameImgA" ClientIDMode="Static"/>
                                                        </td>
                                                        <td>
                                                            <input name="gameImg" type="file" id="gameImgB" style="width: 65px; height: 21px" />&nbsp &nbsp<span>选择上传图片</span>&nbsp &nbsp &nbsp
                                                               <input type="button" name="Button1" value="上传" style="height: 22px;" />
                                                            <input type="button" name="Button7" value="删除" onclick="javascript: window.location.reload();" style="height: 22px; display: none" />
                                                            <asp:HiddenField runat="server" Value="" ID="hiddenimggameImgB" ClientIDMode="Static"/>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td height="190">
                                                            <img src="global/images/nopic2.gif" id="imggameImgC" style="height: 180px; width: 180px; border: 1px solid #001627;" /></td>
                                                        <td>
                                                            <img src="global/images/nopic2.gif" id="imggameImgD" style="height: 180px; width: 180px; border: 1px solid #001627;" /></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="35">
                                                            <input name="gameImg" type="file" id="gameImgC" style="width: 65px; height: 21px" />&nbsp &nbsp<span>选择上传图片</span>&nbsp &nbsp &nbsp
                                                               <input type="button" name="Button1" value="上传" style="height: 22px;" />
                                                            <input type="button" name="Button7" value="删除" onclick="javascript: window.location.reload();" style="height: 22px; display: none" />
                                                            <asp:HiddenField runat="server" Value="" ID="hiddenimggameImgC" ClientIDMode="Static"/>
                                                        </td>
                                                        <td>
                                                            <input name="gameImg" type="file" id="gameImgD" style="width: 65px; height: 21px" />&nbsp &nbsp<span>选择上传图片</span>&nbsp &nbsp &nbsp
                                                               <input type="button" name="Button1" value="上传" style="height: 22px;" />
                                                            <input type="button" name="Button7" value="删除" onclick="javascript: window.location.reload();" style="height: 22px; display: none" />
                                                            <asp:HiddenField runat="server" Value="" ID="hiddenimggameImgD" ClientIDMode="Static" />
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
                                            <asp:Button Text="确认，提交审核" ID="btnSubmit" runat="server" ClientIDMode="Static" CssClass="btn" OnClick="btnSubmit_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <asp:HiddenField ID="accountInfoID" runat="server" ClientIDMode="Static"/>
                            <input type="hidden" id="currentUploadFileName"/>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="clear"></div>
    </div>

    <script type="text/javascript">
        //  
        var ErrorMsg = "";
        var myDate = new Date();
        //检察文件是否允许上传
        function CheckFile(fileData) {
            var filtType = fileData.type;
            var fileSize = fileData.size;
            if (filtType == "image/png" || filtType == "image/jpeg" || filtType == "image/bmp" || filtType == "image/png" || filtType == "image/jpg") {
                if (fileSize > 500000) {
                    ErrorMsg = "文件大小 不符合要求超过512K";
                    return false;
                }
                return true;
            } else {
                ErrorMsg = "文件类型不正确，只允许 jpg,png,bmp,jpeg类型的文件";
                return false;
            }
        };

        $(document).ready(function () {
            var randomCode = $("#hiddenRandCode").val();
            //:todo 标识每一个文件，便于Server端做检察 删除文件  动态参数传递出现问题，想办法在前端处理
            var currentFileType = $("#currentUploadFileName").val();
            $("#gameImgA,#gameImgB,#gameImgC,#gameImgD").fileupload({
                url: "services/fileSave.ashx",
                dataType: "json",
                formData: { sign: "gameImg", RandCode: randomCode, fileType: currentFileType },
                add: function (e, data) {
                    var checkRes = CheckFile(data.files[0]);
                    if (!checkRes) {
                        $(this).next("span").text("文件出错！");
                        alert("请检察文件类型跟文件大小是否符合要求！");
                        return;
                    }
                    $(this).next("span").text(data.fileInput[0].value);
                    //把当前不传文件名写入隐藏域
                    $("#currentUploadFileName").val($(this).attr("id"));
                    $(this).next().next().unbind();
                    data.context = $(this).next().next().click(function () {
                        $(this).prev("span").text("开始上传。。。");
                        data.submit();
                    });
                },
                done: function (e, data) {
                    if (data.result.Status == 1) {
                        //上传成功隐藏上传按钮
                        $(this).next().next().hide();
                        $(this).next("span").text("上传完成。。。");
                        var fileName = data.result.FileName;
                        var imgId = "img" + $(this).attr("id");
                        var hiddenId = "hidden" + imgId;
                        $("#" + imgId).attr("src", "/uploadfile/gameImg/" + fileName);
                        //把图片地址写入hidden field
                        $("#" + hiddenId).val("/uploadfile/gameImg/" + fileName);
                    } else if (data.result.Status == 2) {
                        $(this).next("span").text("请重试！");
                        alert("文件大小超出限制，请调整文件大小后重试！");
                    }
                },
                error: function (xhr) {
                    $(this).next("span").text(xhr.responseText);
                },
            });


            $("#btnSubmit").click(function() {
                if ($("#productProperty").val() == "") {
                    $("#productProperty").focus();
                    alert("商品属性名不能为空！");
                    return false;
                }
                if ($("productTitle").val() == "") {
                    $("productTitle").focus();
                    alert("商品标题不能为空！");
                    return false;
                }
                if ($("#productPrice").val() == "") {
                    $("#productPrice").focus();
                    alert("商品价格不能为空！");
                    return false;
                }
                if (!dataVerify.decimalPrice.test($("#productPrice").val())) {
                    alert("价格输入错误，请重新输入！");
                    $("#productPrice").focus();
                    return false;
                }
                if ($("#pdDescription").val() == "") {
                    alert("商品描述不能为空！");
                    return false;
                }
            });
        });

    </script>
</asp:Content>
