using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base;
using CompraAi.Servicos.Interfaces;
using System;

namespace CompraAi.Servicos
{
    public class UsuarioFamiliaServico : ServicoBase<UsuarioFamilia, Guid, IUsuarioFamiliaRepositorio>, IUsuarioFamiliaServico
    {
        private readonly IUsuarioFamiliaRepositorio _UsuarioFamiliaRepository;
        public UsuarioFamiliaServico(IUsuarioFamiliaRepositorio UsuarioFamiliaRepository) : base(UsuarioFamiliaRepository)
        {
            _UsuarioFamiliaRepository = UsuarioFamiliaRepository
                ?? throw new ArgumentNullException(nameof(IUsuarioRepositorio), "O parâmetro não pode ser nulo.");
        }
    }
}