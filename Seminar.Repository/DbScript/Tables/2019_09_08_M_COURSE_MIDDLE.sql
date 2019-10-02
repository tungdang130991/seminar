CREATE TABLE IF NOT EXISTS M_COURSE_MIDDLE (
  MCM_CD CHAR(3) NOT NULL,
  MCM_CREATE_DATETIME DATETIME NOT NULL,
  MCM_CREATE_MSU_ID INT NOT NULL,
  MCM_UPDATE_DATETIME DATETIME NOT NULL,
  MCM_UPDATE_MSU_ID INT NOT NULL,
  MCM_DELETE_DATETIME DATETIME DEFAULT NULL,
  MCM_MCL_CD CHAR(1) NOT NULL,
  MCM_NAME VARCHAR(40) NOT NULL,
  MCM_SORT INT NOT NULL,
  PRIMARY KEY (MCM_CD)
);