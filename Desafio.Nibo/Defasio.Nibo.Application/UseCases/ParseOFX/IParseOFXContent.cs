using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defasio.Nibo.Application.UseCases.ParseOFX
{
    public interface IParseOFXContent
    {
        T ToObject<T>(string[] lines);
    }
}
