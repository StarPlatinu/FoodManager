-- ----------------------------------------------------------------------------
-- MySQL Workbench Migration
-- Migrated Schemata: restaurantDB
-- Source Schemata: restaurant
-- Created: Sun May 28 14:55:16 2023
-- Workbench Version: 8.0.33
-- ----------------------------------------------------------------------------

-- ----------------------------------------------------------------------------
-- database restaurantDB
-- ----------------------------------------------------------------------------
CREATE database restaurantDB ;

-- ----------------------------------------------------------------------------
-- Table [User]
-- ----------------------------------------------------------------------------
CREATE table [User] (
  id BIGINT NOT NULL identity(1,1)  PRIMARY KEY,
  firstName VARCHAR(50) NULL DEFAULT NULL,
  middleName VARCHAR(50) NULL DEFAULT NULL,
  lastName VARCHAR(50) NULL DEFAULT NULL,
  mobile VARCHAR(15) NULL DEFAULT NULL,
  email VARCHAR(50) NULL DEFAULT NULL,
  passwordHash VARCHAR(32) NOT NULL,
  admin TINYINT NOT NULL DEFAULT '0',
  vendor TINYINT NOT NULL DEFAULT '0',
  chef TINYINT NOT NULL DEFAULT '0',
  agent TINYINT NOT NULL DEFAULT '0',
  registeredAt DATETIME NOT NULL,
  lastLogin DATETIME NULL DEFAULT NULL,
  intro text NULL DEFAULT NULL,
  profile TEXT NULL DEFAULT NULL )



-- ----------------------------------------------------------------------------
-- Table booking
-- ----------------------------------------------------------------------------
CREATE Table booking (
  id BIGINT NOT NULL identity(1,1) primary key,
  tableId BIGINT NOT NULL,
  userId BIGINT NULL DEFAULT NULL,
  token VARCHAR(100) NOT NULL,
  status SMALLINT NOT NULL DEFAULT '0',
  firstName VARCHAR(50) NULL DEFAULT NULL,
  middleName VARCHAR(50) NULL DEFAULT NULL,
  lastName VARCHAR(50) NULL DEFAULT NULL,
  mobile VARCHAR(15) NULL DEFAULT NULL,
  email VARCHAR(50) NULL DEFAULT NULL,
  line1 VARCHAR(50) NULL DEFAULT NULL,
  line2 VARCHAR(50) NULL DEFAULT NULL,
  city VARCHAR(50) NULL DEFAULT NULL,
  province VARCHAR(50) NULL DEFAULT NULL,
  country VARCHAR(50) NULL DEFAULT NULL,
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  CONSTRAINT fk_booking_table
    FOREIGN KEY (tableId)
    REFERENCES table_top (id),
  CONSTRAINT fk_booking_user
    FOREIGN KEY (userId)
    REFERENCES [User] (id)
    ON DELETE CASCADE)

-- ----------------------------------------------------------------------------
-- Table booking_item
-- ----------------------------------------------------------------------------
CREATE Table booking_item (
  id BIGINT NOT NULL identity(1,1),
  bookingId BIGINT NOT NULL,
  itemId BIGINT NOT NULL,
  sku VARCHAR(100) NOT NULL,
  price FLOAT NOT NULL DEFAULT '0',
  discount FLOAT NOT NULL DEFAULT '0',
  quantity FLOAT NOT NULL DEFAULT '0',
  unit SMALLINT NOT NULL DEFAULT '0',
  status SMALLINT NOT NULL DEFAULT '0',
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_booking_item_booking
    FOREIGN KEY (bookingId)
    REFERENCES booking (id)
    ON DELETE CASCADE)


