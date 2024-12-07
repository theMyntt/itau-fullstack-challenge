using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Data.Abstractions;
using Infra.Data.Entities;
using Infra.Data.Repositories;

namespace Infra.Data.Tests.Repositories
{
    public class ClientMapperTest
    {
        private readonly IClientMapper _mapper;

        public ClientMapperTest() => _mapper = new ClientMapper();

        [Fact]
        public void ShouldTransformToADomainEntity()
        {
            var model = new ClientModel
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Participation = 50,
                CreatedAt = DateTime.UtcNow
            };

            var domain = _mapper.ToDomain(model);

            Assert.Equal(model.Id, domain.Id);
            Assert.Equal(model.FirstName, domain.FirstName);
            Assert.Equal(model.LastName, domain.LastName);
            Assert.Equal(model.Participation, domain.Participation);
            Assert.Equal(model.CreatedAt, domain.CreatedAt);
        }

        [Fact]
        public void ShouldTransformToAPersistanceEntity()
        {
            var domain = ClientEntity.Build(
                firstName: "John",
                lastName: "Doe",
                participation: 50);

            var model = _mapper.ToPersistance(domain);
            Assert.Equal(domain.Id, model.Id);
            Assert.Equal(domain.FirstName, model.FirstName);
            Assert.Equal(domain.LastName, model.LastName);
            Assert.Equal(domain.Participation, model.Participation);
            Assert.Equal(domain.CreatedAt, model.CreatedAt);
        }
    }
}
