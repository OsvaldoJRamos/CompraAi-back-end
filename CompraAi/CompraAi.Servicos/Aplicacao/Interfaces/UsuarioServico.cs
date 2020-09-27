using CompraAi.Dominio;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Aplicacao.Interfaces
{
    public interface IUsuarioServico
    {
        Task<Usuario> Registrar(Usuario usuario);
    }
}
