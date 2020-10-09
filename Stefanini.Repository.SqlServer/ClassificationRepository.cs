using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System.Collections.Generic;
using System.Data.SqlClient;
using Stefanini.Utils;

namespace Stefanini.Repository.SqlServer
{
    public class ClassificationRepository : IClassificationRepository
    {
        private string _connectionString;

        public ClassificationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Classification Get(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name FROM Classification WHERE Id = @Id";

                sqlCommand.Parameters.AddWithValue("Id", id);

                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                    return FillFields(sqlDataReader);
                else
                    return null;
            }
        }

        public IEnumerable<Classification> GetAll()
        {
            var returnList = new List<Classification>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name FROM Classification";

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                    returnList.Add(FillFields(sqlDataReader));
            }

            return returnList;
        }

        private Classification FillFields(SqlDataReader sqlDataReader)
        {
            return new Classification()
            {
                Id = sqlDataReader["Id"].ToInt32(),
                Name = sqlDataReader["Name"].ToString()
            };
        }
    }
}
