using N3O.Umbraco.Extensions;
using N3O.Umbraco.Payments.Entities;
using N3O.Umbraco.Payments.Handlers;
using N3O.Umbraco.Payments.Opayo.Client;
using N3O.Umbraco.Payments.Opayo.Commands;
using N3O.Umbraco.Payments.Opayo.Extensions;
using N3O.Umbraco.Payments.Opayo.Models;
using System.Threading;
using System.Threading.Tasks;

namespace N3O.Umbraco.Payments.Opayo.Handlers {
    public class ThreeDSecureCredentialChallengeHandler :
        PaymentsHandler<ThreeDSecureCredentialChallengeCommand, ThreeDSecureChallengeReq, OpayoCredential> {
        private readonly IOpayoClient _opayoClient;

        public ThreeDSecureCredentialChallengeHandler(IPaymentsScope paymentsScope,
                                                      IOpayoClient opayoClient) : base(paymentsScope) {
            _opayoClient = opayoClient;
        }

        protected override async Task HandleAsync(ThreeDSecureCredentialChallengeCommand req,
                                                  OpayoCredential credential,
                                                  IBillingInfoAccessor billingInfoAccessor,
                                                  CancellationToken cancellationToken) {
            var payment = credential.AdvancePayment;
            var apiReq = new ApiThreeDSecureChallenge();
            apiReq.CRes = req.Model.CRes;
            apiReq.TransactionId = payment.TransactionId;

            var transaction = await _opayoClient.ThreeDSecureChallengeAsync(apiReq);

            if (transaction.IsAuthorised()) {
                payment.Paid(transaction.TransactionId, transaction.BankAuthorisationCode, transaction.RetrievalReference.GetValueOrThrow());
            } else if (transaction.IsDeclined()) {
                payment.Declined(transaction.StatusDetail);
            }

            payment.ThreeDSecureProcessCompleted();

            credential.UpdateAdvancePayment(payment);
        }
    }
}