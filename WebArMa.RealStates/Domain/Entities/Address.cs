using NetTopologySuite.Geometries;
using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain
{
    public class Address : WebArMaEntityBase
    {
        private Address(Neighborhood neighborhood, string systemAddress, string addressLine, Point? location)
        {
            ArgumentNullException.ThrowIfNull(neighborhood);
            Neighborhood = neighborhood;
            SystemAddress = systemAddress;
            AddressLine = ValidateAddressLine(addressLine);
            Location = location;
        }

        private Address()
        {
            SystemAddress = null!;
            AddressLine = null!;
            Neighborhood = null!;
        }

        public string SystemAddress { get; private set; }
        public string AddressLine { get; private set; }
        public Point? Location { get; private set; }
        public int NeighborhoodId { get; private set; }
        public Neighborhood Neighborhood { get; private set; }

        public static Address Create(Neighborhood neighborhood, string systemAddress, string addressLine, Point? location = null)
        {
            return new Address(neighborhood, systemAddress, addressLine, location);
        }

        public void ChangeAddressLine(string addressLine)
        {
            AddressLine = ValidateAddressLine(addressLine);
        }

        public void ChangeLocation(Point? location)
        {
            Location = location;
        }

        private static string ValidateAddressLine(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);
            return value.Trim();
        }
    }
}
