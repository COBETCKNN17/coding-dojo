using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DefaultProject.Models
{
    public class Order : BaseEntity
    {
        public Customer customer {get; set;}
        public int quantity {get; set;}

        public Order(Customer customer, int quantity){
            this.customer = customer;
            this.quantity = quantity;
        }

        public Order(){
        }
    }
}