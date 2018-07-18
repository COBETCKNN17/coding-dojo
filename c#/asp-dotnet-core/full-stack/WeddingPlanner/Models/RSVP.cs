using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    public class RSVP : BaseEntity
    {
        public User user {get;set;}
        public Wedding wedding {get;set;}

        public RSVP(){
        }

        public RSVP(User user, Wedding wedding){
            this.user = user;
            this.wedding = wedding;
        }
        
    }
}