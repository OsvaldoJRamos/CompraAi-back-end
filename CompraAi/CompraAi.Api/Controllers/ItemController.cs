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
    public class ItemController : ControllerBase
    {
        private readonly IItemServico _itemServico;
        public ItemController(IItemServico itemServico)
        {
            _itemServico = itemServico;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(string))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Registrar([FromBody] CriarItemViewModel viewModel)
        {
            try
            {
                var item = new Item(viewModel.FamiliaId, viewModel.UsuarioId, viewModel.Descricao);
                var itemResultado = await _itemServico.Criar(item);
                return new ObjectResult(itemResultado.ItemId);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult($"Erro ao cadastrar item: {ex.Message}");
            }
        }
    }
}
