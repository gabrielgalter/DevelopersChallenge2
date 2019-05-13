using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Nibo.Domain;
using Desafio.Nibo.Infrastructure.DAL;

namespace Defasio.Nibo.Application.UseCases.GetTransacoes
{
    public class GetTransacoesUseCase : IGetTransacoesUseCase
    {
        private IExtratoRepository _extratoRepository;

        public GetTransacoesUseCase(IExtratoRepository extratoRepository)
        {
            this._extratoRepository = extratoRepository;
        }

        public IList<Transacao> GetTransacoes()
        {
            return _extratoRepository.GetTransasoes().ToList();
        }

        public IList<Transacao> GetTransacoesByDate(DateTime inicio, DateTime fim)
        {
            return _extratoRepository.GetTransasoesByDate(inicio, fim).ToList();
        }
    }
}
