using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class StatusCodeNotValidException() : Exception("StatusCode is not valid")
    {
    }
}
