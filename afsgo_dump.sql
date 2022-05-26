-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: afsgo_case
-- ------------------------------------------------------
-- Server version	8.0.28

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `input` varchar(1000) NOT NULL,
  `output` varchar(1000) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,'test','test'),(2,6,'You gave Mr. Tim a hearty meal, but unfortunately what he ate made him die.','Too Many Requests: Rate limit of 5 requests per hour exceeded. Please wait for 58 minutes and 58 seconds.'),(3,6,'The cat was playing in the garden.','Too Many Requests: Rate limit of 5 requests per hour exceeded. Please wait for 56 minutes and 8 seconds.'),(4,6,'The cat was playing in the garden.','Too Many Requests: Rate limit of 5 requests per hour exceeded. Please wait for 53 minutes and 45 seconds.'),(5,7,'The cat was playing in the garden.','Too Many Requests: Rate limit of 5 requests per hour exceeded. Please wait for 48 minutes and 42 seconds.'),(6,7,'The cat was playing in the garden.','Too Many Requests: Rate limit of 5 requests per hour exceeded. Please wait for 42 minutes and 55 seconds.');
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_mail` varchar(100) NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user`
--

LOCK TABLES `user` WRITE;
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` VALUES (1,'test@test.com','2022-05-23 14:24:33'),(2,'test2@test.com','2022-05-24 23:21:05'),(3,'test3@test.com','2022-05-24 23:24:01'),(4,'test4@test.com','2022-05-24 23:24:55'),(5,'test5@test.com','2022-05-25 09:09:01'),(6,'r.tugberkinci@gmail.com','2022-05-25 09:09:24'),(7,'test.tokensender@gmail.com','2022-05-26 07:51:22');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_tokens`
--

DROP TABLE IF EXISTS `user_tokens`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_tokens` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_id` int NOT NULL,
  `token` varchar(100) NOT NULL,
  `secret` varchar(100) NOT NULL,
  `created_at` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_tokens`
--

LOCK TABLES `user_tokens` WRITE;
/*!40000 ALTER TABLE `user_tokens` DISABLE KEYS */;
INSERT INTO `user_tokens` VALUES (1,1,'PY2FCKKJBJ0T30P553WCH2Z4','SVII5Q8XMCUS2P7MEYP69VCC','2022-05-24 20:54:02'),(2,5,'9SEKQ8S6Q6T2JVRHRIH54NIX','4261G2WBB0QTXFG5UCC97TCX','2022-05-25 09:09:02'),(3,6,'9WY4QCKGTOAYZCZJGA14Z234','4J9GBSB5SX3NNEUIK7H1QNZH','2022-05-25 09:09:24'),(4,7,'RLW1UOIHFWCK2KIYAURGVGRM','DBN2ITEO7LS58YS4FK3GADHH','2022-05-26 07:51:22');
/*!40000 ALTER TABLE `user_tokens` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'afsgo_case'
--

--
-- Dumping routines for database 'afsgo_case'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-05-26 11:16:34
