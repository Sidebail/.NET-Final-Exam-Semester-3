using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using F2018Pranks.Controllers;
using F2018Pranks.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace F2018Pranks.Tests.Controllers
{
    [TestClass]
    public class PranksControllerTest
    {
        PranksController controller;
        Mock<IMockPrank> mock;
        List<Prank> pranks;

        [TestInitialize]
        public void TestInitialize()
        {
            mock = new Mock<IMockPrank>();

            pranks = new List<Prank>
            {
                new Prank {
                    PrankId = 24,
                    Name = "Tape on the Receiver",
                    Description = "Hilarious",
                    Photo = "tape.png"
                },
                new Prank {
                    PrankId = 49,
                    Name = "Disconnect the Monitor",
                    Description = "Infuriating",
                    Photo = "disconnect.png"
                },
                new Prank {
                    PrankId = 72,
                    Name = "Gift Wrap the Desk",
                    Description = "Jim would be so proud",
                    Photo = "wrap.png"
                }
            };

            mock.Setup(m => m.Pranks).Returns(pranks.AsQueryable());
            controller = new PranksController(mock.Object);
            Console.Write("2121");
        }

        // GET: pranks/Index
        #region
        [TestMethod]
        public void IndexViewLoads()
        {
            

            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void IndexValidLoadsPranks()
        {
            // act
            var result = (List<Prank>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(pranks, result);
        }

        #endregion

        // GET: pranks/Details
        #region

        

        

        [TestMethod]
        public void DetailsValidId()
        {
            // act
            Prank result = (Prank)((ViewResult)controller.Details(24)).Model;

            // assert
            Assert.AreEqual(pranks[0], result);
        }

        [TestMethod]
        public void DetailsInvalidId()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(534);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsNoId()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }
        #endregion

        //GET: pranks/Create
        #region

        [TestMethod]
        public void CreateViewLoads()
        {
            //act
            ViewResult result = (ViewResult)controller.Create();

            //assert
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateSaveInvalid()
        {
            // arrange
            Prank invalidPranks = new Prank();


            // act
            controller.ModelState.AddModelError("some error name", "fake error description");
            ViewResult result = (ViewResult)controller.Create(invalidPranks);

            // assert
            Assert.IsNotNull(result.ViewBag);
        }

        [TestMethod]
        public void CreateSaveValid()
        {
            // act
            Prank copiedPrankFromGlobal = pranks[1];
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Create(copiedPrankFromGlobal);

            // assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        #endregion
    }
}
