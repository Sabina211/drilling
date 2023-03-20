using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Drilling.Infrastructure.Exceptions
{
    public class DrillingException : Exception, ISerializable
    {
        public DrillingException(string message = "Ошибка") : base(message)
        {
        }
    }
}
