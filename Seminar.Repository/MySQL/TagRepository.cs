using Seminar.Common;
using Seminar.Repository.Entity;
using Serilog;
using System;
using System.Linq;

namespace Seminar.Repository.MySQL
{
    public class TagRepository : CommonRepository, ITagRepository
    {
        public TagRepository(SeminarDbContext dbContext):base(dbContext)
        {
        }

        public MMeasurementTag GetMeasurementTag(string tagType)
        {
            return DbContext.MMeasurementTag.Where(s => s.MmtCcdCodeTypeSysfunction.Equals(tagType)).FirstOrDefault();
        }

        public ErrorCodes Insert(ref MMeasurementTag tag, MSystemUser user)
        {
            Log.Logger.Information("Insert a new seminar tag {@tag}", tag);
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                tag.UpdateCreatingInfo(user);
                tag.EnsureTagInfoNotNull();
                DbContext.Add(tag);
                int effectedRows = DbContext.SaveChanges();
                if(effectedRows != 1)
                {
                    transaction.Rollback();
                    return ErrorCodes.SaveFailure;
                }
                transaction.Commit();
            }
            Log.Logger.Information("Insert successfully");
            return ErrorCodes.None;
        }

        public ErrorCodes Update(ref MMeasurementTag tag, MSystemUser user)
        {
            Log.Logger.Information("Update a seminar tag {@tag}", tag);
            using (var transaction = DbContext.Database.BeginTransaction())
            {
                MMeasurementTag originalTag = DbContext.MMeasurementTag.Find(tag.MmtId);
                if (!originalTag.MmtUpdateDatetime.Equals(tag.MmtUpdateDatetime))
                {
                    return ErrorCodes.DataIntegrity;
                }
                originalTag.UpdateTagInfo(tag);
                originalTag.UpdateEditingInfo(user);
                originalTag.EnsureTagInfoNotNull();
                DbContext.Update(originalTag);
                int effectedRows = DbContext.SaveChanges();
                if (effectedRows != 1)
                {
                    transaction.Rollback();
                    return ErrorCodes.SaveFailure;
                }
                transaction.Commit();
                tag = originalTag;
            }
            Log.Logger.Information("Update sucessfully");
            return ErrorCodes.None;
        }
    }
}
