CREATE PROCEDURE [dbo].[SP_Building_Insert]
	@name NVARCHAR(32),
	@number NVARCHAR(32),
	@street NVARCHAR(256),
	@city NVARCHAR(64),
	@zipcode NVARCHAR(8),
	@floorcount INT,
	@parkingcount INT
AS
	INSERT INTO [Building] ([Name],[Number],[Street],[City],[ZipCode],[FloorCount],[ParkingCount])
	OUTPUT [Inserted].[Id]
	VALUES (@name,@number,@street,@city,@zipcode,@floorcount,@parkingcount)
GO
