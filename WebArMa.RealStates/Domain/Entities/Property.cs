using WebArMa.Domain.Entities;
using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Domain
{
    public class Property : WebArMaEntityBase
    {
        public static Property Create(string title, PropertyType propertyType, UsageType usageType, Address address, Specifications specifications, Features features, PropertyOwnership propertyOwnership, PropertyBuilding propertyBuilding)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("عنوان ملک الزامی است", nameof(title));
            }

            var property = new Property
            {
                Title = title,
                PropertyType = propertyType,
                UsageType = usageType,
                Status = PropertyStatus.Active,
                Address = address,
                Specifications = specifications,
                Features = features,
                PropertyOwnership = propertyOwnership,
                PropertyBuilding = propertyBuilding
            };

            return property;
        }

        private Property()
        {
            Title = string.Empty;
            Address = null!;
            Specifications = null!;
            Features = null!;
            PropertyOwnership = null!;
            PropertyBuilding = null!;
        }

        public string Title { get; private set; }
        public PropertyType PropertyType { get; private set; }
        public UsageType UsageType { get; private set; }
        public PropertyStatus Status { get; private set; }
        public Address Address { get; private set; }
        public Specifications Specifications { get; private set; }
        public Features Features { get; private set; }
        public PropertyOwnership PropertyOwnership { get; private set; }
        public PropertyBuilding PropertyBuilding { get; private set; }
    }
}
