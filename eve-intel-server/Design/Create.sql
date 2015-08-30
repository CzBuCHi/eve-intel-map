USE [eve-intel]
GO

/* ships static data */
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

INSERT INTO [EveRaces] VALUES (0,'Amarr'),(1,'Caldari'),(2,'Faction'),(3,'Gallente'),(4,'Minmatar'),(5,'ORE'),(6,'Special Edition');

INSERT INTO [EveShipTypes] VALUES (0,'Assault Frigate'),(1,'Battlecruiser'),(2,'Attack Battlecruiser'),(3,'Battleship'),(4,'Black Ops'),(5,'Capital Industrial Ship'),(6,'Carrier'),(7,'Command Ship'),(8,'Covert Ops'),(9,'Cruiser'),(10,'Destroyer'),(11,'Dreadnought'),(12,'Electronic Attack Frigate'),(13,'Exhumer Barge'),(14,'Exploration Frigate'),(15,'Faction Battleship'),(16,'Faction Cruiser'),(17,'Faction Frigate'),(18,'Faction Shuttle'),(19,'Force Recon'),(20,'Frigate'),(21,'Heavy Assault Cruiser'),(22,'Heavy Interdictor'),(23,'Industrial Ship'),(24,'Interceptor'),(25,'Interdictor'),(26,'Jump Freighter'),(27,'Logistics Cruiser'),(28,'Marauder'),(29,'Mining Barge'),(30,'Recon Ship'),(31,'Rookie Ship'),(32,'Special Edition Battlecruiser'),(33,'Stealth Bomber'),(34,'Strategic Cruiser'),(35,'Tactical Destroyer'),(36,'Titan'),(37,'Transport Ship');

