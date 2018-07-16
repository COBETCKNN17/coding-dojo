using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DefaultProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DefaultProject.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext _context;
        public HomeController (ProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }
        
        [HttpGet]
        [Route("customers")]
        public IActionResult Customers()
        {
            ViewBag.customers = _context.customers;
            return View("Customers");
        }

        [HttpPost]
        [Route("customers")]
        public IActionResult createCustomer(Customer customer){
            if(ModelState.IsValid){
                _context.Add(customer);
                _context.SaveChanges();
                 return RedirectToAction("customers");
            }

            ViewBag.customers = _context.customers;
            return View("customers");
        }

        [HttpPost]
        [Route("customers/{customerId}/remove")]
        public IActionResult removeCustomer(int customerId){
            Customer customer = _context.customers.Where(c => c.id == customerId).SingleOrDefault();
            _context.customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("customers");
        }

        [HttpGet]
        [Route("products")]
        public IActionResult Products(){
            ViewBag.products = _context.products;
            return View("Products");
        }

        [HttpPost]
        [Route("products")]
        public IActionResult createProduct(Product product){
            if(ModelState.IsValid){
                _context.Add(product);
                _context.SaveChanges();
                 return RedirectToAction("products");
            }

            ViewBag.products = _context.products;
            return View("products");
        }

        [HttpGet]
        [Route("orders")]
        public IActionResult Orders(){
            ViewBag.orders = _context.orders;
            ViewBag.customers = _context.customers;
            ViewBag.products = _context.products;

            ViewBag.orderProducts = _context.orders_products.Include(op => op.order).ThenInclude(o => o.customer).Include(op => op.product);

            return View("Orders");
        }

        [HttpPost]
        [Route("orders")]
        public IActionResult createOrder(int customerId, int productId, int quantity){
                Customer customer = _context.customers.Where(u => u.id == customerId).SingleOrDefault();
                Product product = _context.products.Where(p => p.id == productId).SingleOrDefault();
                product.quantity -= quantity;
                
                if(product.quantity <= 0 ){
                    TempData["quantityerror"] = "We do not have enough of that item!";
                    return RedirectToAction("orders");
                }

                _context.SaveChanges();

                Order order = new Order(customer, quantity);
                _context.Add(order);
                _context.SaveChanges();

                OrderProduct orderProduct = new OrderProduct(order,product);
                _context.Add(orderProduct);
                _context.SaveChanges();

                 return RedirectToAction("orders");
            
        }

    }
}
