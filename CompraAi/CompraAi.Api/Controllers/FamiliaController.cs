using CompraAi.Api.ViewModel;
using CompraAi.Dominio;
using CompraAi.Dominio.Validacoes;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CompraAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaServico _familiaServico;
        private readonly IUsuarioServico _usuarioServico;
        public FamiliaController(
            IFamiliaServico familiaServico,
            IUsuarioServico usuarioServico)
        {
            _familiaServico = familiaServico;
            _usuarioServico = usuarioServico;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromBody] CriarFamiliaViewModel viewModel)
        {
            try
            {
                var familia = new Familia(viewModel.Nome, viewModel.Codigo);
                await _familiaServico.Criar(familia);
                return new ObjectResult(familia.FamiliaId);
            }
            catch (ValidacaoEntidadeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{familiaId}/ObterMembros")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Usuario>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterMembros(Guid familiaId)
        {
            try
            {
                var usuarios = _usuarioServico.ObterUsuariosFamilia(familiaId);
                return new ObjectResult(usuarios);
            }
            catch (ValidacaoEntidadeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
