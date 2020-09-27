using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.WebEncoders.Testing;
using System.Threading.Tasks;

namespace CompraAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUsuarioRepository _usuarioRepositorio;
        //private readonly IMapper _mapper;

        public UsuarioController(
            IConfiguration config,
            IUsuarioRepository usuarioRepositorio
            /*IMapper mapper*/)
        {
            _config = config;
            //_mapper = mapper;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        public async Task<IActionResult> Registrar()
        {
            var usuario = new Usuario("testeNome", "testeEmail");
            _usuarioRepositorio.Add(usuario);
            await _usuarioRepositorio.SaveChangesAsync();

            return Ok(usuario);
        }
    }
}
