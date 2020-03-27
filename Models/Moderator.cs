namespace LojaVirtual.Models
{
    public class Moderator
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        /*
            Tipo
             - C = Comum
             - G = Gerente
        */
        public string Role {get; set;}
    }
}