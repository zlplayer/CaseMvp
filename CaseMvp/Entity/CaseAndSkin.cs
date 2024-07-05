using System.ComponentModel.DataAnnotations.Schema;

namespace CaseMvp.Entity
{
    public class CaseAndSkin
    {
        public int Id { get; set; }

        [ForeignKey("Case")]
        public int CaseId { get; set; }
        public Case Case { get; set; }

        [ForeignKey("Skin")]
        public int SkinId { get; set; }
        public Skin Skin { get; set; }

        public DateTime Added { get; set; }=DateTime.Now;
    }
}
