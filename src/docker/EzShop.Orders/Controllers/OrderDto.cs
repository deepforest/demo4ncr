namespace EzShop.Orders.Controllers
{
    public class OrderDto
    {
        public string Pod { get; internal set; }
        public int OrderId { get; set; }
        public int AccountId { get; internal set; }
    }
}
