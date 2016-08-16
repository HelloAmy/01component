/****** 对象:  Table Book    脚本日期: 2014/2/22 11:44:50 ******/
/****** 字段数据长度 = 301 字节 ******/
DROP TABLE IF EXISTS `Book`;
CREATE TABLE `Book`(
	`KeyID`                            varchar(50)          NOT NULL DEFAULT ''                    COMMENT '主键ID',
	`Name`                             varchar(20)          NOT NULL DEFAULT ''                    COMMENT '书名',
	`Author`                           varchar(20)          NOT NULL DEFAULT ''                    COMMENT '作者',
	`Press`                            tinyint(4) unsigned  NOT NULL DEFAULT 0                     COMMENT '出版社',
	`PressDateTime`                    datetime             NOT NULL DEFAULT '1900-01-01 00:00:00' COMMENT '出版日期',
	`IsRead`                           tinyint(4) unsigned  NOT NULL DEFAULT 0                     COMMENT '是否已读(0：未读 / 1：已读)',
	`IsDelete`                         tinyint(4) unsigned  NOT NULL DEFAULT 0                     COMMENT '是否删除(0：未删除 / 1：删除)',
	`ModifyTime`                       timestamp            NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '时间戳(CURRENT_TIMESTAMP)',
	PRIMARY KEY ( `KeyID` ),
	INDEX `IDX_Book_1` (`Name`),
	INDEX `IDX_Book_2` (`Author`),
	INDEX `IDX_Book_3` (`Press`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='图书表:图书表';
