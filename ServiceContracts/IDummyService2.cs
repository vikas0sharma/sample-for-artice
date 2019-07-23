using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public interface IDummyService2
    {
        IEnumerable<string> GetDummyStrings();
    }
}
