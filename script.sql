-- phpMyAdmin SQL Dump
-- version 4.0.9
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Mar 24, 2014 at 09:02 PM
-- Server version: 5.5.34
-- PHP Version: 5.4.22

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `genericinventory`
--
CREATE DATABASE IF NOT EXISTS `genericinventory` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `genericinventory`;

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
CREATE TABLE IF NOT EXISTS `category` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Truncate table before insert `category`
--

TRUNCATE TABLE `category`;
--
-- Dumping data for table `category`
--

INSERT INTO `category` (`Id`, `Name`) VALUES
(1, 'N/A');

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
CREATE TABLE IF NOT EXISTS `customer` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(50) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `MaidenName` varchar(45) DEFAULT NULL,
  `Gender` varchar(10) DEFAULT NULL,
  `Address` varchar(45) DEFAULT NULL,
  `ContactNumber` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- Truncate table before insert `customer`
--

TRUNCATE TABLE `customer`;
-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
CREATE TABLE IF NOT EXISTS `employee` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Username` varchar(24) DEFAULT NULL,
  `Password` varchar(64) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Truncate table before insert `employee`
--

TRUNCATE TABLE `employee`;
--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`Id`, `Username`, `Password`) VALUES
(1, 'admin', '220100126182941031722585558224334357100'),
(2, 'employee', '220100126182941031722585558224334357100'),
(3, 'encoder', '220100126182941031722585558224334357100'),
(4, 'worker', '220100126182941031722585558224334357100');

-- --------------------------------------------------------

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
CREATE TABLE IF NOT EXISTS `invoice` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `Tax` decimal(14,2) DEFAULT NULL,
  `Discount` decimal(14,2) DEFAULT NULL,
  `TotalAmount` decimal(14,2) DEFAULT NULL,
  `TotalAmountDue` decimal(14,2) DEFAULT NULL,
  `Cash` decimal(14,2) DEFAULT NULL,
  `Change` decimal(14,2) DEFAULT NULL,
  `CustomerId` int(11) NOT NULL,
  `EmployeeId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_Invoice_Customer1_idx` (`CustomerId`),
  KEY `fk_Invoice_Employee1_idx` (`EmployeeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- Truncate table before insert `invoice`
--

TRUNCATE TABLE `invoice`;
-- --------------------------------------------------------

--
-- Table structure for table `invoiceline`
--

DROP TABLE IF EXISTS `invoiceline`;
CREATE TABLE IF NOT EXISTS `invoiceline` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Price` decimal(14,2) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `InvoiceId` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_InvoiceLine_Invoice1_idx` (`InvoiceId`),
  KEY `fk_InvoiceLine_Product1_idx` (`ProductId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- Truncate table before insert `invoiceline`
--

TRUNCATE TABLE `invoiceline`;
-- --------------------------------------------------------

--
-- Table structure for table `product`
--

DROP TABLE IF EXISTS `product`;
CREATE TABLE IF NOT EXISTS `product` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `VendorId` int(11) NOT NULL,
  `CategoryId` int(11) NOT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `Description` varchar(100) DEFAULT NULL,
  `Price` decimal(14,2) DEFAULT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `TimeStamp` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `fk_Product_Vendor_idx` (`VendorId`),
  KEY `fk_Product_Category1_idx` (`CategoryId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Truncate table before insert `product`
--

TRUNCATE TABLE `product`;
--
-- Dumping data for table `product`
--

INSERT INTO `product` (`Id`, `VendorId`, `CategoryId`, `Name`, `Description`, `Price`, `Quantity`, `TimeStamp`) VALUES
(1, 1, 1, 'Sample', 'xxx', '0.00', 0, '2014-03-24 18:14:50');

-- --------------------------------------------------------

--
-- Table structure for table `reorderstock`
--

DROP TABLE IF EXISTS `reorderstock`;
CREATE TABLE IF NOT EXISTS `reorderstock` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductId` int(11) NOT NULL,
  `VendorId` int(11) NOT NULL,
  `OrderQuantity` int(11) NOT NULL,
  `RecievedQuantity` int(11) NOT NULL,
  `LastUpdate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- Truncate table before insert `reorderstock`
--

TRUNCATE TABLE `reorderstock`;
-- --------------------------------------------------------

--
-- Table structure for table `stockhistory`
--

DROP TABLE IF EXISTS `stockhistory`;
CREATE TABLE IF NOT EXISTS `stockhistory` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `EmployeeId` int(11) NOT NULL,
  `ProductId` int(11) NOT NULL,
  `Quantity` int(11) DEFAULT NULL,
  `Date` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`Id`),
  KEY `fk_StockHistory_Product1_idx` (`ProductId`),
  KEY `fk_stockhistory_employee1_idx` (`EmployeeId`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Truncate table before insert `stockhistory`
--

TRUNCATE TABLE `stockhistory`;
--
-- Dumping data for table `stockhistory`
--

INSERT INTO `stockhistory` (`Id`, `EmployeeId`, `ProductId`, `Quantity`, `Date`) VALUES
(1, 1, 1, 0, '2014-03-24 19:51:35');

-- --------------------------------------------------------

--
-- Stand-in structure for view `stockhistoryview`
--
DROP VIEW IF EXISTS `stockhistoryview`;
CREATE TABLE IF NOT EXISTS `stockhistoryview` (
`Id` int(11)
,`Quantity` int(11)
,`Product` varchar(50)
,`Employee` varchar(24)
,`Date` timestamp
);
-- --------------------------------------------------------

--
-- Table structure for table `vendor`
--

DROP TABLE IF EXISTS `vendor`;
CREATE TABLE IF NOT EXISTS `vendor` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) NOT NULL,
  `ContactNumber` varchar(45) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=2 ;

--
-- Truncate table before insert `vendor`
--

TRUNCATE TABLE `vendor`;
--
-- Dumping data for table `vendor`
--

INSERT INTO `vendor` (`Id`, `Name`, `ContactNumber`, `Email`) VALUES
(1, 'N/A', '00000000', 'example@example.com');

-- --------------------------------------------------------

--
-- Structure for view `stockhistoryview`
--
DROP TABLE IF EXISTS `stockhistoryview`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `stockhistoryview` AS select `stockhistory`.`Id` AS `Id`,`stockhistory`.`Quantity` AS `Quantity`,`product`.`Name` AS `Product`,`employee`.`Username` AS `Employee`,`stockhistory`.`Date` AS `Date` from ((`stockhistory` join `product` on((`stockhistory`.`ProductId` = `product`.`Id`))) join `employee` on((`stockhistory`.`EmployeeId` = `employee`.`Id`)));

--
-- Constraints for dumped tables
--

--
-- Constraints for table `invoice`
--
ALTER TABLE `invoice`
  ADD CONSTRAINT `fk_Invoice_Customer1` FOREIGN KEY (`CustomerId`) REFERENCES `customer` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Invoice_Employee1` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `invoiceline`
--
ALTER TABLE `invoiceline`
  ADD CONSTRAINT `fk_InvoiceLine_Invoice1` FOREIGN KEY (`InvoiceId`) REFERENCES `invoice` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_InvoiceLine_Product1` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `fk_Product_Category1` FOREIGN KEY (`CategoryId`) REFERENCES `category` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Product_Vendor` FOREIGN KEY (`VendorId`) REFERENCES `vendor` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Constraints for table `stockhistory`
--
ALTER TABLE `stockhistory`
  ADD CONSTRAINT `fk_stockhistory_employee1` FOREIGN KEY (`EmployeeId`) REFERENCES `employee` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_StockHistory_Product1` FOREIGN KEY (`ProductId`) REFERENCES `product` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
