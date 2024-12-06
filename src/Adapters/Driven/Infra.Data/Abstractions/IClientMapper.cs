using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Data.Entities;

namespace Infra.Data.Abstractions
{
    public interface IClientMapper
    {
        ClientEntity ToDomain(ClientModel model);
        ClientModel ToPersistance(ClientEntity entity);
    }
}
