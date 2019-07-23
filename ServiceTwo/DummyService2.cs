using ServiceContracts;
using System.Collections.Generic;

namespace ServiceTwo
{
    public class DummyService2 : IDummyService2
    {
        public IEnumerable<string> GetDummyStrings()
        {
            return new List<string> { "dummy1", "dummy2" };
        }
    }
}
