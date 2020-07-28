using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL.ADO.Interfaces;
using DAL.ADO.Models;

namespace DAL.ADO.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private string _connectionString;

        public ProductRepository(string connectionString)
        {
            if (connectionString == null) 
                throw new NullReferenceException();

            _connectionString = connectionString;
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE Items WHERE id = @id", connection);
                SqlParameter idParam = new SqlParameter("@id", id)
                {
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }

        public Product Get(int id)
        {
            Product result = new Product();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Products WHERE Products.Id = @Id", connection);
                SqlParameter idParameter = new SqlParameter("@Id", id);
                command.Parameters.Add(idParameter);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Id = (int)reader["Id"];
                    result.Name = (string) reader["Name"];
                    result.Price = (decimal) reader["Price"];
                    result.CategoryId = (int) reader["CategoryId"];
                    result.SupplierId = (int) reader["SupplierId"];
                }
            }

            return result;
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Products", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product()
                    {
                        Id = (int)reader.GetValue(0),
                        Name = (string)reader.GetValue(1),
                        Price = (decimal)reader.GetValue(2),
                        CategoryId = (int)reader.GetValue(3),
                        SupplierId = (int)reader.GetValue(4)

                    };
                    products.Add(product);
                }
            }
            return products;
        }

        public void Insert(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand insertItem = new SqlCommand("INSERT INTO Products(Name, CategoryId, SupplierId, Price) VALUES(@name, @categoryId, @supplierId, @cost)", connection);
                SqlParameter nameParam = new SqlParameter("@name", product.Name);
                SqlParameter categoryIdParam = new SqlParameter("@categoryId", product.CategoryId);
                SqlParameter supplierIdParam = new SqlParameter("@supplierId", product.SupplierId);
                SqlParameter costParam = new SqlParameter("@price", product.Price);
                insertItem.Parameters.AddRange(new SqlParameter[] { nameParam, categoryIdParam, supplierIdParam, costParam });
                insertItem.ExecuteNonQuery();
            }
        }

        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand updateItem = new SqlCommand("UPDATE Products SET Name = @name, CategoryId = @categoryId, SupplierId = @supplierId, Price = @price WHERE id = @id", connection);
                SqlParameter idParam = new SqlParameter("@id", product.Id) { SqlDbType = SqlDbType.Int };
                SqlParameter nameParam = new SqlParameter("@name", product.Name);
                SqlParameter categorieIdParam = new SqlParameter("@categoryId", product.CategoryId) { SqlDbType = SqlDbType.Int };
                SqlParameter supplierIdParam = new SqlParameter("@supplierId", product.SupplierId) { SqlDbType = SqlDbType.Int };
                SqlParameter costParam = new SqlParameter("@price", product.Price) { SqlDbType = SqlDbType.Decimal };
                updateItem.Parameters.AddRange(new SqlParameter[] { idParam, nameParam, categorieIdParam, supplierIdParam, costParam });
                updateItem.ExecuteNonQuery();
            }
        }
    }
}
