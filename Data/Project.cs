using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotChocolatePostgres.Data
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Name { get; set; }

        [Column(TypeName = "jsonb")]
        public ProjectLocation? Location { get; set; }

    }

    public class ProjectLocation
    {
        public double Lat { get; set; }
        public double Lon { get; set; }
        public ProjectAddress? Address { get; set; }
    }

    public class ProjectAddress
    {
        public string? Country { get; set; }
        public string? City { get; set; }
    }
}
