using System.Xml;
using System.Net.WebSockets;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System;

using LojaVirtual.Libraries;
using LojaVirtual.Models;
using LojaVirtual.Libraries.Auth;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using LojaVirtual.Database;
using LojaVirtual.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
namespace LojaVirtual.Controllers
{
public class HomeController : Controller
{
    private IClientRepository _clientRepository;
    private INewsLatterRepository _newslatterRepository;
    private Auth _auth;

    public HomeController(IClientRepository clientRepository, INewsLatterRepository newslatterRepository, Auth auth)
    {
        _clientRepository = clientRepository;
        _newslatterRepository = newslatterRepository;
        _auth = auth;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index([FromForm]NewsletterEmail newsletter)
    {
        if(ModelState.IsValid){
            //TODO - Adição no banco de dados
            
            _newslatterRepository.Store(newsletter);
            TempData["MSG_S"] = "E-Mail cadastrado! Agora você vai receber promoções no seu email!";
            return RedirectToAction(nameof(Index));
        }else {

            return View();
        }
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
        try{
            Contact contact = new Contact();
            contact.Name = HttpContext.Request.Form["name"];
            contact.Email = HttpContext.Request.Form["email"];
            contact.Text = HttpContext.Request.Form["text"];

            var messages = new List<ValidationResult>();
            var contexto = new ValidationContext(contact);
            bool isValid = Validator.TryValidateObject(contact, contexto, messages, true);
            if(isValid){
                ContactEmail.SedContact(contact);
                ViewData["MSG_S"] = "Mensagem de contato enciado com sucesso!";        
            }else {
                StringBuilder stringBuilder = new StringBuilder();
                foreach(var message in messages){
                    stringBuilder.Append(message.ErrorMessage+ "<br/>");
                }
                ViewData["MSG_E"] = stringBuilder.ToString();
                ViewData["contact"] = contact;
            }
        }catch (Exception e) {
            ViewData["MSG_E"] = "Ops! Tivemos um erro, tente novamente mais tarde!" + e;
        }
        return View("Contact");
    }
    
    [HttpGet]

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login([FromForm] Client client)
    {
        Client clientdb = _clientRepository.Login(client.Email, client.Password);
        if(clientdb  != null){
            _auth.Login(clientdb);
            return new RedirectResult(Url.Action(nameof(Dashboard)));
        }else {
            ViewData["MSG_E"] = "Usuário não encontrado, verifique o email e senha!";
            return View();
        }
    }

    [HttpGet]
    public IActionResult Dashboard()
    {   
        Client client = _auth.User();
        if(client != null){
            return new ContentResult() {Content = "Usuário: " + client.Id + ", Email: "+ client.Email};
        }else {
            return new ContentResult() {Content = "Acesso negado."};
        }
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register([FromForm] Client client)
    {
        if(ModelState.IsValid){
            _clientRepository.Store(client);
            TempData["MSG_S"] = "Cadastro realizado com sucesso!";

            //TODO - Implementar redirecionamente Diferentes
            return RedirectToAction(nameof(Register));
        }
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