-- ----------------------------------------------------------------------------
-- Table ingredient
-- ----------------------------------------------------------------------------
CREATE Table ingredient (
  id BIGINT NOT NULL identity(1,1),
  userId BIGINT NOT NULL,
  vendorId BIGINT NULL DEFAULT NULL,
  title VARCHAR(75) NOT NULL,
  slug VARCHAR(100) NOT NULL,
  summary TEXT NULL DEFAULT NULL,
  type SMALLINT NOT NULL DEFAULT '0',
  sku VARCHAR(100) NOT NULL,
  quantity FLOAT NOT NULL DEFAULT '0',
  unit SMALLINT NOT NULL DEFAULT '0',
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_ingredient_user
    FOREIGN KEY (userId)
    REFERENCES [User] (id)
    ON DELETE CASCADE,
  CONSTRAINT fk_ingredient_vendor
    FOREIGN KEY (vendorId)
    REFERENCES [User] (id))


-- ----------------------------------------------------------------------------
-- Table item
-- ----------------------------------------------------------------------------
CREATE Table item (
  id BIGINT NOT NULL identity(1,1),
  userId BIGINT NOT NULL,
  vendorId BIGINT NULL DEFAULT NULL,
  title VARCHAR(75) NOT NULL,
  slug VARCHAR(100) NOT NULL,
  summary TEXT NULL DEFAULT NULL,
  type SMALLINT NOT NULL DEFAULT '0',
  cooking TINYINT NOT NULL DEFAULT '0',
  sku VARCHAR(100) NOT NULL,
  price FLOAT NOT NULL DEFAULT '0',
  quantity FLOAT NOT NULL DEFAULT '0',
  unit SMALLINT NOT NULL DEFAULT '0',
  recipe TEXT NULL DEFAULT NULL,
  instructions TEXT NULL DEFAULT NULL,
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_item_user
    FOREIGN KEY (userId)
    REFERENCES [User] (id)
    ON DELETE CASCADE,
  CONSTRAINT fk_item_vendor
    FOREIGN KEY (vendorId)
    REFERENCES [User] (id))

-- ----------------------------------------------------------------------------
-- Table item_chef
-- ----------------------------------------------------------------------------
CREATE Table item_chef (
  id BIGINT NOT NULL identity(1,1),
  itemId BIGINT NOT NULL,
  chefId BIGINT NOT NULL,
  active TINYINT NOT NULL DEFAULT '1',
  PRIMARY KEY (id),
  CONSTRAINT fk_item_chef_chef
    FOREIGN KEY (chefId)
    REFERENCES [User] (id)
    ON DELETE CASCADE)


-- ----------------------------------------------------------------------------
-- Table menu
-- ----------------------------------------------------------------------------
CREATE Table menu (
  id BIGINT NOT NULL identity(1,1),
  userId BIGINT NOT NULL,
  title VARCHAR(75) NOT NULL,
  slug VARCHAR(100) NOT NULL,
  summary TEXT NULL DEFAULT NULL,
  type SMALLINT NOT NULL DEFAULT '0',
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_menu_user
    FOREIGN KEY (userId)
    REFERENCES [User] (id)
    ON DELETE CASCADE)

-- ----------------------------------------------------------------------------
-- Table menu_item
-- ----------------------------------------------------------------------------
CREATE Table menu_item (
  id BIGINT NOT NULL identity(1,1),
  menuId BIGINT NOT NULL,
  itemId BIGINT NOT NULL,
  active TINYINT NOT NULL DEFAULT '1',
  PRIMARY KEY (id),
  CONSTRAINT fk_menu_item_item
    FOREIGN KEY (itemId)
    REFERENCES item (id)
    ON DELETE CASCADE)

