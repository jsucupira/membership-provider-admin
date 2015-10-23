using System;
using System.Collections.Generic;

namespace Membership.Common.Exceptions
{
    [Serializable]
    public class WebErrorResponse
    {
        public WebErrorResponse(string error, string type, List<string> details)
        {
            Error = error;
            Type = type;
            try
            {
                Details = details.ToArray();
            }
            catch
            {
            }
        }

        public string[] Details { get; set; }

        public string Error { get; set; }

        public string Type { get; set; }

        public static WebErrorResponse FromExceptionBase(ExceptionBase exception)
        {
            return new WebErrorResponse(exception.Error, exception.Type, exception.Details);
        }
    }
}