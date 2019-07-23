using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceOne
{
    public class DummyService1 : IDummyService1
    {
        public IEnumerable<string> GetDummyData()
        {
            return new List<string> { "data1", "data2" };
        }
    }
}
