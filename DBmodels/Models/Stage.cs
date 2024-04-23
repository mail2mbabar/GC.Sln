
namespace DBmodels.Models
{
    public class Stage : BaseEntity
    {
        public long StageId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
