using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMgt.Service.Exceptions
{
    public class EmailDomainException : Exception
    {
        public EmailDomainException(string message) : base(message) { }

        public EmailDomainException(string message,  Exception innerException) : base(message, innerException) { }
    }
}