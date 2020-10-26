using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base;
using CompraAi.Servicos.Interfaces;
using System;
using System.Threading.Tasks;

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
    }
}
