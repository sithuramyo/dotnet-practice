using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NetCoreConsoleAppPractice.Models
{
    public class CarDetailsViewModel
    {
        public long id {  get; set; }

        public string car_brand { get; set; }

        public string car_name { get; set; }

        public string car_details { get; set;}
    }
}
