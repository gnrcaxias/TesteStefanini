using Stefanini.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stefanini.Domain.Entity;
using System.Data.SqlClient;
using Stefanini.Utils;

namespace Stefanini.Repository.SqlServer
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private string _connectionString;

        public UserRoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserRole Get(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Name, IsAdmin FROM UserRole WHERE Id = @Id";

                sqlCommand.Parameters.AddWithValue("Id", id);

                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                    return FillFields(sqlDataReader);
                else
                    return null;
            }
        }

        private UserRole FillFields(SqlDataReader sqlDataReader)
        {
            return new UserRole()
            {
                Id = sqlDataReader["Id"].ToInt32(),
                Name = sqlDataReader["Name"].ToString(),
                IsAdmin = sqlDataReader["IsAdmin"].ToBool()
            };
        }
    }
}
