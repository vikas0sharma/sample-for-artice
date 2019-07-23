using ServiceContracts;
using System.Collections.Generic;

namespace NewService
{

    public class NewService : IDummyService1
    {
        public IEnumerable<string> GetDummyData()
        {
            return new List<string> { "data from new service" };
        }
    }
}
