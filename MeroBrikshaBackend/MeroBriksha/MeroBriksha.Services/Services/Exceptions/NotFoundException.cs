using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
