using AutoMapper;
using CompraAi.Api.Aplicacao.ViewModel;
using CompraAi.Dominio;
using CompraAi.Servicos.Aplicacao.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        [ProducesResponseType((int)HttpStatusCode.Created, Type = typeof(UsuarioViewModel))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Registrar([FromBody] UsuarioViewModel viewModel)
        {
            //var usuario = _mapper.Map<=Usuario>(viewModel);
            var usuario = new Usuario(viewModel.Nome, viewModel.Email);
            var result = await _usuarioServico.Registrar(usuario);

            return new ObjectResult(viewModel);
        }
    }
}
