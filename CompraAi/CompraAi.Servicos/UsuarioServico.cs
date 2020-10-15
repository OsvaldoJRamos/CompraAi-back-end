using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioServico(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository
                ?? throw new ArgumentNullException(nameof(IUsuarioRepository), "O parâmetro não pode ser nulo.");
        }

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
            await _usuarioRepository.SaveChangesAsync();

            return usuario;
        }
    }
}
