using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeroBriksha.Core.Entities
{
    public class Campaign
    {
        [Key]
        public string ID { get; set; } = string.Empty;

        public string NAME { get; set; }
        public string? DESCRIPTION { get; set; }

        public string ORGANIZERNAME { get; set; } = string.Empty;

        public DateTime STARTDATEUTC { get; set; }
        public DateTime? ENDDATEUTC { get; set; }

        public int? TARGETTREECOUNT { get; set; }

        public DateTime CREATEDDATE { get; set; }
    }
}
