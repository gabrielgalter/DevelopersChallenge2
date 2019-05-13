using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Defasio.Nibo.Application.UseCases.Upload
{
    public interface IUploadFile
    {
        List<string> Upload(HttpPostedFileBase[] files, string destino);
    }
}
