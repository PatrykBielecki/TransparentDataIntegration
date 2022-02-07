using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransparentData.Models;

namespace TransparentData.Service
{
    public interface ITdService
    {
        public string GetJson(string source, Params param);
        public string GetFile(string source, string method, Params param);
        public string GetOther(string source, string method, Params param);
    }
}
