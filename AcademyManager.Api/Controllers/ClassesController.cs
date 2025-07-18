﻿using AcademyManager.Application.ClassGroupUseCases.Commands;
using AcademyManager.Application.ClassGroupUseCases.Queries;
using AcademyManager.Application.StudentUseCases.Commands;
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

        /// <summary>
        /// Retorna uma lista paginada de turmas.
        /// </summary>
        /// <param name="page">
        /// Número da página a ser exibida. 
        /// Por padrão é 1, o que corresponde à primeira página.
        /// </param>
        /// <param name="pageSize">
        /// Quantidade de registros a serem exibidos por página. 
        /// Por padrão, retorna 10 registros.
        /// </param>
        /// <returns>Lista paginada de turmas.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _classGroupQueries.GetAll(page, pageSize);
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao buscar turmas.");
                return Problem();
            }
        }

        /// <summary>
        /// Cria uma nova turma.
        /// </summary>
        /// <param name="command">Dados da nova turma. Nome e Descrição.</param>
        /// <returns>Mensagem de sucesso ou erro. Caso seja sucesso, retorna o identificador da turma criada.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
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
                _logger.LogError(ex, "Erro inesperado ao criar turma.");
                return Problem();
            }
        }

        /// <summary>
        /// Atualiza uma turma existente.
        /// </summary>
        /// <param name="command">Dados atualizados da turma. Id, nome e descrição.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
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

        /// <summary>
        /// Remove uma turma.
        /// </summary>
        /// <param name="command">Identificador da turma a ser removida.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
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




