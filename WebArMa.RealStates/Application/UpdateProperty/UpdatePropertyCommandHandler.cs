using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Domain.Exceptions;
using WebArMa.RealStates.Domain;
using WebArMa.RealStates.Domain.Enums;

namespace WebArMa.RealStates.Application.UpdateProperty
{
    public sealed class UpdatePropertyCommandHandler(IWebArMaDbContext dbContext)
        : IWebArMaCommandHandler<UpdatePropertyCommand, Guid>
    {
        public async ValueTask<Guid> Handle(
            UpdatePropertyCommand request,
            CancellationToken cancellationToken)
        {
            var property = await dbContext
                .Set<Property>()
                .Include(x => x.Address)
                .Include(x => x.Building)
                .FirstOrDefaultAsync(
                    x => x.Guid == request.Guid,
                    cancellationToken)
                ?? throw new NotFoundException("ملک یافت نشد.");

            var address = await dbContext
                .Set<Address>()
                .FirstOrDefaultAsync(
                    x => x.Guid == request.AddressGuid,
                    cancellationToken)
                ?? throw new NotFoundException("آدرس ملک یافت نشد.");

            property.ChangeAddress(address);

            property.Update(
                title: request.Title,
                propertyType: request.PropertyType,
                usageType: request.UsageType);

            property.Specifications.Update(
                area: request.Area,
                landArea: request.LandArea,
                rooms: request.Rooms,
                bedrooms: request.Bedrooms,
                floor: request.Floor,
                totalFloors: request.TotalFloors,
                unitCount: request.UnitCount,
                unitPerFloor: request.UnitPerFloor,
                yearBuilt: request.YearBuilt);

            property.Features.Update(
                hasParking: request.HasParking,
                parkingCount: request.ParkingCount,
                hasStorage: request.HasStorage,
                storageArea: request.StorageArea,
                hasElevator: request.HasElevator,
                hasBalcony: request.HasBalcony,
                hasTerrace: request.HasTerrace,
                hasYard: request.HasYard,
                hasPool: request.HasPool,
                hasSauna: request.HasSauna,
                hasJacuzzi: request.HasJacuzzi,
                hasSecurity: request.HasSecurity,
                hasCCTV: request.HasCCTV);

            property.PropertyOwnership.Update(
                documentType: request.DocumentType,
                documentStatus: request.DocumentStatus,
                ownershipType: request.OwnershipType);

            if (property.Building is not null)
            {
                property.Building.Update(
                    totalFloors: request.BuildingTotalFloors,
                    unitCount: request.BuildingUnitCount,
                    unitPerFloor: request.BuildingUnitPerFloor,
                    constructionType: request.ConstructionType,
                    facadeType: request.FacadeType);
            }
            else if (ShouldHaveBuilding(request.PropertyType))
            {
                var building = Building.Create(
                    totalFloors: request.BuildingTotalFloors,
                    unitCount: request.BuildingUnitCount,
                    unitPerFloor: request.BuildingUnitPerFloor,
                    constructionType: request.ConstructionType,
                    facadeType: request.FacadeType);

                property.AttachBuilding(building);
            }

            await dbContext.SaveChangesAsync(cancellationToken);

            return property.Guid;
        }

        private static bool ShouldHaveBuilding(PropertyType propertyType)
        {
            // بر اساس enum واقعی پروژه تکمیل شود.
            return true;
        }
    }
}
