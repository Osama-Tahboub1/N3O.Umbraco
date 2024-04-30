using N3O.Umbraco.Exceptions;
using Stripe;

namespace N3O.Umbraco.Payments.Stripe.Models;

public partial class StripePayment {
    private void IntentUpdated(PaymentIntent paymentIntent) {
        ClearErrors();

        if (paymentIntent.Status == "succeeded") {
            Paid(paymentIntent.LatestChargeId);
        } else if (paymentIntent.Status == "requires_action") {
            ActionRequired = true;
        } else {
            throw UnrecognisedValueException.For(paymentIntent.Status);
        }
    }
}
