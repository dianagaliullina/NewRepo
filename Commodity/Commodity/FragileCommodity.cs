using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commodity
{
    public class FragileCommodity : CommodityRealization
    {
        public int MaxStackCount { get; set; }

        public FragileCommodity(string article, string name, decimal wholesalePrice,
                              decimal retailPrice, CommodityUnit unit, int maxStackCount)
            : base(article, name, wholesalePrice, retailPrice, unit)
        {
            if (maxStackCount <= 0)
                throw new ArgumentException("Максимальное количество в стопке должно быть положительным");

            MaxStackCount = maxStackCount;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 1];

            Array.Copy(baseInfo, info, baseInfo.Length);
            info[info.Length - 1] = $"Максимальное количество в стопке: {MaxStackCount} шт.";
            return info;
        }
    }
}