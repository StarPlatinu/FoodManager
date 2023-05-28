-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: restaurantDB
-- Source Schemata: restaurant
-- Created: Sun May 28 14:55:16 2023
-- Workbench Version: 8.0.33
-- ----------------------------------------------------------------------------

SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------------------------------------------------------
-- Schema restaurantDB
-- ----------------------------------------------------------------------------
DROP SCHEMA IF EXISTS `restaurantDB` ;
CREATE SCHEMA IF NOT EXISTS `restaurantDB` ;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.booking
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`booking` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `tableId` BIGINT NOT NULL,
  `userId` BIGINT NULL DEFAULT NULL,
  `token` VARCHAR(100) NOT NULL,
  `status` SMALLINT NOT NULL DEFAULT '0',
  `firstName` VARCHAR(50) NULL DEFAULT NULL,
  `middleName` VARCHAR(50) NULL DEFAULT NULL,
  `lastName` VARCHAR(50) NULL DEFAULT NULL,
  `mobile` VARCHAR(15) NULL DEFAULT NULL,
  `email` VARCHAR(50) NULL DEFAULT NULL,
  `line1` VARCHAR(50) NULL DEFAULT NULL,
  `line2` VARCHAR(50) NULL DEFAULT NULL,
  `city` VARCHAR(50) NULL DEFAULT NULL,
  `province` VARCHAR(50) NULL DEFAULT NULL,
  `country` VARCHAR(50) NULL DEFAULT NULL,
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `idx_booking_table` (`tableId` ASC) VISIBLE,
  INDEX `idx_booking_user` (`userId` ASC) VISIBLE,
  CONSTRAINT `fk_booking_table`
    FOREIGN KEY (`tableId`)
    REFERENCES `restaurantDB`.`table_top` (`id`),
  CONSTRAINT `fk_booking_user`
    FOREIGN KEY (`userId`)
    REFERENCES `restaurantDB`.`user` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.booking_item
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`booking_item` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `bookingId` BIGINT NOT NULL,
  `itemId` BIGINT NOT NULL,
  `sku` VARCHAR(100) NOT NULL,
  `price` FLOAT NOT NULL DEFAULT '0',
  `discount` FLOAT NOT NULL DEFAULT '0',
  `quantity` FLOAT NOT NULL DEFAULT '0',
  `unit` SMALLINT NOT NULL DEFAULT '0',
  `status` SMALLINT NOT NULL DEFAULT '0',
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `idx_booking_item_booking` (`bookingId` ASC) VISIBLE,
  INDEX `idx_booking_item_item` (`itemId` ASC) VISIBLE,
  CONSTRAINT `fk_booking_item_booking`
    FOREIGN KEY (`bookingId`)
    REFERENCES `restaurantDB`.`booking` (`id`)
    ON DELETE RESTRICT,
  CONSTRAINT `fk_booking_item_item`
    FOREIGN KEY (`itemId`)
    REFERENCES `restaurantDB`.`item` (`id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.ingredient
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`ingredient` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `userId` BIGINT NOT NULL,
  `vendorId` BIGINT NULL DEFAULT NULL,
  `title` VARCHAR(75) NOT NULL,
  `slug` VARCHAR(100) NOT NULL,
  `summary` TINYTEXT NULL DEFAULT NULL,
  `type` SMALLINT NOT NULL DEFAULT '0',
  `sku` VARCHAR(100) NOT NULL,
  `quantity` FLOAT NOT NULL DEFAULT '0',
  `unit` SMALLINT NOT NULL DEFAULT '0',
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_slug` (`slug` ASC) VISIBLE,
  INDEX `idx_ingredient_user` (`userId` ASC) VISIBLE,
  INDEX `idx_ingredient_vendor` (`vendorId` ASC) VISIBLE,
  CONSTRAINT `fk_ingredient_user`
    FOREIGN KEY (`userId`)
    REFERENCES `restaurantDB`.`user` (`id`)
    ON DELETE RESTRICT,
  CONSTRAINT `fk_ingredient_vendor`
    FOREIGN KEY (`vendorId`)
    REFERENCES `restaurantDB`.`user` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.item
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`item` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `userId` BIGINT NOT NULL,
  `vendorId` BIGINT NULL DEFAULT NULL,
  `title` VARCHAR(75) NOT NULL,
  `slug` VARCHAR(100) NOT NULL,
  `summary` TINYTEXT NULL DEFAULT NULL,
  `type` SMALLINT NOT NULL DEFAULT '0',
  `cooking` TINYINT(1) NOT NULL DEFAULT '0',
  `sku` VARCHAR(100) NOT NULL,
  `price` FLOAT NOT NULL DEFAULT '0',
  `quantity` FLOAT NOT NULL DEFAULT '0',
  `unit` SMALLINT NOT NULL DEFAULT '0',
  `recipe` TEXT NULL DEFAULT NULL,
  `instructions` TEXT NULL DEFAULT NULL,
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_slug` (`slug` ASC) VISIBLE,
  INDEX `idx_item_user` (`userId` ASC) VISIBLE,
  INDEX `idx_item_vendor` (`vendorId` ASC) VISIBLE,
  CONSTRAINT `fk_item_user`
    FOREIGN KEY (`userId`)
    REFERENCES `restaurantDB`.`user` (`id`)
    ON DELETE RESTRICT,
  CONSTRAINT `fk_item_vendor`
    FOREIGN KEY (`vendorId`)
    REFERENCES `restaurantDB`.`user` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.item_chef
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`item_chef` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `itemId` BIGINT NOT NULL,
  `chefId` BIGINT NOT NULL,
  `active` TINYINT(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_item_chef` (`itemId` ASC, `chefId` ASC) VISIBLE,
  INDEX `idx_item_chef_item` (`itemId` ASC) VISIBLE,
  INDEX `idx_item_chef_chef` (`chefId` ASC) VISIBLE,
  CONSTRAINT `fk_item_chef_chef`
    FOREIGN KEY (`chefId`)
    REFERENCES `restaurantDB`.`user` (`id`)
    ON DELETE CASCADE,
  CONSTRAINT `fk_item_chef_item`
    FOREIGN KEY (`itemId`)
    REFERENCES `restaurantDB`.`item` (`id`)
    ON DELETE CASCADE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.menu
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`menu` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `userId` BIGINT NOT NULL,
  `title` VARCHAR(75) NOT NULL,
  `slug` VARCHAR(100) NOT NULL,
  `summary` TINYTEXT NULL DEFAULT NULL,
  `type` SMALLINT NOT NULL DEFAULT '0',
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_slug` (`slug` ASC) VISIBLE,
  INDEX `idx_menu_user` (`userId` ASC) VISIBLE,
  CONSTRAINT `fk_menu_user`
    FOREIGN KEY (`userId`)
    REFERENCES `restaurantDB`.`user` (`id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.menu_item
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`menu_item` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `menuId` BIGINT NOT NULL,
  `itemId` BIGINT NOT NULL,
  `active` TINYINT(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_menu_item` (`menuId` ASC, `itemId` ASC) VISIBLE,
  INDEX `idx_menu_item_menu` (`menuId` ASC) VISIBLE,
  INDEX `idx_menu_item_item` (`itemId` ASC) VISIBLE,
  CONSTRAINT `fk_menu_item_item`
    FOREIGN KEY (`itemId`)
    REFERENCES `restaurantDB`.`item` (`id`)
    ON DELETE RESTRICT,
  CONSTRAINT `fk_menu_item_menu`
    FOREIGN KEY (`menuId`)
    REFERENCES `restaurantDB`.`menu` (`id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.order
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`order` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `userId` BIGINT NULL DEFAULT NULL,
  `vendorId` BIGINT NULL DEFAULT NULL,
  `token` VARCHAR(100) NOT NULL,
  `status` SMALLINT NOT NULL DEFAULT '0',
  `subTotal` FLOAT NOT NULL DEFAULT '0',
  `itemDiscount` FLOAT NOT NULL DEFAULT '0',
  `tax` FLOAT NOT NULL DEFAULT '0',
  `shipping` FLOAT NOT NULL DEFAULT '0',
  `total` FLOAT NOT NULL DEFAULT '0',
  `promo` VARCHAR(50) NULL DEFAULT NULL,
  `discount` FLOAT NOT NULL DEFAULT '0',
  `grandTotal` FLOAT NOT NULL DEFAULT '0',
  `firstName` VARCHAR(50) NULL DEFAULT NULL,
  `middleName` VARCHAR(50) NULL DEFAULT NULL,
  `lastName` VARCHAR(50) NULL DEFAULT NULL,
  `mobile` VARCHAR(15) NULL DEFAULT NULL,
  `email` VARCHAR(50) NULL DEFAULT NULL,
  `line1` VARCHAR(50) NULL DEFAULT NULL,
  `line2` VARCHAR(50) NULL DEFAULT NULL,
  `city` VARCHAR(50) NULL DEFAULT NULL,
  `province` VARCHAR(50) NULL DEFAULT NULL,
  `country` VARCHAR(50) NULL DEFAULT NULL,
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `idx_order_user` (`userId` ASC) VISIBLE,
  INDEX `idx_order_vendor` (`vendorId` ASC) VISIBLE,
  CONSTRAINT `fk_order_user`
    FOREIGN KEY (`userId`)
    REFERENCES `restaurantDB`.`user` (`id`),
  CONSTRAINT `fk_order_vendor`
    FOREIGN KEY (`vendorId`)
    REFERENCES `restaurantDB`.`user` (`id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.order_item
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`order_item` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `orderId` BIGINT NOT NULL,
  `itemId` BIGINT NOT NULL,
  `sku` VARCHAR(100) NOT NULL,
  `price` FLOAT NOT NULL DEFAULT '0',
  `discount` FLOAT NOT NULL DEFAULT '0',
  `quantity` FLOAT NOT NULL DEFAULT '0',
  `unit` SMALLINT NOT NULL DEFAULT '0',
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `idx_order_item_order` (`orderId` ASC) VISIBLE,
  INDEX `idx_order_item_item` (`itemId` ASC) VISIBLE,
  CONSTRAINT `fk_order_item_item`
    FOREIGN KEY (`itemId`)
    REFERENCES `restaurantDB`.`item` (`id`),
  CONSTRAINT `fk_order_item_order`
    FOREIGN KEY (`orderId`)
    REFERENCES `restaurantDB`.`order` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.recipe
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`recipe` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `itemId` BIGINT NOT NULL,
  `ingredientId` BIGINT NOT NULL,
  `quantity` FLOAT NOT NULL DEFAULT '0',
  `unit` SMALLINT NOT NULL DEFAULT '0',
  `instructions` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_recipe_item_ingredient` (`itemId` ASC, `ingredientId` ASC) VISIBLE,
  INDEX `idx_recipe_item` (`itemId` ASC) VISIBLE,
  INDEX `idx_recipe_ingredient` (`ingredientId` ASC) VISIBLE,
  CONSTRAINT `fk_recipe_ingredient`
    FOREIGN KEY (`ingredientId`)
    REFERENCES `restaurantDB`.`ingredient` (`id`)
    ON DELETE RESTRICT,
  CONSTRAINT `fk_recipe_item`
    FOREIGN KEY (`itemId`)
    REFERENCES `restaurantDB`.`item` (`id`)
    ON DELETE RESTRICT)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.table_top
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`table_top` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `code` VARCHAR(100) NOT NULL,
  `status` SMALLINT NOT NULL DEFAULT '0',
  `capacity` SMALLINT NOT NULL DEFAULT '0',
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.transaction
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`transaction` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `userId` BIGINT NOT NULL,
  `vendorId` BIGINT NOT NULL,
  `orderId` BIGINT NOT NULL,
  `code` VARCHAR(100) NOT NULL,
  `type` SMALLINT NOT NULL DEFAULT '0',
  `mode` SMALLINT NOT NULL DEFAULT '0',
  `status` SMALLINT NOT NULL DEFAULT '0',
  `createdAt` DATETIME NOT NULL,
  `updatedAt` DATETIME NULL DEFAULT NULL,
  `content` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  INDEX `idx_transaction_user` (`userId` ASC) VISIBLE,
  INDEX `idx_transaction_vendor` (`vendorId` ASC) VISIBLE,
  INDEX `idx_transaction_order` (`orderId` ASC) VISIBLE,
  CONSTRAINT `fk_transaction_order`
    FOREIGN KEY (`orderId`)
    REFERENCES `restaurantDB`.`order` (`id`),
  CONSTRAINT `fk_transaction_user`
    FOREIGN KEY (`userId`)
    REFERENCES `restaurantDB`.`user` (`id`),
  CONSTRAINT `fk_transaction_vendor`
    FOREIGN KEY (`vendorId`)
    REFERENCES `restaurantDB`.`user` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;

-- ----------------------------------------------------------------------------
-- Table restaurantDB.user
-- ----------------------------------------------------------------------------
CREATE TABLE IF NOT EXISTS `restaurantDB`.`user` (
  `id` BIGINT NOT NULL AUTO_INCREMENT,
  `firstName` VARCHAR(50) NULL DEFAULT NULL,
  `middleName` VARCHAR(50) NULL DEFAULT NULL,
  `lastName` VARCHAR(50) NULL DEFAULT NULL,
  `mobile` VARCHAR(15) NULL DEFAULT NULL,
  `email` VARCHAR(50) NULL DEFAULT NULL,
  `passwordHash` VARCHAR(32) NOT NULL,
  `admin` TINYINT(1) NOT NULL DEFAULT '0',
  `vendor` TINYINT(1) NOT NULL DEFAULT '0',
  `chef` TINYINT(1) NOT NULL DEFAULT '0',
  `agent` TINYINT(1) NOT NULL DEFAULT '0',
  `registeredAt` DATETIME NOT NULL,
  `lastLogin` DATETIME NULL DEFAULT NULL,
  `intro` TINYTEXT NULL DEFAULT NULL,
  `profile` TEXT NULL DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `uq_mobile` (`mobile` ASC) VISIBLE,
  UNIQUE INDEX `uq_email` (`email` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_unicode_ci;
SET FOREIGN_KEY_CHECKS = 1;
