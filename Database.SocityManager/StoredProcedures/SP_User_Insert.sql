CREATE PROCEDURE [dbo].[SP_User_Insert]
	@email NVARCHAR(384),
	@password NVARCHAR(32)
AS
	DECLARE @salt UNIQUEIDENTIFIER = NEWID()
	INSERT INTO [User] ([Email],[Salt],[Password])
	OUTPUT [Inserted].[Id]
	VALUES (@email, @salt,[dbo].[SF_Hash]([dbo].[SF_Salt](@password,@salt)))
GO
