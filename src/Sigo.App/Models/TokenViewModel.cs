using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sigo.Models
{
    public class ResponseViewModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public TokenViewModel Data { get; set; }
    }

    public class TokenViewModel
    {
        [JsonProperty("accessToken")]
        public string AccessToken { get; set; }

        [JsonProperty("expiresIn")]
        public double ExpiresIn { get; set; }

        [JsonProperty("userToken")]
        public UserTokenViewModel UserToken { get; set; }
    }

    public class UserTokenViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("claims")]
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }

    public class ClaimViewModel
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
