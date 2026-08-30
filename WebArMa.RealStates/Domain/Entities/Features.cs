namespace WebArMa.RealStates.Domain
{
    public sealed class Features
    {
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

        private Features() { }

        public static Features Create(bool hasParking = false, int? parkingCount = null, bool hasStorage = false, decimal? storageArea = null, bool hasElevator = false, bool hasBalcony = false, bool hasTerrace = false, bool hasYard = false, bool hasPool = false, bool hasSauna = false, bool hasJacuzzi = false, bool hasSecurity = false, bool hasCCTV = false)
        {
            if (parkingCount is < 0)
            {
                throw new ArgumentException("مقدار وارد شده پارکینگ معتبر نیست");
            }

            if (storageArea is <= 0)
            {
                throw new ArgumentException("متراژ وارد شده انباری معتبر نیست");
            }

            return new Features
            {
                HasParking = hasParking,
                ParkingCount = parkingCount,
                HasStorage = hasStorage,
                StorageArea = storageArea,
                HasElevator = hasElevator,
                HasBalcony = hasBalcony,
                HasTerrace = hasTerrace,
                HasYard = hasYard,
                HasPool = hasPool,
                HasSauna = hasSauna,
                HasJacuzzi = hasJacuzzi,
                HasSecurity = hasSecurity,
                HasCCTV = hasCCTV
            };
        }
    }
}
