using N3O.Umbraco.Payments.Entities;
using N3O.Umbraco.Payments.Handlers;
using N3O.Umbraco.Payments.Opayo.Commands;
using N3O.Umbraco.Payments.Opayo.Models;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Umbraco.Payments.Opayo.Handlers {
    public class GetCredentialHandler : PaymentsHandler<GetCredentialCommand, None, OpayoCredential> {
        public GetCredentialHandler(IPaymentsScope paymentsScope) : base(paymentsScope) { }

        protected override Task HandleAsync(GetCredentialCommand req, OpayoCredential paymentObject, IBillingInfoAccessor billingInfoAccessor, CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
}