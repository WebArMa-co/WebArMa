using System.Xml.Linq;
using WebArMa.Domain.Entities;

namespace WebArMa.RealStates.Domain
{
    public class Property : WebArMaEntityBase
    {
        /// <summary>
        /// نوع
        /// </summary>
        public PropertyType PropertyType { get; set; }
        public UsageType UsageType { get; set; }
        public Status Status { get; set; }
        public Address Status { get; set; }
        public Address Address { get; private set; }

    }

    public sealed record Address
    {

    }

    public record Cities
    {

    }

    public class Property1
    {
        public Guid Id { get; set; }
        public PropertyType Type { get; set; }
        public PropertyCondition Condition { get; set; }
        public LandUse? LandUse { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Area { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? Floors { get; set; }
        public int? FloorNumber { get; set; }
        public int? YearBuilt { get; set; }
        public bool IsFurnished { get; set; }
        public bool HasParking { get; set; }
        public bool HasElevator { get; set; }
        public bool HasStorage { get; set; }
        public bool HasBalcony { get; set; }
        public Guid AddressId { get; set; }
        public int? LivingRooms { get; set; }
        public int? Kitchens { get; set; }
        public int? Toilets { get; set; }
        public bool HasGarden { get; set; }
        public bool HasTerrace { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasHeating { get; set; }
        public bool HasInternet { get; set; }
        public bool HasSecurity { get; set; }
        public string? RegistrationArea { get; set; }
        public string? MainParcelNumber { get; set; }
        public string? SubParcelNumber { get; set; }
        public string? SectionNumber { get; set; }
        public Address Address { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ICollection<PropertyImage> Images { get; set; } = [];
        public ICollection<PropertyListing> Listings { get; set; } = [];
    }

    public class PropertyOwner1
    {
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public Guid PersonId { get; set; }
        public Person Person { get; set; } = null!;
        public decimal SharePercent { get; set; }
    }

    public class PreSale1
    {
        public Guid Id { get; set; }
        public Guid ListingId { get; set; }
        public PropertyListing Listing { get; set; } = null!;
        public decimal? InitialPayment { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public decimal? DeliveryPayment { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public decimal? ConstructionProgress { get; set; }
        public string? ContractNumber { get; set; }
        public string? Description { get; set; }
    }

    public class ConstructionPartnership1
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public decimal OwnerSharePercent { get; set; }
        public decimal BuilderSharePercent { get; set; }
        public DateTime? ContractDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public decimal? EstimatedConstructionCost { get; set; }
        public string? Description { get; set; }
    }

    public class PropertyDocument1
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public DocumentType Type { get; set; }
        public string? DocumentNumber { get; set; }
        public string? RegistrationNumber { get; set; }
        public string? MainParcelNumber { get; set; }
        public string? SubParcelNumber { get; set; }
        public string? SectionNumber { get; set; }
        public OwnershipType OwnershipType { get; set; }
        public bool IsOfficial { get; set; }
        public DateTime? IssuedAt { get; set; }
        public string? Description { get; set; }
    }

    public enum OwnershipType1
    {
        SixDang = 1,
        Share = 2,
        Joint = 3,
        Endowment = 4,
        Governmental = 5,
        Private = 6,
        Other = 99
    }

    public enum DocumentType1
    {
        SinglePageDeed = 1,
        SixDangDeed = 2,
        ShareDeed = 3,
        Endowment = 4,
        Agricultural = 5,
        Provisional = 6,
        Agreement = 7,
        PowerOfAttorney = 8,
        Other = 99
    }

    public class Address1
    {
        public Guid Id { get; set; }
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? District { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? AddressLine { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public Property Property { get; set; } = null!;
    }

    public class PropertyListing1
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public ListingType Type { get; set; }
        public ListingStatus Status { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; } = "EUR";
        public decimal? DepositAmount { get; set; }
        public decimal? MonthlyRent { get; set; }
        public Guid? AgentId { get; set; }
        public User? Agent { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class PropertyImage1
    {
        public Guid Id { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public string Url { get; set; } = null!;
        public string? AltText { get; set; }
        public int SortOrder { get; set; }
        public bool IsPrimary { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class Feature1
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<PropertyFeature> Properties { get; set; } = [];
    }

    public class PropertyFeature1
    {
        public Guid PropertyId { get; set; }
        public Property Property { get; set; } = null!;
        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; } = null!;
    }

    public enum PropertyType
    {
        Apartment = 1,
        House = 2,
        Villa = 3,
        Office = 4,
        Shop = 5,
        CommercialUnit = 6,
        Warehouse = 7,
        Industrial = 8,
        Land = 9,
        Garden = 10,
        Farm = 11,
        Room = 12,
        Parking = 13,
        Storage = 14,
        Building = 15
    }

    public enum UsageType
    {
        Residential = 1,
        Commercial = 2,
        Office = 3,
        Industrial = 4,
        Agricultural = 5,
        Garden = 6,
        Mixed = 7,
        Administrative = 8,
        Educational = 9,
        Religious = 10,
        Other = 99
    }

    public enum ListingType1
    {
        Sale = 1,
        Rent = 2
    }

    public enum Status
    {
        Draft = 1,
        Published = 2,
        Paused = 3,
        Expired = 4,
        Sold = 5,
        Rented = 6,
        Cancelled = 7
    }

    public enum PropertyCondition1
    {
        New = 1,
        Excellent = 2,
        Good = 3,
        NeedsRenovation = 4,
        UnderConstruction = 5
    }

    public class PriceHistory1
    {
        public Guid Id { get; set; }
        public Guid ListingId { get; set; }
        public PropertyListing Listing { get; set; } = null!;
        public decimal? Price { get; set; }
        public decimal? DepositAmount { get; set; }
        public decimal? MonthlyRent { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}
