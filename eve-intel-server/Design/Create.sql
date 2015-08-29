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

CREATE TABLE [CvaAllianceInfos] (
	[Id] INTEGER NOT NULL PRIMARY KEY,	
    [Type] TEXT NOT NULL,
    [Label] TEXT NOT NULL,
	[Icon] TEXT NOT NULL,    
	[Kos] BIT NOT NULL,
    [EveId] INTEGER NOT NULL,
	[Ticker] TEXT NOT NULL
);

CREATE TABLE [CvaCorporationInfos] (
	[Id] INTEGER NOT NULL PRIMARY KEY,	
    [Type] TEXT NOT NULL,
    [Label] TEXT NOT NULL,
	[Icon] TEXT NOT NULL,    
	[Kos] BIT NOT NULL,
    [EveId] INTEGER NOT NULL,
	[Ticker] TEXT NOT NULL,
    [Npc] BIT NOT NULL,
	[Alliance] INTEGER NULL,

	FOREIGN KEY([Alliance]) REFERENCES [CvaAllianceInfos](Id)    
);

CREATE TABLE [CvaCharacterInfos] (
	[Id] INTEGER NOT NULL PRIMARY KEY,	
    [Type] TEXT NOT NULL,
    [Label] TEXT NOT NULL,
	[Icon] TEXT NULL,    
	[Kos] BIT NULL,
    [EveId] INTEGER NOT NULL,
	[Corp] INTEGER NOT NULL,

	FOREIGN KEY([Corp]) REFERENCES [CvaCorporationInfos](Id)
);

CREATE TABLE [IntelData] (
	[Id] INTEGER NOT NULL PRIMARY KEY,	
    [Character] INTEGER NOT NULL,
    [ShipInfo] INTEGER NULL,
    [ShipInfoDate] DATE NULL,
    [ShipInfoConfirmed] BIT NOT NULL,
    [Solarsystem] INTEGER NULL,
    [SolarsystemDate] DATE NULL,

    FOREIGN KEY([Character]) REFERENCES [CvaCharacterInfos](Id),
    FOREIGN KEY([ShipInfo]) REFERENCES [EveShipInfos](Id),
    FOREIGN KEY([Solarsystem]) REFERENCES [EveMapSolarsystems](Id)
);