using Microsoft.AspNetCore.Mvc;
using SavanNah.DataAccess.Repositories.Payments;

namespace SavanNah.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var payments = await _paymentRepository.GetAll(null, ["User"]);
            return View(payments.ToList());
        }

        public async Task<IActionResult> GetPaymentsData()
        {
            var payments = await _paymentRepository.GetAll(null, ["User"]);
            var paymentData = payments.Select(payment => new
            {
                payment.Id,
                payment.UserId,
                User = new
                {
                    UserName = payment.User?.UserName
                },
                payment.OrderId,
                payment.PaymentDate
            });

            var options = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNamingPolicy = null
            };

            return Json(paymentData, options);
        }
    }
}
