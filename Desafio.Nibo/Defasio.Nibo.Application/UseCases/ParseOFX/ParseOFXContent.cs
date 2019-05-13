using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Defasio.Nibo.Application.UseCases.ParseOFX
{
    public class ParseOFXContent : IParseOFXContent
    {
        /// <summary>
        /// Transforming the OFX File into an Object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lines"></param>
        /// <returns></returns>
        public T ToObject<T>(string[] lines)
        {
            string xmlOfc = ParseOFX(lines);

            T list;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlOfc))
            {
                list = (T)(serializer.Deserialize(reader));
            }

            return list;
        }

        /// <summary>
        /// Transform the OFX file into XML
        /// </summary>
        /// <param name="ofxLines"></param>
        /// <returns></returns>
        private string ParseOFX(string[] ofxLines)
        {
            string[] nodes = new string[] { "<BANKTRANLIST>", "</BANKTRANLIST>", "<STMTTRN>", "</STMTTRN>" };
            bool transList = false;
            string xmlOfx = "";

            foreach (var item in ofxLines)
            {

                // Defining the start and end of the list
                if (item.Equals("<BANKTRANLIST>"))
                {
                    transList = true;
                    xmlOfx = item;
                }
                else if (item.Equals("</BANKTRANLIST>"))
                {
                    transList = false;
                    xmlOfx += item;
                }

                // Close tags with </>
                if (transList && !nodes.Contains(item))
                {
                    xmlOfx += item + item.Substring(0, item.LastIndexOf(">") + 1).Replace("<", "</");
                }
                else if (item.Equals("<STMTTRN>") || item.Equals("</STMTTRN>"))
                {
                    xmlOfx += item;
                }
            }

            return xmlOfx;
        }
    }
}
