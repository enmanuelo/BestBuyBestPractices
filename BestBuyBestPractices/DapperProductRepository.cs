using System;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
	public class DapperProductRepository : IProductRepository
	{
		private readonly IDbConnection _connection;

		public DapperProductRepository(IDbConnection connection)
		{
			_connection = connection;
		}

		public void CreateProduct(string name, double price, int categoryID)
		{
			_connection.Execute("INSERT INTO products (Name, Price) VALUES (@productName, @productPrice);",
				new { productName = name, productPrice = price });
		}

		public IEnumerable<Product> GetAllProducts()
		{
			return _connection.Query<Product>("SELECT * FROM products;");
		}
	}
}

