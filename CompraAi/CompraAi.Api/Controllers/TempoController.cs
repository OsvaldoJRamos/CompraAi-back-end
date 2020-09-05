using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompraAi.Dominio.Exemplos;
using CompraAi.Servicos.Exemplo.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;

namespace CompraAi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TempoController : ControllerBase
    {
        private readonly ILogger<TempoController> _logger;
        private ITempoServico _tempoServico;

        public TempoController(ILogger<TempoController> logger, ITempoServico tempoServico)
        {
            _logger = logger;
            _tempoServico = tempoServico 
                ?? throw new ArgumentNullException(nameof(ITempoServico), "O parâmetro não pode ser nulo.");
        }

        [HttpGet]
        [OpenApiOperation("Retornar lista de tempo", "...")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<Tempo> Get()
        {
            return _tempoServico.RetornarTodos();
        }
    }
}
