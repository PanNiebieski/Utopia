using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class ValidationMessage
    {
        public bool IsValid { get; set; } = true;

        public List<string> WhatIsWrong { get; set; }

        public static ValidationMessage Valid()
        {
            return new ValidationMessage();
        }
    }
}
