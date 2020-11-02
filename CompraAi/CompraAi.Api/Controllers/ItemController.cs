using AutoMapper;
using CompraAi.Api.ViewModel;
using CompraAi.Dominio;
using CompraAi.Dominio.Validacoes;
using CompraAi.Servicos.Exceptions;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CompraAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemServico _itemServico;
        private readonly IMapper _mapper;
        public ItemController(IItemServico itemServico, IMapper mapper)
        {
            _itemServico = itemServico;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Guid))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Criar([FromBody] CriarItemViewModel viewModel)
        {
            try
            {
                var item = _mapper.Map<Item>(viewModel);
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

        [HttpPost("Imagem/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AnexarImagem(Guid id, IFormFile imagemProduto)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imagemProduto.CopyToAsync(memoryStream);
                    await _itemServico.AnexarImagem(id, memoryStream.ToArray());
                }

                return new ObjectResult($"Imagem do item de ID '{id}' atualizada com sucesso.");
            }
            catch (ValidacaoEntidadeException ex) { return BadRequest(ex.Message); }
            catch (ServicoException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); }
        }

        [HttpGet("Imagem/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(byte[]))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetornarImagem(Guid id)
        {
            try
            {
                byte[] imagemItem = await _itemServico.RetornarImagem(id);

                if (imagemItem == null)
                    return NoContent();

                return File(imagemItem, "image/png");
            }
            catch (ValidacaoEntidadeException ex) { return BadRequest(ex.Message); }
            catch (ServicoException ex) { return BadRequest(ex.Message); }
            catch (Exception ex) { return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); }
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

                return new ObjectResult(_mapper.Map<ItemViewModel>(item));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("Familia/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ItemViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetornarPorFamiliaId(Guid id)
        {
            try
            {
                List<Item> itens = await _itemServico.RetornarPorFamiliaId(id);
                return new ObjectResult(_mapper.Map<List<ItemViewModel>>(itens));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
