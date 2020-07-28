using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DAL.ADO.Interfaces;
using DAL.ADO.Models;

namespace DAL.ADO.Repositories
{
    public class SupplierRepository : IRepository<Supplier>
    {
        private string _connectionString;

        public SupplierRepository(string connectionString)
        {
            if (connectionString == null) throw new NullReferenceException();
            _connectionString = connectionString;
        }

        public IEnumerable<Supplier> GetAll()
        {
            List<Supplier> suppliers = new List<Supplier>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Supplier", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Supplier supplier = new Supplier()
                    {
                        Id = (int)reader.GetValue(0),
                        Name = (string)reader.GetValue(1),
                        Locality = (string)reader.GetValue(2)

                    };
                    suppliers.Add(supplier);
                }
            }
            return suppliers;
        }

        public Supplier Get(int id)
        {
            Supplier result = new Supplier();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Suppliers WHERE Suppliers.Id = @Id", connection);
                SqlParameter idParameter = new SqlParameter("@Id", id);
                command.Parameters.Add(idParameter);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result.Id = (int)reader["Id"];
                    result.Name = (string)reader["Name"];
                    result.Locality = (string)reader["Locality"];
                }
            }

            return result;
        }

        public void Insert(Supplier supplier)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand insertItem = new SqlCommand("INSERT INTO Suppliers(Name, Locality) VALUES(@name, @locality)", connection);
                SqlParameter nameParam = new SqlParameter("@name", supplier.Name);
                SqlParameter localityParam = new SqlParameter("@locality", supplier.Locality);
                insertItem.Parameters.AddRange(new SqlParameter[] { nameParam, localityParam });

                insertItem.ExecuteNonQuery();
            }
        }

        public void Update(Supplier supplier)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand updateItem = new SqlCommand("UPDATE Suppliers SET Name = @name, Locality = @locality WHERE id = @id", connection);
                SqlParameter idParam = new SqlParameter("@id", supplier.Id) { SqlDbType = SqlDbType.Int };
                SqlParameter nameParam = new SqlParameter("@name", supplier.Name);
                SqlParameter localityParam = new SqlParameter("@locality", supplier.Locality);
                updateItem.Parameters.AddRange(new SqlParameter[] { nameParam, localityParam });
                updateItem.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE Suppliers WHERE id = @id", connection);
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
