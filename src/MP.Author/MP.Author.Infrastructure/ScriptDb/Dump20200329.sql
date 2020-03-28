-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: mp_author
-- ------------------------------------------------------
-- Server version	5.7.21-log

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
-- Table structure for table `aspnetroleclaims`
--

DROP TABLE IF EXISTS `aspnetroleclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroleclaims`
--

LOCK TABLES `aspnetroleclaims` WRITE;
/*!40000 ALTER TABLE `aspnetroleclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetroleclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetroles`
--

DROP TABLE IF EXISTS `aspnetroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetroles` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetroles`
--

LOCK TABLES `aspnetroles` WRITE;
/*!40000 ALTER TABLE `aspnetroles` DISABLE KEYS */;
INSERT INTO `aspnetroles` VALUES ('0c179e36-41bd-42f8-98c0-706306c2bd22','Chăm sóc khách hàng','CHĂM SÓC KHÁCH HÀNG','a112219c-fbca-4cdc-b9cf-8d4782c262e5'),('462da7f7-65d1-4f39-807c-043f91c02768','Admin','ADMIN','ddeae5d1-f388-4e90-b28d-74887d90eba1');
/*!40000 ALTER TABLE `aspnetroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserclaims`
--

DROP TABLE IF EXISTS `aspnetuserclaims`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_AspNetUserClaims_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserclaims`
--

LOCK TABLES `aspnetuserclaims` WRITE;
/*!40000 ALTER TABLE `aspnetuserclaims` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserclaims` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserlogins`
--

DROP TABLE IF EXISTS `aspnetuserlogins`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4,
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  KEY `IX_AspNetUserLogins_UserId` (`UserId`),
  CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserlogins`
--

LOCK TABLES `aspnetuserlogins` WRITE;
/*!40000 ALTER TABLE `aspnetuserlogins` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetuserlogins` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetuserroles`
--

DROP TABLE IF EXISTS `aspnetuserroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetuserroles`
--

LOCK TABLES `aspnetuserroles` WRITE;
/*!40000 ALTER TABLE `aspnetuserroles` DISABLE KEYS */;
INSERT INTO `aspnetuserroles` VALUES ('9bd06e35-884b-461e-ab17-d9c277aa1055','0c179e36-41bd-42f8-98c0-706306c2bd22'),('9bd06e35-884b-461e-ab17-d9c277aa1055','462da7f7-65d1-4f39-807c-043f91c02768');
/*!40000 ALTER TABLE `aspnetuserroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusers`
--

DROP TABLE IF EXISTS `aspnetusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusers` (
  `Id` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedUserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedEmail` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4,
  `SecurityStamp` longtext CHARACTER SET utf8mb4,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  `PhoneNumber` longtext CHARACTER SET utf8mb4,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusers`
--

LOCK TABLES `aspnetusers` WRITE;
/*!40000 ALTER TABLE `aspnetusers` DISABLE KEYS */;
INSERT INTO `aspnetusers` VALUES ('9bd06e35-884b-461e-ab17-d9c277aa1055','tiennv','TIENNV','tiennv@outlook.com','TIENNV@OUTLOOK.COM',0,'AQAAAAEAACcQAAAAEKjWLIVuGfk54k0OaVRctZLUKO7FvhgWbB4fh9MALX20vzT3k9p+XcOip9jXU+cU1w==','UKNF7A5H2PJUNL33W65UCFEHVTI3HDYI','bb8accdd-9416-48b3-b56f-aa3ac9e976bd',NULL,0,0,NULL,1,0);
/*!40000 ALTER TABLE `aspnetusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `aspnetusertokens`
--

DROP TABLE IF EXISTS `aspnetusertokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`UserId`,`LoginProvider`,`Name`),
  CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `aspnetusertokens`
--

LOCK TABLES `aspnetusertokens` WRITE;
/*!40000 ALTER TABLE `aspnetusertokens` DISABLE KEYS */;
/*!40000 ALTER TABLE `aspnetusertokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `objects`
--

DROP TABLE IF EXISTS `objects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `objects` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4,
  `ParentName` longtext CHARACTER SET utf8mb4,
  `Method` longtext CHARACTER SET utf8mb4,
  `ControllerName` longtext CHARACTER SET utf8mb4,
  `ActionName` longtext CHARACTER SET utf8mb4,
  `Route` longtext CHARACTER SET utf8mb4,
  `Icon` longtext CHARACTER SET utf8mb4,
  `IsShow` tinyint(1) DEFAULT NULL,
  `IsPage` tinyint(1) DEFAULT NULL,
  `IsApp` tinyint(1) DEFAULT NULL,
  `EnumAction` varchar(6) DEFAULT NULL,
  `ParentId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `objects`
--

LOCK TABLES `objects` WRITE;
/*!40000 ALTER TABLE `objects` DISABLE KEYS */;
INSERT INTO `objects` VALUES (1,'Tài khoản','','',NULL,'Personal','account/personal','flaticon2-user-1',1,1,0,'View',0),(2,'Thay đổi mật khẩu','Tài khoản','PUT',NULL,'ChangePassword','account/change-pass','',0,0,0,'View',1),(3,'Loại thiết bị','','',NULL,'Index','category/index','',1,1,0,'View',0),(4,'Get danh sách thiết bị','Loại thiết bị','GET',NULL,'gets','category/gets','',0,0,0,'View',3),(5,'Thêm mới loại thiết bị','Loại thiết bị','',NULL,'Create','category/create','',0,0,0,'View',3),(6,'Thêm mới loại thiết bị','Loại thiết bị','POST',NULL,'Create','/category/create','',0,0,0,'Add',3),(7,'Cập nhật loại thiết bị','Loại thiết bị','',NULL,'Edit','/category/edit','',0,1,0,'View',3),(8,'Cập nhật loại thiết bị','Loại thiết bị','PUT',NULL,'Edit','/category/edit','',0,0,0,'Edit',3),(9,'Chi tiết loại thiết bị','Loại thiết bị','GET',NULL,'Details','/category/detail','',0,0,0,'View',3),(10,'Đơn vị hành chính','','',NULL,'Index','location/index','',1,1,0,'View',0),(11,'Cập nhật đơn vị hành chính','Đơn vị hành chính','PUT',NULL,'Edit','/location/edit','',0,0,0,'Edit',10),(12,'Cập nhật đơn vị hành chính','Đơn vị hành chính','',NULL,'Edit','/location/edit','',0,1,0,'View',10),(13,'Thêm mới đơn vị hành chính','Đơn vị hành chính','POST',NULL,'Create','/location/create','',0,0,0,'Add',10),(14,'Thêm mới đơn vị hành chính','Đơn vị hành chính','',NULL,'Create','location/create','',0,0,0,'View',10),(15,'Get danh sách đơn vị hành chính','Loại thiết bị','GET',NULL,'gets','location/gets','',0,0,0,'View',10);
/*!40000 ALTER TABLE `objects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `operations`
--

DROP TABLE IF EXISTS `operations`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `operations` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4,
  `Create` tinyint(1) NOT NULL,
  `Edit` tinyint(1) NOT NULL,
  `Delete` tinyint(1) NOT NULL,
  `View` tinyint(1) NOT NULL,
  `Import` tinyint(1) NOT NULL,
  `Export` tinyint(1) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `operations`
--

LOCK TABLES `operations` WRITE;
/*!40000 ALTER TABLE `operations` DISABLE KEYS */;
INSERT INTO `operations` VALUES (1,'CREATE',1,0,0,0,0,0),(2,'DELETE',0,0,1,0,0,0),(3,'EDIT',0,1,0,0,0,0),(4,'VIEW',0,0,0,1,0,0);
/*!40000 ALTER TABLE `operations` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permissions`
--

DROP TABLE IF EXISTS `permissions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `permissions` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ObjectId` int(11) NOT NULL,
  `OperationId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_Permissions_Objects_Id_idx` (`ObjectId`),
  KEY `FK_Permissions_Operations_OperationId_idx` (`OperationId`),
  CONSTRAINT `FK_Permissions_Objects_ObjectId` FOREIGN KEY (`ObjectId`) REFERENCES `objects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_Permissions_Operations_OperationId` FOREIGN KEY (`OperationId`) REFERENCES `operations` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permissions`
--

LOCK TABLES `permissions` WRITE;
/*!40000 ALTER TABLE `permissions` DISABLE KEYS */;
INSERT INTO `permissions` VALUES (1,4,1),(2,4,2);
/*!40000 ALTER TABLE `permissions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `refreshtokens`
--

DROP TABLE IF EXISTS `refreshtokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `refreshtokens` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Created` datetime(6) NOT NULL,
  `Modified` datetime(6) NOT NULL,
  `Token` longtext CHARACTER SET utf8mb4,
  `Expires` datetime(6) NOT NULL,
  `UserId` int(11) NOT NULL,
  `RemoteIpAddress` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`),
  KEY `IX_RefreshTokens_UserId` (`UserId`),
  CONSTRAINT `FK_RefreshTokens_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=47 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `refreshtokens`
--

LOCK TABLES `refreshtokens` WRITE;
/*!40000 ALTER TABLE `refreshtokens` DISABLE KEYS */;
INSERT INTO `refreshtokens` VALUES (1,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','nKDe0q2WQgMVBPdObqaAkpTa7ePO8UBMmU2btCTzxiY=','2020-04-02 08:44:40.345009',1,'::1'),(2,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','DrIdUXcT7RJwAO4AskfldjRwtBm7Xf19N0fHMzQ/0OQ=','2020-04-02 14:20:16.596847',1,'::1'),(3,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','xXtkYuBzvYBiaH2OMEnqpHovVDasOqrSfOlnCnZNTcU=','2020-04-02 14:28:57.577094',1,'::1'),(4,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','5BOAtLrnJdeTsDSAvG2OvyaF3aJMofPDp1FflQyavO0=','2020-04-02 14:29:55.091562',1,'::1'),(5,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','bLLPGDIqAjXlXUlWabf9D0b89qBsYDHWdOdZhNWgJKg=','2020-04-02 14:31:22.500287',1,'::1'),(6,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','Qt03FookPBhPMRudPYLxelsr6SiPKhLRZkT7itJVkpk=','2020-04-02 14:31:59.518529',1,'::1'),(7,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','JERK1o9iZllb32fstPp7NYTAXlALbBbHRKZQ8+oL32g=','2020-04-02 14:32:14.012643',1,'::1'),(8,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','OcD0KydIxI8mFKJA+55m3b+rWDKHqAjI7mYtwB7zvHE=','2020-04-02 14:32:43.398025',1,'::1'),(9,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','QEZsCX5/VD24WZzbtcLA5MBd92hTdBtcL7nnAgxvDDs=','2020-04-02 16:07:57.304821',1,'::1'),(10,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','CweW5TqXVcPTkkbP5ChT2EcZ9W4MP28upqTPqkxsS0g=','2020-04-02 16:11:02.712368',1,'::1'),(11,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','qlLWuEQUVNMItCz2jNq0//SYkGJZv11fY9bL2kjFiSM=','2020-04-02 16:13:20.925951',1,'::1'),(12,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','+ham68nLnLv+ep+n4S9+tGx79uNvDYcylknPa7i1imM=','2020-04-02 16:14:18.839416',1,'::1'),(13,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','gN/lKq02KDW0pE3M0zGQrfqlpOzDR5X77d9PR2hDlu4=','2020-04-02 16:14:23.584906',1,'::1'),(14,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','i8zNaniE4sWcupcm41ALm3Asg575bnit/xBhthhfXa4=','2020-04-02 16:14:57.085139',1,'::1'),(15,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','L0xxPAsUd7zpDuazC/nqoSxWAN0I/W9cKESqJTbKnyE=','2020-04-02 16:16:41.190096',1,'::1'),(16,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','41uVfijmOMQ4T2xsOsSJD0iMLAUGtwUIs2iWCKj3bNI=','2020-04-02 16:31:37.049139',1,'::1'),(17,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','pRf8ljRJMesaT/0xzDvwj0M97j4NvY7SPc0g7S0zMNE=','2020-04-02 16:44:16.040546',1,'::1'),(18,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','lK1yOBJUXCFKx18QQNrGrXnSoIhEcWX9yDgLf+ubylM=','2020-04-02 16:46:17.664631',1,'::1'),(19,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','wp9Nl3NVgaRai4sU4/hfIRBiQ6qND4gVMwlsVEYfOBQ=','2020-04-02 16:46:43.369586',1,'::1'),(20,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','q17v4Fx+tAEo/Fe/Sb0JPslzQwXLskYePcrjMQ+1p3s=','2020-04-02 16:53:28.240296',1,'::1'),(21,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','AcTJxasen/1fwspHfSJMFhfFGJL0caLL+ZIzO3tSIrA=','2020-04-02 17:15:25.903901',1,'::1'),(22,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','OSBcPr0xYktPyjPJe3jEdp+OWh3Fzmx5pU9egtxiE48=','2020-04-02 17:19:07.579443',1,'::1'),(23,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','5hPnXvAYWXhhwl0Z36AVT+lRz6py91PWhXtA5LXfmPM=','2020-04-02 17:19:31.113640',1,'::1'),(24,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','ct+WyqLvKVGLNpi1GVJGbO/3MuBHwmgiBArvL+uG24A=','2020-04-02 17:23:04.883868',1,'::1'),(25,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','B4B9z+BXOb12MobKcDIiNDDacmTEjXcj2+Cy+ZhrOqk=','2020-04-02 17:23:39.170547',1,'::1'),(26,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','8aynv2z6y39B3jVv5XuS1gj/6PRZkdlq+/Z5kQHZTZY=','2020-04-02 17:28:01.953083',1,'::1'),(27,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','ujNDDOeVA9SE6gddSbzgbFrXrb/iNJJ+gMtUOErAmrA=','2020-04-02 17:28:05.881884',1,'::1'),(28,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','HfxDjE9pxYI6wBlqKEIe9S4zOdwdzXGumbQouExqS5s=','2020-04-02 17:28:21.606867',1,'::1'),(29,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','JhH3FYgfRpirTlJosV9zvdkI5aOUddvlEwBP6/qol/U=','2020-04-02 17:28:38.075328',1,'::1'),(30,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','GiQVC/9gDC0vH53a0dJAqQAb4fdXuUsBJqiv6pdUGUo=','2020-04-02 17:32:01.097031',1,'::1'),(31,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','JWscVFPMk5lL7I5kVNOp8GcQH2Wqs0KzAGO5YRKZPz0=','2020-04-02 17:32:15.530487',1,'::1'),(32,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','tlq3X87DoAPF04Y6F42BAzDsg6TILdICAgpcnwQ/kZ0=','2020-04-02 17:32:30.365700',1,'::1'),(33,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','09mYGCHIDRXJLD8Ijkq3fdCiiM3laJDqzh8heuPPMtY=','2020-04-02 17:32:39.387939',1,'::1'),(34,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','JzwVgYySQlEAAQ6X7n4A6UO5eyYCxcKUIF+04k/+vUI=','2020-04-02 17:33:30.123880',1,'::1'),(35,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','KbGHHiKevoOozhJhjA1wgVWOtIGcthDIm26WzZrerY4=','2020-04-02 17:37:57.921765',1,'::1'),(36,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','qe8CyLwN67V8k5BmsuC5nb2dLksW5XkffhRALpq4RGw=','2020-04-02 17:38:19.668095',1,'::1'),(37,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','IQYOEdB+IwhCJdjT69ISj9gxFYptNlAyQ8PAkMYSRNQ=','2020-04-02 17:40:21.852356',1,'::1'),(38,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','yYxqG0TleDM29tx8XQGBf/4nR2ikz9e4RV3qbzQpPIs=','2020-04-02 17:42:29.683591',1,'::1'),(39,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','uUtUi06JHr9Ai/LL3O8Tkqy5TLZ8EVqLE63xb8Eo6rk=','2020-04-02 17:42:45.170466',1,'::1'),(40,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','M5nQIIsuD76gq+ltdFfQ7QvHlTE1PyZ4ODOurJCn180=','2020-04-02 17:43:05.440368',1,'::1'),(41,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','WgvDVKY4cqNQPlGEf0MCFZ7cL3/VTCr3XUccpHU/Rag=','2020-04-02 17:44:28.770895',1,'::1'),(42,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','4nhUL7ayMxU8eCstd503aHHoff1wDkAFvcGAvSSC3bo=','2020-04-02 17:44:46.448493',1,'::1'),(43,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','ot1xd3TaqZjzRYJJBC2jMMB05JcWXR6kxuq8JD7kzy0=','2020-04-02 17:46:48.840317',1,'::1'),(44,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','g3oinZfv0bdSctBFFs5hCcnfSqF/TsmfaNAmE9exBjI=','2020-04-02 17:47:07.271099',1,'::1'),(45,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','e/OZiD+Go4pe3q2xBN0XDdKTvHuuZr4RrPZicikiRfI=','2020-04-02 17:51:12.893448',1,'::1'),(46,'0001-01-01 00:00:00.000000','0001-01-01 00:00:00.000000','uCTiMaAW2rGq9EMOk6xVWlP6B8H8vA/WJ937S7Wl7VM=','2020-04-02 17:51:40.846489',1,'::1');
/*!40000 ALTER TABLE `refreshtokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `role_permission`
--

DROP TABLE IF EXISTS `role_permission`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `role_permission` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` varchar(255) CHARACTER SET utf8mb4 DEFAULT NULL,
  `PermissionId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_RolePermission_Permission_Id_idx` (`PermissionId`),
  KEY `FK_RolePermission_Roles_Id_idx` (`RoleId`),
  CONSTRAINT `FK_RolePermission_Permission_Id` FOREIGN KEY (`PermissionId`) REFERENCES `permissions` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_RolePermission_Roles_Id` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `role_permission`
--

LOCK TABLES `role_permission` WRITE;
/*!40000 ALTER TABLE `role_permission` DISABLE KEYS */;
INSERT INTO `role_permission` VALUES (2,'0c179e36-41bd-42f8-98c0-706306c2bd22',1),(3,'0c179e36-41bd-42f8-98c0-706306c2bd22',2),(4,'462da7f7-65d1-4f39-807c-043f91c02768',2);
/*!40000 ALTER TABLE `role_permission` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` longtext CHARACTER SET utf8mb4,
  `LastName` longtext CHARACTER SET utf8mb4,
  `IdentityId` longtext CHARACTER SET utf8mb4,
  `UserName` longtext CHARACTER SET utf8mb4,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Tiến','Nguyễn Việt','9bd06e35-884b-461e-ab17-d9c277aa1055','tiennv');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'mp_author'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-03-29  0:54:21
