using CompraAi.Dominio;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Interfaces
{
    public interface IUsuarioServico
    {
        Task<Usuario> Registrar(Usuario usuario);
    }
}
