using System;

namespace DefaultProject.Models
{
    public class OrderProduct : BaseEntity
    {
        //public int orderId {set; get;}
        public Order order {set; get;}

        //public int productId {set; get;}
        public Product product {set; get;}

        public OrderProduct(Order order, Product product){
            //this.orderId = orderId;
            this.order = order;
            //this.productId = productId;
            this.product = product;
        }

        public OrderProduct(){
        }
    }
}