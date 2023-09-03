namespace educational_platform_api.Models.Base
{
    public abstract class EntityBase : IEntityBase
    {
        public bool IsDeleted { get; set; }
    }
}
