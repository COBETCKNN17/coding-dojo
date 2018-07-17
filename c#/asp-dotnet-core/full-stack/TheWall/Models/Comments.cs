using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    public class Comment : BaseEntity
    {
        public Message message { get; set; }

        public User user { get; set; }

        [Required]
        [MinLength(3)]
        public string text {get;set;}

        public Comment(Message message, User user, string text){
            this.message = message;
            this.user = user;
            this.text = text;
        }

        public Comment(){
        }
    }
}