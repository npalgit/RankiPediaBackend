using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rankipedia.Data.Query
{
    public interface IRandomStringQueryProvider
    {
        List<string> GetCodes();
    }

    public class RandomStringQueryProvider : IRandomStringQueryProvider
    {
        private static Random random = new Random();

        public List<string> GetCodes()
        {
            List<string> res = new List<string>();
            for (int i = 0; i <= 100; i++)
                res.Add(RandomString(5));
            return res;
        }
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
