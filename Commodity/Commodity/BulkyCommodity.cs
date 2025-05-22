using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commodity
{
    public class BulkyCommodity : CommodityRealization
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }

        public BulkyCommodity(string article, string name, decimal wholesalePrice,
                             decimal retailPrice, CommodityUnit unit,
                             double length, double width, double height)
            : base(article, name, wholesalePrice, retailPrice, unit)
        {
            if (length <= 0 || width <= 0 || height <= 0)
                throw new ArgumentException("Габариты должны быть положительными");

            Length = length;
            Width = width;
            Height = height;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 1];

            Array.Copy(baseInfo, info, baseInfo.Length);
            info[info.Length - 1] = $"Габариты: {Length} x {Width} x {Height} м";

            return info;
        }
    }
}