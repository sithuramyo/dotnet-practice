using System;
using System.Collections.Generic;
using System.Text;

namespace ASP.NetCoreConsoleAppPractice.Models
{
    public static class CarTypeChangeModel
    {
        public static CarTypeDataModel Change(this CarTypeViewModel model)
        {
            return new CarTypeDataModel
            {
                id = model.id,
                car_type = model.car_type
            };
        }
    }
}
