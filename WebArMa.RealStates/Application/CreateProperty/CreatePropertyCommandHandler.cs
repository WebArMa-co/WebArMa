using Microsoft.EntityFrameworkCore;
using WebArMa.Application.Contexts;
using WebArMa.Application.Interfaces.Mediator;
using WebArMa.Blogs.Domain.Exceptions;
using WebArMa.RealStates.Domain;

namespace WebArMa.RealStates.Application.CreateProperty
{
    public sealed class CreatePropertyCommandHandler(IWebArMaDbContext dbContext)
    : IWebArMaCommandHandler<CreatePropertyCommand, Guid>
    {
        public async ValueTask<Guid> Handle(
            CreatePropertyCommand request,
            CancellationToken cancellationToken)
        {
            var address = await dbContext
                .Set<Address>()
                .FirstOrDefaultAsync(
                    x => x.Guid == request.AddressGuid,
                    cancellationToken)
                ?? throw new NotFoundException("آدرس ملک یافت نشد.");

            var specifications = Specifications.Create(
                area: request.Area,
                landArea: request.LandArea,
                rooms: request.Rooms,
                bedrooms: request.Bedrooms,
                floor: request.Floor,
                totalFloors: request.TotalFloors,
                unitCount: request.UnitCount,
                unitPerFloor: request.UnitPerFloor,
                yearBuilt: request.YearBuilt);

            var features = Features.Create(
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

            var ownership = PropertyOwnership.Create(
                documentType: request.DocumentType,
                documentStatus: request.DocumentStatus,
                ownershipType: request.OwnershipType);

            var building = Building.Create(
                address: address,
                totalFloors: request.BuildingTotalFloors,
                unitCount: request.BuildingUnitCount,
                unitPerFloor: request.BuildingUnitPerFloor,
                constructionType: request.ConstructionType,
                facadeType: request.FacadeType);

            var property = Property.Create(
                title: request.Title,
                propertyType: request.PropertyType,
                usageType: request.UsageType,
                address: address,
                specifications: specifications,
                features: features,
                propertyOwnership: ownership,
                propertyBuilding: building);

            await dbContext
                .Set<Property>()
                .AddAsync(property, cancellationToken);

            await dbContext.SaveChangesAsync(cancellationToken);

            return property.Guid;
        }
    }

}
