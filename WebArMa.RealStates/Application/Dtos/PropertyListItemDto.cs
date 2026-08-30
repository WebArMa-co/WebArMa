using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Application.Dtos
{
    public sealed record PropertyListItemDto(
        Guid Guid,
        string Title,
        PropertyType PropertyType,
        UsageType UsageType,
        PropertyStatus Status,
        decimal Area,
        string Address,
        string Neighborhood,
        string City,
        string Province,
        bool HasParking,
        bool HasStorage,
        bool HasElevator,
        bool HasBalcony,
        bool HasPool,
        DateTimeOffset CreatedAt
    );
}
