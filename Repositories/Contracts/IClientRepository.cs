using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IClientRepository
    {
        Client Login (string Email, string Password);

        void Store(Client client);
        void Update(Client client);
        void Destroy(int Id);
         
        Client Show(int Id);
        IEnumerable<Client> All();
    }
}