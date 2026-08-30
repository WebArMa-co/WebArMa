namespace WebArMa.RealStates.Domain
{
    public sealed class Specifications
    {
        public decimal Area { get; private set; }
        public decimal? LandArea { get; private set; }
        public int? Rooms { get; private set; }
        public int? Bedrooms { get; private set; }
        public int? Floor { get; private set; }
        public int? TotalFloors { get; private set; }
        public int? UnitCount { get; private set; }
        public int? UnitPerFloor { get; private set; }
        public int? YearBuilt { get; private set; }

        private Specifications() { }

        public static Specifications Create(decimal area, decimal? landArea = null, int? rooms = null, int? bedrooms = null, int? floor = null, int? totalFloors = null, int? unitCount = null, int? unitPerFloor = null, int? yearBuilt = null)
        {
            if (area <= 0)
                throw new ArgumentException("مقدار وارد شده متراژ معتبر نیست");

            return new Specifications
            {
                Area = area,
                LandArea = landArea,
                Rooms = rooms,
                Bedrooms = bedrooms,
                Floor = floor,
                TotalFloors = totalFloors,
                UnitCount = unitCount,
                UnitPerFloor = unitPerFloor,
                YearBuilt = yearBuilt,
            };
        }
    }
}
