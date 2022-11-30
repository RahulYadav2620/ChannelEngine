using System.Collections.Generic;

namespace ChannelEngine_BL.Model
{
    public class OrderDetails
    {
        public IList<Content> Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public IList<object> RequestId { get; set; }
        public IList<object> LogId { get; set; }
        public bool Success { get; set; }
        public IList<object> Message { get; set; }
        public ValidationErrors ValidationErrors { get; set; }

    }
}
