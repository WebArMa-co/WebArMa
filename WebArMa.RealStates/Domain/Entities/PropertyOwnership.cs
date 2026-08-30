using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Domain
{
    public sealed class PropertyOwnership
    {
        private PropertyOwnership(
            PropertyDocumentType documentType,
            PropertyDocumentStatus documentStatus,
            PropertyOwnershipType ownershipType)
        {
            DocumentType = documentType;
            DocumentStatus = documentStatus;
            OwnershipType = ownershipType;
        }

        private PropertyOwnership()
        {
        }

        public PropertyDocumentType DocumentType { get; private set; }
        public PropertyDocumentStatus DocumentStatus { get; private set; }
        public PropertyOwnershipType OwnershipType { get; private set; }

        public static PropertyOwnership Create(
            PropertyDocumentType documentType,
            PropertyDocumentStatus documentStatus,
            PropertyOwnershipType ownershipType)
        {
            return new PropertyOwnership(
                documentType,
                documentStatus,
                ownershipType);
        }

        public void Update(
            PropertyDocumentType documentType,
            PropertyDocumentStatus documentStatus,
            PropertyOwnershipType ownershipType)
        {
            DocumentType = documentType;
            DocumentStatus = documentStatus;
            OwnershipType = ownershipType;
        }
    }
}
