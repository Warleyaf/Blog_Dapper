using System;
using Blog.Models;
using Blog.Repositories;
using Blog.RoleRepositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
   class Program
   {
      private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Encrypt=False";

      static void Main(string[] args)
      {
         var connection = new SqlConnection(CONNECTION_STRING);
         connection.Open();
            ReadUsers(connection);
            ReadRoles(connection);
            //ReadUser();
            //CreateUser();
            //UpdateUser();
            //DeleteUser();
         connection.Close();

      }

      public static void ReadUsers(SqlConnection connection)
      {

         var repository = new Repository<User>(connection);
         var users = repository.Get();

         foreach (var user in users)
            Console.WriteLine(user.Name); // quando tenho apenas 1 linha dentro da "chaves" eu posso remover elas
      }

      public static void ReadRoles(SqlConnection connection)
      {

         var repository = new RoleRepository(connection);
         var roles = repository.Get();

         foreach (var role in roles)
            Console.WriteLine(role.Name);
      }
   }
}