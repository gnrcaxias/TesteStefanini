using Stefanini.Domain.Entity;
using Stefanini.Domain.Repository;
using Stefanini.Utils;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Stefanini.Repository.SqlServer
{
    public class UserSysRepository : IUserSysRepository
    {
        private string _connectionString;

        public UserSysRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public UserSys Get(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Login, Email, Password, UserRoleId FROM UserSys WHERE Id = @Id";

                sqlCommand.Parameters.AddWithValue("Id", id);

                var sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.Read())
                    return FillFields(sqlDataReader);
                else
                    return null;
            }
        }

        //public UserSys TryLogin(string email, string password)
        //{
        //    using (var conexao = new SqlConnection(_connectionString))
        //    {
        //        conexao.Open();

        //        var sqlCommand = new SqlCommand();

        //        sqlCommand.Connection = conexao;
        //        sqlCommand.CommandText = "SELECT Id, Login, Email, Password, UserRoleId FROM UserSys WHERE Email = @Email AND Password = @Password";

        //        sqlCommand.Parameters.AddWithValue("Email", email);
        //        sqlCommand.Parameters.AddWithValue("Password", password);

        //        var sqlDataReader = sqlCommand.ExecuteReader();

        //        if (sqlDataReader.Read())
        //            return FillFields(sqlDataReader);
        //        else
        //            return null;
        //    }
        //}

        public IEnumerable<UserSys> GetAll()
        {
            var returnList = new List<UserSys>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                var sqlCommand = new SqlCommand();

                sqlCommand.Connection = conexao;
                sqlCommand.CommandText = "SELECT Id, Login, Email, Password, UserRoleId FROM UserSys";

                var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                    returnList.Add(FillFields(sqlDataReader));
            }

            return returnList;
        }

        private UserSys FillFields(SqlDataReader sqlDataReader)
        {
            return new UserSys()
            {
                Id = sqlDataReader["Id"].ToInt32(),
                Email = sqlDataReader["Email"].ToString(),
                Login = sqlDataReader["Login"].ToString(),
                Password = sqlDataReader["Password"].ToString(),
                UserRole = new UserRoleRepository(_connectionString).Get(sqlDataReader["UserRoleId"].ToInt32())
            };
        }
    }
}
