namespace PHDotnetPlaygroundAPI.Models
{
    public class Cliente : EntityBase
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
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }
        
    }
}