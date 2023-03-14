using System;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
   class Program
   {
      private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;Encrypt=False";

      static void Main(string[] args)
      {
         //ReadUsers();
         //ReadUser();
         CreateUser();

      }

      public static void ReadUsers() {
         using (var connection = new SqlConnection(CONNECTION_STRING)) {
            var users = connection.GetAll<User>();

            foreach(var user in users) {
               Console.WriteLine(user.Name);
            }
         }
      }

      public static void ReadUser() { // pegando apenas 1 usuário
         using (var connection = new SqlConnection(CONNECTION_STRING)) {
            var user = connection.Get<User>(1);
            Console.WriteLine(user.Name);
         }
      }

      public static void CreateUser() {

         var user = new User() {
            // Id não coloquei por que geral automáticamente
            Bio = "Equipe Warley Afonso",
            Email = "warleysilva@gmail.com",
            Image = "https://....",
            Name = "Equipe Warley.IO",
            PasswordHash = "HASH",
            Slug = "warley-teste"
         };

         using (var connection = new SqlConnection(CONNECTION_STRING)) {
            connection.Insert<User>(user);
            Console.WriteLine("Cadastro Realizado com sucesso!");
         }
      }
   }
}