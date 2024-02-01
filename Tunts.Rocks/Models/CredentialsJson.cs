

namespace Tunts.Rocks.Models
{
    public class CredentialsJson
    {
        public string ClientId { get; set; } = string.Empty;
        public string ProjectId { get; set; } = string.Empty;
        public string AuthUri { get; set; } = string.Empty;
        public string TokenUri { get; set; } = string.Empty;
        public string AuthProviderX509CertUrl { get; set; } = string.Empty;
        public string ClientSecret { get; set; } = string.Empty;
        public string[] RedirectUris { get; set; } = default!;
    }
}
