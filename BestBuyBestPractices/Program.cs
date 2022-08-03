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

var depRepo = new DapperDepartmentRepository(conn);

depRepo.InsertDepartment("New Department");

var departments = depRepo.GetAllDepartments();

foreach(var department in departments)
{
    Console.WriteLine($"Department ID: {department.DepartmentID}\nDepartment Name: {department.Name}");
}

var prodRepo = new DapperProductRepository(conn);
var products = prodRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"Product ID: {product.ProductID}\nProduct Name: {product.Name}\nProduct Price: {product.Price}\n");
}