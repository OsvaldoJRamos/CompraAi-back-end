using System.Threading.Tasks;

namespace CompraAi.Repositorios.Base.Interfaces
{
    public interface IRepositorioBase<TEntity, TId> where TEntity : class
    {
        TEntity Criar(TEntity entity);
        TEntity Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        void ExcluirVarios(TEntity[] entityArray);
        TEntity RetornarPeloId(TId id);
        void ExcluirPeloId(TId id);
        Task<bool> SalvarAlteracoesAsync();
    }
}
