using System;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
	public class DapperDepartmentRepository : IDepartmentRepository
	{
		private readonly IDbConnection _connection;

		public DapperDepartmentRepository(IDbConnection connection)
		{
			_connection = connection;
		}


		// Create a GetAllDepartments Method
		public IEnumerable<Department> GetAllDepartments()
		{
			return _connection.Query<Department>("SELECT * FROM departments;");
		}
        // Create an InsertDepartment Method
        public void InsertDepartment(string newDepName)
        {
			_connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@dapartmentName);",
				new { departmentName = newDepName });
        }
    }
}

