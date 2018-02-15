namespace CryptoCompare.Models
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using CryptoCompare.Helpers;

    public partial class CoinDetailsResponse
    {
        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("Data")]
        public CoinDetails Data { get; set; }

        [JsonProperty("Type")]
        public long Type { get; set; }
    }

    public partial class CoinDetails
    {
        [JsonProperty("SEO")]
        public Seo Seo { get; set; }

        [JsonProperty("General")]
        public General General { get; set; }

        [JsonProperty("ICO")]
        public Ico Ico { get; set; }

        [JsonProperty("Subs")]
        public string[] Subs { get; set; }

        [JsonProperty("StreamerDataRaw")]
        public string[] StreamerDataRaw { get; set; }
    }

    public partial class General
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("DocumentType")]
        public string DocumentType { get; set; }

        [JsonProperty("H1Text")]
        public string H1Text { get; set; }

        [JsonProperty("DangerTop")]
        public string DangerTop { get; set; }

        [JsonProperty("WarningTop")]
        public string WarningTop { get; set; }

        [JsonProperty("InfoTop")]
        public string InfoTop { get; set; }

        [JsonProperty("Symbol")]
        public string Symbol { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("BaseAngularUrl")]
        public string BaseAngularUrl { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Features")]
        public string Features { get; set; }

        [JsonProperty("Technology")]
        public string Technology { get; set; }

        [JsonProperty("TotalCoinSupply")]
        public string TotalCoinSupply { get; set; }

        [JsonProperty("Algorithm")]
        public string Algorithm { get; set; }

        [JsonProperty("ProofType")]
        public string ProofType { get; set; }

        [JsonProperty("StartDate")]
        public string StartDate { get; set; }

        [JsonProperty("Twitter")]
        public string Twitter { get; set; }

        [JsonProperty("AffiliateUrl")]
        public string AffiliateUrl { get; set; }

        [JsonProperty("Website")]
        public string Website { get; set; }

        [JsonProperty("Sponsor")]
        public Sponsor Sponsor { get; set; }

        [JsonProperty("LastBlockExplorerUpdateTS")]
        public string LastBlockExplorerUpdateTs { get; set; }

        [JsonProperty("DifficultyAdjustment")]
        public string DifficultyAdjustment { get; set; }

        [JsonProperty("BlockRewardReduction")]
        public string BlockRewardReduction { get; set; }

        [JsonProperty("BlockNumber")]
        public string BlockNumber { get; set; }

        [JsonProperty("BlockTime")]
        public string BlockTime { get; set; }

        [JsonProperty("NetHashesPerSecond")]
        public string NetHashesPerSecond { get; set; }

        [JsonProperty("TotalCoinsMined")]
        public string TotalCoinsMined { get; set; }

        [JsonProperty("PreviousTotalCoinsMined")]
        public string PreviousTotalCoinsMined { get; set; }

        [JsonProperty("BlockReward")]
        public string BlockReward { get; set; }

        [JsonIgnore]
        public string NoHtmlDescription
        {
            get
            {
                if (!string.IsNullOrEmpty(Description))
                {
                    var str = Description.Substring(3);
                    return str.StripHtml(); //.Truncate(500);
                }
                else
                {
                    return "";
                }
            }
        }

    }

    public partial class Sponsor
    {
        [JsonProperty("TextTop")]
        public string TextTop { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }
    }

    public partial class Ico
    {
        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("TokenType")]
        public string TokenType { get; set; }

        [JsonProperty("Website")]
        public string Website { get; set; }

        [JsonProperty("WebsiteLink")]
        public string WebsiteLink { get; set; }

        [JsonProperty("PublicPortfolioUrl")]
        public string PublicPortfolioUrl { get; set; }

        [JsonProperty("PublicPortfolioId")]
        public string PublicPortfolioId { get; set; }

        [JsonProperty("Features")]
        public string Features { get; set; }

        [JsonProperty("FundingTarget")]
        public string FundingTarget { get; set; }

        [JsonProperty("FundingCap")]
        public string FundingCap { get; set; }

        [JsonProperty("ICOTokenSupply")]
        public string IcoTokenSupply { get; set; }

        [JsonProperty("TokenSupplyPostICO")]
        public string TokenSupplyPostIco { get; set; }

        [JsonProperty("TokenPercentageForInvestors")]
        public string TokenPercentageForInvestors { get; set; }

        [JsonProperty("TokenReserveSplit")]
        public string TokenReserveSplit { get; set; }

        [JsonProperty("Date")]
        public long Date { get; set; }

        [JsonProperty("EndDate")]
        public long EndDate { get; set; }

        [JsonProperty("FundsRaisedList")]
        public string FundsRaisedList { get; set; }

        [JsonProperty("FundsRaisedUSD")]
        public string FundsRaisedUsd { get; set; }

        [JsonProperty("StartPrice")]
        public string StartPrice { get; set; }

        [JsonProperty("StartPriceCurrency")]
        public string StartPriceCurrency { get; set; }

        [JsonProperty("PaymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("Jurisdiction")]
        public string Jurisdiction { get; set; }

        [JsonProperty("LegalAdvisers")]
        public string LegalAdvisers { get; set; }

        [JsonProperty("LegalForm")]
        public string LegalForm { get; set; }

        [JsonProperty("SecurityAuditCompany")]
        public string SecurityAuditCompany { get; set; }

        [JsonProperty("Blog")]
        public string Blog { get; set; }

        [JsonProperty("BlogLink")]
        public string BlogLink { get; set; }

        [JsonProperty("WhitePaper")]
        public string WhitePaper { get; set; }

        [JsonProperty("WhitePaperLink")]
        public string WhitePaperLink { get; set; }
    }

    public partial class Seo
    {
        [JsonProperty("PageTitle")]
        public string PageTitle { get; set; }

        [JsonProperty("PageDescription")]
        public string PageDescription { get; set; }

        [JsonProperty("BaseUrl")]
        public string BaseUrl { get; set; }

        [JsonProperty("BaseImageUrl")]
        public string BaseImageUrl { get; set; }

        [JsonProperty("OgImageUrl")]
        public string OgImageUrl { get; set; }

        [JsonProperty("OgImageWidth")]
        public string OgImageWidth { get; set; }

        [JsonProperty("OgImageHeight")]
        public string OgImageHeight { get; set; }

        [JsonIgnore]
        public string ImageUrl
        {
            get
            {
                return $"{ this.BaseImageUrl }{ this.OgImageUrl }";
            }

        }

    }

 }
