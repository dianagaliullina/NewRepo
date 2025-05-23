using NUnit.Framework;
using Commodity;
using System;

namespace Commodity.UnitTests
{
    [TestFixture]
    public class CommodityUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var item = CreateTestCommodity();

            Assert.That(item.Article, Is.EqualTo("A001"));
            Assert.That(item.Name, Is.EqualTo("Сахар"));
            Assert.That(item.WholesalePrice, Is.EqualTo(50.5m));
            Assert.That(item.RetailPrice, Is.EqualTo(60.0m));
            Assert.That(item.Unit, Is.EqualTo(CommodityUnit.Kilograms));
        }

        [Test]
        public void GetInfoTest() 
        {
            var item = CreateTestCommodity();
            item.Description = "Белый сахар в мешках";
            item.StockQuantity = 120;

            var info = item.GetInfo();

            Assert.That(info.Length, Is.EqualTo(3));
            Assert.That(info[0], Is.EqualTo("Артикул: A001. Наименование: Сахар"));
            Assert.That(info[1], Is.EqualTo($"Цены: оптовая - {50.5m:C}, розничная - {60.0m:C}"));
            Assert.That(info[2], Is.EqualTo("Наличие на складе: 120 кг. Описание: Белый сахар в мешках"));
        }


        private CommodityRealization CreateTestCommodity()
        {
            return new CommodityRealization("A001", "Сахар", 50.5m, 60.0m, CommodityUnit.Kilograms);
        }
    }
}