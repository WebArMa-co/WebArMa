using WebArMa.Domain.Entities;
using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Domain
{
    public sealed class PropertyBuilding : WebArMaEntityBase
    {
        public int? TotalFloors { get; private set; }
        public int? UnitCount { get; private set; }
        public int? UnitPerFloor { get; private set; }
        public ConstructionType? ConstructionType { get; private set; }
        public FacadeType? FacadeType { get; private set; }
        public Address Address { get; set; }

        private PropertyBuilding() { Address = null!; }

        public static PropertyBuilding Create(Address address, int? totalFloors = null, int? unitCount = null, int? unitPerFloor = null, ConstructionType? constructionType = null, FacadeType? facadeType = null)
        {
            return new PropertyBuilding
            {
                Address = address,
                TotalFloors = totalFloors,
                UnitCount = unitCount,
                UnitPerFloor = unitPerFloor,
                ConstructionType = constructionType,
                FacadeType = facadeType
            };
        }
    }
}
