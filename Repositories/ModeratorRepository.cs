using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;

namespace LojaVirtual.Repositories
{
    public class ModeratorRepository : IModeratorRepository
    {
        private LojaVirtualContext _database;
        public ModeratorRepository(LojaVirtualContext database)
        {
            _database = database;
        }

        public IEnumerable<Moderator> All()
        {
            return _database.Moderators.ToList();
        }

        public void Store(Moderator moderator)
        {
            _database.Add(moderator);
            _database.SaveChanges();

        }
        public Moderator Login(string Email, string Password)
        {
            Moderator moderator = _database.Moderators.Where(m => m.Email == Email && m.Password == Password).FirstOrDefault();
            return moderator;
        }

        public Moderator Show(int Id)
        {
            return _database.Moderators.Find(Id);
        }

        public void Update(Moderator moderator)
        {
            _database.Update(moderator);
            _database.SaveChanges();
        }

        public void Destroy(int Id)
        {
            Moderator moderator = _database.Moderators.Find(Id);
            _database.Remove(moderator);
            _database.SaveChanges();

        }
    }   
}