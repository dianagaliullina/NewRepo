using NUnit.Framework;
using Commodity;
using System;

namespace Commodity.UnitTests2
{
    [TestFixture]
    public class ExtendedCommodityTests
    {
        [Test]
        public void FragileCommodityConstructorTest()
        {
            var item = new FragileCommodity("F001", "Хрустальные вазы", 1000m, 1500m,
                                           CommodityUnit.Pieces, 5);

            Assert.That(item.Article, Is.EqualTo("F001"));
            Assert.That(item.MaxStackCount, Is.EqualTo(5));
        }

        [Test]
        public void FragileCommodityGetInfoTest()
        {
            var item = new FragileCommodity("F001", "Хрустальные вазы", 1000m, 1500m,
                                          CommodityUnit.Pieces, 5);
            item.Description = "Хрупкие изделия";
            item.StockQuantity = 10;

            var info = item.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That(info[3], Is.EqualTo("Максимальное количество в стопке: 5 шт."));
        }

        [Test]
        public void PerishableCommodityConstructorTest()
        {
            var item = new PerishableCommodity("P001", "Молоко", 50m, 70m,
                                             CommodityUnit.Packages, TimeSpan.FromDays(7));

            Assert.That(item.Article, Is.EqualTo("P001"));
            Assert.That(item.MaxShelfLife, Is.EqualTo(TimeSpan.FromDays(7)));
        }

        [Test]
        public void PerishableCommodityGetInfoTest()
        {
            var item = new PerishableCommodity("P001", "Молоко", 50m, 70m,
                                             CommodityUnit.Packages, TimeSpan.FromDays(7));
            item.Description = "Пастеризованное";
            item.StockQuantity = 100;

            var info = item.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That(info[3], Is.EqualTo("Максимальный срок хранения: 7 дней"));
        }

        [Test]
        public void BulkyCommodityConstructorTest()
        {
            var item = new BulkyCommodity("B001", "Диван", 5000m, 7500m,
                                         CommodityUnit.Pieces, 2.1, 0.9, 0.8);

            Assert.That(item.Article, Is.EqualTo("B001"));
            Assert.That(item.Length, Is.EqualTo(2.1));
            Assert.That(item.Width, Is.EqualTo(0.9));
            Assert.That(item.Height, Is.EqualTo(0.8));
        }

        [Test]
        public void BulkyCommodityGetInfoTest()
        {
            var item = new BulkyCommodity("B001", "Диван", 5000m, 7500m,
                                        CommodityUnit.Pieces, 2.1, 0.9, 0.8);
            item.Description = "Угловой диван";
            item.StockQuantity = 5;

            var info = item.GetInfo();

            Assert.That(info.Length, Is.EqualTo(4));
            Assert.That(info[3], Is.EqualTo("Габариты: 2,1 x 0,9 x 0,8 м"));
        }
    }
}