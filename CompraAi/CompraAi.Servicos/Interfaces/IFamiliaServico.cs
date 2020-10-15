using CompraAi.Dominio;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Interfaces
{
    public interface IFamiliaServico
    {
        Task<Familia> Registrar(Familia usuario);
    }
}
