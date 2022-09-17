using Core.GNB.Services;
using Data.GNB.Repositories;
using Domain.GNB.Dto;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Http;
using Utilities.Logger;
using Xunit;

namespace Core.GNB.Test.Services
{
    public class RateServicesTests
    {
        private MockRepository mockRepository;

        private Mock<IHttpClientServices> mockHttpClientServices;
        private Mock<IRateRepository> mockRateRepository;
        private Mock<ILoggerGNB<RateServices>> mockLoggerGNB;

        public RateServicesTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockHttpClientServices = this.mockRepository.Create<IHttpClientServices>();
            this.mockRateRepository = this.mockRepository.Create<IRateRepository>();
            this.mockLoggerGNB = this.mockRepository.Create<ILoggerGNB<RateServices>>();
        }

        private RateServices CreateRateServices()
        {
            return new RateServices(
                this.mockHttpClientServices.Object,
                this.mockRateRepository.Object,
                this.mockLoggerGNB.Object);
        }

        [Fact]
        public async Task GetRatesTest()
        {
            var mockServices = new Mock<IHttpClientServices>();
            var mockRepository = new Mock<IRateRepository>();
            var mockLogger = new Mock<ILoggerGNB<RateServices>>();
            mockServices.Setup(m => m.GetUnAuthAsync<IEnumerable<RatesDto>>("/Rates")).ReturnsAsync(GetTestSessions());
            var services = new RateServices(mockServices.Object, mockRepository.Object, mockLogger.Object);
            var query = services.GetRatesFromDb();
            var result = await services.GetRatesAsync();
            Assert.True(result.Any());
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
