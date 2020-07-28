using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL.ADO.Interfaces;
using DAL.ADO.Models;

namespace DAL.ADO.Repositories
{
    public class CategoryRepository: IRepository<Category>
    {
        private string _connectionString;

        public CategoryRepository(string connectionString)
        {
            if (connectionString == null) throw new NullReferenceException();
            _connectionString = connectionString;
        }

        public IEnumerable<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Categories", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category()
                    {
                        Id = (int)reader.GetValue(0),
                        Name = (string)reader.GetValue(1)

                    };
                    categories.Add(category);
                }
            }
            return categories;
        }

        public Category Get(int id)
        {
            Category result = new Category();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Categories WHERE Categories.Id = @Id", connection);
                SqlParameter idParameter = new SqlParameter("@Id", id);
                command.Parameters.Add(idParameter);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Id = (int)reader["Id"];
                    result.Name = (string)reader["Name"];
                }
            }

            return result;
        }

        public void Insert(Category category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand insertItem = new SqlCommand("INSERT INTO Categories(Name) VALUES(@name)", connection);
                SqlParameter nameParam = new SqlParameter("@name", category.Name);
                insertItem.Parameters.Add(nameParam);

                insertItem.ExecuteNonQuery();
            }
        }

        public void Update(Category category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand updateItem = new SqlCommand("UPDATE Categories SET Name = @name WHERE id = @id", connection);
                SqlParameter idParam = new SqlParameter("@id", category.Id) { SqlDbType = SqlDbType.Int };
                SqlParameter nameParam = new SqlParameter("@name", category.Name);
                updateItem.Parameters.Add(nameParam);
                updateItem.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE Categories WHERE id = @id", connection);
                SqlParameter idParam = new SqlParameter("@id", id)
                {
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.Add(idParam);
                command.ExecuteNonQuery();
            }
        }
    }
}