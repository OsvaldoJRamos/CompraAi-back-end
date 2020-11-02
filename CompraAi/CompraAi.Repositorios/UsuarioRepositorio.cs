using CompraAi.Dominio;
using CompraAi.Repositorios.Base;
using CompraAi.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompraAi.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario, Guid>, IUsuarioRepositorio
    {
        private readonly Contexto _contexto;
        public UsuarioRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public List<Usuario> ObterUsuariosFamilia(Guid familiaId)
        {
            var usuariosFamilia = _contexto.UsuarioFamilia.Where(usuario => usuario.FamiliaId == familiaId);
            var usuariosIds = usuariosFamilia.Select(usuario => usuario.UsuarioId);

            var usuarios = _contexto.Usuario.Where(usuario => usuariosIds.Contains(usuario.UsuarioId));

            return usuarios.ToList();
        }

        public List<Familia> ObterFamiliaUsuario(Guid usuarioId)
        {
            var usuarioFamilia = _contexto.UsuarioFamilia.Where(usuarios => usuarios.UsuarioId == usuarioId);
            var familiasId = usuarioFamilia.Select(usuario => usuario.FamiliaId);

            var familia = _contexto.Familia.Where(familias => familiasId.Contains(familias.FamiliaId));
            return familia.ToList();
        }
    }
}
