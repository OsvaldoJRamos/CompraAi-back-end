using AutoMapper;
using CompraAi.Api.ViewModel;
using CompraAi.Dominio;
using CompraAi.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompraAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusServico _statusServico;
        private readonly IMapper _mapper;
        public StatusController(IStatusServico statusServico, IMapper mapper)
        {
            _statusServico = statusServico;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StatusViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RetornarTodos()
        {
            try
            {
                List<Status> listaStatus = await _statusServico.RetornarTodos();

                return new ObjectResult(_mapper.Map<List<StatusViewModel>>(listaStatus));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
