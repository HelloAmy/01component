
/* 建立数据库LogException */
create database LogException default charset utf8 collate utf8_general_ci;

/*建立数表AppException20151208*/
CREATE TABLE AppException20151208
(
	LogID varchar(36) not null default '' COMMENT '日志ID',
	TrackID varchar(30) not null default '' COMMENT '跟踪ID',
	ErrorCode varchar(20) not null default '' COMMENT '错误码',
	ExceptionLevel tinyint(4) not null default 0 COMMENT '异常级别',
	TimePoint timestamp not null current_timestamp on update current_timestamp COMMENT '时间戳',
	ApplicationName varchar(50) not null default '' COMMENT '应用程序名',
	LocalIP varchar(30) not null default '' COMMENT '本地IP',
	ThreadID varchar(11) not null default '' COMMENT '进程ID',
	ExceptionMsg text not null default '' COMMENT '异常信息',
	ExceptionContext text not null default '' COMMENT '异常上下文',
	OrginalExceptionMsg varchar(100) not null default '' COMMENT '原始异常信息',
	primary key(LogID),
	Key IDX_AppException20151208_1 (TrackID)
)ENGINE=InnoDB default charset=utf8 COMMENT='App异常表';


/** 创建存储过程 **/
DROP PROCEDURE IF EXISTS `logexception`.`Pro_CreateAppExceptionTable`;
CREATE PROCEDURE Pro_CreateAppExceptionTable()
BEGIN
	SET @tableName=concat('AppException',DATE_FORMAT(NOW(), '%Y%m%d'));
	SET @sqlstr= concat('CREATE TABLE `',@tableName,'` (
`LogID` varchar(36) NOT NULL DEFAULT \'\' COMMENT \'日志ID\',
`TrackID` varchar(30) NOT NULL DEFAULT \'\' COMMENT \'跟踪ID\',
`ErrorCode` varchar(20) NOT NULL DEFAULT \'\' COMMENT \'错误码\',
`ExceptionLevel` tinyint(4) NOT NULL DEFAULT \'0\' COMMENT \'异常级别\',
`TimePoint` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT \'时间戳\',
`ApplicationName` varchar(50) NOT NULL DEFAULT \'\' COMMENT \'应用程序名\',
`LocalIP` varchar(30) NOT NULL DEFAULT \'\' COMMENT \'本地IP\',
`ExceptionMsg` text NOT NULL COMMENT \'异常信息\',
`ExceptionContext` text NOT NULL COMMENT \'异常上下文\',
`OrginalExceptionMsg` varchar(100) NOT NULL DEFAULT \'\' COMMENT \'原始异常信息\',
PRIMARY KEY (`LogID`),
KEY `IDX_AppException20151208_1` (`TrackID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT=\'App异常表\';');

PREPARE STMT FROM @sqlstr;
EXECUTE STMT;
DEALLOCATE PREPARE STMT;
END;

/** 执行存储过程 
CALL Pro_CreateAppExceptionTable();
**/