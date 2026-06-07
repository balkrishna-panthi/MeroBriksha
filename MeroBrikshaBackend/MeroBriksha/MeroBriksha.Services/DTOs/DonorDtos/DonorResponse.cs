namespace MeroBriksha.Services.DTOs.Donors
{
    public class DonorResponse
    {
        public string Id { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string? Email{ get; set; }
        public string? PhoneNumber{ get; set; }
        public string? Address { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}