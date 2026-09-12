using SavanNah.DataAccess.Contexts;
using SavanNah.DataAccess.Repositories.Generic;
using SavanNah.Models.Models.PaymentModel;

namespace SavanNah.DataAccess.Repositories.Payments
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
