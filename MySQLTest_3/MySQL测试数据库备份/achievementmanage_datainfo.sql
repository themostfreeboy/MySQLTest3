CREATE DATABASE  IF NOT EXISTS `achievementmanage` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `achievementmanage`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: achievementmanage
-- ------------------------------------------------------
-- Server version	5.7.10-log

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
-- Table structure for table `datainfo`
--

DROP TABLE IF EXISTS `datainfo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `datainfo` (
  `AchievementName` varchar(50) NOT NULL,
  `AchievementType` varchar(50) NOT NULL,
  `AchievementDate` date NOT NULL,
  `AchievementAuthor` varchar(50) NOT NULL,
  `AchievementCompany` varchar(50) NOT NULL,
  `AchievementMoney` float NOT NULL,
  PRIMARY KEY (`AchievementName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `datainfo`
--

LOCK TABLES `datainfo` WRITE;
/*!40000 ALTER TABLE `datainfo` DISABLE KEYS */;
INSERT INTO `datainfo` VALUES ('丁专利','专利','2015-12-26','丁','丁公司',106.58),('丁期刊论文','期刊论文','2015-11-27','丁','丁公司',1122.34),('丁机械图','机械图','2013-06-28','丁','丁公司',76.33),('丙专利','专利','2016-02-05','丙','丙公司',78.4),('丙机械图','机械图','2014-03-11','丙','丙公司',125.87),('乙会议论文','会议论文','2016-01-26','乙','乙公司',47.59),('乙期刊论文','期刊论文','2016-01-24','乙','乙公司',1456.3),('乙机械图','机械图','2015-11-23','乙','乙公司',56.33),('甲专利','专利','2016-01-11','甲','甲公司',2345.67),('甲期刊论文','期刊论文','2016-02-08','甲','甲公司',20.34),('甲机械图','机械图','2016-01-18','甲','甲公司',356.98);
/*!40000 ALTER TABLE `datainfo` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-04-02 21:03:52
