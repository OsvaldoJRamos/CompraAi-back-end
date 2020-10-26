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
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaServico _familiaServico;
        public FamiliaController(IFamiliaServico familiaServico)
        {
            _familiaServico = familiaServico;
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

        //Obter Membros

        //Obter familia do usuario
    }
}
