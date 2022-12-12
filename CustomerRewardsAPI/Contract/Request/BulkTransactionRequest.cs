namespace CustomerRewardsAPI.Contract.Request
{
    public class BulkTransactionRequest
    {
        public IEnumerable<TransactionContent> Transactions { get; set; } = Enumerable.Empty<TransactionContent>();
    }
}
