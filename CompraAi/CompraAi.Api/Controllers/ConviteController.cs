using CompraAi.Api.ViewModel;
using CompraAi.Dominio;
using CompraAi.Dominio.Validacoes;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CompraAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConviteController : ControllerBase
    {
        private readonly IConviteServico _conviteServico;

        public ConviteController(IConviteServico conviteServico)
        {
            _conviteServico = conviteServico;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromBody] CriarConviteViewModel viewModel)
        {
            try
            {
                var convite = new Convite(viewModel.UsuarioId, viewModel.FamiliaId);
                await _conviteServico.Criar(convite);
                return new ObjectResult(convite.ConviteId);
            }
            catch (ValidacaoEntidadeException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
