CREATE DATABASE  IF NOT EXISTS `ferreteria_el_tornillo` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ferreteria_el_tornillo`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: ferreteria_el_tornillo
-- ------------------------------------------------------
-- Server version	9.6.0

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
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '26bb312a-6467-11f1-a4b8-a60862bdcfc5:1-48';

--
-- Table structure for table `categorias_producto`
--

DROP TABLE IF EXISTS `categorias_producto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorias_producto` (
  `id_categoria` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id_categoria`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias_producto`
--

LOCK TABLES `categorias_producto` WRITE;
/*!40000 ALTER TABLE `categorias_producto` DISABLE KEYS */;
INSERT INTO `categorias_producto` VALUES (1,'Herramientas Manuales'),(2,'Herramientas Eléctricas'),(3,'Fijaciones y Tornillería'),(4,'Pinturas y Revestimientos'),(5,'Adhesivos y Selladores'),(6,'Electricidad e Iluminación');
/*!40000 ALTER TABLE `categorias_producto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `clientes` (
  `id_cliente` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `direccion` varchar(100) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `tipo_documento` enum('dni','cuit') NOT NULL,
  `numero_documento` varchar(20) NOT NULL,
  PRIMARY KEY (`id_cliente`),
  UNIQUE KEY `numero_documento` (`numero_documento`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'Juan','Perez','Av. Corrientes 1234, CABA','1123456789','juan.perez@gmail.com','dni','28456789'),(2,'Maria','Lopez','Calle Mitre 567, Lomas de Zamora','1134567890','maria.lopez@hotmail.com','dni','31234567'),(3,'Constructora','Del Sur SRL','Ruta 3 km 25, Ezeiza','1145678901','compras@delsur.com.ar','cuit','30712345678'),(4,'Hernan','Gutierrez','Belgrano 890, Quilmes','1156789012','hernan.g@gmail.com','dni','25678901'),(5,'Ana','Martinez','San Martin 345, Lanus','1167890123','ana.martinez@yahoo.com','dni','33456789'),(6,'Reformas','Rapidas SA','Av. Rivadavia 2000, CABA','1178901234','admin@reformasrapidas.com','cuit','30698765432'),(7,'Pedro','Gomez','Italia 456, Avellaneda','1189012345','pedro.gomez@gmail.com','dni','29012345'),(8,'Lucia','Torres','España 789, Berazategui','1190123456','lucia.torres@gmail.com','dni','35678901'),(9,'Albañileria','Moderna SRL','Varela 1100, Florencio Varela','1101234567','ventas@albanileriamoderna.com','cuit','30756789012'),(10,'Santiago','Ruiz','Constitucion 234, La Plata','1112345678','sruiz@gmail.com','dni','27890123'),(11,'Guillermo','Vicente','Congreso 1250','1122334455','gvicente@gmail.com','dni','40012901');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_pedido_proveedor`
--

DROP TABLE IF EXISTS `detalle_pedido_proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle_pedido_proveedor` (
  `id_pedido` int NOT NULL,
  `id_producto` int NOT NULL,
  `cantidad` int NOT NULL,
  `precio_costo` decimal(10,2) NOT NULL,
  `subtotal` decimal(10,2) NOT NULL,
  PRIMARY KEY (`id_pedido`,`id_producto`),
  KEY `id_producto` (`id_producto`),
  CONSTRAINT `detalle_pedido_proveedor_ibfk_1` FOREIGN KEY (`id_pedido`) REFERENCES `pedido_proveedor` (`id_pedido`),
  CONSTRAINT `detalle_pedido_proveedor_ibfk_2` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_pedido_proveedor`
--

LOCK TABLES `detalle_pedido_proveedor` WRITE;
/*!40000 ALTER TABLE `detalle_pedido_proveedor` DISABLE KEYS */;
INSERT INTO `detalle_pedido_proveedor` VALUES (1,1,10,2800.00,28000.00),(1,2,20,950.00,19000.00),(1,5,10,1500.00,15000.00),(2,12,50,320.00,16000.00),(2,14,30,450.00,13500.00),(2,16,30,290.00,8700.00),(3,17,10,3800.00,38000.00),(3,18,8,2100.00,16800.00),(3,22,10,2200.00,22000.00),(4,9,5,8500.00,42500.00),(4,10,4,7200.00,28800.00),(4,11,3,9800.00,29400.00),(5,25,30,480.00,14400.00);
/*!40000 ALTER TABLE `detalle_pedido_proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalle_venta`
--

DROP TABLE IF EXISTS `detalle_venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalle_venta` (
  `id_venta` int NOT NULL,
  `id_producto` int NOT NULL,
  `cantidad` int NOT NULL,
  `precio_venta` decimal(10,2) NOT NULL,
  `id_cliente` int NOT NULL,
  PRIMARY KEY (`id_venta`,`id_producto`),
  KEY `id_producto` (`id_producto`),
  KEY `id_cliente` (`id_cliente`),
  CONSTRAINT `detalle_venta_ibfk_1` FOREIGN KEY (`id_venta`) REFERENCES `venta` (`id_venta`),
  CONSTRAINT `detalle_venta_ibfk_2` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`id_producto`),
  CONSTRAINT `detalle_venta_ibfk_3` FOREIGN KEY (`id_cliente`) REFERENCES `clientes` (`id_cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalle_venta`
--

LOCK TABLES `detalle_venta` WRITE;
/*!40000 ALTER TABLE `detalle_venta` DISABLE KEYS */;
INSERT INTO `detalle_venta` VALUES (1,1,1,4500.00,1),(1,9,1,13900.00,1),(2,12,3,550.00,3),(2,14,2,750.00,3),(2,23,5,200.00,3),(3,9,1,13900.00,4),(4,17,1,6200.00,5),(4,21,2,780.00,5),(5,10,1,11500.00,6),(5,11,1,15800.00,6),(6,22,1,3600.00,7),(7,1,1,4500.00,8),(8,6,1,2900.00,9),(8,7,1,6800.00,9),(9,2,1,1600.00,10),(10,5,1,2400.00,1),(11,11,6,15800.00,11);
/*!40000 ALTER TABLE `detalle_venta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `factura_proveedor`
--

DROP TABLE IF EXISTS `factura_proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `factura_proveedor` (
  `id_factura` int NOT NULL AUTO_INCREMENT,
  `numero_factura` varchar(30) NOT NULL,
  `fecha` date NOT NULL,
  `id_proveedor` int NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `estado_factura` enum('pendiente','pagada') DEFAULT 'pendiente',
  PRIMARY KEY (`id_factura`),
  UNIQUE KEY `numero_factura` (`numero_factura`),
  KEY `id_proveedor` (`id_proveedor`),
  CONSTRAINT `factura_proveedor_ibfk_1` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedores` (`id_proveedor`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `factura_proveedor`
--

LOCK TABLES `factura_proveedor` WRITE;
/*!40000 ALTER TABLE `factura_proveedor` DISABLE KEYS */;
INSERT INTO `factura_proveedor` VALUES (1,'FA-0001-00012345','2025-04-28',1,62000.00,'pagada'),(2,'FB-0001-00008901','2025-05-05',3,38200.00,'pagada'),(3,'FA-0002-00034567','2025-05-12',2,76800.00,'pagada'),(4,'FC-0001-00056789','2025-05-19',5,100700.00,'pendiente'),(5,'FA-0003-00078901','2025-05-26',4,14400.00,'pendiente');
/*!40000 ALTER TABLE `factura_proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `marcas`
--

DROP TABLE IF EXISTS `marcas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `marcas` (
  `id_marca` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  PRIMARY KEY (`id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `marcas`
--

LOCK TABLES `marcas` WRITE;
/*!40000 ALTER TABLE `marcas` DISABLE KEYS */;
INSERT INTO `marcas` VALUES (1,'Stanley'),(2,'Tramontina'),(3,'Black & Decker'),(4,'Bahco'),(5,'Petrilac'),(6,'Klaukol'),(7,'Philips'),(8,'3M');
/*!40000 ALTER TABLE `marcas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medio_pago`
--

DROP TABLE IF EXISTS `medio_pago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `medio_pago` (
  `id_medio_de_pago` int NOT NULL AUTO_INCREMENT,
  `nombre` enum('efectivo','tarjeta_debito','tarjeta_credito','qr') NOT NULL,
  PRIMARY KEY (`id_medio_de_pago`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medio_pago`
--

LOCK TABLES `medio_pago` WRITE;
/*!40000 ALTER TABLE `medio_pago` DISABLE KEYS */;
INSERT INTO `medio_pago` VALUES (1,'efectivo'),(2,'tarjeta_debito'),(3,'tarjeta_credito'),(4,'qr');
/*!40000 ALTER TABLE `medio_pago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pago_proveedor`
--

DROP TABLE IF EXISTS `pago_proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pago_proveedor` (
  `id_pago` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `id_factura_proveedor` int NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `id_medio_pago` int NOT NULL,
  `id_usuario` int NOT NULL,
  PRIMARY KEY (`id_pago`),
  KEY `id_factura_proveedor` (`id_factura_proveedor`),
  KEY `id_medio_pago` (`id_medio_pago`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `pago_proveedor_ibfk_1` FOREIGN KEY (`id_factura_proveedor`) REFERENCES `factura_proveedor` (`id_factura`),
  CONSTRAINT `pago_proveedor_ibfk_2` FOREIGN KEY (`id_medio_pago`) REFERENCES `medio_pago` (`id_medio_de_pago`),
  CONSTRAINT `pago_proveedor_ibfk_3` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pago_proveedor`
--

LOCK TABLES `pago_proveedor` WRITE;
/*!40000 ALTER TABLE `pago_proveedor` DISABLE KEYS */;
INSERT INTO `pago_proveedor` VALUES (1,'2025-05-02',1,62000.00,1,1),(2,'2025-05-09',2,38200.00,1,1),(3,'2025-05-16',3,76800.00,2,1);
/*!40000 ALTER TABLE `pago_proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pedido_proveedor`
--

DROP TABLE IF EXISTS `pedido_proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pedido_proveedor` (
  `id_pedido` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `id_proveedor` int NOT NULL,
  `estado` enum('pendiente','recibido') DEFAULT 'pendiente',
  `id_usuario` int NOT NULL,
  PRIMARY KEY (`id_pedido`),
  KEY `id_proveedor` (`id_proveedor`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `pedido_proveedor_ibfk_1` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedores` (`id_proveedor`),
  CONSTRAINT `pedido_proveedor_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pedido_proveedor`
--

LOCK TABLES `pedido_proveedor` WRITE;
/*!40000 ALTER TABLE `pedido_proveedor` DISABLE KEYS */;
INSERT INTO `pedido_proveedor` VALUES (1,'2025-04-28',1,'recibido',1),(2,'2025-05-05',3,'recibido',1),(3,'2025-05-12',2,'recibido',1),(4,'2025-05-19',5,'pendiente',1),(5,'2025-05-26',4,'pendiente',1);
/*!40000 ALTER TABLE `pedido_proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `id_producto` int NOT NULL AUTO_INCREMENT,
  `id_marca` int NOT NULL,
  `descripcion` varchar(100) NOT NULL,
  `precio_costo` decimal(10,2) NOT NULL,
  `precio_venta` decimal(10,2) NOT NULL,
  `stock_actual` int DEFAULT '0',
  `stock_minimo` int DEFAULT '0',
  `estado` enum('activo','discontinuado','eliminado') DEFAULT 'activo',
  PRIMARY KEY (`id_producto`),
  KEY `id_marca` (`id_marca`),
  CONSTRAINT `productos_ibfk_1` FOREIGN KEY (`id_marca`) REFERENCES `marcas` (`id_marca`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,1,'Martillo carpintero 20oz mango fibra',2800.00,4500.00,25,5,'activo'),(2,2,'Destornillador Phillips N2 mango ergonomico',950.00,1600.00,40,8,'activo'),(3,1,'Cinta metrica 5m con freno',1200.00,1950.00,30,6,'activo'),(4,4,'Llave ajustable 12 pulgadas',3100.00,5200.00,18,4,'activo'),(5,2,'Alicate universal 8 pulgadas',1500.00,2400.00,22,5,'activo'),(6,1,'Nivel de burbuja 60cm aluminio',1800.00,2900.00,15,4,'activo'),(7,4,'Juego llaves fijas 6 a 22mm x8 piezas',4200.00,6800.00,10,3,'activo'),(8,2,'Sierra para metales arco regulable',1650.00,2700.00,20,4,'activo'),(9,3,'Taladro percutor 650W mandril 13mm',8500.00,13900.00,12,3,'activo'),(10,3,'Amoladora angular 115mm 710W',7200.00,11500.00,8,2,'activo'),(11,3,'Atornillador a bateria 12V con 2 baterias',9800.00,15800.00,6,2,'activo'),(12,1,'Tornillos autoperforantes 1 pulgada x100u',320.00,550.00,150,20,'activo'),(13,1,'Clavos de acero 2 pulgadas x kg',280.00,480.00,80,15,'activo'),(14,1,'Tarugos Fisher S8 x50u',450.00,750.00,120,20,'activo'),(15,1,'Bulones 1/4 con tuerca x50u',380.00,640.00,90,15,'activo'),(16,1,'Tornillos madera 3/4 pulgada x100u',290.00,490.00,110,20,'activo'),(17,5,'Pintura latex interior blanco 4L',3800.00,6200.00,20,5,'activo'),(18,5,'Pintura esmalte sintetico negro brillante 1L',2100.00,3400.00,15,4,'activo'),(19,5,'Impermeabilizante para techo 4L',4500.00,7300.00,12,3,'activo'),(20,5,'Pintura anti-oxido rojo minio 1L',1900.00,3100.00,18,4,'activo'),(21,6,'Pastina gris x1kg',480.00,780.00,60,10,'activo'),(22,6,'Adhesivo ceramico 30kg',2200.00,3600.00,25,5,'activo'),(23,8,'Cinta de teflon x10m',120.00,200.00,200,30,'activo'),(24,8,'Silicona neutra transparente 280ml',680.00,1100.00,45,8,'activo'),(25,7,'Lampara LED 9W E27 luz fria',480.00,780.00,80,15,'activo');
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos_x_categoria`
--

DROP TABLE IF EXISTS `productos_x_categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos_x_categoria` (
  `id_producto` int NOT NULL,
  `id_categoria` int NOT NULL,
  PRIMARY KEY (`id_producto`,`id_categoria`),
  KEY `id_categoria` (`id_categoria`),
  CONSTRAINT `productos_x_categoria_ibfk_1` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`id_producto`),
  CONSTRAINT `productos_x_categoria_ibfk_2` FOREIGN KEY (`id_categoria`) REFERENCES `categorias_producto` (`id_categoria`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos_x_categoria`
--

LOCK TABLES `productos_x_categoria` WRITE;
/*!40000 ALTER TABLE `productos_x_categoria` DISABLE KEYS */;
INSERT INTO `productos_x_categoria` VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(9,2),(10,2),(11,2),(12,3),(13,3),(14,3),(15,3),(16,3),(17,4),(18,4),(19,4),(20,4),(21,5),(22,5),(23,5),(24,5),(25,6);
/*!40000 ALTER TABLE `productos_x_categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos_x_proveedor`
--

DROP TABLE IF EXISTS `productos_x_proveedor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos_x_proveedor` (
  `id_producto` int NOT NULL,
  `id_proveedor` int NOT NULL,
  PRIMARY KEY (`id_producto`,`id_proveedor`),
  KEY `id_proveedor` (`id_proveedor`),
  CONSTRAINT `productos_x_proveedor_ibfk_1` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`id_producto`),
  CONSTRAINT `productos_x_proveedor_ibfk_2` FOREIGN KEY (`id_proveedor`) REFERENCES `proveedores` (`id_proveedor`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos_x_proveedor`
--

LOCK TABLES `productos_x_proveedor` WRITE;
/*!40000 ALTER TABLE `productos_x_proveedor` DISABLE KEYS */;
INSERT INTO `productos_x_proveedor` VALUES (1,1),(2,1),(3,1),(4,1),(5,1),(6,1),(7,1),(8,1),(17,2),(18,2),(19,2),(20,2),(21,2),(22,2),(12,3),(13,3),(14,3),(15,3),(16,3),(23,3),(24,3),(25,4),(9,5),(10,5),(11,5);
/*!40000 ALTER TABLE `productos_x_proveedor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedores`
--

DROP TABLE IF EXISTS `proveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `proveedores` (
  `id_proveedor` int NOT NULL AUTO_INCREMENT,
  `razon_social` varchar(100) NOT NULL,
  `cuit` varchar(20) NOT NULL,
  `direccion` varchar(100) DEFAULT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_proveedor`),
  UNIQUE KEY `cuit` (`cuit`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedores`
--

LOCK TABLES `proveedores` WRITE;
/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
INSERT INTO `proveedores` VALUES (1,'Distribuidora Herramientas Del Norte SA','30-61234567-8','Av. General Paz 4500, CABA','1145001234','ventas@herdelnorte.com.ar'),(2,'Pinturas y Revestimientos Sur SRL','30-72345678-9','Camino de Cintura 1200, La Matanza','1156002345','pedidos@pinturassur.com.ar'),(3,'Fijaciones Industriales Omega SA','30-83456789-0','Av. Coronel Roca 789, Lanus','1167003456','comercial@omegafij.com.ar'),(4,'Electro Insumos Rodriguez e Hijos','20-94567890-1','Rivadavia 3400, Moron','1178004567','ventas@electrorodriguez.com'),(5,'Stanley Black & Decker Argentina SA','30-05678901-2','Av. del Libertador 6250, CABA','1189005678','distribuidores@sbdargentina.com');
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recepcion_detalle`
--

DROP TABLE IF EXISTS `recepcion_detalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recepcion_detalle` (
  `id_recepcion` int NOT NULL,
  `id_producto` int NOT NULL,
  `cantidad_recibida` int NOT NULL,
  PRIMARY KEY (`id_recepcion`,`id_producto`),
  KEY `id_producto` (`id_producto`),
  CONSTRAINT `recepcion_detalle_ibfk_1` FOREIGN KEY (`id_recepcion`) REFERENCES `recepcion_pedido` (`id_recepcion`),
  CONSTRAINT `recepcion_detalle_ibfk_2` FOREIGN KEY (`id_producto`) REFERENCES `productos` (`id_producto`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recepcion_detalle`
--

LOCK TABLES `recepcion_detalle` WRITE;
/*!40000 ALTER TABLE `recepcion_detalle` DISABLE KEYS */;
INSERT INTO `recepcion_detalle` VALUES (1,1,10),(1,2,20),(1,5,10),(2,12,50),(2,14,30),(2,16,30),(3,17,10),(3,18,8),(3,22,10);
/*!40000 ALTER TABLE `recepcion_detalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recepcion_pedido`
--

DROP TABLE IF EXISTS `recepcion_pedido`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recepcion_pedido` (
  `id_recepcion` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `id_pedido_proveedor` int NOT NULL,
  `id_factura_proveedor` int NOT NULL,
  `id_usuario` int NOT NULL,
  PRIMARY KEY (`id_recepcion`),
  KEY `id_pedido_proveedor` (`id_pedido_proveedor`),
  KEY `id_factura_proveedor` (`id_factura_proveedor`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `recepcion_pedido_ibfk_1` FOREIGN KEY (`id_pedido_proveedor`) REFERENCES `pedido_proveedor` (`id_pedido`),
  CONSTRAINT `recepcion_pedido_ibfk_2` FOREIGN KEY (`id_factura_proveedor`) REFERENCES `factura_proveedor` (`id_factura`),
  CONSTRAINT `recepcion_pedido_ibfk_3` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recepcion_pedido`
--

LOCK TABLES `recepcion_pedido` WRITE;
/*!40000 ALTER TABLE `recepcion_pedido` DISABLE KEYS */;
INSERT INTO `recepcion_pedido` VALUES (1,'2025-04-30',1,1,1),(2,'2025-05-07',2,2,1),(3,'2025-05-14',3,3,1);
/*!40000 ALTER TABLE `recepcion_pedido` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id_rol` int NOT NULL AUTO_INCREMENT,
  `nombre` enum('admin','vendedor','cajero') NOT NULL,
  PRIMARY KEY (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'admin'),(2,'vendedor'),(3,'cajero');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuarios` (
  `id_usuario` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `telefono` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `usuario_login` varchar(50) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `id_rol` int NOT NULL,
  PRIMARY KEY (`id_usuario`),
  UNIQUE KEY `usuario_login` (`usuario_login`),
  KEY `id_rol` (`id_rol`),
  CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`id_rol`) REFERENCES `roles` (`id_rol`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'Carlos','Mendoza','1145678901','carlos.mendoza@eltornillo.com','cmendoza','240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9',1),(2,'Laura','Gimenez','1156789012','laura.gimenez@eltornillo.com','lgimenez','483856709cd464e93f12750bf53f6eb20099f2fd8ffb451555b6e62ba40ca2dd',2),(3,'Roberto','Sosa','1167890123','roberto.sosa@eltornillo.com','rsosa','7941c4efa9c7674c29d36f6a984cf0b7ed9b6272ad699575ac970b04853c7474',2),(4,'Patricia','Alvarez','1178901234','patricia.alvarez@eltornillo.com','palvarez','6417d9eb6da2a6506cab8fc49439c4af0d20fef5c810bfaf9da35e2c8533d678',3),(5,'Diego','Fernandez','1189012345','diego.fernandez@eltornillo.com','dfernandez','c5fc6a57eafabc72beef934717e2d3eec231a5bff9a6619c101476877afc46a7',3);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `venta`
--

DROP TABLE IF EXISTS `venta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `venta` (
  `id_venta` int NOT NULL AUTO_INCREMENT,
  `fecha` date NOT NULL,
  `total_venta` decimal(10,2) NOT NULL,
  `id_medio_de_pago` int NOT NULL,
  `estado_venta` enum('confirmada','anulada') DEFAULT 'confirmada',
  `id_usuario` int NOT NULL,
  PRIMARY KEY (`id_venta`),
  KEY `id_medio_de_pago` (`id_medio_de_pago`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `venta_ibfk_1` FOREIGN KEY (`id_medio_de_pago`) REFERENCES `medio_pago` (`id_medio_de_pago`),
  CONSTRAINT `venta_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `venta`
--

LOCK TABLES `venta` WRITE;
/*!40000 ALTER TABLE `venta` DISABLE KEYS */;
INSERT INTO `venta` VALUES (1,'2025-05-02',18050.00,1,'confirmada',2),(2,'2025-05-05',6150.00,4,'confirmada',2),(3,'2025-05-07',13900.00,3,'confirmada',3),(4,'2025-05-09',2150.00,2,'confirmada',2),(5,'2025-05-12',31600.00,1,'confirmada',3),(6,'2025-05-14',3600.00,4,'confirmada',2),(7,'2025-05-16',4500.00,2,'confirmada',3),(8,'2025-05-19',9300.00,1,'confirmada',2),(9,'2025-05-21',1600.00,4,'confirmada',3),(10,'2025-05-23',2400.00,1,'anulada',2),(11,'2026-06-10',94800.00,4,'anulada',1);
/*!40000 ALTER TABLE `venta` ENABLE KEYS */;
UNLOCK TABLES;
SET @@SESSION.SQL_LOG_BIN = @MYSQLDUMP_TEMP_LOG_BIN;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2026-06-10 19:07:46
