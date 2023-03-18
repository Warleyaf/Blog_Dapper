using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
   public class UserRepository : Repository<User>
   {
      private readonly SqlConnection _connection;

      public UserRepository(SqlConnection connection) : base(connection)
      {
         _connection = connection;
      }

      public List<User> GetWithRoles()
      { // nesse método iremos ler os usuários com os roles e retonar eles na tela
         var query = @"
            SELECT
               [User].*,
               [Role].*
            FROM
               [User]
                  LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                  LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
         ";

         var users = new List<User>(); // aqui já estou criando as listas de usuários e retornando ela

         var items = _connection.Query<User, Role, User>(
            query,
            (user, role) =>
            {
               var usr = users.FirstOrDefault(x => x.Id == user.Id);
               if (usr == null)
               {
                  usr = user;
                  if(role != null) {
                     usr.Roles.Add(role);
                  }    
                  users.Add(usr);
               }
               else
               {
                  usr.Roles.Add(role);
               }

               return user;
            }, splitOn: "Id");

         return users;
      }
   }
}