INSERT INTO [EveShipInfos] VALUES (0,'Abaddon',3,1,0),(1,'Absolution',7,2,0),(2,'Aeon',6,1,0),(3,'Algos',10,1,3),(4,'Anathema',8,2,0),(5,'Anshar',26,2,3),(6,'Apocalypse',3,1,0),(7,'Apocalypse Navy Issue',15,1,2),(8,'Apocalypse Imperial Issue',15,1,2),(9,'Apotheosis',18,1,2),(10,'Arazu',30,2,3),(11,'Arbitrator',9,1,0),(12,'Archon',6,1,0),(13,'Ares',24,2,3),(14,'Ark',26,2,0),(15,'Armageddon',3,1,0),(16,'Ashimmu',16,1,2),(17,'Astarte',7,2,3),(18,'Astero',17,1,2),(19,'Atron',20,1,3),(20,'Augoror',9,1,0),(21,'Augoror Navy Issue',16,1,2),(22,'Avatar',36,1,0),(23,'Badger',23,1,1),(24,'Bantam',20,1,1),(25,'Basilisk',27,2,1),(26,'Bellicose',9,1,4),(27,'Bestower',23,1,0),(28,'Bhaalgorn',15,1,2),(29,'Blackbird',9,1,1),(30,'Breacher',20,1,4),(31,'Broadsword',22,2,4),(32,'Brutix',1,1,3),(33,'Burst',20,1,4),(34,'Bustard',37,2,1),(35,'Buzzard',8,2,1),(36,'Caldari Navy Hookbill',17,1,2),(37,'Caracal',9,1,1),(38,'Catalyst',10,1,3),(39,'Celestis',9,1,3),(40,'Cerberus',21,2,1),(41,'Chameleon',19,2,2),(42,'Cheetah',8,2,4),(43,'Chimera',6,1,1),(44,'Claw',24,2,4),(45,'Claymore',7,2,4),(46,'Coercer',10,1,0),(47,'Condor',20,1,1),(48,'Confessor',35,3,0),(49,'Corax',10,1,1),(50,'Cormorant',10,1,1),(51,'Covetor',29,1,5),(52,'Crane',37,2,1),(53,'Crow',24,2,1),(54,'Crucifier',20,1,0),(55,'Cruor',17,1,2),(56,'Crusader',24,2,0),(57,'Curse',30,2,0),(58,'Cyclone',1,1,4),(59,'Cynabal',16,1,2),(60,'Damnation',7,2,0),(61,'Daredevil',17,1,2),(62,'Deimos',21,2,3),(63,'Devoter',22,2,0),(64,'Dominix',3,1,3),(65,'Dragoon',10,1,0),(66,'Drake',1,1,1),(67,'Dramiel',17,1,2),(68,'Eagle',21,2,1),(69,'Enyo',0,2,3),(70,'Eos',7,2,3),(71,'Erebus',36,1,3),(72,'Eris',25,2,3),(73,'Executioner',20,1,0),(74,'Exequror',9,1,3),(75,'Exequror Navy Issue',16,1,2),(76,'Falcon',30,2,1),(77,'Ferox',1,1,1),(78,'Flycatcher',25,2,1),(79,'Federation Navy Comet',17,1,2),(80,'Garmur',17,1,2),(81,'Gila',16,1,2),(82,'Gnosis',32,1,6),(83,'Gold Magnate',17,1,2),(84,'Golem',28,2,1),(85,'Goru''s Shuttle',18,1,2),(86,'Griffin',20,1,1),(87,'Guardian',27,2,0),(88,'Guardian-Vexor',16,1,2),(89,'Guristas Shuttle',18,1,2),(90,'Harbinger',1,1,0),(91,'Harpy',0,2,1),(92,'Hawk',0,2,1),(93,'Hecate',35,3,3),(94,'Hel',6,1,4),(95,'Helios',8,2,3),(96,'Heretic',25,2,0),(97,'Heron',20,1,1),(98,'Hoarder',23,1,4),(99,'Hound',33,2,4),(100,'Huginn',30,2,4),(101,'Hulk',13,2,5),(102,'Hurricane',1,1,4),(103,'Hyena',12,2,4),(104,'Hyperion',3,1,3),(105,'Ibis',31,1,1),(106,'Imicus',20,1,3),(107,'Impairor',31,1,0),(108,'Impel',37,2,0),(109,'Imperial Navy Slicer',17,1,2),(110,'Incursus',20,1,3),(111,'Inquisitor',20,1,0),(112,'Ishkur',0,2,3),(113,'Ishtar',21,2,3),(114,'Iteron Mark V',23,1,3),(115,'Jaguar',0,2,4),(116,'Jackdaw',35,3,1),(117,'Keres',12,2,3),(118,'Kestrel',20,1,1),(119,'Kitsune',12,2,1),(120,'Kronos',28,2,3),(121,'Lachesis',30,2,3),(122,'Legion',34,3,0),(123,'Leviathan',36,1,1),(124,'Loki',34,3,4),(125,'Machariel',15,1,2),(126,'Mackinaw',13,2,5),(127,'Maelstrom',3,1,4),(128,'Magnate',20,1,0),(129,'Malediction',24,2,0),(130,'Maller',9,1,0),(131,'Mammoth',23,1,4),(132,'Manticore',33,2,1),(133,'Mastodon',37,2,4),(134,'Maulus',20,1,3),(135,'Megathron',3,1,3),(136,'Megathron Federate Issue',15,1,2),(137,'Megathron Navy Issue',15,1,2),(138,'Merlin',20,1,1),(139,'Moa',9,1,1),(140,'Moros',11,1,3),(141,'Muninn',21,2,4),(142,'Myrmidon',1,1,3),(143,'Naga',2,1,1),(144,'Naglfar',11,1,4),(145,'Navitas',20,1,3),(146,'Nemesis',33,2,3),(147,'Nereus',23,1,3),(148,'Nidhoggur',6,1,4),(149,'Nighthawk',7,2,1),(150,'Nightmare',15,1,2),(151,'Nomad',26,2,4),(152,'Nyx',6,1,3),(153,'Occator',37,2,3),(154,'Omen',9,1,0),(155,'Omen Navy Issue',16,1,2),(156,'Oneiros',27,2,3),(157,'Onyx',22,2,1),(158,'Oracle',2,1,0),(159,'Orca',5,1,5),(160,'Osprey',9,1,1),(161,'Osprey Navy Issue',16,1,2),(162,'Paladin',28,2,0),(163,'Panther',4,2,4),(164,'Phantasm',16,1,2),(165,'Phobos',22,2,3),(166,'Phoenix',11,1,1),(167,'Pilgrim',30,2,0),(168,'Prorator',37,2,0),(169,'Probe',20,1,4),(170,'Procurer',29,1,5),(171,'Prophecy',1,1,0),(172,'Prospect',14,2,5),(173,'Proteus',34,3,3),(174,'Prowler',37,2,4),(175,'Punisher',20,1,0),(176,'Purifier',33,2,0),(177,'Ragnarok',36,1,4),(178,'Rapier',30,2,4),(179,'Raptor',24,2,1),(180,'Rattlesnake',15,1,2),(181,'Raven',3,1,1),(182,'Raven Navy Issue',15,1,2),(183,'Raven State Issue',15,1,2),(184,'Reaper',31,1,4),(185,'Redeemer',4,2,0),(186,'Republic Fleet Firetail',17,1,2),(187,'Retribution',0,2,0),(188,'Retriever',29,1,5),(189,'Revelation',11,1,0),(190,'Rhea',26,2,1),(191,'Rifter',20,1,4),(192,'Rokh',3,1,1),(193,'Rook',30,2,1),(194,'Rorqual',5,1,5),(195,'Rupture',9,1,4),(196,'Sabre',25,2,4),(197,'Sacrilege',21,2,0),(198,'Scimitar',27,2,4),(199,'Scorpion',3,1,1),(200,'Scythe',9,1,4),(201,'Scythe Fleet Issue',16,1,2),(202,'Sentinel',12,2,0),(203,'Sigil',23,1,0),(204,'Silver Magnate',17,1,2),(205,'Sin',4,2,3),(206,'Skiff',13,2,5),(207,'Slasher',20,1,4),(208,'Sleipnir',7,2,4),(209,'Stabber',9,1,4),(210,'Stabber Fleet Issue',16,1,2),(211,'Stiletto',24,2,4),(212,'Stratios',16,1,2),(213,'Succubus',17,1,2),(214,'Svipul',35,3,4),(215,'Talos',2,1,3),(216,'Talwar',10,1,4),(217,'Taranis',24,2,3),(218,'Tempest',3,1,4),(219,'Tempest Fleet Issue',15,1,2),(220,'Tempest Tribal Issue',15,1,2),(221,'Tengu',34,3,1),(222,'Thanatos',6,1,3),(223,'Thorax',9,1,3),(224,'Thrasher',10,1,4),(225,'Tormentor',20,1,0),(226,'Tornado',2,1,4),(227,'Tristan',20,1,3),(228,'Typhoon',3,1,4),(229,'Vagabond',21,2,4),(230,'Vargur',28,2,4),(231,'Velator',31,1,3),(232,'Vengeance',0,2,0),(233,'Vexor',9,1,3),(234,'Vexor Navy Issue',16,1,2),(235,'Viator',37,2,3),(236,'Vigil',20,1,4),(237,'Vigilant',16,1,2),(238,'Vindicator',15,1,2),(239,'Vulture',7,2,1),(240,'Widow',4,2,1),(241,'Wolf',0,2,4),(242,'Worm',17,1,2),(243,'Wreathe',23,1,4),(244,'Wyvern',6,1,1),(245,'Zealot',21,2,0);

/* CVA kos tables */
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

/* intel tables */
CREATE TABLE [IntelData] (
	[Id] INTEGER NOT NULL PRIMARY KEY,	
    [Character] INTEGER NOT NULL,
    [ShipInfo] INTEGER NULL,
    [ShipInfoDate] DATE NULL,
    [ShipInfoConfirmed] BIT NOT NULL,
    [Solarsystem] INTEGER NULL,
    [SolarsystemDate] DATE NULL,

    FOREIGN KEY([Character]) REFERENCES [CvaCharacterInfos](Id),
    FOREIGN KEY([ShipInfo]) REFERENCES [EveShipInfos](Id)
);