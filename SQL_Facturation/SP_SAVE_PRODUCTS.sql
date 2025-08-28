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
CREATE PROCEDURE SP_SAVE_PRODUCTS 
	-- Add the parameters for the stored procedure here
	@id int, 
	@name varchar (40),
	@price float
AS
BEGIN
	if
		@id = 0
		begin
		insert into Products(n_prod,unit_price,active)
		values(@name,@price,1)
		end
	else
	begin
			update Products
			set n_prod = @name,unit_price = @price
			where id_product = @id
	end

END
GO
