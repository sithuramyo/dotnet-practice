using ASP.NetCoreConsoleAppPractice.AppSettings;
using ASP.NetCoreConsoleAppPractice.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ASP.NetCoreConsoleAppPractice.Examples
{
    public class ADONetExample
    {
        public static void Run()
        {
            ADONetService aDONetService = new ADONetService(AppSetting.DbConnection);
        selectAll:
            Console.WriteLine(">>>>>>>Here is  your Car Type List<<<<<<<");
            string QueryReterive = "SELECT * FROM tbl_car_type with (nolock)";
            DataTable dataTable = aDONetService.Query(QueryReterive);
            dataTable.ToLog();
            Console.WriteLine("1: Add New Car Type");
            Console.WriteLine("2: Edit Car Type");
            Console.WriteLine("3: Delete Car Type");
            Console.WriteLine("4: Exit");
            string st = Console.ReadLine();
            if (st == "1")
            {
                Console.WriteLine(">>>>>>>Add new Car Type<<<<<<<");
                Console.Write("Add new Car Type :");
                string cartype = Console.ReadLine();

                string QueryInsert = $"INSERT INTO tbl_car_type values('{cartype}')";

                int resultInsert = aDONetService.Excute(QueryInsert);
                Console.WriteLine(resultInsert > 0 ? "Adding Car Type Successful" : "Adding Car Type Fail");
                goto selectAll;
            }
            else if (st == "2")
            {
                Console.WriteLine(">>>>>>>Edit Car Type<<<<<<<");
                Console.WriteLine("Enter Car Type ID to edit");
                try
                {
                    string carId = Console.ReadLine();
                    DataTable dtGetById = aDONetService.Query($"SELECT * FROM tbl_car_type with (nolock) WHERE id = '{carId}'");
                    dtGetById.ToLog();
                    Console.Write("Edit your Car Type Name    :");
                    string carTypeName = Console.ReadLine();
                    string QueryUpdate = $"UPDATE tbl_car_type SET car_type = '{carTypeName}' WHERE id = '{carId}'";
                    int resultUpdate = aDONetService.Excute(QueryUpdate);
                    Console.WriteLine(resultUpdate > 0 ? "Updating Car Type Successful" : "Updating Car Type Fail");
                    goto selectAll;

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else if (st == "3")
            {
                Console.WriteLine(">>>>>>>Delete Car Type<<<<<<<");
                Console.WriteLine("Enter Car Type Id to delete");
                string carId1 = Console.ReadLine();
                Console.Write("Are you sure want to delete this? If your sure enter 1 to Delete  :");
                string st1 = Console.ReadLine();
                if (st1 == "1")
                {
                    try
                    {
                        string QueryDelete = $"DELETE FROM tbl_car_type WHERE id = '{carId1}'";
                        int resultDelete = aDONetService.Excute(QueryDelete);
                        Console.WriteLine(resultDelete > 0 ? "Delete Car Type Successful" : "Delete Car Type Fail");
                        goto selectAll;
                    }
                    catch (Exception e)
                    {
                        throw new Exception(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                    goto selectAll;
                }
            }
            else if(st == "4")
            {
                return;
            }
            else
            {
                Console.WriteLine("Wrong Input");
                goto selectAll;
            }
            
        }
    }
}
