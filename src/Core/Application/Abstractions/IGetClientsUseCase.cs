using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Abstractions
{
    public interface IGetClientsUseCase
    {
        Task<GetClientsDTO.Output> Run(GetClientsDTO.Input input);
    }
}
