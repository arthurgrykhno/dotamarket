using DotaMarket.DataLayer.Entities;

namespace DotaMarket.DataLayer.Specification
{
    public class UsersWithOutAgeSpecification : BaseSpecification<User>
    {
        public UsersWithOutAgeSpecification()
            : base (u => u.Age == null)
        {

        }
    }
}
