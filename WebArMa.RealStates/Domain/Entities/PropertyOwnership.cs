using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Domain
{
    public sealed class PropertyOwnership
    {
        public PropertyDocumentType DocumentType { get; private set; }
        public PropertyDocumentStatus DocumentStatus { get; private set; }
        public PropertyOwnershipType OwnershipType { get; private set; }

        private PropertyOwnership() { }

        public static PropertyOwnership Create(PropertyDocumentType documentType, PropertyDocumentStatus documentStatus, PropertyOwnershipType ownershipType)
        {
            return new PropertyOwnership
            {
                DocumentType = documentType,
                DocumentStatus = documentStatus,
                OwnershipType = ownershipType
            };
        }
    }
}
