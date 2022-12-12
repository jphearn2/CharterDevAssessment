namespace CustomerRewardsAPI.Models
{
    public sealed class CustomerRewards
    {
        public Guid CustomerId { get; set; }
        public int RewardPoints { get; set; }
    }
}
