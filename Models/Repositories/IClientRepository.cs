using System.Collections.Generic;
namespace LojaVirtual.Models.Repositories
{
    public interface IClientRepository
    {
        Client Login (string Email, string Password);

        void Store(Client client);
        void Update(Client client);
        void Destroy(int Id);
         
        Client Show(int Id);
        List<Client> All();
    }
}