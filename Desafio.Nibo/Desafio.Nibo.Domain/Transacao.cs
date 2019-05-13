using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Desafio.Nibo.Domain
{
    public class Transacao
    {
        [Key]
        public int IdTransacao { get; set; }
        public string IdArquivo { get; set; }       
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public string Nome { get; set; }

    }
}