-- ----------------------------------------------------------------------------
-- Table order
-- ----------------------------------------------------------------------------
CREATE Table [Order] (
  id BIGINT NOT NULL identity(1,1),
  userId BIGINT NULL DEFAULT NULL,
  vendorId BIGINT NULL DEFAULT NULL,
  token VARCHAR(100) NOT NULL,
  status SMALLINT NOT NULL DEFAULT '0',
  subTotal FLOAT NOT NULL DEFAULT '0',
  itemDiscount FLOAT NOT NULL DEFAULT '0',
  tax FLOAT NOT NULL DEFAULT '0',
  shipping FLOAT NOT NULL DEFAULT '0',
  total FLOAT NOT NULL DEFAULT '0',
  promo VARCHAR(50) NULL DEFAULT NULL,
  discount FLOAT NOT NULL DEFAULT '0',
  grandTotal FLOAT NOT NULL DEFAULT '0',
  firstName VARCHAR(50) NULL DEFAULT NULL,
  middleName VARCHAR(50) NULL DEFAULT NULL,
  lastName VARCHAR(50) NULL DEFAULT NULL,
  mobile VARCHAR(15) NULL DEFAULT NULL,
  email VARCHAR(50) NULL DEFAULT NULL,
  line1 VARCHAR(50) NULL DEFAULT NULL,
  line2 VARCHAR(50) NULL DEFAULT NULL,
  city VARCHAR(50) NULL DEFAULT NULL,
  province VARCHAR(50) NULL DEFAULT NULL,
  country VARCHAR(50) NULL DEFAULT NULL,
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_order_user
    FOREIGN KEY (userId)
    REFERENCES [User] (id),
  CONSTRAINT fk_order_vendor
    FOREIGN KEY (vendorId)
    REFERENCES [User] (id)
    ON DELETE CASCADE)

-- ----------------------------------------------------------------------------
-- Table order_item
-- ----------------------------------------------------------------------------
CREATE Table order_item (
  id BIGINT NOT NULL identity(1,1),
  orderId BIGINT NOT NULL,
  itemId BIGINT NOT NULL,
  sku VARCHAR(100) NOT NULL,
  price FLOAT NOT NULL DEFAULT '0',
  discount FLOAT NOT NULL DEFAULT '0',
  quantity FLOAT NOT NULL DEFAULT '0',
  unit SMALLINT NOT NULL DEFAULT '0',
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_order_item_item
    FOREIGN KEY (itemId)
    REFERENCES item (id),
  CONSTRAINT fk_order_item_order
    FOREIGN KEY (orderId)
    REFERENCES [Order] (id))


-- ----------------------------------------------------------------------------
-- Table recipe
-- ----------------------------------------------------------------------------
CREATE Table recipe (
  id BIGINT NOT NULL identity(1,1),
  itemId BIGINT NOT NULL,
  ingredientId BIGINT NOT NULL,
  quantity FLOAT NOT NULL DEFAULT '0',
  unit SMALLINT NOT NULL DEFAULT '0',
  instructions TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_recipe_ingredient
    FOREIGN KEY (ingredientId)
    REFERENCES ingredient (id)
    ON DELETE CASCADE)


-- ----------------------------------------------------------------------------
-- Table table_top
-- ----------------------------------------------------------------------------
CREATE Table table_top (
  id BIGINT NOT NULL identity(1,1),
  code VARCHAR(100) NOT NULL,
  status SMALLINT NOT NULL DEFAULT '0',
  capacity SMALLINT NOT NULL DEFAULT '0',
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id))

-- ----------------------------------------------------------------------------
-- Table transaction
-- ----------------------------------------------------------------------------
CREATE Table [Transaction] (
  id BIGINT NOT NULL identity(1,1),
  userId BIGINT NOT NULL,
  vendorId BIGINT NOT NULL,
  orderId BIGINT NOT NULL,
  code VARCHAR(100) NOT NULL,
  type SMALLINT NOT NULL DEFAULT '0',
  mode SMALLINT NOT NULL DEFAULT '0',
  status SMALLINT NOT NULL DEFAULT '0',
  createdAt DATETIME NOT NULL,
  updatedAt DATETIME NULL DEFAULT NULL,
  content TEXT NULL DEFAULT NULL,
  PRIMARY KEY (id),
  CONSTRAINT fk_transaction_order
    FOREIGN KEY (orderId)
    REFERENCES [Order] (id),
  CONSTRAINT fk_transaction_user
    FOREIGN KEY (userId)
    REFERENCES [User] (id),
  CONSTRAINT fk_transaction_vendor
    FOREIGN KEY (vendorId)
    REFERENCES [User] (id))

