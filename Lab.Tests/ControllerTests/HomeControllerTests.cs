using BLL.DTO;
using BLL.Interfaces;
using Lab.Controllers;
using Lab.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Lab.Tests.ControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            var mock = new Mock<IService>();
            mock.Setup(a => a.GetGoods()).Returns(new List<GoodDTO>());
            HomeController controller = new HomeController(mock.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreatePostAction_ModelError()
        {
            // arrange
            string expected="CreateGood" ;
            var mock = new Mock<IService>();
            Good good = new Good();
            HomeController controller = new HomeController(mock.Object);
            controller.ModelState.AddModelError("Name", "Название модели не установлено");
            // act
            ViewResult result = controller.CreateGood(good) as ViewResult;
            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ViewName);
        }


        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            // arrange
            string expected = "Index";
            var mock = new Mock<IService>();
            var good = new Good();
            HomeController controller = new HomeController(mock.Object);
            // act
            RedirectToRouteResult result = controller.CreateGood(good) as RedirectToRouteResult;

            // assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }


    }
}
