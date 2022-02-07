using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransparentData.Models;

namespace TransparentData
{
    public interface ITDConnection
    {
        public Task<JObject> Execute(Request body);
    }
}
