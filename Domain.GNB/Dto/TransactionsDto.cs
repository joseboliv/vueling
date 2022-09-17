namespace Domain.GNB.Dto
{
    using Domain.GNB.Entity;
    using System;
    using Utilities.Helpers;

    public class TransactionsDto
    {
        public TransactionsDto()
        {

        }

        public TransactionsDto(string Sku, string Currency, double Amount)
        {
            this.Sku = Sku;
            this.Currency = Currency;
            this.Amount = Math.Round(Amount, 2);
        }

        public string Sku { get; set; }
        public string Currency { get; set; }
        public double Amount { get; set; }
        public static explicit operator TransactionEntity(TransactionsDto dto) => dto.Map(new TransactionEntity());
        public static explicit operator TransactionsDto(TransactionEntity entity) => entity.Map(new TransactionsDto());
    }
}
