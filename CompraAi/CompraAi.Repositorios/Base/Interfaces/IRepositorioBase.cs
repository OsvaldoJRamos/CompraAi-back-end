using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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


        Task<List<TEntity>> RetornarTodos();
        Task<List<TEntity>> RetornarTodos(params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> PesquisarPor(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);


        Task<bool> SalvarAlteracoesAsync();
    }
}
