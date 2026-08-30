using WebArMa.Domain.Entities;
using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Domain.Entities
{
    public sealed class Building : WebArMaEntityBase
    {
        private Building(
            int? totalFloors,
            int? unitCount,
            int? unitPerFloor,
            ConstructionType? constructionType,
            FacadeType? facadeType)
        {
            Validate(
                totalFloors,
                unitCount,
                unitPerFloor);

            TotalFloors = totalFloors;
            UnitCount = unitCount;
            UnitPerFloor = unitPerFloor;
            ConstructionType = constructionType;
            FacadeType = facadeType;
        }

        private Building()
        {
        }

        public int? TotalFloors { get; private set; }
        public int? UnitCount { get; private set; }
        public int? UnitPerFloor { get; private set; }
        public ConstructionType? ConstructionType { get; private set; }
        public FacadeType? FacadeType { get; private set; }

        public static Building Create(
            int? totalFloors = null,
            int? unitCount = null,
            int? unitPerFloor = null,
            ConstructionType? constructionType = null,
            FacadeType? facadeType = null)
        {
            return new Building(
                totalFloors,
                unitCount,
                unitPerFloor,
                constructionType,
                facadeType);
        }

        public void Update(
            int? totalFloors = null,
            int? unitCount = null,
            int? unitPerFloor = null,
            ConstructionType? constructionType = null,
            FacadeType? facadeType = null)
        {
            Validate(
                totalFloors,
                unitCount,
                unitPerFloor);

            TotalFloors = totalFloors;
            UnitCount = unitCount;
            UnitPerFloor = unitPerFloor;
            ConstructionType = constructionType;
            FacadeType = facadeType;
        }

        private static void Validate(
            int? totalFloors,
            int? unitCount,
            int? unitPerFloor)
        {
            if (totalFloors is <= 0)
            {
                throw new ArgumentException(
                    "تعداد طبقات باید بیشتر از صفر باشد.",
                    nameof(totalFloors));
            }

            if (unitCount is <= 0)
            {
                throw new ArgumentException(
                    "تعداد واحد باید بیشتر از صفر باشد.",
                    nameof(unitCount));
            }

            if (unitPerFloor is <= 0)
            {
                throw new ArgumentException(
                    "تعداد واحد در هر طبقه باید بیشتر از صفر باشد.",
                    nameof(unitPerFloor));
            }
        }
    }
}
