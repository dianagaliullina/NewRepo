using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Commodity.UnitTests
{
    [TestFixture]
    public class ExtendedCommodityTests
    {
        private CommodityRealization _commodity1;
        private CommodityRealization _commodity2;
        private CommodityRealization _commodity3;

        [SetUp]
        public void Setup()
        {
            _commodity1 = new CommodityRealization("A001", "Сахар", 50.5m, 60.0m, CommodityUnit.Kilograms);
            _commodity2 = new CommodityRealization("B002", "Мука", 40.0m, 50.0m, CommodityUnit.Kilograms);
            _commodity3 = new CommodityRealization("A003", "Соль", 20.0m, 30.0m, CommodityUnit.Kilograms);
        }

        [Test]
        public void Commodity_CompareTo_Test()
        {
            Assert.That(_commodity1.CompareTo(_commodity2), Is.LessThan(0)); 
            Assert.That(_commodity1.CompareTo(_commodity3), Is.LessThan(0)); 
            Assert.That(_commodity1.CompareTo(_commodity1), Is.EqualTo(0)); 
        }

        [Test]
        public void CommodityComparer_Test()
        {
            var comparer = new CommodityComparer();

            Assert.That(comparer.Compare(_commodity2, _commodity1), Is.LessThan(0));
            Assert.That(comparer.Compare(_commodity1, _commodity3), Is.LessThan(0));

            var commodity4 = new CommodityRealization("X001", "Сахар", 55.0m, 65.0m, CommodityUnit.Kilograms);
            Assert.That(comparer.Compare(_commodity1, commodity4), Is.LessThan(0));
        }

        [Test]
        public void Warehouse_Constructor_Test()
        {
            var commodities = new List<CommodityRealization> { _commodity1, _commodity2, _commodity1, _commodity3 };
            var warehouse = new Warehouse("Основной склад", commodities);

            Assert.That(warehouse.Name, Is.EqualTo("Основной склад"));
            Assert.That(warehouse.Count, Is.EqualTo(3));
        }

        [Test]
        public void Warehouse_IEnumerable_Test()
        {
            var commodities = new List<CommodityRealization> { _commodity1, _commodity2, _commodity3 };
            var warehouse = new Warehouse("Основной склад", commodities);

            int count = 0;
            foreach (var item in warehouse)
            {
                count++;
                Assert.That(commodities.Contains(item), Is.True);
            }

            Assert.That(count, Is.EqualTo(3));
        }
    }
}