/*
SQLyog Community v13.1.5  (64 bit)
MySQL - 8.1.0 : Database - tagumpaydb
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`tagumpaydb` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

USE `tagumpaydb`;

/*Table structure for table `adminstb` */

DROP TABLE IF EXISTS `adminstb`;

CREATE TABLE `adminstb` (
  `adminId` int NOT NULL AUTO_INCREMENT,
  `userId` int NOT NULL,
  PRIMARY KEY (`adminId`),
  UNIQUE KEY `userId` (`userId`),
  CONSTRAINT `FK_Admins_Users` FOREIGN KEY (`userId`) REFERENCES `userstb` (`userId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `adminstb` */

/*Table structure for table `attendancerecordstb` */

DROP TABLE IF EXISTS `attendancerecordstb`;

CREATE TABLE `attendancerecordstb` (
  `attendanceId` int NOT NULL AUTO_INCREMENT,
  `employeeId` int NOT NULL,
  `attendanceDate` date NOT NULL,
  `timeIn` time DEFAULT NULL,
  `timeOut` time DEFAULT NULL,
  `status` varchar(20) NOT NULL,
  PRIMARY KEY (`attendanceId`),
  KEY `FK_Attendance_Employees` (`employeeId`),
  CONSTRAINT `FK_Attendance_Employees` FOREIGN KEY (`employeeId`) REFERENCES `employeestb` (`employeeId`) ON DELETE CASCADE,
  CONSTRAINT `CHK_Attendance_Status` CHECK ((`status` in (_utf8mb3'Present',_utf8mb3'Absent')))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `attendancerecordstb` */

/*Table structure for table `employeestb` */

DROP TABLE IF EXISTS `employeestb`;

CREATE TABLE `employeestb` (
  `employeeId` int NOT NULL AUTO_INCREMENT,
  `userId` int NOT NULL,
  `fullName` varchar(150) NOT NULL,
  `positionId` int NOT NULL,
  `contactInfo` varchar(100) NOT NULL,
  `employmentStatus` varchar(30) NOT NULL DEFAULT 'Regular',
  PRIMARY KEY (`employeeId`),
  UNIQUE KEY `userId` (`userId`),
  KEY `FK_Employees_Positions` (`positionId`),
  CONSTRAINT `FK_Employees_Positions` FOREIGN KEY (`positionId`) REFERENCES `positionstb` (`positionId`),
  CONSTRAINT `FK_Employees_Users` FOREIGN KEY (`userId`) REFERENCES `userstb` (`userId`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `employeestb` */

/*Table structure for table `payrollrecordstb` */

DROP TABLE IF EXISTS `payrollrecordstb`;

CREATE TABLE `payrollrecordstb` (
  `payrollId` int NOT NULL AUTO_INCREMENT,
  `employeeId` int NOT NULL,
  `payrollPeriod` date NOT NULL,
  `daysWorked` int NOT NULL,
  `daysAbsent` int NOT NULL,
  `overtimeHours` decimal(5,2) NOT NULL,
  `basicPay` decimal(12,2) NOT NULL,
  `overtimePay` decimal(12,2) NOT NULL,
  `grossPay` decimal(12,2) NOT NULL,
  PRIMARY KEY (`payrollId`),
  KEY `FK_Payroll_Employees` (`employeeId`),
  CONSTRAINT `FK_Payroll_Employees` FOREIGN KEY (`employeeId`) REFERENCES `employeestb` (`employeeId`) ON DELETE CASCADE,
  CONSTRAINT `CHK_Payroll_BasicPay` CHECK ((`basicPay` >= 0)),
  CONSTRAINT `CHK_Payroll_DaysAbsent` CHECK ((`daysAbsent` >= 0)),
  CONSTRAINT `CHK_Payroll_DaysWorked` CHECK ((`daysWorked` >= 0)),
  CONSTRAINT `CHK_Payroll_GrossPay` CHECK ((`grossPay` >= 0)),
  CONSTRAINT `CHK_Payroll_OvertimeHours` CHECK ((`overtimeHours` >= 0)),
  CONSTRAINT `CHK_Payroll_OvertimePay` CHECK ((`overtimePay` >= 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `payrollrecordstb` */

/*Table structure for table `positionstb` */

DROP TABLE IF EXISTS `positionstb`;

CREATE TABLE `positionstb` (
  `positionId` int NOT NULL AUTO_INCREMENT,
  `positionName` varchar(100) NOT NULL,
  `dailyRate` decimal(10,2) NOT NULL,
  `overtimeRate` decimal(10,2) NOT NULL,
  PRIMARY KEY (`positionId`),
  UNIQUE KEY `positionName` (`positionName`),
  CONSTRAINT `CHK_Positions_DailyRate` CHECK ((`dailyRate` >= 0)),
  CONSTRAINT `CHK_Positions_OvertimeRate` CHECK ((`overtimeRate` >= 0))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `positionstb` */

/*Table structure for table `userstb` */

DROP TABLE IF EXISTS `userstb`;

CREATE TABLE `userstb` (
  `userId` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) NOT NULL,
  `passwordHash` varchar(255) NOT NULL,
  `role` varchar(20) NOT NULL,
  PRIMARY KEY (`userId`),
  UNIQUE KEY `username` (`username`),
  CONSTRAINT `CHK_Users_Role` CHECK ((`role` in (_utf8mb3'Admin',_utf8mb3'Employee')))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

/*Data for the table `userstb` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
