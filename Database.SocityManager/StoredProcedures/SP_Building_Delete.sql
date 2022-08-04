CREATE PROCEDURE [dbo].[SP_Building_Delete]
	@id UNIQUEIDENTIFIER
AS
	DELETE FROM [Building]
	WHERE [Id] = @id
GO