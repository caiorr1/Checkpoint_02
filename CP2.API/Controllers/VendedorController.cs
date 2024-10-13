using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _applicationService;

        public VendedorController(IVendedorApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        /// <summary>
        /// Obtém todos os vendedores cadastrados.
        /// </summary>
        /// <returns>Lista de vendedores.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<VendedorEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Get()
        {
            var objModel = _applicationService.ObterTodosVendedores();

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados.");
        }

        /// <summary>
        /// Obtém um vendedor específico pelo ID.
        /// </summary>
        /// <param name="id">ID do vendedor.</param>
        /// <returns>Dados do vendedor.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPorId(int id)
        {
            var objModel = _applicationService.ObterVendedorPorId(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível obter os dados.");
        }

        /// <summary>
        /// Cadastra um novo vendedor.
        /// </summary>
        /// <param name="entity">Dados do vendedor a ser criado.</param>
        /// <returns>Vendedor criado.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Post([FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.SalvarDadosVendedor(entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível salvar os dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Atualiza os dados de um vendedor existente.
        /// </summary>
        /// <param name="id">ID do vendedor a ser atualizado.</param>
        /// <param name="entity">Dados do vendedor atualizados.</param>
        /// <returns>Vendedor atualizado.</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Put(int id, [FromBody] VendedorDto entity)
        {
            try
            {
                var objModel = _applicationService.EditarDadosVendedor(id, entity);

                if (objModel is not null)
                    return Ok(objModel);

                return BadRequest("Não foi possível salvar os dados.");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Remove um vendedor pelo ID.
        /// </summary>
        /// <param name="id">ID do vendedor a ser removido.</param>
        /// <returns>Vendedor removido.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(VendedorEntity), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Delete(int id)
        {
            var objModel = _applicationService.DeletarDadosVendedor(id);

            if (objModel is not null)
                return Ok(objModel);

            return BadRequest("Não foi possível deletar os dados.");
        }
    }
}
