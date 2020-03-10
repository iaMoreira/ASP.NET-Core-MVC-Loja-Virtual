using LojaVirtual.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace LojaVirtual.Database
{
    public class LojaVirtualContext : DbContext
    {

        public LojaVirtualContext(DbContextOptions<LojaVirtualContext> options) : base(options)
        {

        }

        public DbSet<Client> Clients {get; set;}
        public DbSet<NewsletterEmail> NewsletterEmails {get; set;}
        
    }
}