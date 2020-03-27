using System.Xml;
using System.Net.WebSockets;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System;

using LojaVirtual.Libraries;
using LojaVirtual.Libraries.Filter;
using LojaVirtual.Models;
using LojaVirtual.Libraries.Auth;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace LojaVirtual.Areas.Moderator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult RecoverPassword()
        {
            return View();
        }

        public IActionResult NewPassword()
        {
            return View();
        }
        
    }
}