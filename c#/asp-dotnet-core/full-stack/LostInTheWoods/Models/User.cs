using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public abstract class BaseEntity{}

    public class Trail : BaseEntity
    {
        [Key]
        public int idtrails { get; set; }

        [Required]
        [Display(Name="Trail Name")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0,10000)]
        [Display(Name="Trail Length (mi)")]
        public float Length { get; set; }

        [Required]
        [Display(Name="Elevation Change")]
        public int ElevationChange { get; set; }

        [Required]
        [Range(-90, 90)]
        public float Latitude { get; set; }

        [Required]
        [Range(-180, 180)]
        public float Longitude { get; set; }
    }
}