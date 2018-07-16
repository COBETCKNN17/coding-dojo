using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    // public abstract class BaseEntity { }
    public class RSVP : BaseEntity
    {
        public int id { get; set; }
        public int weddingid { get; set; }
        public Wedding wedding { get; set; }
        public int userid { get; set; }
        public User user { get; set; }

    }
}