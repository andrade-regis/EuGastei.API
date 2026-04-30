using EuGastei.Domain.Entities;
using EuGastei.Domain.Interfaces.Repositories;
using EuGastei.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuGastei.Infrastructure.Persistance.Repositories
{
    public class FormaDePagamentoRepository : IFormaDePagamentoRepository
    {
        protected readonly EuGasteiDbContext Db;
        protected readonly DbSet<FormaDePagamento> DbSet;

        public FormaDePagamentoRepository(EuGasteiDbContext db)
        {
            Db = db;
            DbSet = Db.Set<FormaDePagamento>();
        }

        public async Task AdicionarAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default)
        {
            DbSet.Add(formaDePagamento);
        }
        public async Task AtualizarAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default)
        {
            DbSet.Update(formaDePagamento);
        }
        public async Task<ICollection<FormaDePagamento>> ListarAsync(Expression<Func<FormaDePagamento, bool>>? condicao = null, CancellationToken cancellation = default)
        {
            var query = DbSet.AsNoTracking();
            if (condicao != null) query = query.Where(condicao);
            return await query.ToListAsync();
        }
        public async Task<FormaDePagamento> ObterPorIdAsync(Guid id, CancellationToken cancellation = default)
        {
            return await DbSet.AsNoTracking()
                              .FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task RemoverAsync(FormaDePagamento formaDePagamento, CancellationToken cancellation = default)
        {
            DbSet.Remove(formaDePagamento);
        }
        public async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync();
        }
    }
}
