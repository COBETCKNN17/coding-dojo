using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    public class Wedding : BaseEntity
    {
        public User creator {get;set;}

        [Required]
        public string wedder1 {get;set;}

        [Required]
        public string wedder2 {get;set;}

        [Required]
        public string address {get;set;}

        [Required]
        public DateTime date {get; set;}

        public List<RSVP> rsvps {get;set;}

        public Wedding(){
            rsvps = new List<RSVP>();
        }

        public Wedding(User creator, string wedder1, string wedder2, string address, DateTime date){
            this.creator = creator;
            this.wedder1 = wedder1;
            this.wedder2 = wedder2;
            this.address = address;
            this.date = date;
        }
    }
}