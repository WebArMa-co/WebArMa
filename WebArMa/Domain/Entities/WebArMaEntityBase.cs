namespace WebArMa.Domain.Entities
{
    public abstract class WebArMaEntityBase
    {
        protected WebArMaEntityBase()
        {
            Guid = Guid.NewGuid();
            CreatedAt = DateTimeOffset.UtcNow;
        }

        public int Id { get; private set; }
        public Guid Guid { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset? UpdatedAt { get; private set; }
        public DateTimeOffset? DeletedAt { get; private set; }
        public Guid? CreatedByGuid { get; private set; }
        public Guid? UpdatedByGuid { get; private set; }
        public byte[] RowVersion { get; private set; } = [];
        public bool IsDeleted => DeletedAt.HasValue;
    }
}
