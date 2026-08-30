using FluentValidation;

namespace WebArMa.RealStates.Application.CreateProperty
{
    public sealed class CreatePropertyCommandValidator
    : AbstractValidator<CreatePropertyCommand>
    {
        public CreatePropertyCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.AddressGuid)
                .NotEmpty();

            RuleFor(x => x.Area)
                .GreaterThan(0);

            RuleFor(x => x.LandArea)
                .GreaterThan(0)
                .When(x => x.LandArea.HasValue);

            RuleFor(x => x.Rooms)
                .GreaterThan(0)
                .When(x => x.Rooms.HasValue);

            RuleFor(x => x.Bedrooms)
                .GreaterThan(0)
                .When(x => x.Bedrooms.HasValue);

            RuleFor(x => x.Floor)
                .GreaterThanOrEqualTo(0)
                .When(x => x.Floor.HasValue);

            RuleFor(x => x.TotalFloors)
                .GreaterThan(0)
                .When(x => x.TotalFloors.HasValue);

            RuleFor(x => x.UnitCount)
                .GreaterThan(0)
                .When(x => x.UnitCount.HasValue);

            RuleFor(x => x.UnitPerFloor)
                .GreaterThan(0)
                .When(x => x.UnitPerFloor.HasValue);

            RuleFor(x => x.YearBuilt)
                .GreaterThan(0)
                .When(x => x.YearBuilt.HasValue);

            RuleFor(x => x.ParkingCount)
                .GreaterThan(0)
                .When(x => x.HasParking);

            RuleFor(x => x.ParkingCount)
                .Null()
                .When(x => !x.HasParking);

            RuleFor(x => x.StorageArea)
                .GreaterThan(0)
                .When(x => x.HasStorage);

            RuleFor(x => x.StorageArea)
                .Null()
                .When(x => !x.HasStorage);

            RuleFor(x => x.BuildingTotalFloors)
                .GreaterThan(0)
                .When(x => x.BuildingTotalFloors.HasValue);

            RuleFor(x => x.BuildingUnitCount)
                .GreaterThan(0)
                .When(x => x.BuildingUnitCount.HasValue);

            RuleFor(x => x.BuildingUnitPerFloor)
                .GreaterThan(0)
                .When(x => x.BuildingUnitPerFloor.HasValue);
        }
    }

}
