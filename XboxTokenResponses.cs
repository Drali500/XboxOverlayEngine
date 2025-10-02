using System.Collections.Generic;

namespace XBOXACHOVERLAY
{
    public class XboxTokenResponse
    {
        public string IssueInstant { get; set; }
        public string NotAfter { get; set; }
        public string Token { get; set; }
        public DisplayClaims DisplayClaims { get; set; }
    }

    public class DisplayClaims
    {
        public List<Xui> xui { get; set; }
    }

    public class Xui
    {
        public string uhs { get; set; }
        public string gtg { get; set; }
        public string xid { get; set; }
    }
}