CREATE TABLE IF NOT EXISTS M_SYSTEM_USER(
    MSU_ID INT AUTO_INCREMENT,
    MSU_CREATE_DATETIME DATETIME NOT NULL,
    MSU_CREATE_MSU_ID INT NOT NULL,
    MSU_UPDATE_DATETIME DATETIME NOT NULL,
    MSU_UPDATE_MSU_ID INT NOT NULL,
    MSU_DELETE_DATETIME DATETIME,
    MSU_NAME VARCHAR(40) NOT NULL,
    MSU_CCD_CODE_ACCOUNT_TYPE CHAR(3),
    MSU_MS_CD CHAR(6),
    MSU_LOGIN_ID VARCHAR(20) NOT NULL,
    MSU_LOGIN_PASSWD VARCHAR(40) NOT NULL,
    PRIMARY KEY (MSU_ID)
);