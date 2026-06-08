using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.CampaignDTOs
{
    public class CreateCampaignRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string OrganizerName { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }       
    }
}
