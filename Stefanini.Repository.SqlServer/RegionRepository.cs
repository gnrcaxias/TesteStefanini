using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using Stefanini.Utils;

namespace Stefanini.Repository.SqlServer
{
    public class RegionRepository : IRegionRepository
    {
        private string _connectionString;

        public RegionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Region Get(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name FROM Region WHERE Id = @Id";

                sqlCommand.Parameters.AddWithValue("Id", id);

                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                    return FillFields(sqlDataReader);
                else
                    return null;
            }
        }
        
        public IEnumerable<Region> GetAll()
        {
            var returnList = new List<Region>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name FROM Region";

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                    returnList.Add(FillFields(sqlDataReader));
            }

            return returnList;
        }

        private Region FillFields(SqlDataReader sqlDataReader)
        {
            return new Region()
            {
                Id = sqlDataReader["Id"].ToInt32(),
                Name = sqlDataReader["Name"].ToString()
            };
        }
    }
}
