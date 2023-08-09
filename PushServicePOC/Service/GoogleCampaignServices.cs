using Google.Ads.Gax.Config;
using Google.Ads.GoogleAds;
using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Google.Ads.GoogleAds.V14.Common;
using Google.Ads.GoogleAds.V14.Errors;
using Google.Ads.GoogleAds.V14.Resources;
using Google.Ads.GoogleAds.V14.Services;
using Google.Apis.Auth.OAuth2;
using Google.Protobuf.WellKnownTypes;
using PushServicePOC.Data.Entity;
using PushServicePOC.Interface;
using System;
using System.Collections.Generic;
using static Google.Ads.GoogleAds.V14.Resources.Campaign.Types;
using CampaignBudget = Google.Ads.GoogleAds.V14.Resources.CampaignBudget;

namespace PushServicePOC
{
    public class GoogleCampaignServices:IGoogleCampaignManager
    {
        //private CampaignServiceClient campaignService { get; set; }
        //private CampaignBudgetServiceClient _budgetService { get; set; }

        private static Google.Ads.Gax.Config.OAuth2Flow APPLICATION { get; set; }

        //public GoogleCampaignServices(CampaignServiceClient campaignServiceClient, 
        //    CampaignBudgetServiceClient budgetService)
        //{
        //    campaignService = campaignServiceClient;
        //    _budgetService = budgetService;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="googleCampaignModal"></param>
        /// <returns></returns>
        public async Task<GoogleCampaignsResponse> CreateGoogleCampaigns(
            GoogleCampaignModal googleCampaignModal)
        {
            GoogleCampaignsResponse response = new GoogleCampaignsResponse();

         
            // setting google config
            GoogleAdsConfig config = new GoogleAdsConfig()
            {
                DeveloperToken = "JYRHThDv8O1EljjlShtBnA",
                OAuth2Mode = APPLICATION,
                OAuth2ClientId = "774037717510-9u8ghqlqcj373908r43h2cqeq49h6et8.apps.googleusercontent.com",
                OAuth2ClientSecret = "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",
                OAuth2RefreshToken = "1//0gttM01xSgGMKCgYIARAAGBASNwF-L9IrKdo5BgWbvMXaRdW4ORaFbuQTi9Kz5HE5nzlBdoaaUCR9nZiPuvbiLePYY1ErU5L7cxE",
                LoginCustomerId = "2489041417"
            };

            googleCampaignModal.CustomerId = config.LoginCustomerId;

           // config.UseGrpcCore = true;
            GoogleAdsClient client = new GoogleAdsClient(config);

            // Create a budget to be used for the campaign.
            string budget = CreateBudget(client, googleCampaignModal);

            List<CampaignOperation> operations = new List<CampaignOperation>();

            for (int i = 0; i < googleCampaignModal.NumberOfCampaign; i++)
            {
                Campaign campaign = new Campaign()
                {
                    Name = googleCampaignModal.CampaignName,
                    AdvertisingChannelType = Google.Ads.GoogleAds.V14.Enums.AdvertisingChannelTypeEnum.
                    Types.AdvertisingChannelType.Search,

                    // Recommendation: Set the campaign to PAUSED when creating it to prevent
                    // the ads from immediately serving. Set to ENABLED once you've added
                    // targeting and the ads are ready to serve
                    Status=Google.Ads.GoogleAds.V14.Enums.CampaignStatusEnum.Types.CampaignStatus.Paused,


                    // Set the bidding strategy and budget.
                    ManualCpc = new ManualCpc(),

                    CampaignBudget = budget,

                    // Set the campaign network options.
                    NetworkSettings = new NetworkSettings
                    {
                        TargetGoogleSearch = googleCampaignModal.TargetGoogleSearch,
                        TargetSearchNetwork = googleCampaignModal.TargetSearchNetwork,
                        TargetContentNetwork = googleCampaignModal.TargetContentNetwork,
                        TargetPartnerSearchNetwork = googleCampaignModal.TargetPartnerSearchNetwork
                    },

                    // Optional: Set the start date.
                    StartDate = googleCampaignModal.StartDate.ToString("yyyyMMdd"),

                    // Optional: Set the end date.
                    EndDate = googleCampaignModal.EndDate.ToString("yyyyMMdd"),
                };

                // Create the operation.
                operations.Add(new CampaignOperation() { Create = campaign });
            }


            CampaignServiceClient campaignService = client.GetService(Services.V14.CampaignService);
            // Add the campaigns.
            MutateCampaignsResponse retVal = campaignService.MutateCampaigns(
                    googleCampaignModal.CustomerId, operations);

                // Display the results.
                if (retVal.Results.Count > 0)
                {
                    foreach (MutateCampaignResult newCampaign in retVal.Results)
                    {
                        Console.WriteLine("Campaign with resource ID = '{0}' was added.",
                            newCampaign.ResourceName);
                    }
                }
                else
                {
                    Console.WriteLine("No campaigns were added.");
                }
            
           
            response.Status = true;
            response.CampaignsResponseData = retVal;
            response.Message = "Campaign created";

            return response;
        }

        public  string CreateBudget(GoogleAdsClient client, GoogleCampaignModal googleCampaignModal)
        {
            var _budgetService = client.GetService(Services.V14.CampaignBudgetService);
            // Create the campaign budget.
            CampaignBudget budget = new CampaignBudget()
            {
                Name =googleCampaignModal.CampaignBudgets.CampaignBudgetName,
                DeliveryMethod = Google.Ads.GoogleAds.V14.Enums.BudgetDeliveryMethodEnum.
                Types.BudgetDeliveryMethod.Standard,
                AmountMicros = googleCampaignModal.CampaignBudgets.BudgetAmountMicros
            };

            // Create the operation.
            CampaignBudgetOperation budgetOperation = new CampaignBudgetOperation()
            {
                Create = budget
            };

            // Create the campaign budget.
            MutateCampaignBudgetsResponse response = _budgetService.MutateCampaignBudgets(
               googleCampaignModal.CustomerId, new CampaignBudgetOperation[] { budgetOperation });
            return response.Results[0].ResourceName;
        }


    }
}