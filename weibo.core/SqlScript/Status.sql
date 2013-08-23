/**
 *		作用：		创建statusOption表
 * 		表名：		statusOption
 */
 CREATE TABLE `statusOption` (
	`accountMgrId` int(10) unsigned NOT NULL,
	`tableId` int(10) unsigned NOT NULL DEFAULT '0',
	PRIMARY KEY  (`accountMgrId`)
	) ENGINE=MyISAM DEFAULT CHARSET=utf8;
