$(document).ready(function () {
    //用户退出
    $("#logOut").click(function() {
     /*    $.getJSON("/services/UserLogOut.ashx", function(data) {
             alert(data);
             alert("asdf");
         });    */
        $.ajax({
            url: '/services/UserLogOut.ashx',
            type: "post",
            dataType:"json",
            success: function(data) {
                if (data.Status == 1) {
                    window.location.href="/User/Login.aspx";
                }
            },
            error: function() {
                alert("Success");
            }
        });
    });
   





    //页面加载时根据url渲染主导航
    var currentPageUrl = window.location.toString().split("/")[3];
    //根据Url拿到须要渲染的Li元素
    var elementLi = $(".menu a[href=\"/" + currentPageUrl + "\"]").parent();
    if (elementLi.length == 0) {
        if (window.location.toString().split("/")[3] == "User") {
            elementLi = $(".menu li").eq(5);
        }
    }
    elementLi.addClass("cur").siblings().removeClass("cur");
    //重写Li中的元素
	// menu 切换
	positionMenuBg($(".menu .cur"));
    $(".menu li").hover(function() {
        positionMenuBg($(this));
    }, function() {
        positionMenuBg($(".menu .cur"));
    });
	if ("transform" in document.createElement("div").style || "-webkit-transform" in document.createElement("div").style) {
	    $(".menu .cur").addClass('scaletoorignal');
	}
	function positionMenuBg($self) {
	    var lcw = $self.width();
        //如果是IE
	    if (!$.support.leadingWhitespace) {
	        lcw -= 2;}
        //如果是第一个或是最后一个则添加圆角边框
	    if ($self.is(":first-child")) {
	        lcw = $self.is(".cur") ? 156 : 114;
				$(".menu .bg").css('border-radius', '3px 0 0 3px');
			}else if ($self.is(":last-child")) {
				lcw = $self.is(".cur") ? 146:114;
				$(".menu .bg").css({
					'border-radius': ' 0 3px 3px 0'
				});
			} else {
				$(".menu .bg").css('border-radius', '0');
			}
	    $(".menu .bg").stop().animate({ width: lcw, left: $self.position().left }, 200, function() {
	    });
	}
    /*
	// tab切换
	$(".tab-box .trigger a").click(function() {
		$(this).addClass('cur').siblings('.cur').removeClass('cur');
		$(".tab-box .tab-list .tabitem").eq($(this).index()).addClass('cur').siblings('.cur').removeClass('cur');
	});
           */
	// 双栏展开收起，切换
	$(".con-main-sider h3").click(function() {
		$(this).parent().toggleClass('extend');
	});
	$('.con-main-sider li').each(function(index, el) {
		$(this).click(function() {
			$(this).addClass('cur').siblings('.cur').removeClass('cur');
			$(".con-main-main .item").eq(index).addClass('cur').siblings('.cur').removeClass('cur');

		});
	});

	// 表格筛选控制
    $(".cntrl-bar div").click(function(e) {
        if ($(e.target).closest('.inner-pop').length) return true;
        $(this).toggleClass('extend').siblings('.extend').removeClass('extend');
    });
    //live 在新版本的Jq是失效问题
    $(".cntrl-bar .inner-pop").delegate("a","click", function () {
        $(this).addClass('cur').siblings('.cur').removeClass('cur');
        $(this).parents(".pop-box").removeClass('extend').find('.name').html($(this).html());
        //把信息放入hiddenfiled 用来做筛选
        $("#hiddenAreaName").val($("#labelGameArea").text());
        $("#hiddenServerName").val($("#lableGameServer").text());
        //手动触发表单
        //如果是用户选择大区，则不触发表单，用Ajax渲染服务器列表，如果是选择服务器才触发表单提交
        if ($(this).parent().prev().attr("ID") == "lableGameServer") {
            $("#mainForm").submit();
        } else {
            //发送请求更新服务器列表
            var gameName = $("#hiddenGameName").val();
            var areaName = $(this).text();
            var serverContain = $("#lableGameServer").next();
            $.ajax({
                url: "/services/GetGameServerList.ashx",
                data: { gameId: gameName, areaID: areaName,op:"name" },
                type: "post",
                dataType: "json",
                beforeSend: function() {
                    $("#lableGameServer").text("加载中.......");
                },
                success: function (data) {
                    if (data.status == 1) {
                        //清空原有数据
                        serverContain.empty();
                        $(data.ServerList).each(function (i, e) {
                            var serverEl = "<a>" + e.ServerName + "</a>";
                            $(serverEl).appendTo(serverContain);     
                        }   
                        );    
                        $("#lableGameServer").text("请选择服务器");
                    }
                },
                error: function() {
                    
                }
            });
        }     
    });

	// 时间弹出层
	var time = {};
	$(".time").click(function(e) {
		if ($(e.target).closest('.date_selector').length) return true;
		$(".date_selector").show();
		time.startcount = 1;
		time.endcount = 1;
	});
    window.onload = function() {
        $(".pop-box .date_selector").each(function(index, el) {
            if (index % 2 == 1) {
                $(this).css({
                    "left": "103px",
                    "border-left": " 0 none",
                    "padding-left": "2em"
                }).addClass('end');
            } else {
                $(this).css("left", "-117px").addClass('start');
            }
        });
    };
	$(document).on("click", ".date_selector td", function() {
		if ($(this).closest('.start').length) {
			if (time.startcount == 1)  time.startcount = 0;
			time.start = $(this).attr("date");
		}else {
			if (time.endcount == 1)  time.endcount = 0;
			time.end = $(this).attr("date");
		}

		if (time.endcount == 0 && time.startcount == 0) {
			$(".date_selector").hide();
			if (time.start > time.end) {
				t = time.start;
				time.start = time.end;
				time.end = t;
			}
			$(this).parents(".pop-box").removeClass('extend').find(".value").html(time.start + "至" + time.end);
			$("#hiddenTimeSpan").val(time.start + "至" + time.end);
		    //手动触发表单
			$("#mainForm").submit();
		}
	});


    //用户选择订单状态标签时触发表单提交
	$(".trigger>a[orderStatus]").click(function () {
	    var orderStatus = $(this).attr("orderStatus");
        //写入订单状态值，供筛选
	    $("#hiddenOrderStatus").val(orderStatus);
	    //手动触发表单
	    $("#mainForm").submit();
	});

    //AccountSaleList.aspx 页面tab选择卡渲染
	var currentOrderStatus = $("#hiddenOrderStatus").val();
	$(".trigger>a[orderStatus=" + currentOrderStatus + "]").addClass("cur").siblings().removeClass("cur");
    //AccountSaleList.aspx 页面单号，总价，日期排序 时更换箭头方向
    //当用户点击箭头按键时，把排序值写入隐藏域，手动提交表单。
	$(".table-box th span").click(function () {
	    var orderby = $(this).attr("ID");
	    if ($("#hiddenOrderBy").val() == orderby) {
	        $("#hiddenOrderBy").val(orderby+" desc");
	    } else {
	        $("#hiddenOrderBy").val(orderby);
	    }   
	    //手动触发表单
	    $("#mainForm").submit();
	});
    //页面加载时根据隐藏域的值，渲染
    $("#" + $("#hiddenOrderBy").val()).toggleClass("up");
});