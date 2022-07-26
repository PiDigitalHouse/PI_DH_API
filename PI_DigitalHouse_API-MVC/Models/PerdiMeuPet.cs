using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PI_DigitalHouse_API_MVC.Models
{
    public class PerdiMeuPet
    {
        public int Id { get; set; }
        [Required]
        
        public string Informacoes { get; set; }
        public string LocalDesaparecimento { get; set; }
        public bool StatusPerdido { get; set; }
        public int CadastroPetId { get; set; }
       

    }
}
