using Microsoft.AspNetCore.Mvc;

namespace Opayo.Payments.Controllers {
    public class HomeController : Controller {
        public IActionResult Index(string transactionId) {
            var model = new Model();
            model.TransactionId = transactionId;
            return View(model);
        }
    }

    public class Model {
        public string TransactionId { get; set; }
    }
}