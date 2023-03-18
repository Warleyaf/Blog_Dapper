using Dapper.Contrib.Extensions;

namespace Blog.Models
{
   [Table("[Category]")]
   public class Category
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Slug { get; set; }
      public List<Post> Posts { get; set; } // Eu teria aqui uma propriedade de listas de posts chamada de "Posts";
      // Ou seja no "Category" eu teria uma lista de Posts
   }
}