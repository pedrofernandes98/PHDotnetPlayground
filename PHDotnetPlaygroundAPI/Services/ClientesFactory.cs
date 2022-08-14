using PHDotnetPlaygroundAPI.Models;

namespace PHDotnetPlaygroundAPI.Services
{
    public class ClientesFactory
    {
        private static int AutoInc = 1;
        private static List<Cliente> ClientesInMemoryDB = new List<Cliente>();

        public ClientesFactory()
        {
        }
        
        public static void Produce()
        {
            Add(new Cliente("Ronaldo", "ronaldo@teste.com", "31988081331"));
            Add(new Cliente("Cristiano", "cristiano@teste.com", "31988081332"));
            Add(new Cliente("Ney", "ney@teste.com", "31988081333"));
            Add(new Cliente("Messi", "messi@teste.com", "31988081334"));
            Add(new Cliente("Lionel", "lionel@teste.com", "31988081335"));
        }

        public static Cliente Add(Cliente cliente)
        {
            cliente.Id = AutoInc++;
            ClientesInMemoryDB.Add(cliente);
            return cliente;
        }

        public static List<Cliente> GetAll() => ClientesInMemoryDB;
    }
}