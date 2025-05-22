using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commodity
{
    public class CommodityRealization : IComparable<CommodityRealization>
    {
        public int CompareTo(CommodityRealization other)
        {
            if (other == null) return 1;
            return string.Compare(Article, other.Article, StringComparison.Ordinal);
        }

    public readonly string Article;
        public string Name { get; set; }
        public decimal WholesalePrice { get; private set; }
        public decimal RetailPrice { get; private set; }
        public readonly CommodityUnit Unit;

        public string Description { get; set; }
        public double StockQuantity { get; set; }

        public CommodityRealization(string article, string name, decimal wholesalePrice,
                         decimal retailPrice, CommodityUnit unit)
        {
            if (string.IsNullOrWhiteSpace(article))
                throw new ArgumentException("Артикул не может быть пустым");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Наименование не может быть пустым");
            if (wholesalePrice <= 0)
                throw new ArgumentException("Оптовая цена должна быть положительной");
            if (retailPrice <= 0)
                throw new ArgumentException("Розничная цена должна быть положительной");
            if (retailPrice < wholesalePrice)
                throw new ArgumentException("Розничная цена не может быть меньше оптовой");

            Article = article;
            Name = name;
            WholesalePrice = wholesalePrice;
            RetailPrice = retailPrice;
            Unit = unit;
            StockQuantity = 0;
            Description = string.Empty;
        }


        public void SetWholesalePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Цена должна быть положительной");
            if (newPrice > RetailPrice)
                throw new ArgumentException("Оптовая цена не может быть больше розничной");

            WholesalePrice = newPrice;
        }

        public void SetRetailPrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Цена должна быть положительной");
            if (newPrice < WholesalePrice)
                throw new ArgumentException("Розничная цена не может быть меньше оптовой");

            RetailPrice = newPrice;
        }

        public void AddToStock(double quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Количество должно быть положительным");

            StockQuantity += quantity;
        }

        public void RemoveFromStock(double quantity)
        {
            if (quantity <= 0)
                throw new ArgumentException("Количество должно быть положительным");
            if (quantity > StockQuantity)
                throw new ArgumentException("Недостаточно товара на складе");

            StockQuantity -= quantity;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[3];
            info[0] = $"Артикул: {Article}. Наименование: {Name}";
            info[1] = $"Цены: оптовая - {WholesalePrice:C}, розничная - {RetailPrice:C}";

            string unitStr;
            switch (Unit)
            {
                case CommodityUnit.Pieces:
                    unitStr = "шт";
                    break;
                case CommodityUnit.Packages:
                    unitStr = "уп";
                    break;
                case CommodityUnit.Kilograms:
                    unitStr = "кг";
                    break;
                case CommodityUnit.Tons:
                    unitStr = "т";
                    break;
                default:
                    unitStr = Unit.ToString();
                    break;
            }

            info[2] = $"Наличие на складе: {StockQuantity} {unitStr}. Описание: {Description}";

            return info;
        }
    }
}