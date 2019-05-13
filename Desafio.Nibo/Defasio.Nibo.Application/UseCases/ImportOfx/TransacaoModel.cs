using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Defasio.Nibo.Application.UseCases.ImportOfx
{
    public class TransacaoModel
    {
        public string IdArquivo { get; set; }
        [XmlElement("TRNTYPE")]
        public string Tipo { get; set; }
        [XmlElement("DTPOSTED")]
        public string Data { get; set; }
        [XmlElement("TRNAMT")]
        public string Valor { get; set; }
        [XmlElement("MEMO")]
        public string Nome { get; set; }
    }
}
