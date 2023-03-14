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
         //ReadUsers();
         //ReadUser();
         //CreateUser();
         //UpdateUser();
         DeleteUser();

      }

      public static void ReadUsers()
      {

         var repository = new UserRepository();
         var users = repository.Get();

         foreach (var user in users)
            Console.WriteLine(user.Name); // quando tenho apenas 1 linha dentro da "chaves" eu posso remover elas
      }

      public static void ReadUser()
      { // pegando apenas 1 usuário
         using (var connection = new SqlConnection())
         {
            var user = connection.Get<User>(1);
            Console.WriteLine(user.Name);
         }
      }

      public static void CreateUser()
      {

         var user = new User()
         {
            // Id não coloquei por que geral automáticamente
            Bio = "Equipe Warley Afonso",
            Email = "warleysilva@gmail.com",
            Image = "https://....",
            Name = "Equipe Warley.IO",
            PasswordHash = "HASH",
            Slug = "warley-teste"
         };

         using (var connection = new SqlConnection())
         {
            connection.Insert<User>(user); // Salva o meu usuário criar no banco de dados
            Console.WriteLine("Cadastro Realizado com sucesso!");
         }
      }

      public static void UpdateUser()
      {

         var user = new User()
         {
            Id = 2,
            Bio = "Equipe | Warley Afonso",
            Email = "warleysilva@gmail.com",
            Image = "https://....",
            Name = "Equipe suporte Warley.IO",
            PasswordHash = "HASH",
            Slug = "warley-teste"
         };

         using (var connection = new SqlConnection())
         {
            connection.Update<User>(user); // uso o método Update para alterar o usuário
            Console.WriteLine("Cadastro alterado com sucesso!");
         }
      }

      public static void DeleteUser()
      {

         using (var connection = new SqlConnection())
         {
            var user = connection.Get<User>(2);
            connection.Delete<User>(user); // uso o método Delete para deletar o usuário
            Console.WriteLine("Usuário deletado com sucesso!");
         }
      }
   }
}