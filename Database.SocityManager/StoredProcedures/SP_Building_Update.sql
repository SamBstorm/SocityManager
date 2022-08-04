CREATE PROCEDURE [dbo].[SP_Building_Update]
	@id UNIQUEIDENTIFIER,
	@name NVARCHAR(32),
	@number NVARCHAR(32),
	@street NVARCHAR(256),
	@city NVARCHAR(64),
	@zipcode NVARCHAR(8),
	@floorcount INT,
	@parkingcount INT
AS
	UPDATE [Building]
	SET	[Name] = @name,
		[Number] = @number,
		[Street] = @street,
		[City] = @city,
		[ZipCode] = @zipcode,
		[FloorCount] = @floorcount,
		[ParkingCount] = @parkingcount
	WHERE [Id] = @id
GO
