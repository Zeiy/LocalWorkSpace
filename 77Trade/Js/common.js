$(document).ready(function() {
	// menu 切换
	positionMenuBg($(".menu .cur"));
	$(".menu li").hover(function() {
		positionMenuBg($(this));
	}, function() {
		positionMenuBg($(".menu .cur"));
	})
	if ("transform" in document.createElement("div").style || "-webkit-transform" in document.createElement("div").style) {
	    $(".menu .cur").addClass('scaletoorignal');
	}
	function positionMenuBg($self) {
		var lcw =  $self.width();
			if ($self.is(":first-child")) {
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
    $(".cntrl-bar .inner-pop a").click(function() {
        $(this).addClass('cur').siblings('.cur').removeClass('cur');
        $(this).parents(".pop-box").removeClass('extend').find('.name').html($(this).html());
        //把信息放入hiddenfiled 用来做筛选
        $("#hiddenAreaName").val($("#labelGameArea").text());
        $("#hiddenServerName").val($("#lableGameServer").text());
        //手动触发表单
        $("#mainForm").submit();
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
});