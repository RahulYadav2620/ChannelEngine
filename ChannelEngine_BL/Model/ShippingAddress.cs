using System.Collections.Generic;

namespace ChannelEngine_BL.Model
{
    public class ShippingAddress
    {
        public string Line1 { get; set; }
        public IList<string> Line2 { get; set; }
        public IList<string> Line3 { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public IList<string> HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryIso { get; set; }
        public IList<string> Original { get; set; }
    }
}
