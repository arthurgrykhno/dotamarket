using DotaMarket.DataLayer.Entities;
using DotaMarket.DataLayer.Enums;
using System.Linq.Expressions;

namespace DotaMarket.DataLayer.Specification
{
    public class ItemByRareSpecification : BaseSpecification<Item>
    {
        public ItemByRareSpecification(ItemRare rare)
        {
            AddCriteria(i => i.Rare == rare);
        }
    }
}