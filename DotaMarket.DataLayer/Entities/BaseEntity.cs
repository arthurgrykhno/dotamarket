namespace DotaMarket.DataLayer.Entities
{
    public  class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool isDeleted { get; set; }
    }
}