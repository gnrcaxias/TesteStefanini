using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using Stefanini.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stefanini.Repository.SqlServer
{
    public class CityRepository : ICityRepository
    {
        private string _connectionString;

        public CityRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public City Get(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name, RegionId FROM City WHERE Id = @Id";

                sqlCommand.Parameters.AddWithValue("Id", id);

                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                    return FillFields(sqlDataReader);
                else
                    return null;
            }
        }

        public IEnumerable<City> GetAll()
        {
            var returnList = new List<City>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name, RegionId FROM City";

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                    returnList.Add(FillFields(sqlDataReader));
            }

            return returnList;
        }

        private City FillFields(SqlDataReader sqlDataReader)
        {
            return new City()
            {
                Id = sqlDataReader["Id"].ToInt32(),
                Name = sqlDataReader["Name"].ToString(),
                Region = new RegionRepository(_connectionString).Get(sqlDataReader["RegionId"].ToInt32())
            };
        }
    }
}
