using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NetCoreConsoleAppPractice.Services
{
    public static class LogService
    {
        public static void ToLog(this object obj)
        {
            string st = JsonConvert.SerializeObject(obj, Formatting.Indented);
            Console.WriteLine(st);
        }
    }
}
