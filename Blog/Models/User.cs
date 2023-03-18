
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public List<Role> Roles { get; set; } // aqui eu vou ter uma lista de Roles, ou seja, no meu usuário eu posso ter vários Roles

        public User() {
            Roles = new List<Role>(); // Por boa prática é bom a gente já vir e criar um método construtor, e nesse construtor instanciar essa lista, isso é para nunca acontecer dele tentar incluir um role e essa lista estar vazia
        }
    }

   
}