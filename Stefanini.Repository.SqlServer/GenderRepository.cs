using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using System.Collections.Generic;
using Stefanini.Utils;
using System.Data.SqlClient;

namespace Stefanini.Repository.SqlServer
{
    public class GenderRepository : IGenderRepository
    {
        private string _connectionString;

        public GenderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Gender Get(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name FROM Gender WHERE Id = @Id";

                sqlCommand.Parameters.AddWithValue("Id", id);

                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                    return FillFields(sqlDataReader);
                else
                    return null;
            }
        }

        public IEnumerable<Gender> GetAll()
        {
            var returnList = new List<Gender>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name FROM Gender";

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                    returnList.Add(FillFields(sqlDataReader));
            }

            return returnList;
        }

        private Gender FillFields(SqlDataReader sqlDataReader)
        {
            return new Gender()
            {
                Id = sqlDataReader["Id"].ToInt32(),
                Name = sqlDataReader["Name"].ToString()
            };
        }
    }
}
