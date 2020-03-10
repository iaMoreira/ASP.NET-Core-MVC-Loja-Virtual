using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Models;

namespace LojaVirtual.Repositories.Contracts
{
    public interface INewsLatterRepository
    {
        void Store(NewsletterEmail newsletter);

        IEnumerable<NewsletterEmail> All();       
    }
}