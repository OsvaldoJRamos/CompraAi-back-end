using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base.Interfaces;
using System;

namespace CompraAi.Servicos.Interfaces
{
    public interface IUsuarioFamiliaServico : IServicoBase<UsuarioFamilia, Guid, IUsuarioFamiliaRepositorio>
    {
    }
}