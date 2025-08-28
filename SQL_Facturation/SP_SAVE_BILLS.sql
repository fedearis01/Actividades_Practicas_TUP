-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Fede
-- Create date: 27/08
-- Description:	
-- =============================================
CREATE PROCEDURE SP_SAVE_BILLS 
	-- Add the parameters for the stored procedure here
	@id int, 
	@date date,
	@client varchar(40),
	@id_pm int
AS
BEGIN
	if
		@id = 0
		begin
		insert into Bills(date_b,client,id_pay_meth,Cancelled)
		values(@date,@client,@id_pm,0)
		end
	else
		update Bills 
		set date_b = @date,client = @client, id_pay_meth = @id_pm
		where id_bill = @id



END
GO
