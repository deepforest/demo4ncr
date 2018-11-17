using System.Threading.Tasks;
using Refit;

namespace EzShop.Orders.Controllers
{
    public class AccountDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal BuyLimit { get; set; }
    }

    public interface IAccountsApi
    {
        [Get("/accounts/{id}")]
        Task<AccountDto> GetAccount(int id);
    }
}
