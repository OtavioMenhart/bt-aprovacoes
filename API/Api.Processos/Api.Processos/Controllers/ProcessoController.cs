using Api.Processos.Domain.Dtos;
using Api.Processos.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Api.Processos.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private IProcessoService _service;

        public ProcessoController(IProcessoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obter todos os processos cadastrados
        /// </summary>
        [HttpGet]
        public async Task<ActionResult> ObterTodosProcessos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<ProcessoRetornoDto> processos = await _service.ObterTodosProcessos();
                if (processos.Count() > 0)
                    return Ok(processos);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Obter por número do processo
        /// </summary>
        /// <param name="numeroProcesso"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{numeroProcesso}", Name = "ObterPorNumeroProcesso")]
        public async Task<ActionResult> ObterPorNumeroProcesso(string numeroProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ProcessoRetornoDto processo = await _service.ObterPorNumeroProcesso(numeroProcesso);
                if (processo != null)
                    return Ok(processo);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Criar processo
        /// </summary>
        /// <param name="aprovacao"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> CriarProcesso([FromBody] ProcessoDto aprovacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ProcessoResultadoDto result = await _service.CriarProcesso(aprovacao);
                if (result.processo != null)
                    return Created(new Uri(Url.Link("ObterPorNumeroProcesso", new { numeroProcesso = result.processo.NumeroProcesso })), result);
                return BadRequest(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Editar valor, escritório ou reclamante
        /// </summary>
        /// <param name="edicao"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult> EditarProcesso([FromBody] ProcessoDto edicao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ProcessoResultadoDto resultado = await _service.EditarProcesso(edicao);
                if (resultado.processo is null)
                    return BadRequest(resultado);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Ativar/Inativar processo
        /// </summary>
        /// <param name="statusProcesso"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult> AlterarStatusProcesso([FromBody] StatusProcessoDto statusProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ProcessoResultadoDto resultado = await _service.AlterarStatusProcesso(statusProcesso);
                if (resultado.processo is null)
                    return BadRequest(resultado);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Autorizar compra, somente se processo estiver ativo e não tiver sido comprado anteriormente
        /// </summary>
        /// <param name="compraProcesso"></param>
        /// <returns></returns>
        [HttpPatch]
        public async Task<ActionResult> AprovarCompra([FromBody] CompraProcessoDto compraProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                ProcessoResultadoDto resultado = await _service.AprovarCompra(compraProcesso);
                if (resultado.processo is null)
                    return BadRequest(resultado);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
