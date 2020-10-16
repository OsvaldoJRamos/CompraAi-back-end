using CompraAi.Repositorios.Base.Interfaces;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Base.Interfaces
{
    public interface IServicoBase<TEntity, TId, TRepositorio>
        where TEntity : class
        where TRepositorio : IRepositorioBase<TEntity, TId>
    {
        Task<TEntity> Atualizar(TEntity entity);
        Task<TEntity> Criar(TEntity entity);
        Task Excluir(TEntity entity);
        Task ExcluirPeloId(TId id);
        Task ExcluirVarios(TEntity[] entityArray);
        Task<TEntity> RetornarPeloId(TId id);
        Task<bool> SalvarAlteracoesAsync();
    }
}