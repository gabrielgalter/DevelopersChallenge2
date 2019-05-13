using Defasio.Nibo.Application.UseCases.ParseOFX;
using Desafio.Nibo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defasio.Nibo.Application.UseCases.ImportOfx
{
    public interface IImportOfxFile
    {        
        List<Transacao> ImportWithMerge(List<string> OfxFiles);
    }
}
