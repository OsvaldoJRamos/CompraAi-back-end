using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Aplicacao.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Aplicacao
{
    public class FamiliaServico : IFamiliaServico
    {
        private readonly IFamiliaRepository _familiaRepository;
        public FamiliaServico(IFamiliaRepository familiaRepository)
        {
            _familiaRepository = familiaRepository
                ?? throw new ArgumentNullException(nameof(IFamiliaRepository), "O parâmetro não pode ser nulo.");
        }

        public async Task<Familia> Registrar(Familia familia)
        {
            var valido = familia.ValidarFamilia();
            if (!valido)
                return null;

            _familiaRepository.Add(familia);
            await _familiaRepository.SaveChangesAsync();

            return familia;
        }
    }
}
