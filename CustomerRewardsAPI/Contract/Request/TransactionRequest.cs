namespace CustomerRewardsAPI.Contract.Request
{
    public sealed class TransactionRequest
    {
        public Guid CustomerId { get; set; }
        public int Ammount { get; set; }
    }
}
