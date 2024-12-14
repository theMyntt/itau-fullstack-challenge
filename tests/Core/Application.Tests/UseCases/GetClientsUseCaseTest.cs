using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.UseCases;
using Domain.Entities;
using Infra.Data.Abstractions;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.UseCases
{
    public class GetClientsUseCaseTest : IAsyncLifetime
    {
        private readonly DatabaseContext _context;
        private readonly IGetClientsUseCase _useCase;
        private readonly IClientMapper _mapper;

        private List<ClientEntity> CachedClients { get; set; } = [];

        public GetClientsUseCaseTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "GetClientsUseCaseTest")
                .Options;
            _context = new DatabaseContext(options);
            _mapper = new ClientMapper();
            var repository = new ClientRepository(_context, _mapper);
            _useCase = new GetClientsUseCase(repository);
        }

        public async Task InitializeAsync()
        {
            for (int i = 0; i < 60; i++)
            {
                var entity = ClientEntity.Build(
                                firstName: "John",
                                lastName: "Doe",
                                participation: 1);

                await _context.Clients.AddAsync(_mapper.ToPersistance(entity));
                CachedClients.Add(entity);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            var results = await _context.Clients.ToListAsync();
            _context.Clients.RemoveRange(results);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task ShouldPaginateClients()
        {
            var result = await _useCase.Run(new DTOs.GetClientsDTO.Input { Page = 1 });

            Assert.NotNull(result);
            Assert.NotEmpty(result.Clients);

            for (var i = 0; i < 20; i++)
            {
                Assert.Equal(CachedClients[i].Id, result.Clients.ElementAt(i).Id);
            }

            result = await _useCase.Run(new DTOs.GetClientsDTO.Input { Page = 2 });

            for (var i = 0; i < 20; i++)
            {
                Assert.Equal(CachedClients[i + 20].Id, result.Clients.ElementAt(i).Id);
            }

            result = await _useCase.Run(new DTOs.GetClientsDTO.Input { Page = 3 });

            for (var i = 0; i < 20; i++)
            {
                Assert.Equal(CachedClients[i + 40].Id, result.Clients.ElementAt(i).Id);
            }
        }

        [Fact]
        public async Task ShouldHaveCorrectResponse()
        {
            var result = await _useCase.Run(new DTOs.GetClientsDTO.Input { Page = 1 });
            Assert.NotNull(result);
            Assert.NotEmpty(result.Clients);
            Assert.Equal(3, result.TotalPages);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
