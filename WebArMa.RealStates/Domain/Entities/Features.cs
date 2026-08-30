namespace WebArMa.RealStates.Domain
{
    public sealed class Features
    {
        private Features(
            bool hasParking,
            int? parkingCount,
            bool hasStorage,
            decimal? storageArea,
            bool hasElevator,
            bool hasBalcony,
            bool hasTerrace,
            bool hasYard,
            bool hasPool,
            bool hasSauna,
            bool hasJacuzzi,
            bool hasSecurity,
            bool hasCCTV)
        {
            Validate(
                hasParking,
                parkingCount,
                hasStorage,
                storageArea);

            HasParking = hasParking;
            ParkingCount = parkingCount;
            HasStorage = hasStorage;
            StorageArea = storageArea;
            HasElevator = hasElevator;
            HasBalcony = hasBalcony;
            HasTerrace = hasTerrace;
            HasYard = hasYard;
            HasPool = hasPool;
            HasSauna = hasSauna;
            HasJacuzzi = hasJacuzzi;
            HasSecurity = hasSecurity;
            HasCCTV = hasCCTV;
        }

        // EF Core
        private Features()
        {
        }

        public bool HasParking { get; private set; }
        public int? ParkingCount { get; private set; }
        public bool HasStorage { get; private set; }
        public decimal? StorageArea { get; private set; }
        public bool HasElevator { get; private set; }
        public bool HasBalcony { get; private set; }
        public bool HasTerrace { get; private set; }
        public bool HasYard { get; private set; }
        public bool HasPool { get; private set; }
        public bool HasSauna { get; private set; }
        public bool HasJacuzzi { get; private set; }
        public bool HasSecurity { get; private set; }
        public bool HasCCTV { get; private set; }

        public static Features Create(
            bool hasParking = false,
            int? parkingCount = null,
            bool hasStorage = false,
            decimal? storageArea = null,
            bool hasElevator = false,
            bool hasBalcony = false,
            bool hasTerrace = false,
            bool hasYard = false,
            bool hasPool = false,
            bool hasSauna = false,
            bool hasJacuzzi = false,
            bool hasSecurity = false,
            bool hasCCTV = false)
        {
            return new Features(
                hasParking,
                parkingCount,
                hasStorage,
                storageArea,
                hasElevator,
                hasBalcony,
                hasTerrace,
                hasYard,
                hasPool,
                hasSauna,
                hasJacuzzi,
                hasSecurity,
                hasCCTV);
        }

        public void Update(
            bool hasParking = false,
            int? parkingCount = null,
            bool hasStorage = false,
            decimal? storageArea = null,
            bool hasElevator = false,
            bool hasBalcony = false,
            bool hasTerrace = false,
            bool hasYard = false,
            bool hasPool = false,
            bool hasSauna = false,
            bool hasJacuzzi = false,
            bool hasSecurity = false,
            bool hasCCTV = false)
        {
            Validate(
                hasParking,
                parkingCount,
                hasStorage,
                storageArea);

            HasParking = hasParking;
            ParkingCount = parkingCount;
            HasStorage = hasStorage;
            StorageArea = storageArea;
            HasElevator = hasElevator;
            HasBalcony = hasBalcony;
            HasTerrace = hasTerrace;
            HasYard = hasYard;
            HasPool = hasPool;
            HasSauna = hasSauna;
            HasJacuzzi = hasJacuzzi;
            HasSecurity = hasSecurity;
            HasCCTV = hasCCTV;
        }

        private static void Validate(
            bool hasParking,
            int? parkingCount,
            bool hasStorage,
            decimal? storageArea)
        {
            if (hasParking && parkingCount is not > 0)
            {
                throw new ArgumentException(
                    "تعداد پارکینگ باید بیشتر از صفر باشد.",
                    nameof(parkingCount));
            }

            if (!hasParking && parkingCount is not null)
            {
                throw new ArgumentException(
                    "تعداد پارکینگ زمانی باید مشخص شود که پارکینگ وجود داشته باشد.",
                    nameof(parkingCount));
            }

            if (hasStorage && storageArea is not > 0)
            {
                throw new ArgumentException(
                    "متراژ انباری باید بیشتر از صفر باشد.",
                    nameof(storageArea));
            }

            if (!hasStorage && storageArea is not null)
            {
                throw new ArgumentException(
                    "متراژ انباری زمانی باید مشخص شود که انباری وجود داشته باشد.",
                    nameof(storageArea));
            }
        }
    }
}
