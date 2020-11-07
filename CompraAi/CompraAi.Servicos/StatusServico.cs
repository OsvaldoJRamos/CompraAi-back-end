using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base;
using CompraAi.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class StatusServico : ServicoBase<Status, Guid, IStatusRepositorio>, IStatusServico
    {
        public StatusServico(IStatusRepositorio repositorio) : base(repositorio)
        {
        }

        public async Task<List<Status>> RetornarTodos()
        {
            return await _repositorio.RetornarTodos();
        }
    }
}
