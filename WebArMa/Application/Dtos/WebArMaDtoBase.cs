namespace WebArMa.Application.Dtos
{
    public class WebArMaDtoBase
    {
        public Guid Guid { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public DateTime? DeletedAt { get; protected set; }
        public Guid? CreatedByGuid { get; protected set; }
        public Guid? UpdatedByGuid { get; protected set; }
        public byte[] RowVersion { get; private set; } = [];
        public bool IsDeleted => DeletedAt.HasValue;
    }
}
