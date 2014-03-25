<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Common.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="NetBar.OrderManager.OrderDetail" %>
<%@ Import Namespace="DataAccess.Model" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <ul class="breadcrumb">
            <li>
                <a href="#">订单管理</a> <span class="divider">/</span>
            </li>
            <li>
                <a href="#">订单详情</a>
            </li>
        </ul>
    </div>

    <div class="row-fluid sortable">
        <div class="box span12">
            <div class="box-header well" data-original-title>
                <h2><i class="icon-user"></i>订单详情</h2>
                <div class="box-icon">
                    <a href="#" class="btn btn-setting btn-round"><i class="icon-cog"></i></a>
                    <a href="#" class="btn btn-minimize btn-round"><i class="icon-chevron-up"></i></a>
                    <a href="#" class="btn btn-close btn-round"><i class="icon-remove"></i></a>
                </div>
            </div>
            <div class="box-content">
                <form class="form-horizontal" runat="server">
                    <fieldset>
                        <table>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">游戏名称：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.GameName %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">游戏区服：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.GameArea %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">服务器名：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.ServerName %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">联系手机：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.QQMobile %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">Email：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.Email %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">商品单价：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountDescription.Price %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">游戏帐号：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.GameAccount %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">游戏密码：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.GamePassword %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">密保卡序列号：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.SecretCardNo %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">身份证号：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountInfoModel.IdCardNo %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>

                                    <div class="control-group">
                                        <div class="controls">
                                            <% if (CurrentAccountInfoModel.SecretCardBind)
                                               { %>
                                            <img src="<%= CurrentAccountInfoModel.SecretCardImgUrl %>" title="密保卡" width="200px" height="200px" alt="密保卡" />
                                            <% }
                                               else
                                               {%>
                                            <img src="#" title="密保卡" width="200px" height="200px" alt="用户未上传" />
                                            <% } %>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <div class="controls" style="margin-left: 70px">
                                            <% if (CurrentAccountInfoModel.IdentityAuth)
                                               { %>
                                            <img src="<%= CurrentAccountInfoModel.IdentityCardAUrl %>" title="身份证A" width="200px" height="200px" alt="身份证A" />
                                            <img src="<%= CurrentAccountInfoModel.IdentityCardBUrl %>" title="身份证B" width="200px" height="200px" />
                                            <% }
                                               else
                                               {%>
                                            <img src="#" title="mibaoka" width="200px" height="200px" alt="用户未上传" />
                                            <img src="#" title="mibaoka" width="200px" height="200px" alt="用户未上传" />
                                            <% } %>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">商品属性：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountDescription.ProductProperty %></span>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">商品标题：</label>
                                        <div class="controls">
                                            <span class="input-xlarge uneditable-input"><%=CurrentAccountDescription.ProductTitle %></span>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div class="control-group">
                                        <label class="control-label">商品描述：</label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" TextMode="MultiLine" Width="790px" Height="190px" ID="textAreaProductDes"></asp:TextBox>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div class="controls">
                                        <img src="<%= CurrentAccountDescription.ProductImgAUrl %>" title="A" width="200px" height="200px" alt="身份证A" />
                                        <img src="<%= CurrentAccountDescription.ProductImgBUrl  %>" title="B" width="200px" height="200px" />
                                        <img src="<%= CurrentAccountDescription.ProductImgCUrl  %>" title="A" width="200px" height="200px" alt="身份证A" />
                                        <img src="<%= CurrentAccountDescription.ProductImgDUrl  %>" title="B" width="200px" height="200px" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <div class="control-group" id="shenHeRemark">
                            <label class="control-label">审核失败原因：</label>
                            <div class="controls">
                                <table>
                                    <tr>
                                        <td>
                                            <label class="checkbox" style="padding-left: 0px">
                                                <div class="checker" id="uniform-inlineCheckbox1">
                                                    <span class="checked">
                                                        <input type="checkbox" value="option1" msg="游戏帐号密码有误，请重新确认下游戏帐号密码是否正确。" id="inlineCheckbox1" style="opacity: 0;" /></span>
                                                </div>
                                                游戏帐号密码有误，请重新确认下游戏帐号密码是否正确。
                                            </label>
                                        </td>
                                        <td>
                                            <label class="checkbox" style="padding-left: 0px">
                                                <div class="checker" id="uniform-inlineCheckbox2">
                                                    <span class="checked">
                                                        <input type="checkbox" value="option1" msg="密保卡序列号，与上传密保卡图片不符。" id="inlineCheckbox2" style="opacity: 0;" /></span>
                                                </div>
                                                密保卡序列号，与上传密保卡图片不符。
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="checkbox" style="padding-left: 0px">
                                                <div class="checker" id="uniform-inlineCheckbox3">
                                                    <span class="checked">
                                                        <input type="checkbox" value="option1" msg="身份证号，与上传身份证图片不符。" id="inlineCheckbox3" style="opacity: 0;" /></span>
                                                </div>
                                                身份证号，与上传身份证图片不符。
                                            </label>
                                        </td>
                                        <td>
                                            <label class="checkbox" style="padding-left: 0px">
                                                <div class="checker" id="uniform-inlineCheckbox4">
                                                    <span class="checked">
                                                        <input type="checkbox" value="option1" msg="商品描述与所发布游戏帐号不符。" id="inlineCheckbox4" style="opacity: 0;" /></span>
                                                </div>
                                                商品描述与所发布游戏帐号不符。
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label class="checkbox" style="padding-left: 0px">
                                                <div class="checker" id="uniform-inlineCheckbox5">
                                                    <span class="checked">
                                                        <input type="checkbox" value="option1" msg="用户上游戏传帐号图片与游戏帐号不符。" id="inlineCheckbox5" style="opacity: 0;" /></span>
                                                </div>
                                                用户上游戏传帐号图片与游戏帐号不符。
                                            </label>
                                        </td>
                                        <td>
                                            <label class="checkbox" style="padding-left: 0px">
                                                <div class="checker" id="uniform-inlineCheckbox6">
                                                    <span class="checked">
                                                        <input type="checkbox" value="option1" msg="商品标题不合法。" id="inlineCheckbox6" style="opacity: 0;" /></span>
                                                </div>
                                                商品标题不合法。
                                            </label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <label class="checkbox" style="padding-left: 0px">
                                                <div class="checker" id="uniform-inlineCheckbox7">
                                                    <span class="checked">
                                                        <input type="checkbox" value="option1" msg="other" id="inlineCheckbox7" style="opacity: 0;" /></span>
                                                </div>
                                                其它原因
                                            </label>
                                            <textarea id="otherReason" style="height: 100px; width: 600px; display: none"></textarea>
                                        </td>
                                    </tr>
                                </table>
                                <%--<div style="clear: both"></div>--%>
                            </div>
                                                            <table><tr>
                                           <td>
                                                <div class="control-group">
                                                <label for="disabledInput" class="control-label">当前订单状态</label>
                                                <div class="controls">
                                                    <input type="text" disabled="" placeholder="<%=GetOrderStatusStr(CurrentAccountDescription.OrderStatus) %>" id="disabledInput" class="input-xlarge disabled">
                                                </div>
                                            </div>
                                           </td>
                                    <td>
                                         <label class="checkbox" style="padding-left: 87px;">
                                                <div class="checker" id="uniform-inlineCheckbox8">
                                                    <span class="checked">
                                                        <input type="checkbox" value="option1"  id="inlineCheckbox8" style="opacity: 0;" /></span>
                                                </div>
                                                是否自动加载下一张订单
                                            </label>
                                    </td>
                                       </tr></table>
                        </div>
                        <div class="form-actions">
                            <div id="ajaxLoader" style="padding-left: 270px; display: none">
                                <img title="操作进行中，请稍候..." src="/img/ajax-loaders/ajax-loader-7.gif" alt="操作进行中，请稍候..." />
                            </div>
                            <div id="actionDiv">
                                <a href="#" class="btn btn-success"><i class="icon  icon-color  icon-check icon-white"></i>审核通过</a>
                                <a href="#" class="btn btn-danger" style="margin-left: 620px"><i class="icon icon-color icon-close"></i>审核失败</a>
                            </div>
                        </div>
                    </fieldset>
                    <asp:HiddenField runat="server" ID="hiddenAccountInfoID" ClientIDMode="Static" />
                    <script type="text/javascript">
                        $(document).ready(function () {
                            //选择其它原因的checkbox时显示文本框
                            if ($("#inlineCheckbox7").attr("checked") == "checked") {
                                $("#otherReason").show();
                            }
                            $("#inlineCheckbox7").change(function () {
                                $("#otherReason").toggle();
                            });
                            //btn审核失败
                            $(".btn-danger").click(function () {
                                //检察是否选择了,失败原因
                                var checkedBox = $("#shenHeRemark input[type='checkbox']:checked").length;
                                if (checkedBox <= 0) {
                                    $(".modal-footer>.btn-primary").hide();
                                    $(".modal-body p").text("请选择失败原因！");
                                    $('#myModal').modal('show');
                                    return;
                                }
                                //检察是否选择了其它原因
                                if ($("#inlineCheckbox7").attr("checked") == "checked") {
                                    var otherContent = $("#otherReason").val();
                                    if (otherContent == "") {
                                        $(".modal-footer>.btn-primary").hide();
                                        $(".modal-body p").text("请填写失败原因！");
                                        $('#myModal').modal('show');
                                        return;
                                    }
                                }
                                //能过检察，发送修改订单状态，请求。
                                var desId = $("#hiddenAccountInfoID").val();
                                var errorMsg = GetErrorMsg();
                                //总结错误信息

                                $.ajax({
                                    data: { infoID: desId, errorContent: errorMsg, op: "refuse" },
                                    url: "/AjaxServer/AccountShenHe.ashx",
                                    dataType: "json",
                                    type: "post",
                                    beforeSend: function () {
                                        $("#actionDiv").hide();
                                        $("#ajaxLoader").show();
                                    },
                                    success: function (data) {
                                        if (data.Status == 10) {
                                            $(".modal-footer>.btn-primary").hide();
                                            $(".modal-body p").text("操作成功！");
                                            $('#myModal').modal('show');
                                            $("#actionDiv").show();
                                            $("#ajaxLoader").hide();
                                            $("#disabledInput").attr("placeholder", "审核失败");
                                        } else {
                                            $(".modal-footer>.btn-primary").hide();
                                            $(".modal-body p").text(data.ErrorMsg);
                                            $('#myModal').modal('show');
                                            $("#actionDiv").show();
                                            $("#ajaxLoader").hide();
                                        }
                                    },
                                    error: function () {
                                        $("#actionDiv").show();
                                        $("#ajaxLoader").hide();
                                        $(".modal-footer>.btn-primary").hide();
                                        $(".modal-body p").text("出错了，请重试！");
                                        $('#myModal').modal('show');
                                    }

                                });
                            });
                            //审核成功按钮
                            $(".btn-success").click(function () {
                                var desId = $("#hiddenAccountInfoID").val();
                                $.ajax({
                                    data: { infoID: desId, op: "commit" },
                                    url: "/AjaxServer/AccountShenHe.ashx",
                                    dataType: "json",
                                    type: "post",
                                    beforeSend: function () {
                                        $("#actionDiv").hide();
                                        $("#ajaxLoader").show();
                                    },
                                    success: function (data) {
                                        if (data.Status == 10) {
                                            $(".modal-footer>.btn-primary").hide();
                                            $(".modal-body p").text("操作成功！");
                                            $('#myModal').modal('show');
                                            $("#actionDiv").show();
                                            $("#ajaxLoader").hide();
                                            //更新订单状态
                                            $("#disabledInput").attr("placeholder","公示中");
                                        } else {
                                            $(".modal-footer>.btn-primary").hide();
                                            $(".modal-body p").text(data.ErrorMsg);
                                            $('#myModal').modal('show');
                                            $("#actionDiv").show();
                                            $("#ajaxLoader").hide();
                                        }
                                    },
                                    error: function () {
                                        $("#actionDiv").show();
                                        $("#ajaxLoader").hide();
                                        $(".modal-footer>.btn-primary").hide();
                                        $(".modal-body p").text("出错了，请重试！");
                                        $('#myModal').modal('show');
                                    }

                                });
                            });
                            //拼出错误信息
                            function GetErrorMsg() {
                                var msg = "";
                                $("#shenHeRemark input[msg][type='checkbox']:checked").each(function (i, element) {
                                    var message = $(this).attr("msg");
                                    if (message == "msg") {
                                        message = $("#otherReason").val();
                                    }
                                    msg += i + ". " + message + "<br/>";

                                });
                                return escape(msg);
                            }
                        });
                    </script>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
