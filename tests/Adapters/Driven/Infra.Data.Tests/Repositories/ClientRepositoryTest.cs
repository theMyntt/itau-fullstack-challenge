using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infra.Data.Abstractions;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Tests.Repositories
{
    public class ClientRepositoryTest : IDisposable
    {
        private readonly DatabaseContext _context;
        private readonly ClientRepository _repository;

        public ClientRepositoryTest()
        {
            var mapper = new ClientMapper();
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "ClientRepositoryTest")
                .Options;

            _context = new DatabaseContext(options);
            _repository = new ClientRepository(_context, mapper);
        }

        public async void Dispose()
        {
            var records = await _context.Clients.ToListAsync();
            _context.Clients.RemoveRange(records);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task ShouldSaveAClient()
        {
            var entity = ClientEntity.Build(
                firstName: "GABRIEL",
                lastName: "ARAÚJO LIMA",
                participation: 50);

            var repositoryResult = await _repository.AddClientAsync(entity);
            var contextResult = await _context.Clients.FirstOrDefaultAsync(x => x.Id == entity.Id);

            Assert.NotNull(repositoryResult);
            Assert.NotNull(contextResult);
            Assert.Equal(entity.Id, contextResult.Id);
            Assert.Equal(entity.FirstName, contextResult.FirstName);
            Assert.Equal(entity.LastName, contextResult.LastName);
            Assert.Equal(entity.Participation, contextResult.Participation);
            Assert.Equal(entity.CreatedAt, contextResult.CreatedAt); 
        }

        [Fact]
        public async Task ShouldPaginateClients()
        {
            List<ClientEntity> entities = new();

            for (int i = 0; i < 5; i++)
            {
                var entity = ClientEntity.Build(
                    firstName: "GABRIEL",
                    lastName: "ARAÚJO LIMA",
                    participation: 1);

                await _repository.AddClientAsync(entity);
                entities.Add(entity);
            }

            var result = await _repository.GetClientsAsync(1);
            
            Assert.NotNull(result);
            Assert.Equal(5, result.Count());

            for (int i = 0; i < 5; i++)
            {
                var entity = entities[i];
                var contextResult = result.ElementAt(i);
                Assert.Equal(entity.Id, contextResult.Id);
                Assert.Equal(entity.FirstName, contextResult.FirstName);
                Assert.Equal(entity.LastName, contextResult.LastName);
                Assert.Equal(entity.Participation, contextResult.Participation);
                Assert.Equal(entity.CreatedAt, contextResult.CreatedAt);
            }
        }

        [Fact]
        public async Task ShouldThrowInvalidOperationIfSumOfParticipationIsGreatherThanOneHundred()
        {
            var entity = ClientEntity.Build(
                firstName: "GABRIEL",
                lastName: "ARAÚJO LIMA",
                participation: 70);

            await _repository.AddClientAsync(entity);
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _repository.AddClientAsync(entity));
            Assert.Equal("The sum of participations cannot be greater than 100", exception.Message);
        }

        [Fact]
        public async Task ShouldCountItemsOnTable()
        {
            for (int i = 0; i < 5; i++)
            {
                var entity = ClientEntity.Build(
                    firstName: "GABRIEL",
                    lastName: "ARAÚJO LIMA",
                    participation: 1);

                await _repository.AddClientAsync(entity);
            }
            await _context.SaveChangesAsync();

            var itemsCount = await _repository.CountAsync();

            Assert.Equal(5, itemsCount);
        }
    }
}
