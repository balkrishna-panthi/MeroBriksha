using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.CampaignDTOs
{
    public class UpdateCampaignRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OrganizerName { get; set; }


    }
}
