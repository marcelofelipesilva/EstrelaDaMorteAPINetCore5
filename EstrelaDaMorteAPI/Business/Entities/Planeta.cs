using System.ComponentModel.DataAnnotations;

namespace Business.Entities
{
    public class Planeta
    {
        [Key]
        public int IdPlaneta { get; set; }
        public string Nome { get; set; }
        public double Rotacao { get; set; }
        public double Orbita { get; set; }
        public double Diametro { get; set; }
        public string Clima { get; set; }
        public int Populacao { get; set; }
    }
}