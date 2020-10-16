using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class ConviteServico : IConviteServico
    {
        private readonly IConviteRepositorio _conviteRepository;
        public ConviteServico(IConviteRepositorio conviteRepository)
        {
            _conviteRepository = conviteRepository
                ?? throw new ArgumentNullException(nameof(IUsuarioRepositorio), "O parâmetro não pode ser nulo.");
        }

        public async Task<Convite> Criar(Convite convite)
        {
            convite.Validar();
            _conviteRepository.Criar(convite);
            await _conviteRepository.SalvarAlteracoesAsync();
            return convite;
        }
    }
}
