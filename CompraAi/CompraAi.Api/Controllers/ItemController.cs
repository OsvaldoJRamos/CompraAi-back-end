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
    public class ItemController : ControllerBase
    {
        private readonly IItemServico _itemServico;
        public ItemController(IItemServico itemServico)
        {
            _itemServico = itemServico;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromBody] CriarItemViewModel viewModel)
        {
            try
            {
                var item = new Item(viewModel.FamiliaId, viewModel.UsuarioId, viewModel.Descricao);
                await _itemServico.Criar(item);
                return new ObjectResult(item.ItemId);
            }
            catch (ValidacaoEntidadeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Item))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetornarPeloId(Guid id)
        {
            try
            {
                Item item = await _itemServico.RetornarPeloId(id);

                if (item == null)
                    return NotFound($"Item não encontrado pelo ID '{id}'");
                
                return new ObjectResult(item);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
