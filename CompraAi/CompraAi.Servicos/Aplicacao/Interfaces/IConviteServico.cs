using CompraAi.Dominio;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Aplicacao.Interfaces
{
    public interface IConviteServico
    {
        Task<Convite> CriarConvite(Convite usuario);
    }
}
