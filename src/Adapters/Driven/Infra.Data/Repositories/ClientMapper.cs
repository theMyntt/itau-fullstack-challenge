using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Data.Abstractions;
using Infra.Data.Entities;

namespace Infra.Data.Repositories
{
    public class ClientMapper : IClientMapper
    {
        public ClientEntity ToDomain(ClientModel model)
        {
            return ClientEntity.Build(
                id: model.Id,
                firstName: model.FirstName,
                lastName: model.LastName,
                participation: model.Participation,
                createdAt: model.CreatedAt);
        }

        public ClientModel ToPersistance(ClientEntity entity)
        {
            return new ClientModel
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Participation = entity.Participation,
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
