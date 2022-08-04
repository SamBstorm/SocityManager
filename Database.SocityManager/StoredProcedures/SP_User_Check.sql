CREATE PROCEDURE [dbo].[SP_User_Check]
	@email NVARCHAR(384),
	@password NVARCHAR(32)
AS
	SELECT	[Id],
			[Email], 
			'*******' AS [Password]
	FROM [User]
	WHERE	[Email] = @email 
		AND [Password] = [dbo].[SF_Hash]([dbo].[SF_Salt](@password, [Salt]))
GO
