using System.ComponentModel.DataAnnotations;

namespace Business.Entities
{
    public class Nave
    {
        [Key]
        public int IdNave { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Passageiros { get; set; }
        public double Carga { get; set; }
        public string Classe { get; set; }
    }
}