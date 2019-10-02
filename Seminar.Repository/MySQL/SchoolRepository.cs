using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Seminar.Common;
using Seminar.Repository.Entity;
using Serilog;

namespace Seminar.Repository.MySQL
{
    public class SchoolRepository : CommonRepository, ISchoolRepository
    {
        public SchoolRepository(SeminarDbContext dbContext) : base(dbContext)
        {
        }
        public List<MSchool> GetAll()
        {
            return DbContext.MSchool.ToList();
        }

        public ErrorCodes Delete(string id, MSystemUser user)
        {
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                if (checkCondition(id) == true)
                {
                    var deleteSchool = (from c in DbContext.MSchool
                                        where c.MsCd == id
                                        select c).SingleOrDefault();
                    if (deleteSchool.MsDeleteDatetime!=null)
                    {
                        return ErrorCodes.DataIntegrity;
                    }
                    deleteSchool.MsDeleteDatetime = DateTime.Now;
                    DbContext.MSchool.Update(deleteSchool);
                    int effectRow = DbContext.SaveChanges();
                    if (effectRow != 1)
                    {
                        transaction.Rollback();
                        return ErrorCodes.NotDeleteID;
                    }
                }
                else
                {
                    return ErrorCodes.IdSchoolWasUse;
                }
                transaction.Commit();
            }
            Log.Logger.Information("Delete successfully");
            return ErrorCodes.None;
        }

        public ErrorCodes Update(ref MSchool school, MSystemUser user,string id)
        {
            Log.Logger.Information("Update a new school {@mSchool}", school);
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                int effectRow = 0;
                var updateschool = DbContext.MSchool.Find(id); 
                if (!updateschool.MsUpdateDatetime.Equals(school.MsUpdateDatetime))
                {
                    return ErrorCodes.DataIntegrity;
                }
                if (school.MsCd != id)
                {
                    if (CheckDuplicateCode(school.MsCd) == true)
                    {
                        DbContext.MSchool.Remove(updateschool);
                        effectRow=DbContext.SaveChanges();
                        if (effectRow != 1)
                        {
                            transaction.Rollback();
                            return ErrorCodes.SaveFailure;
                        }
                        //updateschool.MsCd = school.MsCd;
                        //updateschool.MsName = school.MsName;
                        //updateschool.MsNameEng = school.MsNameEng;
                        school.UpdateEditingInfo(user);
                        DbContext.MSchool.Add(school);
                        effectRow= DbContext.SaveChanges();
                    }
                    else
                    {
                        return ErrorCodes.IdSchoolDuplicate;
                    }
                }
                else
                {
                    school.MsCd = id;
                    school.UpdateEditingInfo(user);
                    DbContext.MSchool.Update(school);
                    effectRow = DbContext.SaveChanges();
                }
                if (effectRow != 1)
                {
                    transaction.Rollback();
                    return ErrorCodes.SaveFailure;
                }
                transaction.Commit();

            }
            Log.Logger.Information("Update successfully");
            return ErrorCodes.None;
        }

        public ErrorCodes Insert(ref MSchool school, MSystemUser user)
        {
            Log.Logger.Information("Update a new school {@mSchool}", school);
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                if(CheckDuplicateCode(school.MsCd)==true)
                {  
                    school.UpdateCreatingInfo(user);
                    DbContext.MSchool.Add(school);
                   int effectRow= DbContext.SaveChanges();
                    if(effectRow!=1)
                    {
                        transaction.Rollback();
                        return ErrorCodes.SaveFailure;
                    }
                }
                else
                {
                    return ErrorCodes.IdSchoolDuplicate;
                }
                transaction.Commit();
            }
            Log.Logger.Information("Insert successfully");
            return ErrorCodes.None;
        }
        public bool CheckDuplicateCode(string msId)
        {
            if (GetAll().Any(s => s.MsCd.Equals(msId)))
            {
                return false;
            }
            return true;
        }
        public bool checkCondition(string msId)
        {
            var checkMSysUser = (from c in DbContext.MSystemUser
                                     where c.MsuMsCd == msId && c.MsuDeleteDatetime == null
                                     select c).FirstOrDefault();
            var checkTSeminar = (from c in DbContext.TSeminar
                                 where c.TsMsCd == msId && c.TsDeleteDatetime == null
                                 select c).FirstOrDefault();
            var checkMLecture = (from c in DbContext.MLecture
                                 where c.MlMsCd == msId && c.MlDeleteDatetime == null && (c.MlCcdCodeStatus == "001" || c.MlCcdCodeStatus == "003")
                                 select c).FirstOrDefault();

            if (checkMLecture!=null || checkMSysUser !=null || checkTSeminar !=null)
            {
                return false;
            }
            return true;
        }

        public Result IsChangeable(string schoolCode)
        {
            throw new NotImplementedException();
        }
    }

}
