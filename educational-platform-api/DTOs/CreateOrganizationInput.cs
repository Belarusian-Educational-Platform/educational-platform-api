﻿namespace educational_platform_api.DTOs
{
    public class CreateOrganizationInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
