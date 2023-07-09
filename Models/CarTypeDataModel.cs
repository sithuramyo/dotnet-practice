using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ASP.NetCoreConsoleAppPractice.Models
{
    [Table("tbl_car_type")]
    public class CarTypeDataModel
    {
        [Key]
        public long id { get; set; }

        public string car_type { get; set; }

    }
}
