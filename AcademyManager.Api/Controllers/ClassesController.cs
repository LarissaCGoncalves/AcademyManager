using AcademyManager.Application.ClassGroupUseCases.Commands;
using AcademyManager.Application.ClassGroupUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ClassesController> _logger;
        private readonly IClassGroupQueries _classGroupQueries;

        public ClassesController(IClassGroupQueries classGroupQueries, IMediator mediator, ILogger<ClassesController> logger)
        {
            _classGroupQueries = classGroupQueries;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            try
            {
                var result = await _classGroupQueries.GetAll(skip, take);
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao buscar turmas.");
                return Problem();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClassGroupCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new { result.ErrorMessage });
                }

                return Ok(new { Message = "Turma cadastrada com sucesso!", Id = result.Value });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao buscar turma.");
                return Problem();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateClassGroupCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new { result.ErrorMessage });
                }

                return Ok(new { Message = "Turma atualizada com sucesso!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao atualizar turma.");
                return Problem();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoveClassGroupCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new { result.ErrorMessage });
                }

                return Ok(new { Message = "Turma deletada com sucesso!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao deletar turma.");
                return Problem();
            }
        }
    }
}




