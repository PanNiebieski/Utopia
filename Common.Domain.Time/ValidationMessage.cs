using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class ValidationStatus
    {
        public bool IsValid { get; set; } = true;

        public List<string> ValidationErrors { get; set; }

        public ValidationStatus()
        {
            ValidationErrors = new List<string>();
        }

        public static ValidationStatus Valid()
        {
            return new ValidationStatus();
        }
    }
}
