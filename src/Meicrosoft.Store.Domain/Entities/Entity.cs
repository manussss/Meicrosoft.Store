namespace Meicrosoft.Store.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }
    }
}
