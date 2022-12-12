using CustomerRewardsAPI.Business;
using CustomerRewardsAPI.Contract.Request;
using CustomerRewardsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRewardsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RewardsController : ControllerBase
    {
        private readonly ILogger<RewardsController> _logger;
        private readonly RewardsTransactionProcessor _processor;

        public RewardsController(ILogger<RewardsController> logger, RewardsTransactionProcessor processor)
        {
            _logger = logger;
            _processor = processor;
        }

        [HttpPost("transaction")]
        public ActionResult AddTransaction([FromBody] TransactionRequest request)
        {
            CustomerRewards response = _processor.AddTransaction(request.CustomerId, request.Ammount);

            return Ok(response);
        }

        [HttpPost("bulk-transactions")]
        public ActionResult AddBulkTransaction([FromBody] BulkTransactionRequest request)
        {
            IEnumerable<CustomerRewards> response = _processor.AddBulkTransactions(request.Transactions);

            return Ok(response);
        }

        [HttpGet("all-customers")]
        public ActionResult GetAllCustomerRewards()
        {
            IEnumerable<CustomerRewards> response = _processor.GetAllCustomerRewards();

            return Ok(response);
        }
    }
}