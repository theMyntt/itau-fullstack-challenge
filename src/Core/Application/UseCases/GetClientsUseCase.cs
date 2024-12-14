using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.DTOs;

namespace Application.UseCases
{
    public class GetClientsUseCase : IGetClientsUseCase
    {
        private readonly IClientRepository _repository;

        public GetClientsUseCase(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetClientsDTO.Output> Run(GetClientsDTO.Input input)
        {
            var results = await _repository.GetClientsAsync(input.Page);
            var sizeOfTable = await _repository.CountAsync();
             
            var totalPages = (int)Math.Ceiling((double)sizeOfTable / 20);

            return new GetClientsDTO.Output
            {
                Message = "Clients found.",
                StatusCode = 200,
                Clients = results,
                Page = input.Page,
                TotalPages = totalPages
            };
        }
    }
}
