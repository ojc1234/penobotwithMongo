using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace penobotwithMongo.util
{
    internal class util
    {
        public List<int> ramdomList(int indexof)
        {
            var ramdomArray = new List<int>();
            for (int i = 0; ; i++)
            {
                int ramdomInt0_4 = new Random().Next(0, indexof);
                if (!ramdomArray.Contains(ramdomInt0_4)) ramdomArray.Add(ramdomInt0_4);
                if (ramdomArray.Count == indexof) break;
            }
            return ramdomArray;

        }
    }
    
}
