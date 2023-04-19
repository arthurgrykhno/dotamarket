using DotaMarket.DataLayer.Entities;
using DotaMarket.DataLayer.Enums;

namespace DotaMarket.DataLayer.Specification
{
    public class ItemByRareSpecification : BaseSpecification<Item>
    {
        public ItemByRareSpecification(ItemRare rare)
            : base (i => i.Rare == rare)
        {

        }
    }
}