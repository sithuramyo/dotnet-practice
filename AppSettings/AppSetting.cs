using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ASP.NetCoreConsoleAppPractice.AppSettings
{
    public class AppSetting
    {
        public static SqlConnectionStringBuilder DbConnection = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "ASP.NetPractice",
            UserID = "sa",
            Password = "sa@123"
        };
    }
}
