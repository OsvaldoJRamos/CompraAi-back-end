using CompraAi.Api.ViewModel;
using CompraAi.Dominio;
using CompraAi.Dominio.Validacoes;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly IConviteServico _conviteServico;
        private readonly IUsuarioFamiliaServico _usuarioFamiliaServico;

        public UsuarioController(
            IUsuarioServico usuarioServico,
            IConviteServico conviteServico,
            IUsuarioFamiliaServico usuarioFamiliaServico)
        {
            _usuarioServico = usuarioServico;
            _conviteServico = conviteServico;
            _usuarioFamiliaServico = usuarioFamiliaServico;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromBody] CriarUsuarioViewModel viewModel)
        {
            try
            {
                var usuario = new Usuario(viewModel.Nome, viewModel.Email);
                await _usuarioServico.Criar(usuario);
                return new ObjectResult(usuario.UsuarioId);
            }
            catch (ValidacaoEntidadeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AceitarConvite")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AceitarConvite([FromBody] AceitarConviteViewModel viewModel)
        {
            try
            {
                var convite = await _conviteServico.RetornarPeloId(viewModel.ConviteId);
                var usuario = await _usuarioServico.RetornarPeloId(viewModel.UsuarioId);

                if (convite == null || usuario == null)
                    return BadRequest("O convite ou a família não foi encontrado!");

                _conviteServico.UsarConvite(convite, usuario);

                var usuarioFamilia = new UsuarioFamilia(viewModel.UsuarioId, convite.FamiliaId);
                await _usuarioFamiliaServico.Criar(usuarioFamilia);

                return new ObjectResult(usuario.UsuarioId);
            }
            catch (ValidacaoEntidadeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{usuarioId}/ObterFamilia")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Familia>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterFamiliaUsuario(Guid usuarioId)
        {
            try
            {
                var usuarios = _usuarioServico.ObterFamiliaUsuario(usuarioId);
                return new ObjectResult(usuarios);
            }
            catch (ValidacaoEntidadeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}