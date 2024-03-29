CREATE TABLE IF NOT EXISTS M_MEASUREMENT_TAG(
    MMT_ID INT NOT NULL  AUTO_INCREMENT ,
	MMT_CREATE_DATETIME DATETIME NOT NULL DEFAULT NOW(),
	MMT_CREATE_MSU_ID INT NOT NULL,
	MMT_UPDATE_DATETIME DATETIME NOT NULL DEFAULT NOW(),
	MMT_UPDATE_MSU_ID INT NOT NULL,
	MMT_DELETE_DATETIME DATETIME  ,
	MMT_CCD_CODE_TYPE_SYSFUNCTION CHAR(3) NOT NULL,
	MMT_HEAD_AREA TEXT NOT NULL,
	MMT_BODY_TOP TEXT NOT NULL,
	MMT_BODY_BOTTOM TEXT NOT NULL,
    PRIMARY KEY (MMT_ID)
);