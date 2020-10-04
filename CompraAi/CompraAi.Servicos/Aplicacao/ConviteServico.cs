using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Aplicacao.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Aplicacao
{
    public class ConviteServico : IConviteServico
    {
        private readonly IConviteRepository _conviteRepository;
        public ConviteServico(IConviteRepository conviteRepository)
        {
            _conviteRepository = conviteRepository
                ?? throw new ArgumentNullException(nameof(IUsuarioRepository), "O parâmetro não pode ser nulo.");
        }

        public async Task<Convite> CriarConvite(Convite convite)
        {
            _conviteRepository.Add(convite);
            await _conviteRepository.SaveChangesAsync();

            return convite;
        }
    }
}
