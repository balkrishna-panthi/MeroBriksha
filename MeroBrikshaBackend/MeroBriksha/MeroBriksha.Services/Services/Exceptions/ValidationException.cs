using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {
        }
    }
}
