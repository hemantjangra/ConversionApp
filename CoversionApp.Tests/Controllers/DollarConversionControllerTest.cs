using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoversionApp;
using CoversionApp.Controllers;

namespace CoversionApp.Tests.Controllers
{
    [TestClass]
    public class DollarConversionControllerTest
    {
        [TestMethod]
        public void Convert()
        {
            // Arrange
            DollarConversionController controller = new DollarConversionController();

            // Act
            ViewResult result = controller.Convert() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("~/Views/DollarConversion/Convert.cshtml", result.ViewName);
        }
    }
}
