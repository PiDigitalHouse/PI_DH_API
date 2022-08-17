using System.ComponentModel.DataAnnotations;

namespace PI_DigitalHouse_API_MVC.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        [MinLength(11, ErrorMessage = "O número do telefone está incompleto")]
        [MaxLength(11, ErrorMessage = "O número do telefone está incorreto")]
        public string Telefone { get; set; }
        public bool? StatusCadastro { get; set; }
        public List<CadastroPet> Pets { get;  set; } = new List<CadastroPet>();
        
        //public FotoPerfil {get; set;} 
    }
}

//eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoiQCIsIm5iZiI6MTY2MDc1MTI1NiwiZXhwIjoxNjYwNzU4NDU2LCJpYXQiOjE2NjA3NTEyNTZ9.fnh68HxrPhTki4nWibQEh1oNcxaK7Nz5Ynk48WQvJPY"