using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base;
using CompraAi.Servicos.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class ConviteServico : ServicoBase<Convite, Guid, IConviteRepositorio>, IConviteServico
    {
        private readonly IConviteRepositorio _conviteRepository;
        public ConviteServico(IConviteRepositorio conviteRepository) : base(conviteRepository)
        {
            _conviteRepository = conviteRepository
                ?? throw new ArgumentNullException(nameof(IUsuarioRepositorio), "O parâmetro não pode ser nulo.");
        }

    }
}
