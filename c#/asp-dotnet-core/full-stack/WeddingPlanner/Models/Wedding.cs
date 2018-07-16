using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    // public abstract class BaseEntity { }
    public class Wedding : BaseEntity
    {
        public int id { get; set; }

        [Required]
        public string wedder1 { get; set; }

        [Required]
        public string wedder2 { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        public string address { get; set; }

        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int userid { get; set; }
        public User creator { get; set; }
        public List<RSVP> rsvps { get; set; }

        public Wedding()
            {
            rsvps = new List<RSVP>();
            }

    }
}