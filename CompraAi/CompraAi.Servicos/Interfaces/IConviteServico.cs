using CompraAi.Dominio;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Interfaces
{
    public interface IConviteServico
    {
        Task<Convite> CriarConvite(Convite usuario);
    }
}
