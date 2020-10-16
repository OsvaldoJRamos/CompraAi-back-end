using CompraAi.Dominio;
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

        private readonly TRepositorio _repositorio;

        public ServicoBase(TRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<TEntity> Atualizar(TEntity entity)
        {
            var item =  _repositorio.Atualizar(entity);
            await _repositorio.SalvarAlteracoesAsync();

            return item;
        }

        public async Task<TEntity> Criar(TEntity entity)
        {
            entity.Validar();
            var item = _repositorio.Criar(entity);
            await _repositorio.SalvarAlteracoesAsync();

            return item;
        }

        public async Task Excluir(TEntity entity)
        {
            _repositorio.Excluir(entity);
            await _repositorio.SalvarAlteracoesAsync();
        }

        public async Task ExcluirPeloId(TId id)
        {
            _repositorio.ExcluirPeloId(id);
            await _repositorio.SalvarAlteracoesAsync();
        }

        public async Task ExcluirVarios(TEntity[] entityArray)
        {
            _repositorio.ExcluirVarios(entityArray);
            await _repositorio.SalvarAlteracoesAsync();
        }

        public async Task<TEntity> RetornarPeloId(TId id)
        {
            return await _repositorio.RetornarPeloId(id);
        }

        public Task<bool> SalvarAlteracoesAsync()
        {
            return _repositorio.SalvarAlteracoesAsync();
        }
    }
}