using NetTopologySuite.Geometries;
using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain
{
    public class Province : WebArMaEntityBase
    {
        public static Province Create(string name, List<City> cities)
        {
            return new Province
            {
                Name = name,
                Cities = cities
            };
        }

        public Province()
        {
            Name = string.Empty;
            Cities = [];
        }

        public string Name { get; private set; }
        public ICollection<City> Cities { get; private set; }
    }

    public class City : WebArMaEntityBase
    {
        public static City Create(string name, Province province, List<Neighborhood> neighborhoods)
        {
            return new City
            {
                Name = name,
                Province = province,
                Neighborhoods = neighborhoods
            };
        }

        public City()
        {
            Name = string.Empty;
            Province = null!;
            Neighborhoods = [];
        }

        public string Name { get; private set; }
        public int ProvinceId { get; private set; }
        public Province Province { get; private set; }
        public ICollection<Neighborhood> Neighborhoods { get; private set; }
    }

    public class Neighborhood : WebArMaEntityBase
    {
        public static Neighborhood Create(string name, City city)
        {
            return new Neighborhood
            {
                Name = name,
                City = city
            };
        }

        public Neighborhood()
        {
            Name = string.Empty;
            City = null!;
        }

        public string Name { get; private set; }
        public int CityId { get; private set; }
        public City City { get; private set; }
    }

    public class Address : WebArMaEntityBase
    {
        public static Address Create(Neighborhood neighborhood, string systemAddress, string addressLine, Point location, string title)
        {
            return new Address
            {
                Neighborhood = neighborhood,
                AddressLine = addressLine,
                Location = location,
                SystemAddress = systemAddress,
                Title = title
            };
        }

        public Address()
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
