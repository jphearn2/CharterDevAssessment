using CustomerRewardsAPI.Contract.Request;
using CustomerRewardsAPI.Models;

namespace CustomerRewardsAPI.Business
{
    public sealed class RewardsTransactionProcessor
    {
        public Dictionary<Guid, int> _rewards = new Dictionary<Guid, int>();

        public RewardsTransactionProcessor() { }

        public CustomerRewards AddTransaction(Guid customerId, int amount)
        {
            int rewardPoints = CalculateRewardsPoints(amount);

            if(_rewards.ContainsKey(customerId) )
            {
                _rewards[customerId] += rewardPoints;
            }
            else
            {
                _rewards.Add(customerId, rewardPoints);
            }

            return new CustomerRewards()
            {
                CustomerId = customerId,
                RewardPoints = _rewards[customerId]
            };
        }

        public IEnumerable<CustomerRewards> AddBulkTransactions(IEnumerable<TransactionContent> transactions)
        {
            List<Guid> customerIds = new List<Guid>();
            foreach (TransactionContent transaction in transactions)
            {
                if(!customerIds.Contains(transaction.CustomerId))
                {
                    customerIds.Add(transaction.CustomerId);
                }

                int rewardPoints = CalculateRewardsPoints(transaction.Amount);

                if (_rewards.ContainsKey(transaction.CustomerId))
                {
                    _rewards[transaction.CustomerId] += rewardPoints;
                }
                else
                {
                    _rewards.Add(transaction.CustomerId, rewardPoints);
                }
            }

            return _rewards.Where(x => customerIds.Contains(x.Key))
                .Select(x => new CustomerRewards()
                {
                    CustomerId = x.Key,
                    RewardPoints = x.Value
                });
        }

        public IEnumerable<CustomerRewards> GetAllCustomerRewards()
        {
            return _rewards.Select(x => new CustomerRewards()
            {
                CustomerId = x.Key,
                RewardPoints = x.Value
            });
        }

        #region Private Methods

        private int CalculateRewardsPoints(int amount)
        {
            int rewardPoints = 0;

            if (amount > 100)
            {
                rewardPoints += (amount - 100) * 2;
                amount = 100;
            }
            if (amount > 50)
            {
                rewardPoints += (amount - 50);
            }

            return rewardPoints;
        }

        #endregion
    }
}
