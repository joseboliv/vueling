using System.Text.Json.Serialization;

namespace Api.Ingeneo
{
    public class JwtTokenConfig
    {
        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        [JsonPropertyName("issuer")]
        public string Issuer { get; set; }

        [JsonPropertyName("audience")]
        public string Audience { get; set; }

        [JsonPropertyName("accessTokenExpiration")]
        public int AccessTokenExpiration { get; set; }

        [JsonPropertyName("refreshTokenExpiration")]
        public int RefreshTokenExpiration { get; set; }

        [JsonPropertyName("CodigoEmpresa")]
        public int CodigoEmpresa { get; set; }

        [JsonPropertyName("Ejercicio")]
        public string Ejercicio { get; set; }
    }
}
