using System.ComponentModel.DataAnnotations;

namespace api_university.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public  string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedAd { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdateAt { get; set; }
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime? DeleteAt { get; set; }
        public bool Isdeleted { get; set; } = false;
    }
}
