using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desafio.Nibo.Domain;
using System.Xml.Serialization;
using System.IO;
using Defasio.Nibo.Application.UseCases.ParseOFX;
using Desafio.Nibo.Infrastructure.DAL;
using AutoMapper;

namespace Defasio.Nibo.Application.UseCases.ImportOfx
{
    public class ImportOfxFile : IImportOfxFile
    {
        private IParseOFXContent _parseOFXContent;
        private IExtratoRepository _extratoRepository;

        public ImportOfxFile() { }

        public ImportOfxFile(IParseOFXContent parseOFXContent, IExtratoRepository extratoRepository)
        {
            this._parseOFXContent = parseOFXContent;
            this._extratoRepository = extratoRepository;
        }
        
        /// <summary>
        /// Import OFX Files with merge
        /// </summary>
        /// <param name="OfxFiles"></param>
        /// <returns></returns>
        public List<Transacao> ImportWithMerge(List<string> OfxFiles)
        {
            var transacoes = new List<Transacao>();

            if (OfxFiles.Count > 0)
            {
                foreach (var item in OfxFiles)
                {
                    string[] lines = System.IO.File.ReadAllLines(item);
                    
                    ArquivoModel ofx = this._parseOFXContent.ToObject<ArquivoModel>(lines);
                  
                    Guid identificacaoArquivo = Guid.NewGuid();

                    foreach (var current in ofx.STMTTRN)
                    {
                        
                        var currentMapped = Mapper.Map<TransacaoModel, Transacao>(current);

                        var qtdLocal = transacoes.Where(x => x.Data == currentMapped.Data && x.Nome == currentMapped.Nome && x.Tipo == currentMapped.Tipo && x.Valor == currentMapped.Valor && x.IdArquivo != identificacaoArquivo.ToString()).Count();
                        var qtd = _extratoRepository.GetTransasoes().Where(x => x.Data == currentMapped.Data && x.Nome == currentMapped.Nome && x.Tipo == currentMapped.Tipo && x.Valor == currentMapped.Valor && x.IdArquivo != identificacaoArquivo.ToString()).Count();


                        // Save only data that is not repeated in files
                        if (qtd == 0 && qtdLocal == 0)
                        {
                            currentMapped.IdArquivo = identificacaoArquivo.ToString();
                            transacoes.Add(currentMapped);

                            this._extratoRepository.InsertExtrato(currentMapped);
                        }
                    }
                }
            }

            
            this._extratoRepository.Save();

            return transacoes;
        }
       
    }
}
