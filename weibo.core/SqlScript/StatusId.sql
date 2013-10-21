/**
 *		作用：		创建statusId表
 * 		表名：		statusId
 */
 CREATE TABLE `statusId` (
	`accountMgrId` int(10) unsigned NOT NULL,
	`tableId` int(10) unsigned NOT NULL DEFAULT '0',
	PRIMARY KEY  (`accountMgrId`)
	) ENGINE=MyISAM DEFAULT CHARSET=utf8;
