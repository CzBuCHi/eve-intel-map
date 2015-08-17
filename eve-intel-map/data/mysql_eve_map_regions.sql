-- MySQL dump 10.13  Distrib 5.5.41, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: eve_marketdata_prod
-- ------------------------------------------------------
-- Server version	5.5.41-0+wheezy1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `eve_map_regions`
--

DROP TABLE IF EXISTS `eve_map_regions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `eve_map_regions` (
  `region_id` int(11) NOT NULL,
  `region_name` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`region_id`),
  KEY `i_region_name` (`region_name`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;
-- /*!40101 SET character_set_client = @saved_cs_client */;
-- /*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eve_map_regions`
--

LOCK TABLES `eve_map_regions` WRITE;
/*!40000 ALTER TABLE `eve_map_regions` DISABLE KEYS */;
INSERT INTO `eve_map_regions` VALUES (10000002,'The Forge'),(10000003,'Vale of the Silent'),(10000004,'UUA-F4'),(10000005,'Detorid'),(10000006,'Wicked Creek'),(10000007,'Cache'),(10000008,'Scalding Pass'),(10000009,'Insmother'),(10000010,'Tribute'),(10000011,'Great Wildlands'),(10000012,'Curse'),(10000013,'Malpais'),(10000014,'Catch'),(10000015,'Venal'),(10000016,'Lonetrek'),(10000017,'J7HZ-F'),(10000018,'The Spire'),(10000019,'A821-A'),(10000020,'Tash-Murkon'),(10000021,'Outer Passage'),(10000022,'Stain'),(10000023,'Pure Blind'),(10000025,'Immensea'),(10000027,'Etherium Reach'),(10000028,'Molden Heath'),(10000029,'Geminate'),(10000030,'Heimatar'),(10000031,'Impass'),(10000032,'Sinq Laison'),(10000033,'The Citadel'),(10000034,'The Kalevala Expanse'),(10000035,'Deklein'),(10000036,'Devoid'),(10000037,'Everyshore'),(10000038,'The Bleak Lands'),(10000039,'Esoteria'),(10000040,'Oasa'),(10000041,'Syndicate'),(10000042,'Metropolis'),(10000043,'Domain'),(10000044,'Solitude'),(10000045,'Tenal'),(10000046,'Fade'),(10000047,'Providence'),(10000048,'Placid'),(10000049,'Khanid'),(10000050,'Querious'),(10000051,'Cloud Ring'),(10000052,'Kador'),(10000053,'Cobalt Edge'),(10000054,'Aridia'),(10000055,'Branch'),(10000056,'Feythabolis'),(10000057,'Outer Ring'),(10000058,'Fountain'),(10000059,'Paragon Soul'),(10000060,'Delve'),(10000061,'Tenerifis'),(10000062,'Omist'),(10000063,'Period Basis'),(10000064,'Essence'),(10000065,'Kor-Azor'),(10000066,'Perrigen Falls'),(10000067,'Genesis'),(10000068,'Verge Vendor'),(10000069,'Black Rise'),(11000001,'Unknown'),(11000002,'Unknown'),(11000003,'Unknown'),(11000004,'Unknown'),(11000005,'Unknown'),(11000006,'Unknown'),(11000007,'Unknown'),(11000008,'Unknown'),(11000009,'Unknown'),(11000010,'Unknown'),(11000011,'Unknown'),(11000012,'Unknown'),(11000013,'Unknown'),(11000014,'Unknown'),(11000015,'Unknown'),(11000016,'Unknown'),(11000017,'Unknown'),(11000018,'Unknown'),(11000019,'Unknown'),(11000020,'Unknown'),(11000021,'Unknown'),(11000022,'Unknown'),(11000023,'Unknown'),(11000024,'Unknown'),(11000025,'Unknown'),(11000026,'Unknown'),(11000027,'Unknown'),(11000028,'Unknown'),(11000029,'Unknown'),(11000030,'Unknown'),(10000001,'Derelik');
/*!40000 ALTER TABLE `eve_map_regions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-05-16 11:02:58
