using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    // public abstract class BaseEntity { }
    public class Product : BaseEntity
    {
        public string name {get; set;}
        public string url {get; set;}
        public string description {get; set;}
        public int quantity {get; set;}

        public Product(){

        }

        public Product(string name, string url, string description, int quantity){
            this.name = name;
            this.description = description;
            this.url = url;
            this.quantity = quantity;
        }

    }
}