using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain
{
    public class City : WebArMaEntityBase
    {
        private readonly List<Neighborhood> _neighborhoods = [];

        private City(string name, Province province)
        {
            ArgumentNullException.ThrowIfNull(province);

            Name = ValidateName(name);
            Province = province;
        }


        private City()
        {
            Name = null!;
            Province = null!;
        }

        public string Name { get; private set; }
        public int ProvinceId { get; private set; }
        public Province Province { get; private set; }
        public IReadOnlyCollection<Neighborhood> Neighborhoods => _neighborhoods.AsReadOnly();

        public static City Create(string name, Province province)
        {
            return new City(name, province);
        }

        public void AddNeighborhood(Neighborhood neighborhood)
        {
            ArgumentNullException.ThrowIfNull(neighborhood);

            if (_neighborhoods.Contains(neighborhood))
            {
                return;
            }

            _neighborhoods.Add(neighborhood);
        }

        public void RemoveNeighborhood(Neighborhood neighborhood)
        {
            ArgumentNullException.ThrowIfNull(neighborhood);

            _neighborhoods.Remove(neighborhood);
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
