using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Models;
namespace LojaVirtual.Controllers
{
    public class ProductController: Controller
    {
        
        public ActionResult index(){
            Product product = GetProduct();

            return View(product);
        } 

        private Product GetProduct()
        {
            return new Product()
                {
                    Id = 3,
                    Name = "Xbox One X",
                    Description = "Logue",
                    Value = 2000.00
                };
        }
    }
}
