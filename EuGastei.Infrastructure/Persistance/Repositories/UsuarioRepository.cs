using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EuGastei.Application.UseCases.Queries.Usuario.Consultar;
using EuGastei.Domain.QueryObject;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<Usuario> DbSet;

        public UsuarioRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<Usuario>();
        }

        public async Task AdicionarAsync(Usuario usuario, CancellationToken cancellation = default)
        {
            DbSet.Add(usuario);
        }

        public async Task AtualizarAsync(Usuario usuario, CancellationToken cancellation = default)
        {
            DbSet.Update(usuario);
        }

        public async Task<Usuario> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                         .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoverAsync(Usuario usuario, CancellationToken cancellation = default)
        {
            DbSet.Remove(usuario);
        }

        public async Task<ICollection<Usuario>> ListarAsync(Expression<Func<Usuario, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> ListarPorFiltro(UsuarioFiltro filtro)
        {
            var query = DbSet.AsQueryable();

            if(filtro.PerfilId.HasValue)
                query = query.Where(x => x.PerfilId == filtro.PerfilId);
            
            if (!string.IsNullOrEmpty(filtro.Nome))
                query = query.Where(x => EF.Functions.Like(x.Nome, $"%{filtro.Nome}%"));
            
            if (!string.IsNullOrEmpty(filtro.Email))
                query = query.Where(x => EF.Functions.Like(x.Email, $"%{filtro.Email}%"));
            
            if (filtro.Ativo.HasValue)
                query = query.Where(x => x.Ativo == filtro.Ativo);

            return await query.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
