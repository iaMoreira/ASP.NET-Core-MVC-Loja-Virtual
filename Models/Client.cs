using System;
using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Models
{
    public class Client
    {
        public int Id {get; set;}
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        [MinLength(4, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres!")]
        public string Name { get; set;}

        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public DateTime BirthDate { get; set;}
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        
        public string Gender { get; set;}
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string CPF { get; set;}
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        public string Phone { get; set;}
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo {0} não é válido!")]
        public string Email { get; set;}
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        [MinLength(6, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres!")]
        public string Password { get; set;}
    }
}