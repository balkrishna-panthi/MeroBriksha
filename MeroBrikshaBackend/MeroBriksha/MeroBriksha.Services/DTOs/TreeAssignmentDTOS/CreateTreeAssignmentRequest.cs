using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.TreeAssignmentDTOS
{
    public class CreateTreeAssignmentRequest
    {
        //this request does not need DonationId.Because we will take donation id from the route
        public string? Remarks { get; set; }
    }
}
