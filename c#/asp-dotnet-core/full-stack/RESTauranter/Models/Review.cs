using System;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    // public abstract class BaseEntity { }
    public class Review : BaseEntity
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Reviewer Name")]
        public string reviewer_name { get; set; }

        [Required]
        [Display(Name = "Restaurant Name")]
        public string restaurant_name { get; set; }

        [Required]
        [MinLength (10)]
        [Display(Name = "Review")]
        public string review_comments { get; set; }

        [Required]
        [Display(Name = "Rating")]
        [Range(1,5, ErrorMessage="Rating must be between 1 and 5 stars")]
        public int rating { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Visited")]
        public DateTime visited { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}