using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.Controllers
{
    public class OrderController : Controller
    {
        IService OrderService;

        public OrderController(IService service)
        {
            OrderService = service;
        }
        // GET: Order
        public ActionResult Index()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var orders=mapper.Map<IEnumerable<OrderDTO>, List <Order>> (OrderService.GetOrders());
            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
                return View("Error");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(OrderService.GetOrder(id));
            if (order != null)
                return View(order);
            return HttpNotFound();
        }

        // GET: Order/Edit/5
        public ActionResult ChangeStatus(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order = mapper.Map<OrderDTO, Order>(OrderService.GetOrder(id));
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult ChangeStatus(Order order)
        {
            try
            {

                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
                var orderEdit = mapper.Map<Order, OrderDTO>(order);
                OrderService.ChangeOrderStatus(orderEdit);
                return RedirectToAction("Index");
            }
            catch(InvalidOperationException e)
            {
                return View("Exception", e);
            }
        }
        
        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderDTO, Order>()).CreateMapper();
            var order=mapper.Map<OrderDTO, Order>(OrderService.GetOrder(id));
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                if (id == null)
                {
                    return View("Error");
                }
                OrderService.DeleteOrder((int)id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
