using CompraAi.Repositorios.Interfaces;
using System.Threading.Tasks;

namespace CompraAi.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;
        public UsuarioRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _contexto.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _contexto.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _contexto.SaveChangesAsync()) > 0;
        }
    }
}
