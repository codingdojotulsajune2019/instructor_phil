-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema dojo_survey
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema dojo_survey
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `dojo_survey` DEFAULT CHARACTER SET utf8 ;
USE `dojo_survey` ;

-- -----------------------------------------------------
-- Table `dojo_survey`.`dojos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `dojo_survey`.`dojos` (
  `dojo_id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NULL,
  `location` VARCHAR(45) NULL,
  `language` VARCHAR(45) NULL,
  `comment` TEXT NULL,
  `created_at` DATETIME NULL DEFAULT Now(),
  `updated_at` DATETIME NULL DEFAULT Now() ON UPDATE Now(),
  PRIMARY KEY (`dojo_id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
