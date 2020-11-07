using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Interfaces
{
    public interface IStatusServico : IServicoBase<Status, Guid, IStatusRepositorio>
    {
        Task<List<Status>> RetornarTodos(); 
    }
}
