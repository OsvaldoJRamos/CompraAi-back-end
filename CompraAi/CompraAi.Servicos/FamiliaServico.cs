using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class FamiliaServico : IFamiliaServico
    {
        private readonly IFamiliaRepositorio _familiaRepository;
        public FamiliaServico(IFamiliaRepositorio familiaRepository)
        {
            _familiaRepository = familiaRepository
                ?? throw new ArgumentNullException(nameof(IFamiliaRepositorio), "O parâmetro não pode ser nulo.");
        }

        public async Task<Familia> Criar(Familia familia)
        {
            familia.Validar();
            await _familiaRepository.Criar(familia);
            await _familiaRepository.SalvarAlteracoesAsync();
            return familia;
        }
    }
}
