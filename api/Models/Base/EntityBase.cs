namespace api.Models.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public bool IsDeleted { get; set; }
    }
}
