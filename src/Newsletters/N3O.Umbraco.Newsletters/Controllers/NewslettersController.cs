using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N3O.Umbraco.Hosting;
using N3O.Umbraco.Newsletters.Models;
using System.Threading.Tasks;

namespace N3O.Umbraco.Newsletters.Controllers {
    public class NewslettersController : ApiController {
        private readonly INewslettersClient _client;

        public NewslettersController(ILogger logger, INewslettersClient client) : base(logger) {
            _client = client;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<SubscribeResult>> Subscribe(ContactReq req) {
            var result = await _client.SubscribeAsync(req);

            if (result.Subscribed) {
                return Ok(result);
            } else {
                return RequestFailed(result,
                                     l => l.LogError("Failed to subscribe {Req} due to error {Error}", req, result.ErrorDetails));
            }
        }
    }
}
