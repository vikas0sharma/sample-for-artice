using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public interface IDummyService1
    {
        IEnumerable<string> GetDummyData();
    }
}
