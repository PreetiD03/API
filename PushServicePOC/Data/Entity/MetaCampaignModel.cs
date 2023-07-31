namespace PushServicePOC.Data.Entity
{
    /// <summary>
    ///     Representing Meta Campaign Class model  
    /// </summary>
    public class MetaCampaignModel
    {
        /// <summary>
        ///     get or set campaign name
        /// </summary>
        public string? CampaignName { get; set; }

        /// <summary>
        ///     gets or sets objective
        /// </summary>
        public string? Objective { get; set; }

        /// <summary>
        ///     gets or sets status 
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        ///     gets or sets special ad categories
        /// </summary>
        public string? SpecialAdCategories { get; set; }

        /// <summary>
        ///     gets or sets smart promotion type 
        /// </summary>
        public string? SmartPromotionType { get; set; }

        /// <summary>
        ///     gets or sets access token 
        /// </summary>
        public string? AccessToken { get; set; }
    }
}
