using System;
using System.Collections.Generic;
using System.Text;

namespace MeroBriksha.Services.DTOs.DonorDtos
{
    public class CreateDonorRequest
    {
        public string Fullname { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
