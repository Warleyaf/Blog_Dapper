
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.RoleRepositories {
   public class RoleRepository {
      private readonly SqlConnection _connection; // readonly, de apenas leitura

      public RoleRepository(SqlConnection connection)
      {
         _connection = connection;
      }

      public IEnumerable<Role> Get()
         => _connection.GetAll<Role>();

      public Role Get(int id)
         => _connection.Get<Role>(id);

      public void Create(Role role)
        => _connection.Insert<Role>(role);
   }
}