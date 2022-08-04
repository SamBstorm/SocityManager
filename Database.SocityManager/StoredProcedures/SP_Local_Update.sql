CREATE PROCEDURE [dbo].[SP_Local_Update]
	@id UNIQUEIDENTIFIER,
	@name NVARCHAR(32),
	@buildingId UNIQUEIDENTIFIER,
	@buildingFloor INTEGER,
	@surface FLOAT,
	@haveAirCo BIT = NULL,
	@haveProjector BIT = NULL,
	@workstationCount INTEGER
AS
	UPDATE [Local]
	SET [Name] = @name,
		[BuildingId] = @buildingId,
		[BuildingFloor] = @buildingFloor,
		[Surface] = @surface,
		[HaveAirCo] = @haveAirCo,
		[HaveProjector] = @haveProjector,
		[WorkStationCount] = @workstationCount
	WHERE [Id] = @id
GO