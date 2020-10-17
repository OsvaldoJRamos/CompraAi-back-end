using CompraAi.Dominio;
using CompraAi.Repositorios.Interfaces;
using CompraAi.Servicos.Base.Interfaces;
using System;

namespace CompraAi.Servicos.Interfaces
{
    public interface IConviteServico : IServicoBase<Convite, Guid, IConviteRepositorio>
    {
        void UsarConvite(Convite convite, Usuario usuario);
    }
}
