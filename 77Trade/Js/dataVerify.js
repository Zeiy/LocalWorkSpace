var dataVerify = {
    //    JQuery
    //手机号码
    regexMobli: /^[1][358][0-9]{9}$/,
    mobileClassName: "mobile",
    alertMsg: "手机号码有误，请重新输入！",
    //身份证18位
    regexShenFenZheng: /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{4}$/,
    //身份证15位
    regexShenFenSec: /^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$/,
    shenFengClassName: "shenfen",
    alertShenFenMsg: "输入的身份证号码有误，请重新输入！",
    //电子邮箱
    regexEmail: /[a-z0-9-]{1,30}@[a-z0-9-]{1,65}.[a-z]{3}/,
    emailClassName: "email",
    alertEmailMsg: "邮件输入 有误，请重新输入！",
    BeginVerify: function () {
        $("input").blur(function () {
            var valueInput = $(this).val();
            if ($(this).hasClass(dataVerify.shenFengClassName)) {
                if (dataVerify.regexShenFenZheng.test(valueInput) || dataVerify.regexShenFenSec.test(valueInput)) {
                    //alert("验证通过");
                } else {
                    alert(dataVerify.alertShenFenMsg);
                }
            }
            if ($(this).hasClass(dataVerify.mobileClassName)) {
                if (dataVerify.regexMobli.test(valueInput)) {
                    //验证通过
                } else {
                    alert(dataVerify.alertMsg);
                }
            }
            if ($(this).hasClass(dataVerify.emailClassName)) {
                if (dataVerify.regexEmail.test(valueInput)) {
                    //通过
                } else {
                    alert(dataVerify.alertEmailMsg);
                }
            }
        });
    }
}