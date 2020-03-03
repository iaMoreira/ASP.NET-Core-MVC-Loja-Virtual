using System.ComponentModel.DataAnnotations;

namespace LojaVirtual.Models
{
    public class NewsletterEmail
    {
        public int Id {get; set;}
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo {0} não é válido!")]
       
        public string Email {get; set;}
    }
}