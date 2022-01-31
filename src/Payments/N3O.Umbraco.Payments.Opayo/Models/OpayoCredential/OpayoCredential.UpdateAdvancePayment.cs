using N3O.Umbraco.Payments.Lookups;

namespace N3O.Umbraco.Payments.Opayo.Models {
    public partial class OpayoCredential {
        public void UpdateAdvancePayment(OpayoPayment payment) {
            AdvancePayment = payment;

            UpdateStatus();
        }

        private void UpdateStatus() {
            if (AdvancePayment.RequireThreeDSecure) {
                if (!AdvancePayment.ThreeDSecureCompleted) {
                    Status = PaymentObjectStatuses.InProgress;
                } else if (AdvancePayment.IsPaid) {
                    Status = PaymentObjectStatuses.Complete;
                } else {
                    Status = PaymentObjectStatuses.Failed;
                }
            } else if (AdvancePayment.IsPaid) {
                Status = PaymentObjectStatuses.Complete;
            } else {
                Status = PaymentObjectStatuses.Failed;
            } 
        }
    }
}