using N3O.Umbraco.Payments.Entities;
using N3O.Umbraco.Payments.Handlers;
using N3O.Umbraco.Payments.Opayo.Commands;
using N3O.Umbraco.Payments.Opayo.Models;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Umbraco.Payments.Opayo.Handlers {
    public class GetPaymentHandler : PaymentsHandler<GetPaymentCommand, None, OpayoPayment> {
        public GetPaymentHandler(IPaymentsScope paymentsScope) : base(paymentsScope) { }

        protected override Task HandleAsync(GetPaymentCommand req, OpayoPayment paymentObject, IBillingInfoAccessor billingInfoAccessor, CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
}