using DotaMarket.DataLayer.Entities;

namespace DotaMarket.DataLayer.Specification
{
    public class UsersWithOutAgeSpecification : BaseSpecification<User>
    {
        public UsersWithOutAgeSpecification()
        {
            AddCriteria(u => u.Age == null);
        }
    }
}