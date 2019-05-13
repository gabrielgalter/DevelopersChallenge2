using Desafio.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Nibo.Infrastructure.DAL
{
    public interface IExtratoRepository : IDisposable
    {
        IEnumerable<Transacao> GetTransasoes();
        IEnumerable<Transacao> GetTransasoesByDate(DateTime inicio, DateTime fim);
        void InsertExtrato(IEnumerable<Transacao> transacoes);
        void InsertExtrato(Transacao transacao);
        void ExcluirTodos();
        void Save();
    }
}
