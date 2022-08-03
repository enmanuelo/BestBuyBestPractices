using System;
namespace BestBuyBestPractices
{
	public interface IDepartmentRepository
	{
		public IEnumerable<Department> GetAllDepartments();

		//public Department GetDepartment(int newID);

		public void InsertDepartment(string newDepName);
	}
}

