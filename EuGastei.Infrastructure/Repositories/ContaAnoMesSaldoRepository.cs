using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class ContaAnoMesSaldoRepository : IContaAnoMesSaldoRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<ContaAnoMesSaldo> DbSet;

        public ContaAnoMesSaldoRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<ContaAnoMesSaldo>();
        }

        public async Task AdicionarAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default)
        {
            DbSet.Add(contaAnoMesSaldo);
        }
        public async Task AtualizarAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default)
        {
            DbSet.Update(contaAnoMesSaldo);
        }
        public async Task<ICollection<ContaAnoMesSaldo>> ListarAsync(Expression<Func<ContaAnoMesSaldo, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<ContaAnoMesSaldo> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(ContaAnoMesSaldo contaAnoMesSaldo, CancellationToken cancellation = default)
        {
            DbSet.Remove(contaAnoMesSaldo);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
