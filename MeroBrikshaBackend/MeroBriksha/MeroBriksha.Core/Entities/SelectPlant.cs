using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MeroBriksha.Core.Entities
{
    public class SelectPlant
    {
        [Key]
        public string PlantID { get; set; }

        public string TreeAssignmentID { get; set; }
    }
}
