using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commodity
{
    public class PerishableCommodity : CommodityRealization
    {
        public TimeSpan MaxShelfLife { get; set; }

        public PerishableCommodity(string article, string name, decimal wholesalePrice,
                                 decimal retailPrice, CommodityUnit unit, TimeSpan maxShelfLife)
            : base(article, name, wholesalePrice, retailPrice, unit)
        {
            if (maxShelfLife <= TimeSpan.Zero)
                throw new ArgumentException("Срок хранения должен быть положительным");

            MaxShelfLife = maxShelfLife;
        }

        public override string[] GetInfo()
        {
            var baseInfo = base.GetInfo();
            var info = new string[baseInfo.Length + 1];

            Array.Copy(baseInfo, info, baseInfo.Length);
            info[info.Length - 1] = $"Максимальный срок хранения: {MaxShelfLife.TotalDays} дней";

            return info;
        }
    }
}