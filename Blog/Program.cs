using System;
using Blog.Models;
using Blog.Repositories;
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
            //ReadUsers(connection);
            //ReadRoles(connection);
            //ReadTags(connection);
            //ReadUser(connection);
            CreateUser(connection);
            
         connection.Close();

      }

      public static void ReadUsers(SqlConnection connection)
      {

         var repository = new Repository<User>(connection);
         var items = repository.Get();

         foreach (var item in items)
            Console.WriteLine(item.Name); // quando tenho apenas 1 linha dentro da "chaves" eu posso remover elas
      }

      public static void ReadRoles(SqlConnection connection)
      {

         var repository = new Repository<Role>(connection);
         var items = repository.Get();

         foreach (var item in items)
            Console.WriteLine(item.Name);
      }

      public static void ReadTags(SqlConnection connection)
      {

         var repository = new Repository<Tag>(connection);
         var items = repository.Get();

         foreach (var item in items)
            Console.WriteLine(item.Name);
      }

      public static void ReadUser(SqlConnection connection) {
         var repository = new Repository<User>(connection);
         var user = repository.Get(1002);
         Console.WriteLine(user.Email);
      }

      public static void CreateUser(SqlConnection connection) {
         var repository = new Repository<User>(connection);
         var user = new User() {
            Bio = "Jao",
            Email = "Jao@gmail.com",
            Image = "https:// jaoimg",
            Name = "jao gótico",
            PasswordHash = "HASH6",
            Slug = "jaozito",
         };

         repository.Create(user);
         Console.WriteLine("Usuário inserido com sucesso!!");
      }

      

   }
}