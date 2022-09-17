namespace Domain.GNB.Dto
{
    using System;
    using System.Text.Json.Serialization;

    public class ResponseDto
    {
        public ResponseDto(object Result, double ElapsedMilliseconds)
        {
            this.Result = Result;
            this.ElapsedMilliseconds = ElapsedMilliseconds;
        }

        public ResponseDto(object Result, double TotalAmount, int TotalRecords, double ElapsedMilliseconds)
        {
            this.Result = Result;
            this.TotalAmount = Math.Round(TotalAmount, 2);
            this.TotalRecords = TotalRecords;
            this.ElapsedMilliseconds = ElapsedMilliseconds;
        }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object Result { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TotalAmount { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TotalRecords { get; set; }
        public double ElapsedMilliseconds { get; set; }
    }
}
