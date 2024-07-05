using System.ComponentModel.DataAnnotations.Schema;

namespace CaseMvp.Entity
{
    public class Skin
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Fload { get; set; }

        public float Price { get; set; }
        public string  Quality { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public IEnumerable<CaseAndSkin> CaseAndSkins { get; set; }
    }
}
