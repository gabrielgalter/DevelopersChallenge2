using Desafio.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defasio.Nibo.Application.UseCases.GetTransacoes
{
    public interface IGetTransacoesUseCase
    {
        IList<Transacao> GetTransacoes();

        IList<Transacao> GetTransacoesByDate(DateTime inicio, DateTime fim);
    }
}
