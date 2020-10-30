using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base;
using CompraAi.Servicos.Interfaces;
using System;
using System.Collections.Generic;

namespace CompraAi.Servicos
{
    public class UsuarioServico : ServicoBase<Usuario, Guid, IUsuarioRepositorio>, IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepository;
        public UsuarioServico(IUsuarioRepositorio usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository
                ?? throw new ArgumentNullException(nameof(IUsuarioRepositorio), "O parâmetro não pode ser nulo.");
        }

        public List<Familia> ObterFamiliaUsuario(Guid usuarioId)
        {
            return _usuarioRepository.ObterFamiliaUsuario(usuarioId);
        }

        public List<Usuario> ObterUsuariosFamilia(Guid familiaId)
        {
            return _usuarioRepository.ObterUsuariosFamilia(familiaId);
        }
    }
}
