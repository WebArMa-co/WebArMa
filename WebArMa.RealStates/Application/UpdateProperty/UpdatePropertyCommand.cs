using WebArMa.Application.Interfaces.Mediator;
using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Application.UpdateProperty
{
    public sealed record UpdatePropertyCommand(
        Guid Guid,
        string Title,
        PropertyType PropertyType,
        UsageType UsageType,
        Guid AddressGuid,
        decimal Area,
        decimal? LandArea = null,
        int? Rooms = null,
        int? Bedrooms = null,
        int? Floor = null,
        int? TotalFloors = null,
        int? UnitCount = null,
        int? UnitPerFloor = null,
        int? YearBuilt = null,

        bool HasParking = false,
        int? ParkingCount = null,
        bool HasStorage = false,
        decimal? StorageArea = null,
        bool HasElevator = false,
        bool HasBalcony = false,
        bool HasTerrace = false,
        bool HasYard = false,
        bool HasPool = false,
        bool HasSauna = false,
        bool HasJacuzzi = false,
        bool HasSecurity = false,
        bool HasCCTV = false,
        PropertyDocumentType DocumentType = default,
        PropertyDocumentStatus DocumentStatus = default,
        PropertyOwnershipType OwnershipType = default,
        int? BuildingTotalFloors = null,
        int? BuildingUnitCount = null,
        int? BuildingUnitPerFloor = null,
        ConstructionType? ConstructionType = null,
        FacadeType? FacadeType = null
    ) : IWebArMaCommand<Guid>;
}
