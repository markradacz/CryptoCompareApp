using System;
using Newtonsoft.Json;

namespace CryptoCompare
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }

    public class Item1
    {
		public string id { get; set; }
		public string name { get; set; }
		public string symbol { get; set; }
		public string rank { get; set; }
		public string price_usd { get; set; }
		public string price_btc { get; set; }
		public string __invalid_name__24h_volume_usd { get; set; }
		public string market_cap_usd { get; set; }
		public string available_supply { get; set; }
		public string total_supply { get; set; }
		public string percent_change_1h { get; set; }
		public string percent_change_24h { get; set; }
		public string percent_change_7d { get; set; }
		public string last_updated { get; set; }


        [JsonIgnore]
        public string Description
        {
            get
            {
                return $"Symbol: { this.symbol } - rank {this.rank } - price USD ${ this.price_usd } - supply: { this.total_supply}";
            }

        }
	}
}
