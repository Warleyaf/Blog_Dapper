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
         //CreateUser(connection);
         //CreateRoles(connection);
         //CreateTags(connection);
         //CreateCategorys(connection);
         //UpdateUser(connection);
         //DeleteUser(connection);
         ReadUsersWithRoles(connection);

         connection.Close();

      }
      // Métodos de Leituras
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

      public static void ReadUser(SqlConnection connection)
      {
         var repository = new Repository<User>(connection);
         var user = repository.Get(1002);
         Console.WriteLine(user.Email);
      }

      // Métodos de Create

      public static void CreateUser(SqlConnection connection)
      {
         var repository = new Repository<User>(connection);
         var user = new User()
         {
            Bio = "Justino",
            Email = "Justino@gmail.com",
            Image = "https:// jaoimg",
            Name = "justino gótico",
            PasswordHash = "HASH6",
            Slug = "justizitos",
         };

         repository.Create(user);
         Console.WriteLine("Usuário inserido com sucesso!!");
      }
      public static void CreateRoles(SqlConnection connection)
      {
         var repository = new Repository<Role>(connection);

         var roles = new Role()
         {
            Name = "Suporte Ti",
            Slug = "Ajuda Usuário"
         };

         repository.Create(roles);
         Console.WriteLine("Usuário criado com sucesso!");

      }
      public static void CreateTags(SqlConnection connection)
      {
         var repository = new Repository<Tag>(connection);

         var tags = new Tag()
         {
            Name = "React",
            Slug = "React Front-end"
         };

         repository.Create(tags);
         Console.WriteLine("Tag criada com sucesso!!");
      }
      public static void CreateCategorys(SqlConnection connection)
      {
         var repository = new Repository<Category>(connection);

         var categorys = new Category()
         {
            Name = "Fullstack",
            Slug = "Tudo sobre Fullstack"
         };

         repository.Create(categorys);

         Console.WriteLine("Categoria criada com sucesso!!");
      }

      // Métodos de Update

      public static void UpdateUser(SqlConnection connection)
      {
         var repository = new Repository<User>(connection);

         var users = new User()
         {
            Id = 1002,
            Name = "Launa Afonso",
            Email = "LauanaAfonso@gmail.com",
            PasswordHash = "Hashmybrother",
            Bio = "O mvmaster",
            Image = "https://warleyfonsoimg",
            Slug = "Warley O Braboo"
         };

         repository.Update(users);
         Console.WriteLine("Usuário alterado com sucesso!!");
      }

      // Método Delete
      public static void DeleteUser(SqlConnection connection)
      {
         var repository = new Repository<User>(connection);
         var users = new User()
         {
            Id = 1003,
         };

         repository.Delete(users);
         Console.WriteLine("Usuário deletado com sucesso!!");
      }


      public static void ReadUsersWithRoles(SqlConnection connection)
      {

         var repository = new UserRepository(connection);
         var items = repository.GetWithRoles();

         foreach (var item in items)
         {
            Console.WriteLine(item.Name); // quando tenho apenas 1 linha dentro da "chaves" eu posso remover elas
            foreach (var role in item.Roles) {
               Console.WriteLine($" - {role.Name}");
            }
         }

      }









   }
}