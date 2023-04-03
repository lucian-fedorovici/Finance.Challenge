using System;

namespace Finance.Shared.Common
{
    [Serializable]
    public class RequestContext
    {
        public string LACode { get; set; }
        public string SchoolCode { get; set; }
        public long CompanyId { get; set; }
        public long UserId { get; set; }
    }
}
