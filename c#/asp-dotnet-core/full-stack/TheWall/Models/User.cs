using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    public class User : BaseEntity
    {

        [Required(ErrorMessage ="Field is required!")]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage="Your name can only contain letters!")]
        [MinLength(2)]
        public string first_name {get;set;}

        [Required(ErrorMessage ="Field is required!")]
        [RegularExpression("^[a-zA-Z ]*$",ErrorMessage="Your name can only contain letters!")]
        [MinLength(2)]
        public string last_name {get;set;}

        [Required(ErrorMessage ="Field is required!")]
        [EmailAddress]
        public string email {get;set;}

        [Required(ErrorMessage ="Field is required!")]
        [MinLength(8)]    
        public string password {get;set;}
        
        [Compare("password",ErrorMessage="Your passwords must match!")]
        public string confirm_password {get;set;}

        public List<Message> messages {get;set;}

        public User(){
            messages = new List<Message>();
        }
    }
}