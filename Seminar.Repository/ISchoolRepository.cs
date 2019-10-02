using Seminar.Common;
using Seminar.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar.Repository
{
    public interface ISchoolRepository
    {
        List<MSchool> GetAll();
        ErrorCodes Delete(string id, MSystemUser user);
        ErrorCodes Update(ref MSchool school, MSystemUser user, string id);
        ErrorCodes Insert(ref MSchool school,MSystemUser user);

        /// <summary>
        /// Check whether the school which code is <paramref name="schoolCode"/> has the ability to be deleted
        /// </summary>
        /// <param name="schoolCode"></param>
        /// <returns> True: if the s </returns>
        Result IsChangeable(string schoolCode);
        bool checkCondition(string msId);
        bool CheckDuplicateCode(string msId);
    }
}
