using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    public class Message : BaseEntity
    {
        public User user {get;set;}

        [Required]
        [MinLength(3)]
        public string text {get;set;}
    
        public List<Comment> comments {get;set;}

        public Message(){
            comments = new List<Comment>();
        }

        public Message(User user, string text){
            this.user = user;
            this.text = text;
        }
    }
}