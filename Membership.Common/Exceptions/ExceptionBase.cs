using System;
using System.Collections.Generic;
using System.Linq;

namespace Membership.Common.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public ExceptionBase(string error, string type, params string[] details)
            : base(error)
        {
            Error = error;
            Type = type;
            if (details != null)
                Details = details.ToList();
            else
                Details = new List<string>();
        }

        public List<string> Details { get; set; }

        public string Error { get; set; }
        public string Type { get; set; }
    }
}