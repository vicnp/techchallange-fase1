﻿using Contatos.Interfaces;
using Contatos.Reponses;
using Contatos.Requests;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace Controllers.Contatos
{
    [ApiController]
    [Route("api/contatos")]
    public class ContatosController(IContatosAppServico contatosAppServico) : ControllerBase
    {
        /// <summary>
        /// Lista os contatos, permitindo filtragem.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Listagem paginada de contatos.</returns>
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<PaginacaoConsulta<ContatoResponse>>> ListarContatosComPaginacaoAsync([FromQuery] ContatoPaginacaoRequest request)
        {
            return Ok(await contatosAppServico.ListarContatosComPaginacaoAsync(request));
        }

        /// <summary>
        /// Lista os contatos, permitindo filtragem.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Listagem paginada de contatos.</returns>
        [HttpGet("itens")]
        //[Authorize]
        public async Task<ActionResult<List<ContatoResponse>>> ListarContatosSemPaginacaoAsync([FromQuery] ContatoRequest request)
        {
            return Ok(await contatosAppServico.ListarContatosSemPaginacaoAsync(request));
        }

        /// <summary>
        /// Lista os contatos, permitindo filtragem.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Listagem paginada de contatos.</returns>
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<List<ContatoResponse>>> RecuperarContatoAsync(int id)
        {
            return Ok(await contatosAppServico.RecuperarContatoAsync(id));
        }

        /// <summary>
        /// Realiza o cadastro de um contato na base de dados.
        /// </summary>
        /// <param name="request">Dados para cadastro do contato.</param>
        /// <returns>O contato cadastrado.</returns>
        [HttpPost]
        //[Authorize]
        public async Task<ActionResult<ContatoResponse>> InserirContato(ContatoCrudRequest request)
        {
            try
            {
                return Ok(await contatosAppServico.InserirContatoAsync(request));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Remove um contato da base de dados.
        /// </summary>
        /// <param name="id">Código do contato a ser removido</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        //[Authorize]
        public async Task<ActionResult<ContatoResponse>> RemoverContatoAsync(int id)
        {
            try
            {
                await contatosAppServico.RemoverContatoAsync(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Atualiza os dados de um contato.
        /// </summary>
        /// <param name="id">Código do contato a ser editado</param>
        /// <param name="request">Dados atualizados</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        //[Authorize]
        public async Task<ActionResult<ContatoResponse>> AtualizarContatoAsync(int id, [FromBody] ContatoCrudRequest request)
        {
            try
            {
                ContatoResponse? contatoResponse = await contatosAppServico.AtualizarContatoAsync(request, id);
                if (contatoResponse == null)
                    return BadRequest("Contato não encontrado.");

                return Ok(contatoResponse);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }

}
