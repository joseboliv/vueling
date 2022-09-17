using System.Collections.Generic;

namespace Domain.GNB.Dto
{
    public class ReceiveDto
    {
        public IEnumerable<TransactionsDto> Result { get; set; }
    }
}
