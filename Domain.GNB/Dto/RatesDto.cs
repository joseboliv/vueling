namespace Domain.GNB.Dto
{
    using Domain.GNB.Entity;
    using Utilities.Helpers;

    public class RatesDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Rate { get; set; }

        public static explicit operator RateEntity(RatesDto dto) => dto.Map(new RateEntity());
        public static explicit operator RatesDto(RateEntity dto) => dto.Map(new RatesDto());
    }
}
