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

        private Province()
        {
            Name = string.Empty;
            Cities = [];
        }

        public string Name { get; private set; }
        public ICollection<City> Cities { get; private set; }
    }
}
