namespace educational_platform_api.DTOs.Organization
{
    public class UpdateOrganizationInput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
