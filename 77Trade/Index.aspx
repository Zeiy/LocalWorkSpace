<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_77Trade.Index" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>首页</title>
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <link href="global/css/base.css" rel="stylesheet" />
    <link type="text/css" href="global/css/style.css" rel="stylesheet" />
    <script src="global/js/jquery.min.js" type="text/javascript"></script>
</head>
<body>
    <div class="header bg1 center">
        <div class="logo"><h1><a href="/" title="巨人网络">巨人网络</a></h1></div>
        <div class="clear"></div>
          <div class="nav">
            <ul>
                <li><a href="/Index.aspx">专区首页</a></li>
                <li><a href="#">求购查询</a></li>
                <li><a href="#">出售查询</a></li>
                <li><a href="/accountinfo.aspx">发布帐号</a></li>
                <li><a href="#">点卡查询</a></li>
                <li><a href="#">我的七七交易</a></li>
                <li style="background:none;"><a href="#">交易指南</a></li>
            </ul>
</div>
        <div class="clear"></div>
    </div>
    <div class="main">
        <!-- header end -->
        <div class="box">
            <!--<div class="tips"><span><a href="#">546564654</a> <a href="#">[更换用户]</a> <a href="#">[退出]</a></span>您当前参与抽奖的角色是：DorisHU [更换抽奖角色]</div>-->
            <div class="index">
                <ul>
                    <%foreach (var item in GameInfoList)
	{%>
                        <li><a href="ServerSelect.aspx?gameID=<%=item.ID %>"><img alt="<%=item.GameName %>" src="global/images/game_<%=item.ID %>.jpg" /></a></li>    
	<%} %>
                </ul>
            </div>
            <div class="clear"></div>
        </div>
        <!-- main end -->
    </div>
    <div class="footer">
        <div class="fl"><img src="global/images/foot_logo1.png" width="113" height="43" /> <img src="global/images/foot_logo2.png" width="140" height="43" /></div>
        <div class="fr"><p>京ICP备10014751号 京ICP证100162号&nbsp;  京网文[2011]0082-031号&nbsp; 电子商务经营者信息公示<br />Copyright &copy; 2010  北京易网合纵网络科技有限公司   All Rights Reserved   版权所有 不得转载</p></div>
    </div>
</body>
</html>
