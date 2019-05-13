using Desafio.Nibo.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defasio.Nibo.Application.UseCases.ExcluirTransacoes
{
    public class ExcluirTransacoesUseCase : IExcluirTransacoesUseCase
    {
        private IExtratoRepository _extratoRepository;

        public ExcluirTransacoesUseCase(IExtratoRepository extratoRepository)
        {
            this._extratoRepository = extratoRepository;
        }
        public void ExcluirTodos()
        {
            this._extratoRepository.ExcluirTodos();
        }
    }
}
