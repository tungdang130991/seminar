using System;

namespace Novate.Web.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public string Message { get; set; }
        public string PreviousUrl { get; set; }
        public string ButtonCapture { get; set; }

        public ErrorViewModel()
        {
            ButtonCapture = "";
        }
    }
}