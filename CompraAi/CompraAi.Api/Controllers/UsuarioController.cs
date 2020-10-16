using AutoMapper;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioServico _usuarioServico;
        //private readonly IMapper _mapper;

        public UsuarioController(
            IUsuarioServico usuarioServico/*,
            IMapper mapper*/)
        {
            //_mapper = mapper;
            _usuarioServico = usuarioServico;
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
    }
}
