using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Defasio.Nibo.Application.UseCases.ImportOfx
{
    [XmlRoot("BANKTRANLIST")]
    public class ArquivoModel
    {
        [XmlElement("DTSTART")]
        public string Inicio { get; set; }
        [XmlElement("DTEND")]
        public string Fim { get; set; }

        [XmlElement("STMTTRN")]
        public List<TransacaoModel> STMTTRN { get; set; }

    }
}
