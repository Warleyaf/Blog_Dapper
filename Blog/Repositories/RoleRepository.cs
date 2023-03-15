
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

      public void Update (Role role)
      {
         if(role.Id != 0) // se o user id for diferente de 0 eu faço o update
            _connection.Insert<Role>(role);
      }

      public void Delete (Role role)
      {
         if(role.Id != 0)
            _connection.Delete<Role>(role);
      }

      public void Delete (int id) {
         if (id != 0)
            return;
            var role = _connection.Get<Role>(id);
            _connection.Delete<Role>(role);
      }
   }
}