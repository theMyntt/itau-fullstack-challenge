using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validators
{
    public class GenericDomainValidator
    {
        private GenericDomainValidator() { }

        public static void When(bool condition, Exception e)
        {
            if (!condition)
                throw e;
        }
    }
}
