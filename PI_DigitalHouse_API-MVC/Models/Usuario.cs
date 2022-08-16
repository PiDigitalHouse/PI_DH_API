using System.ComponentModel.DataAnnotations;

namespace PI_DigitalHouse_API_MVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        public string Email { get; set; }

        [MinLength(11, ErrorMessage = "O número do telefone está incompleto")]
        public string Telefone { get; set; }
        public bool? StatusCadastro { get; set; }
        public List<CadastroPet> Pets { get;  set; } = new List<CadastroPet>();
        
        //public FotoPerfil {get; set;} 
    }
}
