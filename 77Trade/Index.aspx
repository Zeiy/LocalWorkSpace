<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="_77Trade.Index" MasterPageFile="Common.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="center" runat="server">
    <div class="con-main-middle" style="height: 550px">
                <!--<div class="tips"><span><a href="#">546564654</a> <a href="#">[更换用户]</a> <a href="#">[退出]</a></span>您当前参与抽奖的角色是：DorisHU [更换抽奖角色]</div>-->
                <div class="index">
                    <ul>
                        <%foreach (var item in GameInfoList)
                          {%>
                        <li><a href="ServerSelect.aspx?gameID=<%=item.ID %>">
                            <img alt="<%=item.GameName %>" src="global/images/game_<%=item.ID %>.jpg" /></a></li>
                        <%} %>
                    </ul>
                </div>
                <div class="clear"></div>
    </div>
</asp:Content>
