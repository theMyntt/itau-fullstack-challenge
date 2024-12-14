using Application.Abstractions;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Presentations.Controllers
{
    [ApiController]
    [Route("/api/client")]
    [Tags("Client Management")]
    public class GetClientsController : ControllerBase
    {
        private readonly IGetClientsUseCase _useCase;

        public GetClientsController(IGetClientsUseCase useCase) => _useCase = useCase;

        [HttpGet]
        public async Task<IActionResult> Perform([FromQuery] GetClientsDTO.Input input)
        {
            var result = await _useCase.Run(input);

            return StatusCode(result.StatusCode, result);
        }
    }
}
