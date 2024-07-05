using System.ComponentModel.DataAnnotations.Schema;

namespace CaseMvp.Entity
{
    public class Case
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }=DateTime.Now;

        public IEnumerable<CaseAndSkin> CaseAndSkins { get; set; }
    }
}
