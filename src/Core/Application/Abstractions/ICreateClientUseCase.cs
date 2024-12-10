using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Abstractions
{
    public interface ICreateClientUseCase
    {
        Task<StandardResponseEntity> CreateAsync(CreateClientDTO.Input input);
    }
}
