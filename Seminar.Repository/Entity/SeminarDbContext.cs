using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Seminar.Repository.Entity
{
    public partial class SeminarDbContext : DbContext
    {
        public SeminarDbContext()
        {
        }

        public SeminarDbContext(DbContextOptions<SeminarDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CClassDetail> CClassDetail { get; set; }
        public virtual DbSet<CClassHeader> CClassHeader { get; set; }
        public virtual DbSet<LSystemUserAuthority> LSystemUserAuthority { get; set; }
        public virtual DbSet<MCourseLarge> MCourseLarge { get; set; }
        public virtual DbSet<MCourseMiddle> MCourseMiddle { get; set; }
        public virtual DbSet<MCourseSmall> MCourseSmall { get; set; }
        public virtual DbSet<MLecture> MLecture { get; set; }
        public virtual DbSet<MMeasurementTag> MMeasurementTag { get; set; }
        public virtual DbSet<MProduct> MProduct { get; set; }
        public virtual DbSet<MSchool> MSchool { get; set; }
        public virtual DbSet<MSchoolScheduleClosed> MSchoolScheduleClosed { get; set; }
        public virtual DbSet<MSystemUser> MSystemUser { get; set; }
        public virtual DbSet<TSeminar> TSeminar { get; set; }
        public virtual DbSet<TSeminarConfigCalender> TSeminarConfigCalender { get; set; }
        public virtual DbSet<TSeminarSchedule> TSeminarSchedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=172.16.19.17;User=seminar;Password=123456;Database=seminar");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CClassDetail>(entity =>
            {
                entity.HasKey(e => new { e.CcdCode, e.CcdCchCode });

                entity.ToTable("C_CLASS_DETAIL");

                entity.Property(e => e.CcdCode)
                    .HasColumnName("CCD_CODE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.CcdCchCode)
                    .HasColumnName("CCD_CCH_CODE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.CcdName)
                    .HasColumnName("CCD_NAME")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<CClassHeader>(entity =>
            {
                entity.HasKey(e => e.CchCode);

                entity.ToTable("C_CLASS_HEADER");

                entity.Property(e => e.CchCode)
                    .HasColumnName("CCH_CODE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.CchName)
                    .HasColumnName("CCH_NAME")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<LSystemUserAuthority>(entity =>
            {
                entity.HasKey(e => new { e.LsuaMsuId, e.LsuaCcdCodeAuthority });

                entity.ToTable("L_SYSTEM_USER_AUTHORITY");

                entity.Property(e => e.LsuaMsuId)
                    .HasColumnName("LSUA_MSU_ID")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.LsuaCcdCodeAuthority)
                    .HasColumnName("LSUA_CCD_CODE_AUTHORITY")
                    .HasColumnType("char(3)");
            });

            modelBuilder.Entity<MCourseLarge>(entity =>
            {
                entity.HasKey(e => e.MclCd);

                entity.ToTable("M_COURSE_LARGE");

                entity.Property(e => e.MclCd)
                    .HasColumnName("MCL_CD")
                    .HasColumnType("char(1)");

                entity.Property(e => e.MclCreateDatetime)
                    .HasColumnName("MCL_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MclCreateMsuId)
                    .HasColumnName("MCL_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MclDeleteDatetime)
                    .HasColumnName("MCL_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MclName)
                    .IsRequired()
                    .HasColumnName("MCL_NAME")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.MclSort)
                    .HasColumnName("MCL_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MclUpdateDatetime)
                    .HasColumnName("MCL_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MclUpdateMsuId)
                    .HasColumnName("MCL_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MCourseMiddle>(entity =>
            {
                entity.HasKey(e => e.McmCd);

                entity.ToTable("M_COURSE_MIDDLE");

                entity.Property(e => e.McmCd)
                    .HasColumnName("MCM_CD")
                    .HasColumnType("char(3)");

                entity.Property(e => e.McmCreateDatetime)
                    .HasColumnName("MCM_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.McmCreateMsuId)
                    .HasColumnName("MCM_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.McmDeleteDatetime)
                    .HasColumnName("MCM_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.McmMclCd)
                    .IsRequired()
                    .HasColumnName("MCM_MCL_CD")
                    .HasColumnType("char(1)");

                entity.Property(e => e.McmName)
                    .IsRequired()
                    .HasColumnName("MCM_NAME")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.McmSort)
                    .HasColumnName("MCM_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.McmUpdateDatetime)
                    .HasColumnName("MCM_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.McmUpdateMsuId)
                    .HasColumnName("MCM_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MCourseSmall>(entity =>
            {
                entity.HasKey(e => e.McsCd);

                entity.ToTable("M_COURSE_SMALL");

                entity.Property(e => e.McsCd)
                    .HasColumnName("MCS_CD")
                    .HasColumnType("char(5)");

                entity.Property(e => e.McsCreateDatetime)
                    .HasColumnName("MCS_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.McsCreateMsuId)
                    .HasColumnName("MCS_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.McsDeleteDatetime)
                    .HasColumnName("MCS_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.McsMcmCd)
                    .IsRequired()
                    .HasColumnName("MCS_MCM_CD")
                    .HasColumnType("char(3)");

                entity.Property(e => e.McsName)
                    .IsRequired()
                    .HasColumnName("MCS_NAME")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.McsSort)
                    .HasColumnName("MCS_SORT")
                    .HasColumnType("int(11)");

                entity.Property(e => e.McsUpdateDatetime)
                    .HasColumnName("MCS_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.McsUpdateMsuId)
                    .HasColumnName("MCS_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MLecture>(entity =>
            {
                entity.HasKey(e => e.MlCd);

                entity.ToTable("M_LECTURE");

                entity.Property(e => e.MlCd)
                    .HasColumnName("ML_CD")
                    .HasColumnType("char(18)");

                entity.Property(e => e.MlCapacity)
                    .HasColumnName("ML_CAPACITY")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MlCategoryCd)
                    .HasColumnName("ML_CATEGORY_CD")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.MlCategoryName)
                    .HasColumnName("ML_CATEGORY_NAME")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.MlCcdCodeStatus)
                    .HasColumnName("ML_CCD_CODE_STATUS")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MlClassCd)
                    .HasColumnName("ML_CLASS_CD")
                    .HasColumnType("char(4)");

                entity.Property(e => e.MlClassName)
                    .HasColumnName("ML_CLASS_NAME")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.MlCreateDatetime)
                    .HasColumnName("ML_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MlDateUpdateMwbp)
                    .HasColumnName("ML_DATE_UPDATE_MWBP")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MlDeleteDatetime)
                    .HasColumnName("ML_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MlKbnEntryZuiji)
                    .HasColumnName("ML_KBN_ENTRY_ZUIJI")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.MlKbnKouzaKaiji)
                    .HasColumnName("ML_KBN_KOUZA_KAIJI")
                    .HasColumnType("char(1)");

                entity.Property(e => e.MlKbnSetProduct)
                    .HasColumnName("ML_KBN_SET_PRODUCT")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.MlKouzaDivisionCd)
                    .HasColumnName("ML_KOUZA_DIVISION_CD")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.MlKouzaDivisionName)
                    .HasColumnName("ML_KOUZA_DIVISION_NAME")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.MlKouzaName)
                    .HasColumnName("ML_KOUZA_NAME")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.MlLectureMonth)
                    .HasColumnName("ML_LECTURE_MONTH")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MlMpCd)
                    .HasColumnName("ML_MP_CD")
                    .HasColumnType("char(8)");

                entity.Property(e => e.MlMsCd)
                    .HasColumnName("ML_MS_CD")
                    .HasColumnType("char(6)");

                entity.Property(e => e.MlNote01)
                    .HasColumnName("ML_NOTE_01")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.MlNote02)
                    .HasColumnName("ML_NOTE_02")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.MlScheduleDateEnd)
                    .HasColumnName("ML_SCHEDULE_DATE_END")
                    .HasColumnType("date");

                entity.Property(e => e.MlScheduleDateStart)
                    .HasColumnName("ML_SCHEDULE_DATE_START")
                    .HasColumnType("date");

                entity.Property(e => e.MlScheduleTimeEnd)
                    .HasColumnName("ML_SCHEDULE_TIME_END")
                    .HasColumnType("time");

                entity.Property(e => e.MlScheduleTimeStart)
                    .HasColumnName("ML_SCHEDULE_TIME_START")
                    .HasColumnType("time");

                entity.Property(e => e.MlSchoolName)
                    .HasColumnName("ML_SCHOOL_NAME")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.MlSort)
                    .HasColumnName("ML_SORT")
                    .HasColumnType("int(3)");

                entity.Property(e => e.MlTimeUpdateMwbp)
                    .HasColumnName("ML_TIME_UPDATE_MWBP")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MlUpdateDatetime)
                    .HasColumnName("ML_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MlUrlKouza)
                    .HasColumnName("ML_URL_KOUZA")
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.MlUrlSchool)
                    .HasColumnName("ML_URL_SCHOOL")
                    .HasColumnType("varchar(11)");
            });

            modelBuilder.Entity<MMeasurementTag>(entity =>
            {
                entity.HasKey(e => e.MmtId);

                entity.ToTable("M_MEASUREMENT_TAG");

                entity.Property(e => e.MmtId)
                    .HasColumnName("MMT_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MmtBodyBottom)
                    .IsRequired()
                    .HasColumnName("MMT_BODY_BOTTOM")
                    .HasColumnType("text");

                entity.Property(e => e.MmtBodyTop)
                    .IsRequired()
                    .HasColumnName("MMT_BODY_TOP")
                    .HasColumnType("text");

                entity.Property(e => e.MmtCcdCodeTypeSysfunction)
                    .IsRequired()
                    .HasColumnName("MMT_CCD_CODE_TYPE_SYSFUNCTION")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MmtCreateDatetime)
                    .HasColumnName("MMT_CREATE_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.MmtCreateMsuId)
                    .HasColumnName("MMT_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MmtDeleteDatetime)
                    .HasColumnName("MMT_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MmtHeadArea)
                    .IsRequired()
                    .HasColumnName("MMT_HEAD_AREA")
                    .HasColumnType("text");

                entity.Property(e => e.MmtUpdateDatetime)
                    .HasColumnName("MMT_UPDATE_DATETIME")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.MmtUpdateMsuId)
                    .HasColumnName("MMT_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MProduct>(entity =>
            {
                entity.HasKey(e => e.MpCd);

                entity.ToTable("M_PRODUCT");

                entity.Property(e => e.MpCd)
                    .HasColumnName("MP_CD")
                    .HasColumnType("char(8)");

                entity.Property(e => e.MpAcceptDatetime)
                    .HasColumnName("MP_ACCEPT_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MpCcdCodeAttendCourse)
                    .IsRequired()
                    .HasColumnName("MP_CCD_CODE_ATTEND_COURSE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MpCcdCodeStatusBenefit)
                    .IsRequired()
                    .HasColumnName("MP_CCD_CODE_STATUS_BENEFIT")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MpCcdCodeStatusOrderPc)
                    .IsRequired()
                    .HasColumnName("MP_CCD_CODE_STATUS_ORDER_PC")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MpCcdCodeStatusProdut)
                    .IsRequired()
                    .HasColumnName("MP_CCD_CODE_STATUS_PRODUT")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MpCcdCodeStatusSupport)
                    .IsRequired()
                    .HasColumnName("MP_CCD_CODE_STATUS_SUPPORT")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MpCcdStatusOrderMb)
                    .IsRequired()
                    .HasColumnName("MP_CCD_STATUS_ORDER_MB")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MpCcdStatusSale)
                    .IsRequired()
                    .HasColumnName("MP_CCD_STATUS_SALE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MpCreateDatetime)
                    .HasColumnName("MP_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MpDeleteDatetime)
                    .HasColumnName("MP_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MpLectureCount)
                    .HasColumnName("MP_LECTURE_COUNT")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MpLectureTime)
                    .HasColumnName("MP_LECTURE_TIME")
                    .HasColumnType("decimal(4,2)");

                entity.Property(e => e.MpLectureTotalTime)
                    .HasColumnName("MP_LECTURE_TOTAL_TIME")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.MpMcsCd)
                    .IsRequired()
                    .HasColumnName("MP_MCS_CD")
                    .HasColumnType("char(5)");

                entity.Property(e => e.MpMonayEntry)
                    .HasColumnName("MP_MONAY_ENTRY")
                    .HasColumnType("decimal(12,0)");

                entity.Property(e => e.MpMonayEntryTax)
                    .HasColumnName("MP_MONAY_ENTRY_TAX")
                    .HasColumnType("decimal(12,0)");

                entity.Property(e => e.MpMonayLecture)
                    .HasColumnName("MP_MONAY_LECTURE")
                    .HasColumnType("decimal(12,0)");

                entity.Property(e => e.MpMonayLectureTax)
                    .HasColumnName("MP_MONAY_LECTURE_TAX")
                    .HasColumnType("decimal(12,0)");

                entity.Property(e => e.MpName)
                    .IsRequired()
                    .HasColumnName("MP_NAME")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.MpUpdateDatetime)
                    .HasColumnName("MP_UPDATE_DATETIME")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<MSchool>(entity =>
            {
                entity.HasKey(e => e.MsCd);

                entity.ToTable("M_SCHOOL");

                entity.Property(e => e.MsCd)
                    .HasColumnName("MS_CD")
                    .HasColumnType("char(6)");

                entity.Property(e => e.MsCreateDatetime)
                    .HasColumnName("MS_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsCreateMsuId)
                    .HasColumnName("MS_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MsDeleteDatetime)
                    .HasColumnName("MS_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsName)
                    .HasColumnName("MS_NAME")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MsNameEng)
                    .HasColumnName("MS_NAME_ENG")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.MsUpdateDatetime)
                    .HasColumnName("MS_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsUpdateMsuId)
                    .HasColumnName("MS_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MSchoolScheduleClosed>(entity =>
            {
                entity.HasKey(e => e.MsscId);

                entity.ToTable("M_SCHOOL_SCHEDULE_CLOSED");

                entity.Property(e => e.MsscId)
                    .HasColumnName("MSSC_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MsscClosedDate)
                    .HasColumnName("MSSC_CLOSED_DATE")
                    .HasColumnType("date");

                entity.Property(e => e.MsscCreateDatetime)
                    .HasColumnName("MSSC_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsscCreateMsuId)
                    .HasColumnName("MSSC_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MsscDeleteDatetime)
                    .HasColumnName("MSSC_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsscUpdateDatetime)
                    .HasColumnName("MSSC_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsscUpdateMsuId)
                    .HasColumnName("MSSC_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<MSystemUser>(entity =>
            {
                entity.HasKey(e => e.MsuId);

                entity.ToTable("M_SYSTEM_USER");

                entity.Property(e => e.MsuId)
                    .HasColumnName("MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MsuCcdCodeAccountType)
                    .HasColumnName("MSU_CCD_CODE_ACCOUNT_TYPE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.MsuCreateDatetime)
                    .HasColumnName("MSU_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsuCreateMsuId)
                    .HasColumnName("MSU_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MsuDeleteDatetime)
                    .HasColumnName("MSU_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsuLoginId)
                    .IsRequired()
                    .HasColumnName("MSU_LOGIN_ID")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.MsuLoginPasswd)
                    .IsRequired()
                    .HasColumnName("MSU_LOGIN_PASSWD")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.MsuMsCd)
                    .HasColumnName("MSU_MS_CD")
                    .HasColumnType("char(6)");

                entity.Property(e => e.MsuName)
                    .IsRequired()
                    .HasColumnName("MSU_NAME")
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.MsuUpdateDatetime)
                    .HasColumnName("MSU_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsuUpdateMsuId)
                    .HasColumnName("MSU_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TSeminar>(entity =>
            {
                entity.HasKey(e => e.TsId);

                entity.ToTable("T_SEMINAR");

                entity.Property(e => e.TsId)
                    .HasColumnName("TS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TsCcdCodeInputtypeDate)
                    .IsRequired()
                    .HasColumnName("TS_CCD_CODE_INPUTTYPE_DATE")
                    .HasColumnType("char(3)");

                entity.Property(e => e.TsCcdCodePublish)
                    .IsRequired()
                    .HasColumnName("TS_CCD_CODE_PUBLISH")
                    .HasColumnType("char(3)");

                entity.Property(e => e.TsCcdCodeScheduleCtl)
                    .IsRequired()
                    .HasColumnName("TS_CCD_CODE_SCHEDULE_CTL")
                    .HasColumnType("char(3)");

                entity.Property(e => e.TsContents)
                    .IsRequired()
                    .HasColumnName("TS_CONTENTS")
                    .HasColumnType("varchar(10000)");

                entity.Property(e => e.TsCreateDatetime)
                    .HasColumnName("TS_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsCreateMsuId)
                    .HasColumnName("TS_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TsDeleteDatetime)
                    .HasColumnName("TS_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsMclCd)
                    .IsRequired()
                    .HasColumnName("TS_MCL_CD")
                    .HasColumnType("char(1)");

                entity.Property(e => e.TsMcmCd)
                    .IsRequired()
                    .HasColumnName("TS_MCM_CD")
                    .HasColumnType("char(3)");

                entity.Property(e => e.TsMcsCd)
                    .IsRequired()
                    .HasColumnName("TS_MCS_CD")
                    .HasColumnType("char(5)");

                entity.Property(e => e.TsMsCd)
                    .IsRequired()
                    .HasColumnName("TS_MS_CD")
                    .HasColumnType("char(6)");

                entity.Property(e => e.TsName)
                    .IsRequired()
                    .HasColumnName("TS_NAME")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TsPublishDatetimeEnd)
                    .HasColumnName("TS_PUBLISH_DATETIME_END")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsPublishDatetimeStart)
                    .HasColumnName("TS_PUBLISH_DATETIME_START")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsThumbnailUrl)
                    .IsRequired()
                    .HasColumnName("TS_THUMBNAIL_URL")
                    .HasColumnType("varchar(200)");

                entity.Property(e => e.TsUpdateDatetime)
                    .HasColumnName("TS_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsUpdateMsuId)
                    .HasColumnName("TS_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TSeminarConfigCalender>(entity =>
            {
                entity.HasKey(e => e.TsccId);

                entity.ToTable("T_SEMINAR_CONFIG_CALENDER");

                entity.Property(e => e.TsccId)
                    .HasColumnName("TSCC_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TsccCreateDatetime)
                    .HasColumnName("TSCC_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsccCreateMsuId)
                    .HasColumnName("TSCC_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TsccDeleteDatetime)
                    .HasColumnName("TSCC_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsccSetTimeEnd)
                    .HasColumnName("TSCC_SET_TIME_END")
                    .HasColumnType("time");

                entity.Property(e => e.TsccSetTimeInterval)
                    .HasColumnName("TSCC_SET_TIME_INTERVAL")
                    .HasColumnType("char(3)");

                entity.Property(e => e.TsccSetTimeStart)
                    .HasColumnName("TSCC_SET_TIME_START")
                    .HasColumnType("time");

                entity.Property(e => e.TsccTsId)
                    .HasColumnName("TSCC_TS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TsccUpdateDatetime)
                    .HasColumnName("TSCC_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TsccUpdateMsuId)
                    .HasColumnName("TSCC_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TSeminarSchedule>(entity =>
            {
                entity.HasKey(e => e.TssId);

                entity.ToTable("T_SEMINAR_SCHEDULE");

                entity.Property(e => e.TssId)
                    .HasColumnName("TSS_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TssCcdCodeVacancy)
                    .IsRequired()
                    .HasColumnName("TSS_CCD_CODE_VACANCY")
                    .HasColumnType("char(3)");

                entity.Property(e => e.TssCreateDatetime)
                    .HasColumnName("TSS_CREATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TssCreateMsuId)
                    .HasColumnName("TSS_CREATE_MSU_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TssDeleteDatetime)
                    .HasColumnName("TSS_DELETE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TssScheduleDatetime)
                    .HasColumnName("TSS_SCHEDULE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TssTshId)
                    .HasColumnName("TSS_TSH_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TssUpdateDatetime)
                    .HasColumnName("TSS_UPDATE_DATETIME")
                    .HasColumnType("datetime");

                entity.Property(e => e.TssUpdateMsuId)
                    .HasColumnName("TSS_UPDATE_MSU_ID")
                    .HasColumnType("int(11)");
            });
        }
    }
}
