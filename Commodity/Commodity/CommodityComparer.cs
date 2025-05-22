using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commodity
{
    public class CommodityComparer : IComparer<CommodityRealization>
    {
        public int Compare(CommodityRealization x, CommodityRealization y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            int nameComparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            if (nameComparison != 0)
                return nameComparison;

            return x.RetailPrice.CompareTo(y.RetailPrice);
        }
    }
}