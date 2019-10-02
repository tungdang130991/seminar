using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar.Common
{
    public enum ErrorCodes
    {
        None,

        /// <summary>
        /// Error when 2 user modifies the same data at the same time
        /// </summary>
        [ResourceKey(Key = "W.HSP-0000.0001")]
        DataIntegrity,

        /// <summary>
        /// Error when a user want to access a page which not exists
        /// </summary>
        [ResourceKey(Key = "")]
        PageNotExist,

        /// <summary>
        /// Fail to saving data to database
        /// </summary>
        [ResourceKey(Key = "E.HSP-0000.0004")]
        SaveFailure,
        /// <summary>
        /// Fail id to duplicate
        /// </summary>
        [ResourceKey(Key = "E.HSP-M002.0008")]
        IdSchoolDuplicate,
        /// <summary>
        /// Id was used
        /// </summary>
        [ResourceKey(Key = "I.HSP-M002.0013")]
        IdSchoolWasUse,
        /// <summary>
        /// Id was used
        /// </summary>
        [ResourceKey(Key = "I.HSP-M002.0006")]
        NotDeleteID
    }
}
