using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ChannelEngine_BL.Model
{
    public class Lines
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public StockLocation StockLocation { get; set; }
        public double UnitVat { get; set; }
        public double LineTotalInclVat { get; set; }
        public double LineVat { get; set; }
        public double OriginalUnitPriceInclVat { get; set; }
        public double OriginalUnitVat { get; set; }
        public double OriginalLineTotalInclVat { get; set; }
        public double OriginalLineVat { get; set; }
        public double OriginalFeeFixed { get; set; }
        public IList<string> BundleProductMerchantProductNo { get; set; }
        public IList<string> JurisCode { get; set; }
        public IList<string> JurisName { get; set; }
        public double VatRate { get; set; }
        [JsonIgnore]
        public IList<ExtraData> ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public double UnitPriceInclVat { get; set; }
        public double FeeFixed { get; set; }
        public double FeeRate { get; set; }
        public string Condition { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }
}
