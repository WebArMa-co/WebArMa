using WebArMa.Domain.Entities;
using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Domain
{
    public sealed class Property : WebArMaEntityBase
    {
        private Property(
            string title,
            PropertyType propertyType,
            UsageType usageType,
            Address address,
            Specifications specifications,
            Features features,
            PropertyOwnership propertyOwnership,
            Building? building)
        {
            ArgumentNullException.ThrowIfNull(address);
            ArgumentNullException.ThrowIfNull(specifications);
            ArgumentNullException.ThrowIfNull(features);
            ArgumentNullException.ThrowIfNull(propertyOwnership);

            Title = ValidateTitle(title);
            PropertyType = propertyType;
            UsageType = usageType;
            Status = PropertyStatus.Active;
            Address = address;
            Specifications = specifications;
            Features = features;
            PropertyOwnership = propertyOwnership;
            Building = building;
        }

        private Property()
        {
            Title = null!;
            Address = null!;
            Specifications = null!;
            Features = null!;
            PropertyOwnership = null!;
        }

        public string Title { get; private set; }
        public PropertyType PropertyType { get; private set; }
        public UsageType UsageType { get; private set; }
        public PropertyStatus Status { get; private set; }
        public Address Address { get; private set; }
        public Specifications Specifications { get; private set; }
        public Features Features { get; private set; }
        public PropertyOwnership PropertyOwnership { get; private set; }
        public int? BuildingId { get; private set; }
        public Building? Building { get; private set; }
        public static Property Create(
            string title,
            PropertyType propertyType,
            UsageType usageType,
            Address address,
            Specifications specifications,
            Features features,
            PropertyOwnership propertyOwnership,
            Building? building = null)
        {
            return new Property(
                title,
                propertyType,
                usageType,
                address,
                specifications,
                features,
                propertyOwnership,
                building);
        }

        public void Update(
            string title,
            PropertyType propertyType,
            UsageType usageType)
        {
            Title = ValidateTitle(title);
            PropertyType = propertyType;
            UsageType = usageType;
        }

        public void ChangeAddress(Address address)
        {
            ArgumentNullException.ThrowIfNull(address);

            Address = address;
        }

        public void ChangeStatus(PropertyStatus status)
        {
            Status = status;
        }

        public void AttachBuilding(Building building)
        {
            ArgumentNullException.ThrowIfNull(building);

            Building = building;
        }

        public void RemoveBuilding()
        {
            Building = null;
        }

        private static string ValidateTitle(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            return value.Trim();
        }
    }
}
