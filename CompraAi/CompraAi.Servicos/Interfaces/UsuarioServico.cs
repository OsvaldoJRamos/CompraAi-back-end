using CompraAi.Dominio;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Interfaces
{
    public interface IUsuarioServico
    {
        Task<Usuario> Criar(Usuario usuario);
    }
}
