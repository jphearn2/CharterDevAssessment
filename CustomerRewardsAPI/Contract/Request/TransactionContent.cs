namespace CustomerRewardsAPI.Contract.Request
{
    public sealed class TransactionContent
    {
        public Guid CustomerId { get; set; }
        public int Amount { get; set; }
    }
}
