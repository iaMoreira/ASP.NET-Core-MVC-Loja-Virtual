using System;
namespace LojaVirtual.Models
{
    public class Client
    {
        public int Id {get; set;}
        public string Name { get; set;}
        public DateTime birthDate { get; set;}
        public string Sexo { get; set;}
        public string CPF { get; set;}
        public string Phone { get; set;}
        public string Email { get; set;}
        public string Password { get; set;}
    }
}