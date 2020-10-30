using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CompraAi.Servicos
{
    public class FamiliaServico : IFamiliaServico
    {
        private readonly IFamiliaRepositorio _familiaRepository;
        private readonly IUsuarioRepositorio _usuarioRepository;
        public FamiliaServico(
            IFamiliaRepositorio familiaRepository,
            IUsuarioRepositorio usuarioRepository)
        {
            _familiaRepository = familiaRepository
                ?? throw new ArgumentNullException(nameof(IFamiliaRepositorio), "O parâmetro não pode ser nulo.");

            _usuarioRepository = usuarioRepository
                ?? throw new ArgumentNullException(nameof(IUsuarioRepositorio), "O parâmetro não pode ser nulo.");
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
