using N3O.Umbraco.Payments.Commands;
using N3O.Umbraco.Payments.NamedParameters;
using N3O.Umbraco.Payments.Opayo.Models;

namespace N3O.Umbraco.Payments.Opayo.Commands {
    public class ThreeDSecureCredentialChallengeCommand : PaymentsCommand<ThreeDSecureChallengeReq, OpayoCredential> {
        public ThreeDSecureCredentialChallengeCommand(FlowId flowId) : base(flowId) { }
    }
}