using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commodity
{
    public class Warehouse : IEnumerable<CommodityRealization>
    {
        public string Name { get; set; }
        public int Count => _commodities.Count;

        private readonly List<CommodityRealization> _commodities;

        public Warehouse(string name, IEnumerable<CommodityRealization> commodities)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название склада не может быть пустым");

            Name = name;
            _commodities = commodities.Distinct().ToList();
        }

        public IEnumerator<CommodityRealization> GetEnumerator() => _commodities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}