namespace Domain.Ingenio.Dto
{
    using System;
    using System.Text.Json.Serialization;

    public class ResponseLoginDto
    {
        public ResponseLoginDto(int id, string userName, string token, string refreshToken)
        {
            this.Id= Id = Id;
            this.UserName = userName;
            Token = token;
            RefreshToken = refreshToken;
        }

        public int? Id { get; set; }
        
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UserName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Token { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string RefreshToken { get; set; }

        public double ElapsedMilliseconds { get; set; }
    }
}
