using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Interfaces
{
    public interface IUsuarioServico : IServicoBase<Usuario, Guid, IUsuarioRepositorio>
    {
    }
}
