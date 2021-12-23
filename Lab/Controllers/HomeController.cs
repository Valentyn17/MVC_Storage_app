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
    public class HomeController : Controller
    {
        IService GoodService;
        public HomeController(IService serv)
        {
            GoodService = serv;
        }
        public ActionResult Index(string search=null)
        {
            if (search != null)
            {
                var mappr = new MapperConfiguration(cfg => cfg.CreateMap<GoodDTO, Good>()).CreateMapper();
                var searchedgoods = mappr.Map<IEnumerable<GoodDTO>, List<Good>>(GoodService.FindByName(search));
                return View(searchedgoods);
            }
            else
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodDTO, Good>()).CreateMapper();
                var goods = mapper.Map<IEnumerable<GoodDTO>, List<Good>>(GoodService.GetGoods());
                return View(goods);
            }
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            if (GoodService.GetGood(id) == null)
            {
                return Redirect("/Home/Index");
            }

            ViewBag.GoodId = id;
            ViewBag.Title = "Покупка";
            Order order = new Order { GoodId = id };
            return View(order);
        }

        // кнопка submit на /Home/Buy/номер товара 1-3
        [HttpPost]
        public ActionResult Buy(Order order)
        {
            if (order.Count<=0)
            {
                return View("Error");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
            var orderDTO = mapper.Map<Order, OrderDTO>(order);
            GoodService.MakeOrder(orderDTO);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditGood(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodDTO, Good>()).CreateMapper();
            var good = mapper.Map<GoodDTO, Good>(GoodService.GetGood(id));
            if (good == null)
            {
                return View("Error");
            }
            return View(good);
        }

        [HttpPost]
        public ActionResult EditGood(Good good)
        {
            if (ModelState.IsValid)
            {
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Good, GoodDTO>()).CreateMapper();
                var goodtoEdit = mapper.Map<Good, GoodDTO>(good);
                GoodService.UpdateGood(goodtoEdit);
                return RedirectToAction("Index");
            }

            return View(good);
        }

        public ActionResult CreateGood()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateGood(Good good)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Good, GoodDTO>()).CreateMapper();
                    var newGood = mapper.Map<Good, GoodDTO>(good);
                    GoodService.CreateGood(newGood);
                    return RedirectToAction("Index");
                }
                catch (InvalidOperationException ex)
                {
                    return View("Exception", ex);
                }
            }

            return View("CreateGood",good);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return View("Error");
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodDTO, Good>()).CreateMapper();
            var newGood = mapper.Map<GoodDTO, Good>(GoodService.GetGood(id));
            if (newGood != null)
                return View(newGood);
            return HttpNotFound();
        }


        [HttpGet]
        public ActionResult DeleteGood(int? id)
        {
            try
            {
                if (id == null)
                {
                    return View("Error") ;
                }
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GoodDTO, Good>()).CreateMapper();
                var newGood = mapper.Map<GoodDTO, Good>(GoodService.GetGood(id));
                if (newGood == null)
                {
                    return View("Error");
                }
                return View(newGood);
            }
            catch (InvalidOperationException ex)
            {
                return View("Exception", ex);
            }
        }
        // Атрибут ActionName("DeleteGood") указывает, что метод DeleteConfirmed будет восприниматься как действие Delete. 
        [HttpPost, ActionName("DeleteGood")]
        public ActionResult DeleteBookConfirmed(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            GoodService.DeleteGood((int)id);
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}