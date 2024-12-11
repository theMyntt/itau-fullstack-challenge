using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Domain.Entities;
using Infra.Data.Abstractions;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DatabaseContext _context;
        private readonly IClientMapper _mapper;

        public ClientRepository(DatabaseContext context, IClientMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientEntity> AddClientAsync(ClientEntity entity)
        {
            var model = _mapper.ToPersistance(entity);

            var participation = await _context.Clients.SumAsync(c => c.Participation);

            if (participation + entity.Participation > 100)
                throw new InvalidOperationException("The sum of participations cannot be greater than 100");

            await _context.Clients.AddAsync(model);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<ClientEntity>> GetClientsAsync(int page)
        {
            return await _context.Clients
                .Skip((page - 1) * 20)
                .Take(20)
                .Select(model => _mapper.ToDomain(model))
                .ToListAsync();
        }
    }
}
