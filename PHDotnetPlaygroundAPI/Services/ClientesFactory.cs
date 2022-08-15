using PHDotnetPlaygroundAPI.Models;

namespace PHDotnetPlaygroundAPI.Services
{
    public class ClientesFactory
    {
        private static int AutoInc = 1;
        private static List<Cliente> _ClientesInMemoryDB = new List<Cliente>();

        public ClientesFactory()
        {
        }
        //string user, string password, string role, string nome, string email, string telefone
        public static void Produce()
        {
            Add(new Cliente("Ronaldo","123456","admin", "Ronaldo", "ronaldo@teste.com", "31988081331"));
            Add(new Cliente("Cristiano","123456","cliente","Cristiano", "cristiano@teste.com", "31988081332"));
            Add(new Cliente("Ney","123456","cliente","Ney", "ney@teste.com", "31988081333"));
            Add(new Cliente("Messi","123456","cliente","Messi", "messi@teste.com", "31988081334"));
            Add(new Cliente("Lionel","123456","cliente","Lionel", "lionel@teste.com", "31988081335"));
        }

        public static Cliente Add(Cliente cliente)
        {
            cliente.Id = AutoInc++;
            _ClientesInMemoryDB.Add(cliente);
            return cliente;
        }

        public static List<Cliente> GetAll() => _ClientesInMemoryDB;

        public static Cliente GetById(int id)
        {
            return _ClientesInMemoryDB.FirstOrDefault(x => x.Id == id);
        }

        public static Cliente Update(int id, Cliente cliente)
        {
            var clienteInMemory = GetById(id);

            if(clienteInMemory != null)
            {
                var index = IndexOf(clienteInMemory);
                cliente.Id = clienteInMemory.Id;
                _ClientesInMemoryDB.RemoveAt(index);
                _ClientesInMemoryDB.Insert(index, cliente);
                clienteInMemory = cliente;
            }
            
            return clienteInMemory;
        }

        public static bool Remove(int id)
        {
            bool sucess = false;
            var clienteInMemory = GetById(id);

            if(clienteInMemory != null)
            {
                _ClientesInMemoryDB.RemoveAt(IndexOf(clienteInMemory));
                sucess = !sucess;
            }

            return sucess;
        }

        private static int IndexOf(Cliente clienteInMemory)
        {
            return _ClientesInMemoryDB.IndexOf(clienteInMemory);
        }

        public static Cliente ValidateUserPassword(string user, string password)
        {
            return _ClientesInMemoryDB.FirstOrDefault(x => x.User == user && x.Password == password);
        }
    }
}