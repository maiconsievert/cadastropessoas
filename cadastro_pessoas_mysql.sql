/*
SQLyog Ultimate v10.00 Beta1
MySQL - 5.5.45 : Database - cadastro_pessoas
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `pessoas` */

DROP TABLE IF EXISTS `pessoas`;

CREATE TABLE `pessoas` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Tipo` varchar(50) DEFAULT NULL,
  `Nome` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Cpf` varchar(50) DEFAULT NULL,
  `Cnpj` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `pessoas` */

insert  into `pessoas`(`Id`,`Tipo`,`Nome`,`Email`,`Cpf`,`Cnpj`) values (1,'fisica','Maicon Sievert','maicon.ii@gmail.com','058.941.149-77',''),(2,'juridica','José Pereira','jose@pereira.com','','11.111.111/1111-11'),(3,'fisica','Benetido Ruy','ben@dito.ru','222.222.222-22','');

/*Table structure for table `pessoas_enderecos` */

DROP TABLE IF EXISTS `pessoas_enderecos`;

CREATE TABLE `pessoas_enderecos` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Rua` varchar(100) DEFAULT NULL,
  `Numero` varchar(100) DEFAULT NULL,
  `Bairro` varchar(100) DEFAULT NULL,
  `Cidade` varchar(100) DEFAULT NULL,
  `Estado` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `pessoas_enderecos` */

insert  into `pessoas_enderecos`(`Id`,`Rua`,`Numero`,`Bairro`,`Cidade`,`Estado`) values (1,'Rua Erwin Glau','130','Itoupavazinha','Blumenau','SC'),(2,'Rua XV de Novembro Teste','1066','Centro','Blumenau','SC'),(3,'Rua São Paulo','999','Itoupava Seca','Blumenau','SC');

/*Table structure for table `usuarios` */

DROP TABLE IF EXISTS `usuarios`;

CREATE TABLE `usuarios` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(100) DEFAULT NULL,
  `Password` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Data for the table `usuarios` */

insert  into `usuarios`(`Id`,`Username`,`Password`) values (1,'sances','1a618b4c5fdd24e9b9fa87260875b081');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
