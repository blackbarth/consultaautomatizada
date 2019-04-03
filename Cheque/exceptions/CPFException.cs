using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheque.exceptions
{
    public class CPFException : Exception
    {
        public CPFException()
        {
        }
        public CPFException(string message)
    : base(message)
        {
        }

        public CPFException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
