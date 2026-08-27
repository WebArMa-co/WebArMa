namespace WebArMa.Domain.Entities
{
    public abstract record WebArMaEntityBase
    {
        protected WebArMaEntityBase()
        {
            Guid = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }

        public int Id { get; private set; }
        public Guid Guid { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public Guid? CreatedByGuid { get; private set; }
        public Guid? UpdatedByGuid { get; private set; }
        public byte[] RowVersion { get; private set; } = [];
        public bool IsDeleted => DeletedAt.HasValue;
    }
}
