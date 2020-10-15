using CompraAi.Api.ViewModel;
using CompraAi.Dominio;
using CompraAi.Servicos.Interfaces;
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
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(Guid))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CriarConvite([FromBody] CriarConviteViewModel viewModel)
        {
            var usuario = new Convite(viewModel.UsuarioId, viewModel.FamiliaId);
            var result = await _conviteServico.CriarConvite(usuario);

            if (result == null)
                return new BadRequestObjectResult("Houve um erro ao criar convite.");

            return new ObjectResult(result.ConviteId);
        }
    }
}
