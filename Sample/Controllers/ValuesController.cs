using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IDummyService1 dummyService1;
        private readonly IDummyService2 dummyService2;

        public ValuesController(IDummyService1 dummyService1, IDummyService2 dummyService2)
        {
            this.dummyService1 = dummyService1;
            this.dummyService2 = dummyService2;
        }


        [HttpGet("data")]
        public IEnumerable<string> GetData()
        {
            return dummyService1.GetDummyData();
        }

        [HttpGet("strings")]
        public IEnumerable<string> GetStrings()
        {
            return dummyService2.GetDummyStrings();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
