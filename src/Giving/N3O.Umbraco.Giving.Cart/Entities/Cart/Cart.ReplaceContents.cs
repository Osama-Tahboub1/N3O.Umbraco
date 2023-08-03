using N3O.Umbraco.Content;
using N3O.Umbraco.Exceptions;
using N3O.Umbraco.Extensions;
using N3O.Umbraco.Forex;
using N3O.Umbraco.Giving.Cart.Extensions;
using N3O.Umbraco.Giving.Lookups;
using N3O.Umbraco.Giving.Cart.Models;
using N3O.Umbraco.Giving.Content;
using N3O.Umbraco.Giving.Extensions;
using N3O.Umbraco.Giving.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N3O.Umbraco.Giving.Cart.Entities;

public partial class Cart {
    private async Task ReplaceContentsAsync(IContentLocator contentLocator,
                                            IForexConverter forexConverter,
                                            IPriceCalculator priceCalculator,
                                            GivingType givingType,
                                            Func<CartContents, CartContents> replace) {
        if (givingType == GivingTypes.Donation) {
            Donation = await UpdateUpsellAmountsAsync(contentLocator,
                                                      forexConverter,
                                                      priceCalculator,
                                                      replace(Donation));
        } else if (givingType == GivingTypes.RegularGiving) {
            RegularGiving = await UpdateUpsellAmountsAsync(contentLocator,
                                                           forexConverter,
                                                           priceCalculator,
                                                           replace(RegularGiving));
        } else {
            throw UnrecognisedValueException.For(givingType);
        }
    }

    private async Task<CartContents> UpdateUpsellAmountsAsync(IContentLocator contentLocator,
                                                              IForexConverter forexConverter,
                                                              IPriceCalculator priceCalculator,
                                                              CartContents cartContents) {
        if (cartContents.Allocations.None(x => x.UpsellId.HasValue())) {
            return cartContents;
        }

        var allocations = new List<Allocation>();
        
        foreach (var allocation in cartContents.Allocations) {
            if (allocation.UpsellId.HasValue()) {
                var upsellContent = contentLocator.ById<UpsellContent>(allocation.UpsellId.GetValueOrThrow());
                
                var newUpsellAllocation = await upsellContent.ToAllocationAsync(forexConverter,
                                                                                priceCalculator,
                                                                                Currency,
                                                                                allocation.Value.Amount,
                                                                                cartContents.Type,
                                                                                cartContents.Allocations.GetTotalExcludingUpsells(Currency));

                if (newUpsellAllocation.Value == allocation.Value) {
                    allocations.Add(allocation);
                } else {
                    allocations.Add(newUpsellAllocation);
                }
            } else {
                allocations.Add(allocation);
            }
        }

        return new CartContents(Currency, cartContents.Type, allocations);
    }
}
