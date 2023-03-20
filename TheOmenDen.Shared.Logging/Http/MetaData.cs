using System.Net;

namespace TheOmenDen.Shared.Logging.Http;
public sealed class MetaData
{
    public string RequestContentType { get; set; }
    public string RequestUri { get; set; }
    public string RequestMethod { get; set; }
    public DateTime? RequestTimestamp { get; set; }
    public string ResponseContentType { get; set; }
    public HttpStatusCode ResponseStatusCode { get; set; }
    public DateTime? ResponseTimestamp { get; set; }
}
