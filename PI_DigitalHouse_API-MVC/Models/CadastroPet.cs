using System.ComponentModel.DataAnnotations;

namespace PI_DigitalHouse_API_MVC.Models
{
    public class CadastroPet
    {
        public int Id { get; set; }
        [Required]
        public string TipoPet { get; set; }
        public string Nome { get; set; }
        public string? Informações { get; set; }
        public string Raça { get; set; }
        public int UsuarioId { get; set; }
        public PerdiMeuPet? PerdiMeuPet { get; set; }

        //public imagem {get; set;}


    }
}
//select* from CadastroPets;
//select* from CadastroUsuarios;
//select* from PerdiMeusPets;