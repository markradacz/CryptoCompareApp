using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace CryptoCompare
{
    public class CoinListResult
    {
        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("BaseImageUrl")]
        public string BaseImageUrl { get; set; }

        [JsonProperty("BaseLinkUrl")]
        public string BaseLinkUrl { get; set; }

        [JsonProperty("DefaultWatchlist")]
        public DefaultWatchlist DefaultWatchlist { get; set; }

        [JsonProperty("Data")]
        public Dictionary<string, Coin> Data { get; set; }

        [JsonProperty("Type")]
        public long Type { get; set; }
    }

    public class Coin
    {
        string BasePath = "https://www.cryptocompare.com";

        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        [JsonProperty("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Symbol")]
        public string Symbol { get; set; }

        [JsonProperty("CoinName")]
        public string CoinName { get; set; }

        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [JsonProperty("Algorithm")]
        public string Algorithm { get; set; }

        [JsonProperty("ProofType")]
        public string ProofType { get; set; }

        [JsonProperty("FullyPremined")]
        public string FullyPremined { get; set; }

        [JsonProperty("TotalCoinSupply")]
        public string TotalCoinSupply { get; set; }

        [JsonProperty("PreMinedValue")]
        public string PreMinedValue { get; set; }

        [JsonProperty("TotalCoinsFreeFloat")]
        public string TotalCoinsFreeFloat { get; set; }

        [JsonProperty("SortOrder")]
        public int SortOrder { get; set; }

        [JsonProperty("Sponsored")]
        public bool Sponsored { get; set; }

        [JsonIgnore]
        public string CoinImage { get => $"{ this.BasePath }{this.ImageUrl}"; }
    }

    public class DefaultWatchlist
    {
        [JsonProperty("CoinIs")]
        public string CoinIs { get; set; }

        [JsonProperty("Sponsored")]
        public string Sponsored { get; set; }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }

}
