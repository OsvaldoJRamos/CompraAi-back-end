using CompraAi.Api.ViewModel;
using CompraAi.Dominio;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace CompraAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaServico _familiaServico;
        public FamiliaController(IFamiliaServico familiaServico)
        {
            _familiaServico = familiaServico;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(FamiliaViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Registrar([FromBody] FamiliaViewModel viewModel)
        {
            var familia = new Familia(viewModel.Nome, viewModel.Codigo);
            var result = await _familiaServico.Registrar(familia);

            if (result == null)
                return new BadRequestObjectResult("Houve um erro ao registar a familia.");

            return new ObjectResult(viewModel);
        }
    }
}
