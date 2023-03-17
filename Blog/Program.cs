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
            CreateCategorys(connection);
            
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

      public static void CreateRoles(SqlConnection connection) {
         var repository = new Repository<Role>(connection);

         var roles = new Role() {
            Name = "Suporte Ti",
            Slug = "Ajuda Usuário"
         };

         repository.Create(roles);
         Console.WriteLine("Usuário criado com sucesso!");

      }
      public static void CreateTags(SqlConnection connection) {
         var repository = new Repository<Tag>(connection);

         var tags = new Tag() {
            Name = "React",
            Slug = "React Front-end"
         };

         repository.Create(tags);
         Console.WriteLine("Tag criada com sucesso!!");
      }
      public static void CreateCategorys(SqlConnection connection){
         var repository = new Repository<Category>(connection);

         var categorys = new Category() {
            Name = "Fullstack",
            Slug = "Tudo sobre Fullstack"
         };

         repository.Create(categorys);

         Console.WriteLine("Categoria criada com sucesso!!");
      }












   }
}