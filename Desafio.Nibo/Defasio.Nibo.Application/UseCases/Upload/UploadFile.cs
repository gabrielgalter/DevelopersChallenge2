using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Defasio.Nibo.Application.UseCases.Upload
{
    public class UploadFile : IUploadFile
    {
        public UploadFile() { }

        /// <summary>
        /// Store a loaded file inside a directory
        /// </summary>
        /// <param name="files"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public List<string> Upload(HttpPostedFileBase[] files, string destino)
        {
            List<string> ofxFiles = new List<string>();
            
            //iterating through multiple file collection   
            foreach (HttpPostedFileBase file in files)
            {
                //Checking file is available to save.  
                if (file != null)
                {
                    var InputFileName = DateTime.UtcNow.ToFileTime() + "" + Path.GetFileName(file.FileName);
                    var ServerSavePath = Path.Combine(destino + InputFileName);
                    //Save file to server folder  
                    file.SaveAs(ServerSavePath);

                    ofxFiles.Add(ServerSavePath);
                    
                }

            }

            return ofxFiles;
        }
    }
}
