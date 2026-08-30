using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain
{
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

        private Neighborhood()
        {
            Name = string.Empty;
            City = null!;
        }

        public string Name { get; private set; }
        public int CityId { get; private set; }
        public City City { get; private set; }
    }
}
