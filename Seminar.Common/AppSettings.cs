using System;
using System.Collections.Generic;
using System.Text;

namespace Seminar
{

    /// <summary>
    /// Contain all setting for web.
    /// All values read from appsetting.json
    /// </summary>
    public class AppSettings
    {
        public string PowerCMSUrl { get; set; }
        public int SessionTimeOut { get; set; }
        public string SeminarTagCodeType { get; set; }
        public string ProductTagCodeType { get; set; }
        public int MaxlengthTag { get; set; }
    }
}
