using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.Extensions.Logging;
using N3O.Umbraco.Content;
using N3O.Umbraco.Giving.Checkout.Lookups;
using N3O.Umbraco.Pages;
using System;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;

namespace N3O.Umbraco.Giving.Checkout.Controllers;

public class CheckoutRegularGivingPageController : CheckoutStagePageController {
    public CheckoutRegularGivingPageController(ILogger<CheckoutRegularGivingPageController> logger,
                                               ICompositeViewEngine compositeViewEngine,
                                               IUmbracoContextAccessor umbracoContextAccessor,
                                               IPublishedUrlProvider publishedUrlProvider,
                                               IPagePipeline pagePipeline,
                                               IContentCache contentCache,
                                               IServiceProvider serviceProvider,
                                               ICheckoutAccessor checkoutAccessor)
        : base(logger,
               compositeViewEngine,
               umbracoContextAccessor,
               publishedUrlProvider,
               pagePipeline,
               contentCache,
               serviceProvider,
               checkoutAccessor) { }

    protected override CheckoutStage Stage => CheckoutStages.RegularGiving;
}
