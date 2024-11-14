using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Exceptions
{
    public class TimeException : Exception
    {
        public TimeException(string message) : base(message)
        {
            ErrorCode = 320;
        }

        public int ErrorCode { get; }

    }
}
