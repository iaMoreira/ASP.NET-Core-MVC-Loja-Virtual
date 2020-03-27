using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories.Contracts
{
    public interface IModeratorRepository
    {
        Moderator Login (string Email, string Password);

        void Store(Moderator moderator);
        void Update(Moderator moderator);
        void Destroy(int Id);
         
        Moderator Show(int Id);
        IEnumerable<Moderator> All();
    }
}