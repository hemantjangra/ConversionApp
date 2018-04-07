using CoversionAPI.Models.Implementation;
using CoversionAPI.Repository.Interface;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;

namespace CoversionAPI.Controllers
{
    public class ConversionController : ApiController
    {
        private readonly IConvertAmount _convertAmountRepo;
        public ConversionController(IConvertAmount _convrtAmtRepo)
        {
            _convertAmountRepo = _convrtAmtRepo;
        }

        /// <summary>
        /// Post Api to Convert Numeric to Alphabets
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        [EnableCors(origins:"*", headers:"*", methods:"*")]
        [System.Web.Http.HttpPost]
        public JsonResult ConvertNumtoAlpha(PersonDetail personDetails)
        {
            if (personDetails != null && !string.IsNullOrEmpty(personDetails?.Name) && personDetails?.Amount!=null)
            {
                var model = _convertAmountRepo.ConvertAmountToAplha(personDetails);
                return new JsonResult()
                {
                    Data = new { outPut = model, StatusCode = 200 },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            return new JsonResult()
            {
                Data = new { outPut = "", StatusCode = 400},
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}