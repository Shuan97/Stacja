SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema stacja
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `stacja` DEFAULT CHARACTER SET utf8 COLLATE utf8_bin ;
USE `stacja` ;

-- -----------------------------------------------------
-- Table `stacja`.`camera`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `stacja`.`camera` (
  `CAM_ID` INT(11) NOT NULL,
  `CAM_ACCES` TINYINT(4) NULL DEFAULT NULL,
  `CAM_INFO` VARCHAR(255) NULL DEFAULT NULL,
  `CAM_POSITION` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`CAM_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `stacja`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `stacja`.`user` (
  `USR_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `USR_NAME` VARCHAR(255) NULL DEFAULT NULL,
  `USR_SURNAME` VARCHAR(255) NULL DEFAULT NULL,
  `USR_LEVEL` INT(11) NULL DEFAULT NULL,
  `USR_LOGIN` VARCHAR(255) NOT NULL,
  `USR_PASSWORD` VARCHAR(255) NOT NULL,
  `USR_MAIL` VARCHAR(255) NOT NULL,
  `USR_AGE` INT(2) NULL DEFAULT NULL,
  `USR_ROLE` INT(1) NOT NULL,
  `USR_CITY` VARCHAR(100) NULL DEFAULT NULL,
  `USR_STREET` VARCHAR(100) NULL DEFAULT NULL,
  `USR_CODE` VARCHAR(45) NULL DEFAULT NULL,
  `USR_PESEL` VARCHAR(45) NULL DEFAULT NULL,
  `USR_NIP` VARCHAR(45) NULL DEFAULT NULL,
  `USR_REGON` VARCHAR(45) NULL DEFAULT NULL,
  PRIMARY KEY (`USR_ID`),
  UNIQUE INDEX `USR_ID_UNIQUE` (`USR_ID` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 59
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `stacja`.`cam_usr`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `stacja`.`cam_usr` (
  `CAM_USR_ID` INT(11) NOT NULL,
  `USR_ID` INT(11) NULL DEFAULT NULL,
  `CAM_ID` INT(11) NULL DEFAULT NULL,
  `CAM_USR_INFO` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`CAM_USR_ID`),
  INDEX `USR_ID_idx` (`USR_ID` ASC) VISIBLE,
  INDEX `CAM_ID_idx` (`CAM_ID` ASC) VISIBLE,
  CONSTRAINT `FK_CAM_CAM_USR`
    FOREIGN KEY (`CAM_ID`)
    REFERENCES `stacja`.`camera` (`CAM_ID`),
  CONSTRAINT `FK_USR_CAM_USR`
    FOREIGN KEY (`USR_ID`)
    REFERENCES `stacja`.`user` (`USR_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `stacja`.`carwash_res`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `stacja`.`carwash_res` (
  `CAR_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `USR_ID` INT(11) NOT NULL,
  `CAR_DATE` VARCHAR(10) NULL DEFAULT NULL,
  `CAR_PROGRAM` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`CAR_ID`),
  INDEX `USR_ID_idx` (`USR_ID` ASC) VISIBLE,
  CONSTRAINT `FK_USR_CAR`
    FOREIGN KEY (`USR_ID`)
    REFERENCES `stacja`.`user` (`USR_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `stacja`.`gas_delivery`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `stacja`.`gas_delivery` (
  `GAS_ID` INT(11) NOT NULL,
  `GAD_DATE` DATE NULL DEFAULT NULL,
  `GAS_WHO` VARCHAR(255) NULL DEFAULT NULL,
  `GAS_95` FLOAT NULL DEFAULT NULL,
  `GAS_98` FLOAT NULL DEFAULT NULL,
  `GAS_NO` FLOAT NULL DEFAULT NULL,
  `GAS_LPG` FLOAT NULL DEFAULT NULL,
  `USR_ID` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`GAS_ID`),
  INDEX `USR_ID_idx` (`USR_ID` ASC) VISIBLE,
  CONSTRAINT `FK_USR_GAS`
    FOREIGN KEY (`USR_ID`)
    REFERENCES `stacja`.`user` (`USR_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `stacja`.`invoice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `stacja`.`invoice` (
  `INV_ID` INT(11) NOT NULL,
  `USR_ID` INT(11) NULL DEFAULT NULL,
  `INV_VALUE` FLOAT NULL DEFAULT NULL,
  `INV_TYPE` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`INV_ID`),
  INDEX `USR_ID_idx` (`USR_ID` ASC) VISIBLE,
  CONSTRAINT `FK_USR_INV`
    FOREIGN KEY (`USR_ID`)
    REFERENCES `stacja`.`user` (`USR_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `stacja`.`loyalty_card`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `stacja`.`loyalty_card` (
  `LOY_ID` INT(11) NOT NULL,
  `USR_ID` INT(11) NULL DEFAULT NULL,
  `LOY_CODE` VARCHAR(255) NULL DEFAULT NULL,
  `LOY_POINTS` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`LOY_ID`),
  INDEX `USR_ID_idx` (`USR_ID` ASC) VISIBLE,
  CONSTRAINT `FK_USR_LOY`
    FOREIGN KEY (`USR_ID`)
    REFERENCES `stacja`.`user` (`USR_ID`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


-- -----------------------------------------------------
-- Table `stacja`.`price`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `stacja`.`price` (
  `PRI_ID` INT(11) NOT NULL AUTO_INCREMENT,
  `PRI_PB95` VARCHAR(10) NULL DEFAULT NULL,
  `PRI_PB98` VARCHAR(10) NULL DEFAULT NULL,
  `PRI_ON` VARCHAR(10) NULL DEFAULT NULL,
  `PRI_LPG` VARCHAR(10) NULL DEFAULT NULL,
  `PRI_DATE` VARCHAR(10) NULL DEFAULT NULL,
  PRIMARY KEY (`PRI_ID`))
ENGINE = InnoDB
AUTO_INCREMENT = 10
DEFAULT CHARACTER SET = utf8
COLLATE = utf8_bin;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
