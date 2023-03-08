/*
Navicat MySQL Data Transfer

Source Server         : local_mysql
Source Server Version : 80028
Source Host           : localhost:3306
Source Database       : fastlink

Target Server Type    : MYSQL
Target Server Version : 80028
File Encoding         : 65001

Date: 2023-03-08 09:24:42
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for peoples
-- ----------------------------
DROP TABLE IF EXISTS `peoples`;
CREATE TABLE `peoples` (
`id`  int NOT NULL AUTO_INCREMENT ,
`name`  varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL ,
`birthday`  varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL ,
`telephone`  varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=MyISAM
DEFAULT CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
AUTO_INCREMENT=3

;

-- ----------------------------
-- Records of peoples
-- ----------------------------
BEGIN;
INSERT INTO `peoples` VALUES ('1', 'user51', '2020-01-01', '18932180745'), ('2', 'kevin', '2020-01-01', '18932180745');
COMMIT;

-- ----------------------------
-- Table structure for product
-- ----------------------------
DROP TABLE IF EXISTS `product`;
CREATE TABLE `product` (
`name`  varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL ,
`id`  int NOT NULL AUTO_INCREMENT ,
`specification`  varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL ,
`product_code`  varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NULL DEFAULT NULL ,
`create_time`  datetime NULL DEFAULT NULL ,
PRIMARY KEY (`id`)
)
ENGINE=InnoDB
DEFAULT CHARACTER SET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
AUTO_INCREMENT=12

;

-- ----------------------------
-- Records of product
-- ----------------------------
BEGIN;
INSERT INTO `product` VALUES ('1', '1', null, '1', '2023-03-22 19:38:56'), ('string', '2', 'string', 'string', '2023-03-04 13:02:00'), ('string', '3', 'string', 'string', '2023-03-04 13:02:57'), ('put4', '4', 'put4', 'put4', '2023-03-04 13:42:12'), ('string', '5', 'string', 'string', '0001-01-01 00:00:00'), ('string', '6', 'string', 'string', '2023-03-04 13:08:52'), ('string', '7', 'string', 'string', '2023-03-04 13:09:16'), ('string', '8', 'string', 'string', '2023-03-04 13:09:36'), ('string', '9', 'string', 'string', '2023-03-04 13:22:49'), ('good', '11', 'good', 'good', '2023-03-08 01:16:30');
COMMIT;

-- ----------------------------
-- Auto increment value for peoples
-- ----------------------------
ALTER TABLE `peoples` AUTO_INCREMENT=3;

-- ----------------------------
-- Auto increment value for product
-- ----------------------------
ALTER TABLE `product` AUTO_INCREMENT=12;
