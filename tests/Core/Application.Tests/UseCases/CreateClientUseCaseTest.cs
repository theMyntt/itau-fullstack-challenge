using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.DTOs;
using Application.UseCases;
using Infra.Data.Context;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests.UseCases
{
    public class CreateClientUseCaseTest : IDisposable
    {
        private readonly IClientRepository _clientRepository;
        private readonly DatabaseContext _context;
        private readonly ICreateClientUseCase _useCase;

        public CreateClientUseCaseTest()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "CreateClientUseCaseTest")
                .Options;

            _context = new DatabaseContext(options);
            _clientRepository = new ClientRepository(_context, new ClientMapper());
            _useCase = new CreateClientUseCase(_clientRepository);
        }

        public async void Dispose()
        {
            var records = await _context.Clients.ToListAsync();
            _context.Clients.RemoveRange(records);
            await _context.SaveChangesAsync();
        }

        [Fact]
        public async Task ShouldCreateAClient()
        {
            var dto = new CreateClientDTO.Input
            {
                FirstName = "GABRIEL",
                LastName = "ARAÚJO LIMA",
                Participation = 50
            };

            await _useCase.CreateAsync(dto);

            var entity = await _context.Clients.FirstOrDefaultAsync();

            Assert.NotNull(entity);
            Assert.Equal(dto.FirstName, entity.FirstName);
            Assert.Equal(dto.LastName, entity.LastName);
            Assert.Equal(dto.Participation, entity.Participation);
        }

        [Fact]
        public async Task ShouldBlockIfParticipationIsGreatherThanOneHundred()
        {
            var dto = new CreateClientDTO.Input
            {
                FirstName = "GABRIEL",
                LastName = "ARAÚJO LIMA",
                Participation = 70
            };
            await _useCase.CreateAsync(dto); // this should pass with no errors
            var response = await _useCase.CreateAsync(dto);

            Assert.Equal(400, response.StatusCode);
            Assert.Equal("The sum of participations cannot be greater than 100", response.Message);

            var entity = await _context.Clients.ToListAsync();

            Assert.NotEmpty(entity);
            Assert.Single(entity);
        }
    }
}
