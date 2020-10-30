using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base.Interfaces;
using System;
using System.Collections.Generic;

namespace CompraAi.Servicos.Interfaces
{
    public interface IUsuarioServico : IServicoBase<Usuario, Guid, IUsuarioRepositorio>
    {
        List<Usuario> ObterUsuariosFamilia(Guid familiaId);
        List<Familia> ObterFamiliaUsuario(Guid usuarioId);
    }
}
