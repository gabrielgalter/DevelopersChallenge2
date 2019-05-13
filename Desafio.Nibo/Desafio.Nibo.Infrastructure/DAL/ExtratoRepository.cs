using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Nibo.Domain;

namespace Desafio.Nibo.Infrastructure.DAL
{
    public class ExtratoRepository : IExtratoRepository, IDisposable
    {
        private readonly OfxDbContext _context;

        public ExtratoRepository(OfxDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<Transacao> GetTransasoes()
        {
            return this._context.Transacoes.OrderBy(o => o.Data).ToList();
        }

        public IEnumerable<Transacao> GetTransasoesByDate(DateTime inicio, DateTime fim)
        {
            return this._context.Transacoes.Where(w => w.Data >= inicio && w.Data <= fim).OrderBy(o => o.Data).ToList();
        }

        public void InsertExtrato(IEnumerable<Transacao> transacoes)
        {
            this._context.Transacoes.AddRange(transacoes);
        }

        public void InsertExtrato(Transacao transacao)
        {
            this._context.Transacoes.Add(transacao);
        }

        public void Save()
        {
            this._context.SaveChanges();
        }

        public void ExcluirTodos()
        {
            this._context.Database.ExecuteSqlCommand("delete from Transacao");
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
