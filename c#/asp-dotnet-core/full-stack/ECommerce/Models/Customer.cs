using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    // public abstract class BaseEntity { }
    public class Customer : BaseEntity
    {
        [Required]
        public string name {get; set;}

        public List<Order> orders {get; set;}

        public Customer(){
            orders = new List<Order>();
        }

        public Customer(string name){
            this.name = name;
        }

    }
}