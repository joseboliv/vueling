using Core.GNB.Services;
using Data.GNB.Repositories;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Threading.Tasks;
using Utilities.Http;
using Utilities.Logger;
using Xunit;

namespace Core.GNB.Test.Services
{
    public class TransactionServicesTests
    {
        private MockRepository mockRepository;

        private Mock<IHttpClientServices> mockHttpClientServices;
        private Mock<ITransactionRepository> mockTransactionRepository;
        private Mock<IConfiguration> mockConfiguration;
        private Mock<IRateServices> mockRateServices;
        private Mock<ILoggerGNB<TransactionServices>> mockLoggerGNB;

        public TransactionServicesTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockHttpClientServices = this.mockRepository.Create<IHttpClientServices>();
            this.mockTransactionRepository = this.mockRepository.Create<ITransactionRepository>();
            this.mockConfiguration = this.mockRepository.Create<IConfiguration>();
            this.mockRateServices = this.mockRepository.Create<IRateServices>();
            this.mockLoggerGNB = this.mockRepository.Create<ILoggerGNB<TransactionServices>>();
        }

        private TransactionServices CreateTransactionServices()
        {
            return new TransactionServices(
                this.mockHttpClientServices.Object,
                this.mockTransactionRepository.Object,
                this.mockConfiguration.Object,
                this.mockRateServices.Object,
                this.mockLoggerGNB.Object);
        }

        [Fact]
        public async Task GetTransactionAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transactionServices = this.CreateTransactionServices();

            // Act
            var result = await transactionServices.GetTransactionAsync();

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetTransactionBySkuAsync_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var transactionServices = this.CreateTransactionServices();
            string sku = null;

            // Act
            var result = await transactionServices.GetTransactionBySkuAsync(
                sku);

            // Assert
            Assert.True(false);
            this.mockRepository.VerifyAll();
        }
    }
}
