CREATE TABLE [dbo].[Building]
(
	[Id] UNIQUEIDENTIFIER NOT NULL DEFAULT NEWID(),
	[Name] NVARCHAR(32) NOT NULL,
	[Number] NVARCHAR(32) NOT NULL,
	[Street] NVARCHAR(256) NOT NULL,
	[City] NVARCHAR(64) NOT NULL,
	[ZipCode] NVARCHAR(8) NOT NULL,
	[FloorCount] INTEGER NOT NULL,
	[ParkingCount] INTEGER NOT NULL,
	CONSTRAINT [PK_Building] PRIMARY KEY ([Id]),
	CONSTRAINT [UK_Building_Name] UNIQUE ([Name]),
	CONSTRAINT [CK_Building_Positives] CHECK ([FloorCount] > 0 AND [ParkingCount] >=0)
)
