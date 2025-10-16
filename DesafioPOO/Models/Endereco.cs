using System.ComponentModel.DataAnnotations;

namespace DesafioPOO.Models
{
    public class Endereco
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(200)]
        public string Rua { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(100)]
        public string Cidade { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string Estado { get; set; } = string.Empty;
        
        [Required]
        [MaxLength(50)]
        public string Pais { get; set; } = string.Empty;

        public Endereco() { }

        public Endereco(string rua, string cidade, string estado, string pais)
        {
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }
    }
}