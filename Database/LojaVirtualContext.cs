using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
namespace LojaVirtual.Database
{
    public class LojaVirtualContext : DbContext
    {

        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients {get; set;}
        
    }
}