using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransparentData.Exceptions;
using TransparentData.Models;

namespace TransparentData.Service
{
    public class TdService : ITdService
    {
        private readonly ITDConnection _connection;

        public TdService(ITDConnection connection)
        {
            _connection = connection;
        }

        public string GetFile(string source, string method, Params param)
        {
            var obj = _connection.Execute(new Request()
            {
                Source = source,
                Method = method,
                Params = param
            }).Result;

            if (obj == null) return "TDTIMEOUT";

            var result = obj["data"][0]["result"]["pdf"].ToString();
            return result;
        }

        public string GetJson(string source, Params param)
        {
            var obj = _connection.Execute(new Request()
            {
                Source = source,
                Method = "data",
                Params = param
            }).Result;
            if (obj == null) return "TDTIMEOUT";

            var result = obj["data"][0].ToString();
            return result;
        }
        public string GetOther(string source, string method, Params param)
        {
            var obj = _connection.Execute(new Request()
            {
                Source = source,
                Method = method,
                Params = param
            }).Result;
            if (obj == null) return "TDTIMEOUT";

            var result = obj["data"][0].ToString();
            return result;
        }
    }
}
