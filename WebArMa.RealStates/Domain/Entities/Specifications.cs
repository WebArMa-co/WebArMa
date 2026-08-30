namespace WebArMa.RealStates.Domain.Entities
{
    public sealed class Specifications
    {
        private Specifications(
            decimal area,
            decimal? landArea,
            int? rooms,
            int? bedrooms,
            int? floor,
            int? totalFloors,
            int? unitCount,
            int? unitPerFloor,
            int? yearBuilt)
        {
            Validate(
                area,
                landArea,
                rooms,
                bedrooms,
                floor,
                totalFloors,
                unitCount,
                unitPerFloor,
                yearBuilt);

            Area = area;
            LandArea = landArea;
            Rooms = rooms;
            Bedrooms = bedrooms;
            Floor = floor;
            TotalFloors = totalFloors;
            UnitCount = unitCount;
            UnitPerFloor = unitPerFloor;
            YearBuilt = yearBuilt;
        }

        // EF Core
        private Specifications()
        {
        }

        public decimal Area { get; private set; }
        public decimal? LandArea { get; private set; }
        public int? Rooms { get; private set; }
        public int? Bedrooms { get; private set; }
        public int? Floor { get; private set; }
        public int? TotalFloors { get; private set; }
        public int? UnitCount { get; private set; }
        public int? UnitPerFloor { get; private set; }
        public int? YearBuilt { get; private set; }

        public static Specifications Create(
            decimal area,
            decimal? landArea = null,
            int? rooms = null,
            int? bedrooms = null,
            int? floor = null,
            int? totalFloors = null,
            int? unitCount = null,
            int? unitPerFloor = null,
            int? yearBuilt = null)
        {
            return new Specifications(
                area,
                landArea,
                rooms,
                bedrooms,
                floor,
                totalFloors,
                unitCount,
                unitPerFloor,
                yearBuilt);
        }

        public void Update(
            decimal area,
            decimal? landArea = null,
            int? rooms = null,
            int? bedrooms = null,
            int? floor = null,
            int? totalFloors = null,
            int? unitCount = null,
            int? unitPerFloor = null,
            int? yearBuilt = null)
        {
            Validate(
                area,
                landArea,
                rooms,
                bedrooms,
                floor,
                totalFloors,
                unitCount,
                unitPerFloor,
                yearBuilt);

            Area = area;
            LandArea = landArea;
            Rooms = rooms;
            Bedrooms = bedrooms;
            Floor = floor;
            TotalFloors = totalFloors;
            UnitCount = unitCount;
            UnitPerFloor = unitPerFloor;
            YearBuilt = yearBuilt;
        }

        private static void Validate(
            decimal area,
            decimal? landArea,
            int? rooms,
            int? bedrooms,
            int? floor,
            int? totalFloors,
            int? unitCount,
            int? unitPerFloor,
            int? yearBuilt)
        {
            if (area <= 0)
                throw new ArgumentException(
                    "متراژ باید بیشتر از صفر باشد.",
                    nameof(area));

            if (landArea is <= 0)
                throw new ArgumentException(
                    "متراژ زمین باید بیشتر از صفر باشد.",
                    nameof(landArea));

            if (rooms is <= 0)
                throw new ArgumentException(
                    "تعداد اتاق‌ها باید بیشتر از صفر باشد.",
                    nameof(rooms));

            if (bedrooms is <= 0)
                throw new ArgumentException(
                    "تعداد اتاق‌خواب‌ها باید بیشتر از صفر باشد.",
                    nameof(bedrooms));

            if (floor is < 0)
                throw new ArgumentException(
                    "شماره طبقه نمی‌تواند منفی باشد.",
                    nameof(floor));

            if (totalFloors is <= 0)
                throw new ArgumentException(
                    "تعداد طبقات باید بیشتر از صفر باشد.",
                    nameof(totalFloors));

            if (unitCount is <= 0)
                throw new ArgumentException(
                    "تعداد واحد باید بیشتر از صفر باشد.",
                    nameof(unitCount));

            if (unitPerFloor is <= 0)
                throw new ArgumentException(
                    "تعداد واحد در هر طبقه باید بیشتر از صفر باشد.",
                    nameof(unitPerFloor));

            if (yearBuilt is <= 0)
                throw new ArgumentException(
                    "سال ساخت معتبر نیست.",
                    nameof(yearBuilt));
        }
    }
}
