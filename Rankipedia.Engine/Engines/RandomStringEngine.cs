using Rankipedia.Data.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rankipedia.Engine.Engines
{
    public interface IRandomStringEngine
    {
        List<string> GetCodes();
    }

    public class RandomStringEngine : IRandomStringEngine
    {
        private readonly IRandomStringQueryProvider _randomStringQueryProvider;
        public RandomStringEngine(IRandomStringQueryProvider randomStringQueryProvider)
        {
            _randomStringQueryProvider = randomStringQueryProvider;
        }
        public List<string> GetCodes()
        {
            return _randomStringQueryProvider.GetCodes();
        }
    }
}
