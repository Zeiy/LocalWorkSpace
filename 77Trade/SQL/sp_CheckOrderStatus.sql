USE [NetBar]
GO
/****** Object:  StoredProcedure [dbo].[sp_CheckOrderStatus]    Script Date: 2014/4/8 10:19:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[sp_CheckOrderStatus]
(
@TimeLine int --订单还原的时间，用户下单后多久未支付开始还原订单 分钟为单位
)
as
--查到所有符合条件的主键ID，订单号
select AccountInfoID,ID,OrderNo into #table_tmpID from AccountDescription where  OrderStatus = 7 and DATEDIFF(minute,EditDate,getdate())>@TimeLine;
update AccountDescription set OrderStatus = 5 where ID in ( select ID from  #table_tmpID);
update AccountInfo set OrderStatus= 5 where OrderStatus = 7 and ID in (select AccountInfoID from #table_tmpID);
select * from #table_tmpID
drop table #table_tmpID