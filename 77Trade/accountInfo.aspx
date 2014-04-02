<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accountInfo.aspx.cs" Inherits="_77Trade.accountInfo"  MasterPageFile="Common.Master" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <link href="style/style.css" rel="stylesheet" />
    <script src="Js/jquery-1.11.0.min.js"></script>
    <script src="Js/fileupload/jquery.ui.widget.js"></script>
    <%--    <script src="Js/fileupload/tmpl.min.js"></script>--%>
    <script src="Js/fileupload/load-image.min.js"></script>
    <script src="Js/fileupload/canvas-to-blob.min.js"></script>
    <script src="Js/fileupload/bootstrap.min.js"></script>
    <script src="Js/fileupload/jquery.blueimp-gallery.min.js"></script>
    <script src="Js/fileupload/jquery.fileupload.js"></script>
    <script src="Js/fileupload/jquery.fileupload-process.js"></script>
    <script src="Js/fileupload/jquery.fileupload-image.js"></script>
    <script src="Js/fileupload/jquery.fileupload-video.js"></script>
    <script src="Js/fileupload/jquery.fileupload-audio.js"></script>
    <%--    <script src="Js/fileupload/jquery.fileupload-ui.js"></script>--%>
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
                                                            <asp:TextBox runat="server" ID="txtSecretNo" CssClass="form1"></asp:TextBox>
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
                                                            <input type="button" name="Button12" value="删除" onclick="javascript: window.location.reload();" id="Button12" style="height: 22px;" />
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
                                                                            <input type="button" name="Button7" value="删除" id="Button7" onclick="javascript: window.location.reload();" style="height: 22px;" />
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
                                                                            <input type="button" name="Button7" value="删除" id="btnCancleShenB" onclick="javascript: window.location.reload();" style="height: 22px;" />
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
    <script type="text/javascript">
        $(document).ready(function () {
            //页面加载时如果用户有未完成订单渲染页面，如果密保卡号不为空，则把
            $("body").on("mouseover", ".newemail", function () { //鼠标经过提示Email时，高亮该条Email
                $(".newemail").css("background", "#FFF");
                $(this).css("background", "#CACACA");
                $(this).focus();
                nowid = $(this).index();
            }).on("click", ".newemail", function () { //鼠标点击Email时，文本框内容替换成该条Email，并删除提示层
                var newhtml = $(this).html();
                newhtml = newhtml.replace(/<.*?>/g, "");
                $("#userEmail").val(newhtml);
                $("#myemail").remove();
            });
            //验证用户输入
            dataVerify.BeginVerify();
            //是否使用密保卡切换
            var isBindSecretCard = $("#isBindSecretCard");
            var isNotBindSecretCard = $("#isNotBindSecretCard");
            isNotBindSecretCard.change(function () {
                $("#tr1").hide();
                $("#tr2").hide();
                $("#tr3").hide();
                $("#tr5").hide();
            });
            isBindSecretCard.change(function () {
                $("#tr1").show();
                $("#tr2").show();
                $("#tr3").show();
                $("#tr5").show();
            });
            //是否使用身份证
            var isBindIdentityCard = $("#bindIdentityCard");
            isBindIdentityCard.change(function () {
                $("#tr4").toggle();
            });

            //校验文件的错误信息
            var ErrorMsg = "";
            var myDate = new Date();
            //检察文件是否允许上传
            function CheckFile(fileData) {
                var filtType = fileData.type;
                var fileSize = fileData.size;
                if (filtType == "image/png" || filtType == "image/jpeg" || filtType == "image/bmp" || filtType == "image/png" || filtType == "image/jpg") {
                    if (fileSize > 600000) {
                        ErrorMsg = "文件大小 不符合要求超过512K";
                        return false;
                    }
                    return true;
                } else {
                    ErrorMsg = "文件类型不正确，只允许 jpg,png,bmp,jpeg类型的文件";
                    return false;
                }
            };
            //密保卡
            $('#secretCardImgUpload').fileupload({
                url: "services/fileSave.ashx?date=" + myDate.getMilliseconds(),
                formData: { sign: "FileSecretCard" },
                dataType: 'json',
                imageMaxWidth: 800,
                imageMaxHeight: 800,
                maxFileSize: 512,
                maxNumberOfFiles: 1,
                replaceFileInput: true,
                imageCrop: true,//强制裁剪图片
                acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
                singleFileUploads: false,
                limitMultiFileUploads: 1,
                add: function (e, data) {
                    var checkRes = CheckFile(data.files[0]);
                    if (!checkRes) {
                        $("#msgSecretCard").text("文件出错！");
                        alert(ErrorMsg);
                        data.files = null;
                        return;
                    }
                    //添加图片时在Data里判断文件信息，是否符合上传要求
                    $("#msgSecretCard").text(data.fileInput[0].value);
                    data.context = $("#btnUploadSecretCard").click(function () {
                        $("#msgSecretCard").text("开始上传。。。");
                        data.submit();
                        $(this).hide();
                    });
                    //临时解决用户重复选择文件上传问题，选择文件后隐藏input 控件
                    $('#secretCardImgUpload').hide();
                },
                done: function (e, data) {
                    if (data.result.Status == 1) {
                        //上传成功隐藏上传按钮
                        $("#btnUploadSecretCard").hide();
                        $("#msgSecretCard").text("上传完成。。。");
                        var fileName = data.result.FileName;
                        $("#Image3").attr("src", "/uploadfile/MiBaoKa/" + fileName);
                        //把图片地址写入隐藏域
                        $("#SecretCardImg").val("/uploadfile/MiBaoKa/" + fileName);
                    }
                },
                error: function (xhr, txt, error) {
                    $("#msgSecretCard").text(xhr.responseText);
                    alert(xhr.responseText + "Tset");
                },
                //complete: function () { alert("上传成功")}
            });

            //身份证A
            $('#fileuploadIdentityA').fileupload({
                url: "services/fileSave.ashx",
                dataType: 'json',
                formData: { sign: "ShenFenA" },
                imageMaxWidth: 800,
                imageMaxHeight: 800,
                maxFileSize: 512,
                maxNumberOfFiles: 1,
                imageCrop: true,//强制裁剪图片
                acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i,
                limitMultiFileUploads: 1,
                add: function (e, data) {
                    var checkRes = CheckFile(data.files[0]);
                    if (!checkRes) {
                        $("#msgIdentityA").text("文件出错！");
                        alert(ErrorMsg);
                        data.files = null;
                        return;
                    }
                    //添加图片时在Data里判断文件信息，是否符合上传要求
                    $("#msgIdentityA").text(data.fileInput[0].value);
                    data.context = $("#btnIdentityAUpload").click(function () {
                        $("#msgIdentityA").text("开始上传。。。");
                        data.submit();
                    });
                    //用户重复选择文件上传问题，选择文件后隐藏input 控件
                    $('#fileuploadIdentityA').hide();
                },
                done: function (e, data) {
                    if (data.result.Status == 1) {
                        $("#msgIdentityA").text("上传完成。。。");
                        //防止用户重复上传，隐藏上传按钮
                        $("#btnIdentityAUpload").hide();
                        var fileName = data.result.FileName;
                        $("#Image1").attr("src", "/uploadfile/ShenFenZheng/" + fileName);
                        //把图片地址写入隐藏域
                        $("#identityImgA").val("/uploadfile/ShenFenZheng/" + fileName);
                    }
                },
                error: function (xhr, txt, error) {
                    $("#msgIdentityA").text(xhr.responseText);
                    alert(xhr.responseText);
                },
                //complete: function () { alert("上传成功")}
            });

            //身份证B
            $('#fileupload').fileupload({
                url: "services/fileSave.ashx",
                dataType: 'json',
                formData: { sign: "ShenFenB" },
                maxFileSize: 512,
                maxNumberOfFiles: 1,
                limitConcurrentUploads: true,
                singleFileUploads: false,
                add: function (e, data) {
                    //添加图片时在Data里判断文件信息，是否符合上传要求
                    var msg;
                    var checkRes = CheckFile(data.files[0]);
                    if (!checkRes) {
                        $("#msg").text("文件出错！");
                        alert(ErrorMsg);
                        data.files = null;
                        return;
                    }
                    $("#msg").text(data.fileInput[0].value);
                    data.context = $("#upBegin").click(function () {
                        $("#msg").text("开始上传。。。");
                        data.submit();
                    });
                    //用户重复选择文件上传问题，选择文件后隐藏input 控件
                    $('#fileupload').hide();
                },
                done: function (e, data) {
                    if (data.result.Status == 1) {
                        var fileName = data.result.FileName;
                        $("#upBegin").hide();
                        $("#msg").text("上传完成。。。");
                        $("#Image2").attr("src", "/uploadfile/ShenFenZheng/" + fileName);
                        //把图片地址写入隐藏域
                        $("#identityImgB").val("/uploadfile/ShenFenZheng/" + fileName);
                    }
                },
                error: function (xhr, txt, error) {
                    $("#msg").text(xhr.responseText);
                    alert(xhr.responseText);
                }
                //complete: function () { alert("上传成功")}
            });

            //Email AutoComplete
            var nowid;
            var totalid;
            var can1press = false;
            var emailafter;
            var emailbefor;

            $("#userEmail").focus(function () { //文本框获得焦点，插入Email提示层  position:absolute;
                $("#myemail").remove();
                $(this).after("<div id='myemail' style='width:170px; height:auto; background:#fff; color:#6B6B6B; left:" + $(this).get(0).offsetLeft + "px; top:" + ($(this).get(0).offsetTop + $(this).height() + 2) + "px; border:1px solid #ccc;z-index:5px; '></div>");
                if ($("#myemail").html()) {
                    $("#myemail").css("display", "block");
                    $(".newemail").css("width", $("#myemail").width());
                    can1press = true;
                } else {
                    $("#myemail").css("display", "none");
                    can1press = false;
                }
            }).keyup(function () { //文本框输入文字时，显示Email提示层和常用Email
                var press = $("#userEmail").val();
                if (press != "" || press != null) {
                    var emailtxt = "";
                    var emailvar = new Array("@163.com", "@126.com", "@yahoo.com", "@qq.com", "@sina.com", "@gmail.com", "@hotmail.com", "@foxmail.com");
                    totalid = emailvar.length;
                    var emailmy = "<div class='newemail' style='width:170px; color:#6B6B6B; overflow:hidden;'><font color='#D33022'>" + press + "</font></div>";
                    if (!(isEmail(press))) {
                        for (var i = 0; i < emailvar.length; i++) {
                            emailtxt = emailtxt + "<div class='newemail' style='width:170px; color:#6B6B6B; overflow:hidden;'><font color='#D33022'>" + press + "</font>" + emailvar[i] + "</div>"
                        }
                    } else {
                        emailbefor = press.split("@")[0];
                        emailafter = "@" + press.split("@")[1];
                        for (var i = 0; i < emailvar.length; i++) {
                            var theemail = emailvar[i];
                            if (theemail.indexOf(emailafter) == 0) {
                                emailtxt = emailtxt + "<div class='newemail' style='width:170px; color:#6B6B6B; overflow:hidden;'><font color='#D33022'>" + emailbefor + "</font>" + emailvar[i] + "</div>";
                            }
                        }
                    }
                    $("#myemail").html(emailmy + emailtxt);
                    if ($("#myemail").html()) {
                        $("#myemail").css("display", "block");
                        $(".newemail").css("width", $("#myemail").width());
                        can1press = true;
                    } else {
                        $("#myemail").css("display", "none");
                        can1press = false;
                    }
                    beforepress = press;
                }
                if (press == "" || press == null) {
                    $("#myemail").html("");
                    $("#myemail").css("display", "none");
                }
            });
            $(document).click(function () { //文本框失焦时删除层
                if (can1press) {
                    $("#myemail").remove();
                    can1press = false;
                    if ($("#userEmail").focus()) {
                        can1press = false;
                    }
                }
            });
            /*因为绑定事件时母标签不存在，所以绑定失效
            $(".newemail").live("mouseover", function () { //鼠标经过提示Email时，高亮该条Email
                $(".newemail").css("background", "#FFF");
                $(this).css("background", "#CACACA");
                $(this).focus();
                nowid = $(this).index();
            }).live("click", function () { //鼠标点击Email时，文本框内容替换成该条Email，并删除提示层
                var newhtml = $(this).html();
                newhtml = newhtml.replace(/<.*?>/g, "");
                $("#userEmail").val(newhtml);
                $("#myemail").remove();
            });*/
            $(document).bind("keydown", function (e) {
                if (can1press) {
                    switch (e.which) {
                        case 38:
                            if (nowid > 0) {
                                $(".newemail").css("background", "#FFF");
                                $(".newemail").eq(nowid).prev().css("background", "#CACACA").focus();
                                nowid = nowid - 1;
                            }
                            if (!nowid) {
                                nowid = 0;
                                $(".newemail").css("background", "#FFF");
                                $(".newemail").eq(nowid).css("background", "#CACACA");
                                $(".newemail").eq(nowid).focus();
                            }
                            break;

                        case 40:
                            if (nowid < totalid) {
                                $(".newemail").css("background", "#FFF");
                                $(".newemail").eq(nowid).next().css("background", "#CACACA").focus();
                                nowid = nowid + 1;
                            }
                            if (!nowid) {
                                nowid = 0;
                                $(".newemail").css("background", "#FFF");
                                $(".newemail").eq(nowid).css("background", "#CACACA");
                                $(".newemail").eq(nowid).focus();
                            }
                            break;

                        case 13:
                            var newhtml = $(".newemail").eq(nowid).html();
                            newhtml = newhtml.replace(/<.*?>/g, "");
                            $("#userEmail").val(newhtml);
                            $("#myemail").remove();
                    }
                }
            });


            var serverSelect = $("#gameServer");
            $(serverSelect).change(function() {
                $("#hiddenGameServer").val($(this).val());
            });
            $("#btnSubmit").click(function() {
                $("#hiddenGameServer").val($("#gameServer").val());
            });
            //页面加载时，如果游戏已选择则加载服务器列表
            if ($("#gameName").val() != "请选择游戏") {
                $.ajax({
                    method: "post",
                    url: "/services/GetGameServerList.ashx",
                    data: { areaID: $("#gameArea").val(), gameId: $("#gameName").val() },
                    success: function (data) {
                        //更新服务器选择框
                        if (data.status == 1) {
                            $(serverSelect).html("");
                            if (data.ServerList.length <= 0) {
                                $(serverSelect).html("<option value=\"请选择游戏\" selected=\"selected\">服务器列表为空</option>");
                                return;
                            }
                            $(data.ServerList).each(function (e, serverList) {
                                //<option value="请选择服务器">请选择服务器</option>
                                var option = "<option value=\"" + serverList.ID + "\">" + serverList.ServerName + "</option>";
                                $(serverSelect).append(option);
                            });
                        }
                    },
                    error: function (data) {
                        $(serverSelect).html("<option value=\"error\" selected=\"selected\">" + data.errorMsg + "</option>");
                    }
                });
            }
            //游戏区服自动填充
            $("#gameName").change(function () {
                //用户选择游戏时，根据区服值，更新服务器列表
                $.ajax({
                    method: "post",
                    url: "/services/GetGameServerList.ashx",
                    data: { areaID: $("#gameArea").val(), gameId: $(this).val() },
                    success: function (data) {
                        //更新服务器选择框
                        if (data.status == 1) {
                            $(serverSelect).html("");
                            if (data.ServerList.length <= 0) {
                                $(serverSelect).html("<option value=\"请选择游戏\" selected=\"selected\">服务器列表为空</option>");
                                return;
                            }
                            $(data.ServerList).each(function (e, serverList) {
                                //<option value="请选择服务器">请选择服务器</option>
                                var option = "<option value=\"" + serverList.ID + "\">" + serverList.ServerName + "</option>";
                                $(serverSelect).append(option);
                            });
                        }
                    },
                    error: function (data) {
                        $(serverSelect).html("<option value=\"error\" selected=\"selected\">" + data.errorMsg + "</option>");
                    }
                });
                $(serverSelect).html("<option value=\"请选择游戏\" selected=\"selected\">读取中...</option>");
            });
            $("#gameArea").change(function () {
                //用户选择区服值时，根据游戏名，更新服务器列表，先检察游戏名是否已选择，如果游戏名未选择提醒用户先选择游戏名
                if ($("#gameName").val() == "请选择游戏") {
                    alert("请先选择游戏！");
                    return;
                }
                $.ajax({
                    method: "post",
                    url: "/services/GetGameServerList.ashx",
                    data: { areaID: $(this).val(), gameId: $("#gameName").val() },
                    success: function (data) {
                        //更新服务器选择框
                        if (data.status == 1) {
                            $(serverSelect).html("");
                            if (data.ServerList.length <= 0) {
                                $(serverSelect).html("<option value=\"请选择游戏\" selected=\"selected\">服务器列表为空</option>");
                                return;
                            }
                            $(data.ServerList).each(function (e, serverList) {
                                //<option value="请选择服务器">请选择服务器</option>
                                var option;
                                if (e == 0) {
                                    option = "<option selected=\"selected\" value=\"" + serverList.ID + "\">" + serverList.ServerName + "</option>";
                                } else {
                                    option = "<option value=\"" + serverList.ID + "\">" + serverList.ServerName + "</option>";
                                }
                                $(serverSelect).append(option);
                            });
                        }
                    },
                    error: function (data) {
                        $(serverSelect).html("<option value=\"error\" selected=\"selected\">" + data.errorMsg + "</option>");
                    }
                });
                $(serverSelect).html("<option value=\"请选择游戏\" selected=\"selected\">读取中...</option>");
            });
        });
        //检查email邮箱
        function isEmail(str) {
            if (str.indexOf("@") > 0) {
                return true;
            } else {
                return false;
            }
        }
    </script>
</asp:Content>
