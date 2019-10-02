using Seminar.Common;
using Seminar.Repository.Entity;

namespace Seminar.Repository
{
    public interface ITagRepository
    {
        /// <summary>
        /// Get tag information by [MMT_CCD_CODE_TYPE_SYSFUNCTION] 
        /// </summary>
        /// <param name="tagType"></param>
        /// <returns></returns>
        MMeasurementTag GetMeasurementTag(string tagType);

        /// <summary>
        /// Create a new measurement tag in database.
        /// And update <paramref name="newTag"/> again.
        /// </summary>
        /// <param name="newTag"> The content of tag </param>
        /// <param name="user"> The person who creates the tag </param>
        /// <returns> The result of inserting </returns>
        ErrorCodes Insert(ref MMeasurementTag newTag, MSystemUser user);

        /// <summary>
        /// Updating a existed measurement tag in database.
        /// And update <paramref name="editedTag"/> again.
        /// </summary>
        /// <param name="editedTag"> The content of tag </param>
        /// <param name="user"> The person who modifies the tag </param>
        /// <returns> The result of updating </returns>
        ErrorCodes Update(ref MMeasurementTag editedTag, MSystemUser user);
    }
}
