using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Abstractions;
using Application.DTOs;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.UseCases
{
    public class CreateClientUseCase : ICreateClientUseCase
    {
        private readonly IClientRepository _repository;

        public CreateClientUseCase(IClientRepository repository)
        {
            _repository = repository;
        }

        public async Task<StandardResponseEntity> CreateAsync(CreateClientDTO.Input input)
        {
            try
            {
                var entity = ClientEntity.Build(input.FirstName, input.LastName, input.Participation);

                await _repository.AddClientAsync(entity);

                return StandardResponseEntity.Build(message: "Created.", statusCode: 201);
            }
            catch (ParticipationNotValid e)
            {
                return StandardResponseEntity.Build(message: e.Message, statusCode: 400);
            }
            catch (InvalidOperationException e)
            {
                return StandardResponseEntity.Build(message: e.Message, statusCode: 400);
            }
            catch (Exception e)
            {
                return StandardResponseEntity.Build(message: "Internal Server Error", statusCode: 500);
            }

        }
    }
}
