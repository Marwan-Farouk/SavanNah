using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SavanNah.Business.Managers.OrderManager;
using SavanNah.Business.Managers.ProductManager;
using SavanNah.Business.Managers.ShoppingCartManager;
using SavanNah.DataAccess.Repositories.Payments;
using SavanNah.Models.DTOs.Order;
using SavanNah.Models.Models.PaymentModel;
using Stripe.Checkout;
using System.Security.Claims;

namespace SavanNah.Presentation.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IShoppingCartManager _shoppingCartManager;
        private readonly IProductManager _productManager;
        public IPaymentRepository _paymentRepository;




        public PaymentController(IOrderManager orderManager, IShoppingCartManager shoppingCartManager, IProductManager productManager, IPaymentRepository paymentRepository)
        {
            this._orderManager = orderManager;
            _shoppingCartManager = shoppingCartManager;
            _productManager = productManager;
            _paymentRepository = paymentRepository;
        }
        private Guid GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            return Guid.Parse(claimsIdentity!.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        }
        [HttpPost]
        public async Task<IActionResult> StartPaymentSession()
        {
            // 1- Create Order
            var userId = GetUserId();

            var cartItems = await _shoppingCartManager.GetUserCart(userId);

            var products = await _productManager.GetAll(prod => cartItems.Select(item => item.Product.Id).Contains(prod.Id), null);


            var total = products.Sum(prod => (prod.Price - (prod.Price * (prod.Discount / 100))) * (cartItems.First(item => item.Product.Id == prod.Id).Count));

            var orderProducts = cartItems.Select(item => new CreateOrderProductDTO
            {
                ProductId = item.Product.Id,
                Count = item.Count
            });

            var orderDto = new CreateOrderDTO
            {
                UserId = userId,
                Products = products.ToList(),
                TotalAmount = total,
                OrderProducts = orderProducts.ToList(),
            };
            var created = await _orderManager.Create(orderDto);
            if (created is not null)
            {
                // 2- Create Session
                var orderProductList = created.OrderProducts.Select(op => _productManager.Get(prod => prod.Id == op.ProductId, null).Result).ToList();
                var lineItems = orderProductList.Select(prod => new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "egp",
                        UnitAmountDecimal = (prod.Price - (prod.Price * (prod.Discount / 100))) * 100,
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = prod.Name,
                            Description = prod.Description,

                        }
                    },
                    Quantity = created.OrderProducts.First(op => op.ProductId == prod.Id).Count
                }).ToList();

                var domain = $"https://localhost:7225";
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = ["card"],
                    LineItems = lineItems,
                    Mode = "payment",
                    SuccessUrl = $"{domain}/Payment/Success?sessionId={{CHECKOUT_SESSION_ID}}&orderId={created.Id}",
                    CancelUrl = $"{domain}/Cart/"
                };

                // 3- Start Session
                var service = new SessionService();
                Session session = await service.CreateAsync(options);
                Response.Headers.Append("Location", session.Url);
                return new StatusCodeResult(303);

            }
            TempData["error"] = "Failed to submit your order";
            return RedirectToAction("Index", "Cart");
        }

        [HttpGet]
        public async Task<IActionResult> Success(string sessionId, string orderId)
        {
            if (string.IsNullOrEmpty(sessionId) || string.IsNullOrEmpty(orderId))
            {
                return BadRequest();
            }

            var service = new SessionService();
            Session session = await service.GetAsync(sessionId);

            if (session.Status == "complete")
            {
                var order = await _orderManager.Get(o => o.Id == Guid.Parse(orderId));
                order.Status = "paid";
                var updated = _orderManager.Update(order);
                var payment = new Payment
                {
                    Id = Guid.NewGuid(),
                    OrderId = Guid.Parse(orderId),
                    UserId = GetUserId(),
                    PaymentDate = DateTime.Now,

                };
                var createdPayment = await _paymentRepository.Create(payment);
                await _orderManager.Save();
            }

            return RedirectToAction("Clear", "Cart");
        }
    }
}
