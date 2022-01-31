using Microsoft.AspNetCore.Mvc;
using N3O.Umbraco.Attributes;
using N3O.Umbraco.Lookups;
using N3O.Umbraco.Mediator;
using N3O.Umbraco.Payments.Controller;
using N3O.Umbraco.Payments.Models;
using N3O.Umbraco.Payments.Opayo.Commands;
using N3O.Umbraco.Payments.Opayo.Models;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Mapping;

namespace N3O.Umbraco.Payments.Opayo.Controllers {
    [ApiDocument(OpayoConstants.ApiName)]
    public class CredentialController : PaymentsController {
        private readonly IMediator _mediator;

        public CredentialController(IMediator mediator, ILookups lookups, IUmbracoMapper mapper)
            : base(lookups, mapper, mediator) {
            _mediator = mediator;
        }

        [HttpGet("credential")]
        public async Task<ActionResult<PaymentFlowRes<OpayoCredential>>> GetCredential() {
            var res = await _mediator.SendAsync<GetCredentialCommand, None, PaymentFlowRes<OpayoCredential>>(None.Empty);

            return Ok(res);
        }
        
        [HttpGet("payment")]
        public async Task<ActionResult<PaymentFlowRes<OpayoPayment>>> GetPayment() {
            var res = await _mediator.SendAsync<GetPaymentCommand, None, PaymentFlowRes<OpayoPayment>>(None.Empty);

            return Ok(res);
        }
    }
}