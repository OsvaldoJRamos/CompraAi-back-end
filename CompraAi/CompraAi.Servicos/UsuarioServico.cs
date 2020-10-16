using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepository;
        public UsuarioServico(IUsuarioRepositorio usuarioRepository)
        {
            _usuarioRepository = usuarioRepository
                ?? throw new ArgumentNullException(nameof(IUsuarioRepositorio), "O parâmetro não pode ser nulo.");
        }

        public async Task<Usuario> Criar(Usuario usuario)
        {
            usuario.Validar();
            _usuarioRepository.Criar(usuario);
            await _usuarioRepository.SalvarAlteracoesAsync();
            return usuario;
        }
    }
}
