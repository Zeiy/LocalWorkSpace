$(document).ready(function () {
    var gameName = $("#gameName");
    var gameServer = $("#gameServer");
    var gameAccount = $("#gameAccount");
    var gamePwd = $("#gamePwd");
    var regamePwd = $("#regamePwd");
    var gameRoleName = $("#gameRoleName");
    var identityCardId = $("#identityCardID");
    var qqOrMobile = $("#qqOrMobile");
    var userEmail = $("#userEmail");
    var levelTwoPwd = $("#levelTwoPwd");
    var propertyPwd = $("#propertyPwd");
    var isBindSecretCard = $("#isBindSecretCard");
    var bindIdentityCard = $("#bindIdentityCard");
    //是否使用密保卡切换
    var isNotBindSecretCard = $("#isNotBindSecretCard");
    var imgMibaokaContainer = $("#Image3");
    var imgShenFenZhengContainerA = $("#Image1");
    var imgShenFenZhengContainerB = $("#Image2");
    var btnMiBaoKaUpload = $("#btnUploadSecretCard");
    var btnShenFenZhengAUpload = $("#btnIdentityAUpload");
    var btnShenFenZhengBUpload = $("#upBegin");
    var btnDelMiBaoKa = $("#btnSecretCardDelete");
    var btnDelShenFenA = $("#Button7");
    var btnDelShenFenB = $("#btnCancleShenB");
    var hiddenRandomCode = $("#hiddenRandCode").val();
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
    var errorMsg = "";
    var myDate = new Date();
    //检察文件是否允许上传
    function checkFile(fileData) {
        var filtType = fileData.type;
        var fileSize = fileData.size;
        if (filtType == "image/png" || filtType == "image/jpeg" || filtType == "image/bmp" || filtType == "image/png" || filtType == "image/jpg") {
            if (fileSize > 600000) {
                errorMsg = "文件大小 不符合要求超过512K";
                return false;
            }
            return true;
        } else {
            errorMsg = "文件类型不正确，只允许 jpg,png,bmp,jpeg类型的文件";
            return false;
        }
    };
    //密保卡
    $('#secretCardImgUpload').fileupload({
        url: "services/fileSave.ashx?date=" + myDate.getMilliseconds(),
        formData: { sign: "FileSecretCard", RandCode: hiddenRandomCode },
        dataType: 'json',
        add: function (e, data) {
            if (imgMibaokaContainer.attr("src") != "global/images/nopic.jpg") {
                alert("请先删除已上传的图片");
                return;
            }
            var checkRes = checkFile(data.files[0]);
            if (!checkRes) {
                $("#msgSecretCard").text("文件出错！");
                alert(errorMsg);
                data.files = null;
                return;
            }
            $("#msgSecretCard").text(data.fileInput[0].value);
            //在添加绑定之前删除其它绑定
           btnMiBaoKaUpload.unbind();
            data.context = btnMiBaoKaUpload.click(function () {
                e.preventDefault();
                $("#msgSecretCard").text("开始上传。。。");
                data.submit();
            });
        },
        done: function (e, data) {
            if (data.result.Status == 1) {
                $("#msgSecretCard").text("上传完成。。。");
                var fileName = data.result.FileName;
                imgMibaokaContainer.attr("src", "/uploadfile/MiBaoKa/" + fileName);
                $("#SecretCardImg").val("/uploadfile/MiBaoKa/" + fileName);
                //上传完成后解绑事件
                btnMiBaoKaUpload.unbind();
            }
        },
        error: function (xhr) {
            $("#msgSecretCard").text(xhr.responseText);
            alert(xhr.responseText);
        }
    });

    //密保卡删除操作
    btnDelMiBaoKa.click(function () {
        var orginSrc = "global/images/nopic.jpg";
        var fileUrl = $("#Image3").attr("src");
        if (orginSrc == fileUrl) {
            alert("未上传图片");
            return;
        }
        var uploadFileName = fileUrl.split("/")[3];
        if (uploadFileName == "") {
            alert("没有找到用户上传的图片，请重试！");
        }
        $.ajax({
            type: "post",
            dataType: "json",
            url: "/services/filedelete.ashx",
            data: { FilleName: uploadFileName, FileType: "FileSecretCard" },
            success: function(data) {
                if (data.Status == 1) {
                    $("#Image3").attr("src", orginSrc);
                    $("#msgSecretCard").text("删除成功！");
                } else {
                    alert("删除文件失败，请刷新页面重试！");
                }
            }
        });

    });
    //身份证A
    $("#fileuploadIdentityA").fileupload({
        url: "services/fileSave.ashx",
        dataType: 'json',
        formData: { sign: "ShenFenA", RandCode: hiddenRandomCode },
        add: function (e, data) {
            if (imgShenFenZhengContainerA.attr("src") != "global/images/card1.jpg") {
                alert("请先处理已上传的图片！");
                return;
            }
            var checkRes = checkFile(data.files[0]);
            if (!checkRes) {
                $("#msgIdentityA").text("文件出错！");
                alert(errorMsg);
                data.files = null;
                return;
            }
            //添加图片时在Data里判断文件信息，是否符合上传要求
            $("#msgIdentityA").text(data.fileInput[0].value);
            //在添加绑定之前删除其它绑定
            btnShenFenZhengAUpload.unbind();
            data.context = btnShenFenZhengAUpload.click(function () {
                $("#msgIdentityA").text("开始上传。。。");
                data.submit();
            });
        },
        done: function (e, data) {
            if (data.result.Status == 1) {
                $("#msgIdentityA").text("上传完成。。。");
                var fileName = data.result.FileName;
                imgShenFenZhengContainerA.attr("src", "/uploadfile/ShenFenZheng/" + fileName);
                //把图片地址写入隐藏域
                $("#identityImgA").val("/uploadfile/ShenFenZheng/" + fileName);
                btnShenFenZhengAUpload.unbind();
            }
        },
        error: function (xhr) {
            $("#msgIdentityA").text(xhr.responseText);
            alert(xhr.responseText);
        }
    });
    //身份证A删除操作
    btnDelShenFenA.click(function () {
        var orginSrc = "global/images/card1.jpg";
        var fileUrl = imgShenFenZhengContainerA.attr("src");
        if (orginSrc == fileUrl) {
            alert("未上传图片");
            return;
        }
        var uploadFileName = fileUrl.split("/")[3];
        if (uploadFileName == "") {
            alert("没有找到用户上传的图片，请重试！");
        }
        $.ajax({
            type: "post",
            dataType: "json",
            url: "/services/filedelete.ashx",
            data: { FilleName: uploadFileName, FileType: "ShenFenA" },
            success: function (data) {
                if (data.Status == 1) {
                   imgShenFenZhengContainerA.attr("src", orginSrc);
                    $("#msgIdentityA").text("删除成功！");
                } else {
                    alert("删除文件失败，请刷新页面重试！");
                }
            }
        });

    });
    //身份证B
    $('#fileupload').fileupload({
        url: "services/fileSave.ashx",
        dataType: 'json',
        formData: { sign: "ShenFenB", RandCode: hiddenRandomCode },
        add: function (e, data) {
            //添加图片时在Data里判断文件信息，是否符合上传要求
            if (imgShenFenZhengContainerB.attr("src") != "global/images/card2.jpg") {
                alert("请先删除已上传的图片！");
                return;
            }
            var checkRes = checkFile(data.files[0]);
            if (!checkRes) {
                $("#msg").text("文件出错！");
                alert(errorMsg);
                data.files = null;
                return;
            }
            $("#msg").text(data.fileInput[0].value);
            //在添加绑定之前删除其它绑定
            btnShenFenZhengBUpload.unbind();
            data.context = btnShenFenZhengBUpload.click(function () {
                $("#msg").text("开始上传。。。");
                data.submit();
            });
        },
        done: function (e, data) {
            if (data.result.Status == 1) {
                var fileName = data.result.FileName;
                $("#msg").text("上传完成。。。");
                $("#Image2").attr("src", "/uploadfile/ShenFenZheng/" + fileName);
                //把图片地址写入隐藏域
                $("#identityImgB").val("/uploadfile/ShenFenZheng/" + fileName);
                btnShenFenZhengBUpload.unbind();
            }
        },
        error: function (xhr) {
            $("#msg").text(xhr.responseText);
            alert(xhr.responseText);
        }
    });

    //身份证B删除操作
    btnDelShenFenB.click(function () {
        var orginSrc = "global/images/card2.jpg";
        var fileUrl = imgShenFenZhengContainerB.attr("src");
        if (orginSrc == fileUrl) {
            alert("未上传图片");
            return;
        }
        var uploadFileName = fileUrl.split("/")[3];
        if (uploadFileName == "") {
            alert("没有找到用户上传的图片，请重试！");
        }
        $.ajax({
            type: "post",
            dataType: "json",
            url: "/services/filedelete.ashx",
            data: { FilleName: uploadFileName, FileType: "ShenFenB" },
            success: function (data) {
                if (data.Status == 1) {
                    imgShenFenZhengContainerB.attr("src", orginSrc);
                    $("#msg").text("删除成功！");
                } else {
                    alert("删除文件失败，请刷新页面重试！");
                }
            }
        });

    });

    //Email AutoComplete
    var nowid;
    var totalid;
    var can1Press = false;
    var emailafter;
    var emailbefor;

    $("#userEmail").focus(function () { //文本框获得焦点，插入Email提示层  position:absolute;
        $("#myemail").remove();
        $(this).after("<div id='myemail' style='width:170px; height:auto; background:#fff; color:#6B6B6B; left:" + $(this).get(0).offsetLeft + "px; top:" + ($(this).get(0).offsetTop + $(this).height() + 2) + "px; border:1px solid #ccc;z-index:5px; '></div>");
        if ($("#myemail").html()) {
            $("#myemail").css("display", "block");
            $(".newemail").css("width", $("#myemail").width());
            can1Press = true;
        } else {
            $("#myemail").css("display", "none");
            can1Press = false;
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
                can1Press = true;
            } else {
                $("#myemail").css("display", "none");
                can1Press = false;
            }
            beforepress = press;
        }
        if (press == "" || press == null) {
            $("#myemail").html("");
            $("#myemail").css("display", "none");
        }
    });
    $(document).click(function () { //文本框失焦时删除层
        if (can1Press) {
            $("#myemail").remove();
            can1Press = false;
            if ($("#userEmail").focus()) {
                can1Press = false;
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
        if (can1Press) {
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
    $(serverSelect).change(function () {
        $("#hiddenGameServer").val($(this).val());
    });
    $("#btnSubmit").click(function () {
        //校验数据
        if (gameName.val() == "请选择游戏") {
            alert("请选择游戏！");
            return false;
        }
        if (gameServer.val() == "请选择服务器") {
            alert("请选择服务器！");
            return false;
        }
        if (gameAccount.val() == "") {
            alert("请填写游戏帐号");
            gameAccount.focus();
            return false;
        }
        if (gamePwd.val() == "") {
            alert("用户密码不能为空！");
            gamePwd.focus();
            return false;
        }
        if (regamePwd.val() == "") {
            alert("请再次输入用户密码！");
            regamePwd.focus();
            return false;
        }
        if (gamePwd.val() != regamePwd.val()) {
            alert("用户两次输入密码不一致，请重新输入！");
            regamePwd.focus();
            return false;
        }
        if (gameRoleName.val() == "") {
            alert("游戏角色名不能为空！");
            gameRoleName.focus();
            return false;
        }
        if (identityCardId.val() == "") {
            alert("身份证号不能为空！");
            identityCardId.focus();
            return false;
        }
        if (qqOrMobile.val() == "") {
            alert("手机号码不能为空！");
            qqOrMobile.focus();
            return false;
        }
        if (userEmail.val() == "") {
            alert("用户邮件地址错误！");
            userEmail.focus();
            return false;
        }
        if (!isEmail(userEmail.val())) {
            alert("用户邮件地址错误！");
            userEmail.focus();
            return false;
        }
        if (levelTwoPwd.val() == "") {
            alert("用户二级密码不能为空！");
            levelTwoPwd.focus();
            return false;
        }
        if (propertyPwd.val() == "") {
            alert("用户财产密码不能为空！");
            propertyPwd.focus();
            return false;
        }
        if (isBindSecretCard[0].checked) {
            if ($("#txtSecretNo").val() == "") {
                $("#txtSecretNo").focus();
                alert("密保卡号，不能为空！");
                return false;
            }
            if ($("#SecretCardImg").val() == "") {
                alert("密保卡未上传");
                return false;
            }
        }
        if (bindIdentityCard.checked) {
            if ($("identityImgA").val() == "") {
                alert("身份证图片未上传");
                return false;
            }
            if ($("identityImgB").val() == "") {
                alert("身份证图片未上传");
                return false;
            }
        }
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