using Application.Abstractions;
using Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Presentations.Controllers
{
    [ApiController]
    [Route("/api/client")]
    [Tags("Client Management")]
    public class CreateClientController : ControllerBase
    {
        private readonly ICreateClientUseCase _useCase;

        public CreateClientController(ICreateClientUseCase useCase) => _useCase = useCase;

        [HttpPost]
        public async Task<IActionResult> Perform([FromBody] CreateClientDTO.Input input)
        {
            var result = await _useCase.CreateAsync(input);

            return StatusCode(result.StatusCode, result);
        }
    }
}
