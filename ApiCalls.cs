using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RSSApp
{
    class ApiCalls
    {
        public void Getdownload(string url, string path, string fileName)
        {
            string apiurl = "http://nickstechtips.com/Getdownload?url=" + url + "?path=" + path + "?fileName=" + fileName;
        } 
    }
}
