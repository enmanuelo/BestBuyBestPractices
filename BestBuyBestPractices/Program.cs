using System.Data;
using BestBuyBestPractices;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;



var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection conn = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(conn);

var departments = repo.GetAllDepartments();

foreach(var department in departments)
{
    Console.WriteLine($"Department ID: {department.DepartmentID}\nDepartment Name: {department.Name}");
}