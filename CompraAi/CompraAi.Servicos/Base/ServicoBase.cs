using CompraAi.Dominio.Base;
using CompraAi.Repositorios.Base.Interfaces;
using CompraAi.Servicos.Base.Interfaces;
using System;
using System.Threading.Tasks;

namespace CompraAi.Servicos.Base
{
    public class ServicoBase<TEntity, TId, TRepositorio> : IServicoBase<TEntity, TId, TRepositorio>
                                    where TEntity : EntidadeBase
                                    where TRepositorio : IRepositorioBase<TEntity, TId>
    {

        protected readonly TRepositorio _repositorio;

        public ServicoBase(TRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<TEntity> Atualizar(TEntity entity)
        {
            var item = await _repositorio.Atualizar(entity);
            await _repositorio.SalvarAlteracoesAsync();
            return item;
        }

        public async Task<TEntity> Criar(TEntity entity)
        {
            entity.Validar();
            var item = await _repositorio.Criar(entity);
            await _repositorio.SalvarAlteracoesAsync();
            return item;
        }

        public async Task Excluir(TEntity entity)
        {
            await _repositorio.Excluir(entity);
            await _repositorio.SalvarAlteracoesAsync();
        }

        public async Task ExcluirPeloId(TId id)
        {
            await _repositorio.ExcluirPeloId(id);
            await _repositorio.SalvarAlteracoesAsync();
        }

        public async Task ExcluirVarios(TEntity[] entityArray)
        {
            await _repositorio.ExcluirVarios(entityArray);
            await _repositorio.SalvarAlteracoesAsync();
        }

        public async Task<TEntity> RetornarPeloId(TId id)
        {
            return await _repositorio.RetornarPeloId(id);
        }

        public async Task<bool> SalvarAlteracoesAsync()
        {
            return await _repositorio.SalvarAlteracoesAsync();
        }
    }
}