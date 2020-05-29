/*
Navicat MySQL Data Transfer

Source Server         : 本地mysql
Source Server Version : 50724
Source Host           : localhost:3306
Source Database       : fastlink

Target Server Type    : MYSQL
Target Server Version : 50724
File Encoding         : 65001

Date: 2020-05-11 17:01:31
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `peoples`
-- ----------------------------
DROP TABLE IF EXISTS `peoples`;
CREATE TABLE `peoples` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `birthday` varchar(50) DEFAULT NULL,
  `telephone` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4;

-- ----------------------------
-- Records of peoples
-- ----------------------------
INSERT INTO `peoples` VALUES ('1', 'user51', '2020-01-01', '18932180745');
INSERT INTO `peoples` VALUES ('2', 'kevin', '2020-01-01', '18932180745');
