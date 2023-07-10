using ASP.NetCoreConsoleAppPractice.AppSettings;
using ASP.NetCoreConsoleAppPractice.Models;
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
            string QueryReterive = "SELECT * FROM tbl_car_type ct with (nolock)";
            DataTable dataTable = aDONetService.Query(QueryReterive);
            dataTable.ToLog();
            Console.WriteLine("Choose Option");
            Console.WriteLine("1: Car Type Option");
            Console.WriteLine("2: Car Details Option");
            Console.WriteLine("3: Show Details");
            Console.WriteLine("4: Exit");
            string option = Console.ReadLine();
            if(option == "1")
            {
                Console.WriteLine("1: Add New Car Type");
                Console.WriteLine("2: Edit Car Type");
                Console.WriteLine("3: Delete Car Type");
                Console.WriteLine("4: Return");
                string carTypeOption = Console.ReadLine();
                if (carTypeOption == "1")
                {
                    Console.WriteLine(">>>>>>>Add new Car Type<<<<<<<");
                    Console.Write("Add new Car Type :");
                    string cartype = Console.ReadLine();

                    string QueryInsert = $"INSERT INTO tbl_car_type values('{cartype}')";

                    int resultInsert = aDONetService.Excute(QueryInsert);
                    Console.WriteLine(resultInsert > 0 ? "Adding Car Type Successful" : "Adding Car Type Fail");
                    goto selectAll;
                }
                else if (carTypeOption == "2")
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
                else if (carTypeOption == "3")
                {
                    Console.WriteLine(">>>>>>>Delete Car Type<<<<<<<");
                    Console.WriteLine("Enter Car Type Id to delete");
                    string carId1 = Console.ReadLine();
                    Console.Write("Are you sure want to delete this? If your sure enter 1 to Delete  :");
                    string carTypeDelete = Console.ReadLine();
                    if (carTypeDelete == "1")
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
                else if (carTypeOption == "4")
                {
                    goto selectAll;
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                    goto selectAll;
                }
            }
            else if(option == "2")
            {
                Console.WriteLine("Enter Id To Choose Car Type For Making Details");
                string chooseCarType = Console.ReadLine();
                try
                {
                    DataTable dtGetById = aDONetService.Query($"SELECT * FROM tbl_car_type with (nolock) WHERE id = '{chooseCarType}'"); 
                    foreach(DataRow dataRow in dtGetById.Rows)
                    {
                        CarTypeDataModel carType = new CarTypeDataModel();
                        carType.id = (long)dataRow["id"];
                        carType.car_type = (string)dataRow["car_type"];
                        Console.WriteLine("Car Type is  :"+carType.car_type);
                        Console.Write("Add Car Brand   :");
                        string carbrand = Console.ReadLine();
                        Console.Write("Add Car Name    :");
                        string carname = Console.ReadLine();
                        Console.Write("Add Car Details :");
                        string cardetails = Console.ReadLine();
                        string QueryInsertDetails = $"INSERT INTO tbl_car_details VALUES('{carbrand}','{carname}','{cardetails}','{carType.id}')";
                        int resultInsertDetails = aDONetService.Excute(QueryInsertDetails);
                        Console.WriteLine(resultInsertDetails > 0 ? "Adding Car Type Details Successful" : "Adding Car Type Details Fail");
                    }
                    
                }
                catch(Exception e)
                {
                    throw new Exception (e.Message);
                }
            }
            else if(option == "3")
            {
               Console.WriteLine("Enter Id to Show Details");
               string ShowId = Console.ReadLine() ;
                try
                {
                    DataTable dtGetById = aDONetService.Query($"SELECT * FROM tbl_car_type with (nolock) WHERE id = '{ShowId}'");
                    foreach(DataRow dataRow in dtGetById.Rows)
                    {
                        CarTypeDataModel CarType = new CarTypeDataModel();
                        CarType.id = (long)dataRow["id"];
                        CarType.car_type = (string)dataRow["car_type"];
                        Console.WriteLine(">>>>>>>Car Details is<<<<<<<");
                        Console.WriteLine("Car Type is    :"+CarType.car_type);
                        string SelectQuery = $"SELECT * FROM tbl_car_details with (nolock) WHERE car_type_id = '{CarType.id}'";
                        DataTable carDetails = aDONetService.Query(SelectQuery);
                        foreach(DataRow dataRow1 in carDetails.Rows)
                        {
                            CarDetailsViewModel carDetailsView = new CarDetailsViewModel();
                            carDetailsView.id = (long)dataRow1["id"];
                            carDetailsView.car_brand = (string)dataRow1["car_brand"];
                            carDetailsView.car_name = (string)dataRow1["car_name"];
                            carDetailsView.car_details = (string)dataRow1["car_details"];
                            Console.WriteLine("Car Brand is   :"+carDetailsView.car_brand);
                            Console.WriteLine("Car Name is    :"+carDetailsView.car_name);
                            Console.WriteLine("Car Details is :"+carDetailsView.car_details);
                            goto selectAll;

                        }
                    }
                }
                catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            else if(option == "4")
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
