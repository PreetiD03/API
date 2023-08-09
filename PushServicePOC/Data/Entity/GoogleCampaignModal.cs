namespace PushServicePOC.Data.Entity
{
    public class GoogleCampaignModal
    {
        public string CampaignName { get; set; }
        public string CustomerId { get; set; }
        public int NumberOfCampaign { get; set; }
        public bool TargetGoogleSearch { get; set; }
        public bool TargetSearchNetwork { get; set; }
        public bool TargetContentNetwork { get; set; }
        public bool TargetPartnerSearchNetwork { get; set; }
        public string AdvertisingChannelTypes { get; set; }
        public CampaignBudget CampaignBudgets { get; set; }
        public  string CampaignStatus { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public enum BudgetDeliveryMethod
    {
        /// <summary>
        /// Not specified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// Used for return value only. Represents value unknown in this version.
        /// </summary>
        Unknown = 1,
        /// <summary>
        /// The budget server will throttle serving evenly across
        /// the entire time period.
        /// </summary>
        Standard = 2,
        /// <summary>
        /// The budget server will not throttle serving,
        /// and ads will serve as fast as possible.
        /// </summary>
        Accelerated = 3,
    }
    public class CampaignBudget
    {
        /// <summary>
        ///     Campaign Budget Name
        /// </summary>
        public string CampaignBudgetName { get; set; }

        /// <summary>
        ///     Budget Amount
        /// </summary>
        public long BudgetAmountMicros { get; set; }

        /// <summary>
        ///    Budget Delivery Method
        /// </summary>
        public string DeliveryMethod { get; set; }
    }

    public enum AdvertisingChannelType
    {
        /// <summary>
        ///     Not specified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        ///     Used for return value only. Represents value unknown in this version.
        /// </summary>
        Unknown = 1,
        /// <summary>
        ///     Search Network. Includes display bundled, and Search+ campaigns.
        /// </summary>
        Search = 2,
        /// <summary>
        ///     Google Display Network only.
        /// </summary>.
        Display = 3,
        /// <summary>
        ///     Shopping campaigns serve on the shopping property
        ///     and on google.com search results.
        /// </summary>
        Shopping = 4,
        /// <summary>
        ///     Hotel Ads campaigns.
        /// </summary>
        Hotel = 5,
        /// <summary>
        ///     Video campaigns.
        /// </summary>
        Video = 6,
        /// <summary>
        ///     App Campaigns, and App Campaigns for Engagement, that run
        ///     across multiple channels.
        /// </summary>
        MultiChannel = 7,
        /// <summary>
        ///     Local ads campaigns.
        /// </summary>
        Local = 8,
        /// <summary>
        /// Smart campaigns.
        /// </summary>
        Smart = 9,
        /// <summary>
        ///     Performance Max campaigns.
        /// </summary>
        PerformanceMax = 10,
        /// <summary>
        ///     Local services campaigns.
        /// </summary>
        LocalServices = 11,
        /// <summary>
        ///     Discovery campaigns.
        /// </summary>
        Discovery = 12,
        /// <summary>
        ///     Travel campaigns.
        /// </summary>
         Travel = 13,
    }

    public enum CampaignStatus
    {
        /// <summary>
        /// Not specified.
        /// </summary>
        Unspecified = 0,
        /// <summary>
        /// Used for return value only. Represents value unknown in this version.
        /// </summary>
        Unknown = 1,
        /// <summary>
        /// Campaign is active and can show ads.
        /// </summary>
        Enabled = 2,
        /// <summary>
        /// Campaign has been paused by the user.
        /// </summary>
        Paused = 3,
        /// <summary>
        /// Campaign has been removed.
        /// </summary>
        Removed = 4,
    }
}