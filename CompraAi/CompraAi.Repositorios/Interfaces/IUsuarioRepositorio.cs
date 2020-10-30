using CompraAi.Dominio;
using CompraAi.Repositorios.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraAi.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario, Guid>
    {
        List<Usuario> ObterUsuariosFamilia(Guid familiaId);
        List<Familia> ObterFamiliaUsuario(Guid usuarioId);
    }
}
