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
-- Create date: 8/9
-- Description:	
-- =============================================
CREATE PROCEDURE SP_SAVE_BILLSDETAILS 
	-- Add the parameters for the stored procedure here
	@id int = 0,
	@id_product int = 0, 
	@amount int = 0
AS
BEGIN
	if @id = 0
		begin
		insert into Details(id_product,amount)
		values (@id_product,@amount)
		end
	else
		update Details
		set id_product = @id_product, amount = @amount
		where id_detail = @id
END
GO
