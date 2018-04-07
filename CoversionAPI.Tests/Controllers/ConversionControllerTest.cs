using System;
using CoversionAPI.Models.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CoversionAPI.Repository.Interface;
using CoversionAPI.Controllers;
using System.Web.Mvc;

namespace CoversionAPI.Tests.Controllers
{
    [TestClass]
    public class ConversionControllerTest
    {
        [TestMethod]
        public void ConvertNumtoAlphaTest()
        {
            Mock<IConvertAmount> convertAmtObj = new Mock<IConvertAmount>();
            ConversionController conversionControllerObj = new ConversionController(convertAmtObj.Object);
            PersonDetail personDetails = new PersonDetail();
            personDetails.Name = "Hemant";
            personDetails.Amount = "123";
            var result = conversionControllerObj.ConvertNumtoAlpha(personDetails) as JsonResult;

            var mockResult = GetTestPersonDetails();

            Assert.AreEqual(result.Data, mockResult.Data);
        }

        private JsonResult GetTestPersonDetails()
        {
            var model = new PersonDetail() { Name = "Hemant", Amount = "one hundred and twenty three dollar" };
            return new JsonResult() { Data = new { outPut = model, StatusCode = 200 } };
        }
    }
}
