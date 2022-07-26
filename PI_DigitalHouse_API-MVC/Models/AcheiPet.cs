using System.ComponentModel.DataAnnotations;

namespace PI_DigitalHouse_API_MVC.Models
{
    public class AcheiPet
    {
        public int Id { get; set; }
        [Required]
        public int Telefone { get; set; }
        public string TipoPet { get; set; }
        public string? NomePet { get; set; }
        public string Informações { get; set; }
        public string Endereco { get; set; }
        public int NumColeira  { get; set; }

        
        //public imagem {get; set;}
    }
}
