using System.Threading.Tasks;

namespace CompraAi.Repositorios.Base.Interfaces
{
    public interface IRepositorioBase<TEntity, TId> where TEntity : class
    {
        Task<TEntity> Criar(TEntity entity);
        Task<TEntity> Atualizar(TEntity entity);
        Task Excluir(TEntity entity);
        Task ExcluirVarios(TEntity[] entityArray);
        Task<TEntity> RetornarPeloId(TId id);
        Task ExcluirPeloId(TId id);
        Task<bool> SalvarAlteracoesAsync();
    }
}
