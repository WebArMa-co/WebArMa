using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain
{
    public sealed class Province : WebArMaEntityBase
    {
        private readonly List<City> _cities = [];

        private Province(string name)
        {
            Name = ValidateName(name);
        }

        private Province()
        {
            Name = null!;
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

        public static Province Create(string name)
        {
            return new Province(name);
        }

        public void AddCity(City city)
        {
            ArgumentNullException.ThrowIfNull(city);

            if (_cities.Contains(city))
            {
                return;
            }

            _cities.Add(city);
        }

        public void RemoveCity(City city)
        {
            ArgumentNullException.ThrowIfNull(city);

            _cities.Remove(city);
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
