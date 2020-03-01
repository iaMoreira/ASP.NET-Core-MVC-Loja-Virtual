
using LojaVirtual.Models;
using Microsoft.AspNetCore.Mvc;
namespace LojaVirtual.Controllers
{
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult ContactStore()
    {
        Contact contact = new Contact();
        contact.Name = HttpContext.Request.Form["name"];
        contact.Email = HttpContext.Request.Form["email"];
        contact.Text = HttpContext.Request.Form["text"];
        return new ContentResult() { Content = string.Format("Dados recebidos com sucesso!<br/>Nome: {0} <br/>E-mai: {1}<br/>Texto: {2}", contact.Name, contact.Email, contact.Text), ContentType = "text/html"};
    }
    

    public IActionResult Login()
    {
        return View();
    }

    public IActionResult Register()
    {
        return View();
    }
    public IActionResult ShoppingCart(){
        return View();
    }
    public IActionResult Error()
    {
        return View();
    }
}

}