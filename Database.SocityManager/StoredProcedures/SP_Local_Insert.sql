CREATE PROCEDURE [dbo].[SP_Local_Insert]
	@name NVARCHAR(32),
	@buildingId UNIQUEIDENTIFIER,
	@buildingFloor INTEGER,
	@surface FLOAT,
	@haveAirCo BIT = NULL,
	@haveProjector BIT = NULL,
	@workstationCount INTEGER
AS
	INSERT INTO [Local]([Name],[BuildingId],[BuildingFloor],[Surface],[HaveAirCo],[HaveProjector],[WorkStationCount])
	OUTPUT [inserted].[Id]
	VALUES (@name, @buildingId, @buildingFloor, @surface, @haveAirCo, @haveProjector, @workstationCount)
GO
