CREATE TABLE [dbo].[Local]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[Name] NVARCHAR(16) NOT NULL,
	[BuildingId] UNIQUEIDENTIFIER NOT NULL,
	[BuildingFloor] INT NOT NULL,
	[Surface] FLOAT NOT NULL,
	[HaveAirCo] BIT,
	[HaveProjector] BIT,
	[WorkStationCount] INTEGER NOT NULL,
	CONSTRAINT [PK_Local] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Local_Name] UNIQUE ([Name]),
	CONSTRAINT [CK_Local_Positives] CHECK ([Surface] > 0 AND [WorkStationCount] >=0),
	CONSTRAINT [FK_Local_Building] FOREIGN KEY ([BuildingId]) REFERENCES [Building]([Id])
)
