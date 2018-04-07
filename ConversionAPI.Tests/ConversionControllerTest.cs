using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CoversionAPI.Repository.Interface;
using CoversionAPI.Controllers;
using CoversionAPI.Models.Implementation;
using System.Web.Http;
using System.Web.Mvc;
using System.Linq;

namespace ConversionAPI.Tests
{
    [TestClass]
    public class ConversionControllerTest
    {
        [TestMethod]
        public void ConvertNumtoAlphaTest()
        {
            Mock<IConvertAmount> convertAmtObj = new Mock<IConvertAmount>();
            PersonDetail personDetails = new PersonDetail();
            personDetails.Name = "Hemant";
            personDetails.Amount = "123";

            PersonDetail personDetailsMock = new PersonDetail() { Name = "Hemant", Amount = "one hundred and twenty three dollar" };

            convertAmtObj.Setup(x => x.ConvertAmountToAplha(personDetails)).Returns(personDetailsMock);
            ConversionController conversionControllerObj = new ConversionController(convertAmtObj.Object);
            
            var result = conversionControllerObj.ConvertNumtoAlpha(personDetails) as JsonResult;

            Assert.AreEqual(200, GetVal<int>(result, "StatusCode"));
            Assert.AreEqual("Hemant", GetVal<PersonDetail>(result, "outPut").Name);
            Assert.AreEqual("one hundred and twenty three dollar", GetVal<PersonDetail>(result, "outPut").Amount);
        }
        
        /// <summary>
        /// Map Properties from JSON Result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonResult"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private T GetVal<T>(JsonResult jsonResult, string propertyName)
        {
            var property = jsonResult.Data.GetType().GetProperties()
                    .Where(p => string.Compare(p.Name, propertyName) == 0)
                    .FirstOrDefault();
            if (null == property)
                throw new ArgumentException("propertyName not found", "propertyName");
            return (T)property.GetValue(jsonResult.Data, null);
        }

    }
}
