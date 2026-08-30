using NetTopologySuite.Geometries;
using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain
{
    public class Address : WebArMaEntityBase
    {
        public static Address Create(Neighborhood neighborhood, string systemAddress, string addressLine, Point? location = null)
        {
            return new Address
            {
                Neighborhood = neighborhood,
                AddressLine = addressLine,
                Location = location,
                SystemAddress = systemAddress
            };
        }

        private Address()
        {
            SystemAddress = string.Empty;
            AddressLine = string.Empty;
            Neighborhood = null!;
        }

        public string SystemAddress { get; private set; }
        public string AddressLine { get; private set; }
        public Point? Location { get; private set; }
        public int NeighborhoodId { get; private set; }
        public Neighborhood Neighborhood { get; private set; }
    }
}
