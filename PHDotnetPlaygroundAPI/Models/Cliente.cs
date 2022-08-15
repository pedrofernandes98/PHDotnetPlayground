namespace PHDotnetPlaygroundAPI.Models
{


    public class Cliente : EntityBase, IAuthEntity
    {
        public Cliente()
        {
            
        }
        public Cliente(string nome, string email, string telefone) 
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }

        public Cliente(string user, string password, string role, string nome, string email, string telefone) 
        {
            this.User = user;
            this.Password = password;
            this.Role = role;
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }
        public string User { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string? Token { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

    }
}