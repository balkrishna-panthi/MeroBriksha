using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MeroBriksha.Core.Entities
{
    public class Plant
    {
        public Plant() { }

        [Key]
        public string ID { get; set; }

        public string NAME { get; set; }
        public string? SCIENTIFICNAME { get; set; }

        public string? DESCRIPTION { get; set; }


    }
}
