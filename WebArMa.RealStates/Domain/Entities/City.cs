using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain
{
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

        private City()
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
}
