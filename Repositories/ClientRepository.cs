using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;

namespace LojaVirtual.Repositories
{
    public class ClientRepository : IClientRepository
    {
        
        private LojaVirtualContext _database;
        public ClientRepository(LojaVirtualContext database)
        {
            _database = database;
        }

        public IEnumerable<Client> All()
        {
            return _database.Clients.ToList();
        }

        public void Store(Client client)
        {
            _database.Add(client);
            _database.SaveChanges();

        }
        public Client Login(string Email, string Password)
        {
            Client client = _database.Clients.Where(m => m.Email == Email && m.Password == Password).FirstOrDefault();
            return client;
        }

        public Client Show(int Id)
        {
            return _database.Clients.Find(Id);
        }

        public void Update(Client client)
        {
            _database.Update(client);
            _database.SaveChanges();
        }

        public void Destroy(int Id)
        {
            Client client = _database.Clients.Find(Id);
            _database.Remove(client);
            _database.SaveChanges();

        }

    }
}