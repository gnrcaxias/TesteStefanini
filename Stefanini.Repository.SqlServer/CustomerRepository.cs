using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using Stefanini.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Stefanini.Repository.SqlServer
{
    public class CustomerRepository : ICustomerRepository
    {
        private string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public IEnumerable<Customer> GetAll()
        {
            var returnList = new List<Customer>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = @"SELECT 
                                                Id
                                                ,Name
                                                ,Phone
                                                ,GenderId
                                                ,CityId
                                                ,RegionId
                                                ,LastPurchase
                                                ,ClassificationId
                                                ,UserId
                                            FROM Customer";

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                    returnList.Add(FillFields(sqlDataReader));
            }

            return returnList;
        }

        private Customer FillFields(SqlDataReader sqlDataReader)
        {
            return new Customer()
            {
                Id = sqlDataReader["Id"].ToInt32(),
                Name = sqlDataReader["Name"].ToString(),
                City = new CityRepository(_connectionString).Get(sqlDataReader["CityId"].ToInt32()),
                Classification = new ClassificationRepository(_connectionString).Get(sqlDataReader["ClassificationId"].ToInt32()),
                Gender = new GenderRepository(_connectionString).Get(sqlDataReader["GenderId"].ToInt32()),
                LastPurchase = sqlDataReader["LastPurchase"].ToDateTime(),
                Phone = sqlDataReader["Phone"].ToString(),
                Region = new RegionRepository(_connectionString).Get(sqlDataReader["RegionId"].ToInt32()),
                User = new UserSysRepository(_connectionString).Get(sqlDataReader["UserId"].ToInt32())
            };
        }
    }
}
