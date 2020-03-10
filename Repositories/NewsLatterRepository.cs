using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;

namespace LojaVirtual.Repositories
{
  public class NewsLatterRepository : INewsLatterRepository
  {
    private LojaVirtualContext _database;
    public NewsLatterRepository(LojaVirtualContext database){
        _database = database;
    }

    public IEnumerable<NewsletterEmail> All()
    {
        return _database.NewsletterEmails.ToList();
    }

    public void Store(NewsletterEmail newsletter)
    {
        _database.NewsletterEmails.Add(newsletter);
        _database.SaveChanges();
    }
  }
}