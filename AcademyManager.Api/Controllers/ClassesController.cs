using AcademyManager.Application.ClassGroup.Commands;
using AcademyManager.Domain.Repositories;
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
        private readonly IClassGroupRepository _classGroupRepository;

        public ClassesController(IClassGroupRepository classGroupRepository, IMediator mediator, ILogger<ClassesController> logger)
        {
            _classGroupRepository = classGroupRepository;
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            try
            {
                var result = await _classGroupRepository.GetById(1);

                //if (result.IsFailure)
                //{
                //    _logger.LogWarning("Falha ao criar turma: {Motivo}", result.ErrorMessage);
                //    return BadRequest(new { result.ErrorMessage });
                //}

                
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao buscar turma.");
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
                    _logger.LogWarning("Falha ao criar turma: {Motivo}", result.ErrorMessage);
                    return BadRequest(new { result.ErrorMessage });
                }

                return Ok(new { Message = "Turma cadastrada com sucesso!", UserId = result.Value });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao criar turma.");
                return Problem();
            }
        }
    }

}




