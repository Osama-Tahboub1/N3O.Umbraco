using N3O.Umbraco.Payments.Lookups;

namespace N3O.Umbraco.Payments.Models {
    public abstract partial class Payment : PaymentObject {
        public string DeclineReason { get; protected set; }
        public bool IsDeclined { get; protected set; }
        public bool IsPaid { get; protected set; }
        public bool IsFailed { get; protected set; }
        public bool RequireThreeDSecure { get; protected set; }
        
        public override PaymentObjectType Type => PaymentObjectTypes.Payment;
    }
}