USE [eve-intel]
GO

CREATE TABLE [EveMapRegions] (
    [Id] INTEGER NOT NULL PRIMARY KEY,
    [Name] TEXT NOT NULL
);

CREATE TABLE [EveMapSolarsystems] (
    [Id] INTEGER NOT NULL PRIMARY KEY,
    [Region] INTEGER NOT NULL,
    [Name] TEXT NOT NULL,	
    
	FOREIGN KEY(Region) REFERENCES [EveMapRegions](Id)
);

CREATE TABLE [EveMapSolarsystemJumps] (
    [FromSolarsystem] INTEGER NOT NULL,
    [ToSolarsystem] INTEGER NOT NULL,

    PRIMARY KEY ([FromSolarsystem], [ToSolarsystem]),    
    FOREIGN KEY([FromSolarsystem]) REFERENCES [EveMapSolarsystems](Id),
    FOREIGN KEY([ToSolarsystem]) REFERENCES [EveMapSolarsystems](Id)    
);

CREATE TABLE [EveRaces] (
    [Id] INTEGER NOT NULL PRIMARY KEY,
    [Name] TEXT NOT NULL
);

CREATE TABLE [EveShipTypes] (
    [Id] INTEGER NOT NULL PRIMARY KEY,
    [Name] TEXT NOT NULL
);

CREATE TABLE [EveShipInfos] (
	[Id] INTEGER NOT NULL PRIMARY KEY,
    [ShipName] TEXT NOT NULL,
    [ShipType] INTEGER NOT NULL,
    [TechLevel] INTEGER NOT NULL,
    [Race] INTEGER NOT NULL,    
    
	FOREIGN KEY([ShipType]) REFERENCES [EveShipTypes](Id),
    FOREIGN KEY([Race]) REFERENCES [EveRaces](Id)
);

CREATE TABLE [EvePlayerInfos] (
	[Id] INTEGER NOT NULL PRIMARY KEY,	
    [PlayerName] TEXT NOT NULL,
    [IsKos] BIT NOT NULL,
	[ShipInfo] INTEGER NULL,    
	[ShipInfoTime] DATE NULL,
    [IsShipInfoConfirmed] BIT NOT NULL,
	[Solarsystem] INTEGER NULL,
	[SolarsystemTime] DATE NULL,

	FOREIGN KEY([ShipInfo]) REFERENCES [EveShipInfos](Id),
    FOREIGN KEY([Solarsystem]) REFERENCES [EveMapSolarsystems](Id)
);