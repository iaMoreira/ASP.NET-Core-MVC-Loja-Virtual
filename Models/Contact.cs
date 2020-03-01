using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
namespace LojaVirtual.Models
{
    public class Contact
    {   
        // [Required(ErrorMessageResourceType = typeof(Messages))]
        [Required(ErrorMessage="O campo {0} é obrigatório!")]
        [MinLength(4, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo {0} não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter no mínimo {1} caracteres!")]
        [MaxLength(1000, ErrorMessage = "O campo {0} deve ter no máxiimo {1} caracteres!")]
        public string Text { get; set; }
    }
}