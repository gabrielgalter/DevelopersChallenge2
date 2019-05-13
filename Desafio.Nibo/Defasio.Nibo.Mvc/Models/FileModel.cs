using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Defasio.Nibo.Mvc.Models
{
    public class FileModel
    {
        [Required(ErrorMessage = "Selecione um ou mais arquivos OFX.")]
        [Display(Name = "Arquivos OFX")]
        public HttpPostedFileBase[] files { get; set; }
    }
}