using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain.Entities
{
    public sealed class Neighborhood : WebArMaEntityBase
    {
        private Neighborhood(string name, City city)
        {
            ArgumentNullException.ThrowIfNull(city);

            Name = ValidateName(name);
            City = city;
        }

        private Neighborhood()
        {
            Name = null!;
            City = null!;
        }

        public string Name { get; private set; }
        public int CityId { get; private set; }
        public City City { get; private set; }

        public static Neighborhood Create(string name, City city)
        {
            return new Neighborhood(name, city);
        }

        public void Rename(string name)
        {
            Name = ValidateName(name);
        }

        private static string ValidateName(string value)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(value);

            return value.Trim();
        }
    }
}
