CREATE TABLE IF NOT EXISTS T_SEMINAR (
  TS_ID INT NOT NULL,
  TS_CREATE_DATETIME DATETIME NOT NULL,
  TS_CREATE_MSU_ID INT NOT NULL,
  TS_UPDATE_DATETIME DATETIME NOT NULL,
  TS_UPDATE_MSU_ID INT NOT NULL,
  TS_DELETE_DATETIME DATETIME DEFAULT NULL,
  TS_MS_CD CHAR(6) NOT NULL,
  TS_MCLS_CD CHAR(1) NOT NULL,
  TS_MCM_CD CHAR(3) NOT NULL,
  TS_MCS_CD CHAR(5) NOT NULL,
  TS_CCD_CODE_PUBLISH CHAR(3) NOT NULL,
  TS_PUBLISH_DATEIME_START DATETIME NOT NULL,
  TS_PUBLISH_DATEIME_END DATETIME NOT NULL,
  TS_NAME VARCHAR(200) NOT NULL,
  TS_CONTENTS VARCHAR(10000) NOT NULL,
  TS_THUMBNAIL_URL VARCHAR(200) NOT NULL,
  TS_CCD_CODE_SCHEDULE_CTL CHAR(3) NOT NULL,
  TS_CCD_CODE_INPUTTYPE_DATE CHAR(3) NOT NULL,
  PRIMARY KEY (TS_ID)
);