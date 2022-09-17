namespace Api.GNB.Test.Controllers
{
    using Api.GNB.Controllers;
    using Core.GNB.Services;
    using Domain.GNB.Dto;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class RateControllerTests
    {
        [Fact]
        public async Task GetRatesTest()
        {
            var mockRepository = new Mock<IRateServices>();
            mockRepository.Setup(m => m.GetRatesAsync()).ReturnsAsync(GetTestSessions());
            var controller = new RateController(mockRepository.Object);
            var result = await controller.GetRates();
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<IEnumerable<RatesDto>>(viewResult.Value);
            Assert.Equal(6, response.Count());
        }

        private IEnumerable<RatesDto> GetTestSessions()
        {
            IList<RatesDto> rates = new List<RatesDto>
            {
                new RatesDto()
                {
                    From = "AUD",
                    To = "USD",
                    Rate = 0.76
                },
                new RatesDto()
                {
                    From = "USD",
                    To = "AUD",
                    Rate = 1.31
                },
                new RatesDto()
                {
                    From = "EUR",
                    To = "CAD",
                    Rate = 1.59
                },
                new RatesDto()
                {
                    From = "CAD",
                    To = "EUR",
                    Rate = 0.63
                },
                new RatesDto()
                {
                    From = "USD",
                    To = "CAD",
                    Rate = 1.59
                },
                new RatesDto()
                {
                    From = "CAD",
                    To = "USD",
                    Rate = 0.63
                },
            };
            return rates;
        }
    }
}
