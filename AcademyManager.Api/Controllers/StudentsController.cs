using AcademyManager.Application.StudentUseCases.Commands;
using AcademyManager.Application.StudentUseCases.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcademyManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentQueries _studentQueries;

        public StudentsController(IStudentQueries studentQueries, IMediator mediator, ILogger<StudentsController> logger)
        {
            _studentQueries = studentQueries;
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Retorna uma lista paginada de alunos.
        /// </summary>
        /// <param name="skip">
        /// Número da página a ser exibida. 
        /// Por padrão é 0, o que corresponde à primeira página.
        /// </param>
        /// <param name="take">
        /// Quantidade de registros a serem exibidos por página. 
        /// Por padrão, retorna 10 registros.
        /// </param>
        /// <param name="search">
        /// Utilizado para filtrar os alunos pelo nome. 
        /// Se não informado, todos os registros serão considerados.
        /// </param>
        /// <returns>Lista paginada de alunos.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 10, [FromQuery] string? search = null)
        {
            try
            {
                var result = await _studentQueries.GetAll(skip, take, search);
                return Ok(result.Value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao buscar alunos.");
                return Problem();
            }
        }

        /// <summary>
        /// Cria um novo aluno.
        /// </summary>
        /// <param name="command">Dados do aluno. Nome, data de nascimento, cpf e email.</param>
        /// <returns>Mensagem de sucesso ou erro. Caso seja sucesso, retorna o identificador do aluno criado.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new { result.ErrorMessage });
                }

                return Ok(new { Message = "Aluno cadastrado com sucesso!", Id = result.Value });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao criar aluno.");
                return Problem();
            }
        }

        /// <summary>
        /// Atualiza uma turma existente.
        /// </summary>
        /// <param name="command">Dados atualizados do aluno. Id, Nome, data de nascimento, cpf e email.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStudentCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new { result.ErrorMessage });
                }

                return Ok(new { Message = "Aluno atualizado com sucesso!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao atualizar aluno.");
                return Problem();
            }
        }

        /// <summary>
        /// Remove uma turma.
        /// </summary>
        /// <param name="command">Identificador do aluno a ser removido.</param>
        /// <returns>Mensagem de sucesso ou erro.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] RemoveStudentCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);

                if (result.IsFailure)
                {
                    return BadRequest(new { result.ErrorMessage });
                }

                return Ok(new { Message = "Aluno deletado com sucesso!" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro inesperado ao deletar aluno.");
                return Problem();
            }
        }
    }
}




