using CompraAi.Api.ViewModel;
using CompraAi.Dominio;
using CompraAi.Dominio.Validacoes;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CompraAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        private readonly IConviteServico _conviteServico;

        public UsuarioController(
            IUsuarioServico usuarioServico,
            IConviteServico conviteServico)
        {
            _usuarioServico = usuarioServico;
            _conviteServico = conviteServico;
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
                //TODO
                //Falta terminar 
                var convite = await _conviteServico.RetornarPeloId(viewModel.ConviteId);
                var usuario = await _usuarioServico.RetornarPeloId(viewModel.UsuarioId);

                _conviteServico.UsarConvite(convite, usuario);

                return new ObjectResult(usuario.UsuarioId);
            }
            catch (ValidacaoEntidadeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
