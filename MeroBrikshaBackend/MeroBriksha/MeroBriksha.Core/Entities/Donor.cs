using System.ComponentModel.DataAnnotations;

namespace MeroBriksha.Core.Entities
{
    public class Donor
    {
        [Key]
        public string ID { get; set; } = string.Empty;

        public string FULLNAME { get; set; } = string.Empty;

        public string? EMAIL { get; set; }

        public string? PHONENUMBER { get; set; }

        public string? ADDRESS { get; set; }

        public DateTime CREATEDDATE { get; set; } = DateTime.UtcNow;
    }
}