using CompraAi.Dominio;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Aplicacao.Interfaces
{
    public interface IFamiliaServico
    {
        Task<Familia> Registrar(Familia usuario);
    }
}
