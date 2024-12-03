using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ParticipationNotValid() : Exception("Participation needs to be >= 1 and <= 100");
}
