namespace Api.GNB.Test.Controllers
{
    using Api.GNB.Controllers;
    using Core.GNB.Services;
    using Domain.GNB.Dto;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;

    public class TransactionControllerTests
    {
        [Fact]
        public async Task GetTransactionsTest()
        {
            var mockRepository = new Mock<ITransactionServices>();
            mockRepository.Setup(m => m.GetTransactionAsync()).ReturnsAsync(GetTransactionsResponse());
            var controller = new TransactionController(mockRepository.Object);
            var result = await controller.GetTransactions();
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<ResponseDto>(viewResult.Value);
            Assert.True(response.TotalRecords > 0);
        }

        [Fact]
        public async Task GetTransactionsBySkuTest()
        {
            var mockRepository = new Mock<ITransactionServices>();
            mockRepository.Setup(m => m.GetTransactionBySkuAsync("Q9218")).ReturnsAsync(GetTransactionsResponse("Q9218"));
            var controller = new TransactionController(mockRepository.Object);
            var result = await controller.GetTransactionBySku("Q9218");
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsAssignableFrom<ResponseDto>(viewResult.Value);
            int total = Convert.ToInt32(response.TotalRecords);
            Assert.Equal(3, total);
        }

        private ResponseDto GetTransactionsResponse()
        {
            DateTime startTime = DateTime.Now;
            IEnumerable<TransactionsDto> result = GetTestSessions();
            return new ResponseDto(result, ((DateTime.Now - startTime)).TotalMilliseconds);
        }

        private ResponseDto GetTransactionsResponse(string sku)
        {
            DateTime startTime = DateTime.Now;
            IEnumerable<TransactionsDto> result = GetTestSessions();
            var query = result.Where(x => x.Sku == sku);
            return new ResponseDto(query, query.Sum(m => m.Amount), query.Count(), ((DateTime.Now - startTime)).TotalMilliseconds);
        }

        private IEnumerable<TransactionsDto> GetTestSessions()
        {
            IList<TransactionsDto> transactions = new List<TransactionsDto>
            {
                new TransactionsDto()
                {
                    Sku ="Q9218",
                    Currency ="USD",
                    Amount = 17.2
                },
                new TransactionsDto()
                {
                    Sku ="J7278",
                    Currency ="AUD",
                    Amount = 24.2
                },
                new TransactionsDto()
                {
                    Sku ="Q7788",
                    Currency ="AUD",
                    Amount = 31.4
                },
                new TransactionsDto()
                {
                    Sku ="E5543",
                    Currency ="USD",
                    Amount = 17
                },
                new TransactionsDto()
                {
                    Sku ="G7931",
                    Currency ="EUR",
                    Amount = 23.8
                },
                new TransactionsDto()
                {
                    Sku ="Q9218",
                    Currency ="USD",
                    Amount = 28.3
                },
                new TransactionsDto()
                {
                    Sku ="G7931",
                    Currency ="USD",
                    Amount = 27.2
                },
                new TransactionsDto()
                {
                    Sku ="Q9218",
                    Currency ="USD",
                    Amount = 23.6
                },
                new TransactionsDto()
                {
                    Sku ="J7278",
                    Currency ="AUD",
                    Amount = 28.8
                },
                new TransactionsDto()
                {
                    Sku ="O1001",
                    Currency ="USD",
                    Amount = 22.8
                },
                new TransactionsDto()
                {
                    Sku ="H8690",
                    Currency ="EUR",
                    Amount = 18.9
                },
            };
            return transactions;
        }
    }
}
