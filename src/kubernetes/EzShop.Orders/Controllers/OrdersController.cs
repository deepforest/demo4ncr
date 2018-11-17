using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;

namespace EzShop.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET api/account
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> Get(int id)
        {
            if (id <= 0)
                return BadRequest("id must be greater than zero.");

            var accountsServiceUri = Environment.GetEnvironmentVariable("ACCOUNTS_SERVICE_API_URI");
            if (string.IsNullOrEmpty(accountsServiceUri))
                accountsServiceUri = "http://ezshop.accounts/api";

            Console.WriteLine($"Accounts service URI {accountsServiceUri}");

            var accountsApi = RestService.For<IAccountsApi>(accountsServiceUri);
            var account = await accountsApi.GetAccount(id);
            
            Console.WriteLine($"Account id {account.Id} has buy limit of {account.BuyLimit}.");

            return new OrderDto
            {
                Pod = Environment.GetEnvironmentVariable("HOSTNAME"),
                OrderId = id,
                AccountId = 5
            };
        }
    }
}