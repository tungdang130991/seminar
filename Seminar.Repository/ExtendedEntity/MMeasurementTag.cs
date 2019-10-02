using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Seminar.Repository.Entity
{
    [ModelMetadataType(typeof(IMeasurementTagMetadata))]
    public partial class MMeasurementTag:IMeasurementTagMetadata
    {
        public MMeasurementTag()
        {
            MmtHeadArea = " ";
            MmtBodyTop = " ";
            MmtBodyBottom = " ";
            MmtCreateDatetime = DateTime.MinValue;
            MmtUpdateDatetime = DateTime.MinValue;
        }

        /// <summary>
        /// Ensure that: content of tag not null
        /// Because They are setted; not null in database
        /// </summary>
        public void EnsureTagInfoNotNull()
        {
            if (string.IsNullOrEmpty(MmtHeadArea))
            {
                MmtHeadArea = " ";
            }
            if (string.IsNullOrEmpty(MmtBodyTop))
            {
                MmtBodyTop = " ";
            }
            if (string.IsNullOrEmpty(MmtBodyBottom))
            {
                MmtBodyBottom = " ";
            }
        }

        /// <summary>
        /// Copy the content of measurement tag from <paramref name="source"/>
        /// </summary>
        /// <param name="source"> Source from which measurement tag is copyed </param>
        public void CopyTagInfo(MMeasurementTag source)
        {
            MmtHeadArea = source.MmtHeadArea;
            MmtBodyTop = source.MmtBodyTop;
            MmtBodyBottom = source.MmtBodyBottom;
        }

        /// <summary>
        /// Update the content of measurement tag if it is modified
        /// </summary>
        /// <param name="source"> The measurement tag is compared </param>
        public void UpdateTagInfo(MMeasurementTag source)
        {
            if (!MmtHeadArea.Equals(source.MmtHeadArea))
            {
                MmtHeadArea = source.MmtHeadArea;
            }
            if (!MmtBodyTop.Equals(source.MmtBodyTop))
            {
                MmtBodyTop = source.MmtBodyTop;
            }
            if (!MmtBodyBottom.Equals(source.MmtBodyBottom))
            {
                MmtBodyBottom = source.MmtBodyBottom;
            }
        }

        /// <summary>
        /// Update information related to who creates it, when it is created
        /// </summary>
        /// <param name="user"> User creates tag </param>
        public void UpdateCreatingInfo(MSystemUser user)
        {
            MmtCreateMsuId = user.MsuId;
            MmtCreateDatetime = DateTime.Now;
            UpdateEditingInfo(user);
        }

        /// <summary>
        /// Update information related to who edits it, when it is modired
        /// </summary>
        /// <param name="user"> User modifies tag </param>
        public void UpdateEditingInfo(MSystemUser user)
        {
            MmtUpdateMsuId = user.MsuId;
            MmtUpdateDatetime = DateTime.Now;
        }
    }

    public interface IMeasurementTagMetadata
    {
        [Required(ErrorMessage = "E.HSP-0000.0005")]
        [MaxLength(10000, ErrorMessage = "E.HSP-M102.0002")]
        string MmtHeadArea { get; set; }
        [Required(ErrorMessage = "E.HSP-0000.0005")]
        [MaxLength(10000, ErrorMessage = "E.HSP-M102.0002")]
        string MmtBodyTop { get; set; }
        [Required(ErrorMessage = "E.HSP-0000.0005")]
        [MaxLength(10000, ErrorMessage = "E.HSP-M102.0002")]
        string MmtBodyBottom { get; set; }
    }
}
