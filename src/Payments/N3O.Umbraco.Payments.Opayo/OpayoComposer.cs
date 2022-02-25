﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using N3O.Umbraco.Composing;
using N3O.Umbraco.Content;
using N3O.Umbraco.Extensions;
using N3O.Umbraco.Payments.Opayo.Client;
using N3O.Umbraco.Payments.Opayo.Content;
using N3O.Umbraco.Payments.Opayo.Extensions;
using N3O.Umbraco.Payments.Opayo.Models;
using Refit;
using Umbraco.Cms.Core.DependencyInjection;

namespace N3O.Umbraco.Payments.Opayo {
    public class OpayoComposer : Composer {
        public override void Compose(IUmbracoBuilder builder) {
            builder.Services.AddOpenApiDocument(OpayoConstants.ApiName);
           
            builder.Services.AddSingleton<OpayoApiSettings>(serviceProvider => {
                var contentCache = serviceProvider.GetRequiredService<IContentCache>();
                var webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();
                var settings = contentCache.Single<OpayoSettingsContent>();
                OpayoApiSettings apiSettings = null;
                
                if (settings != null) {
                    if (webHostEnvironment.IsProduction()) {
                        apiSettings =  settings.GetProductionSettings();
                    } else {
                        apiSettings = settings.GetSandboxSettings();
                    }
                }

                return apiSettings;
            });

            builder.Services.AddTransient<IOpayoClient>(serviceProvider => {
                var apiSettings = serviceProvider.GetRequiredService<OpayoApiSettings>();
                IOpayoClient client = null;

                if (apiSettings != null) {
                    var refitSettings = new RefitSettings();
                    refitSettings.ContentSerializer = new NewtonsoftJsonContentSerializer();

                    refitSettings.HttpMessageHandlerFactory =
                        () => new CredentialsAuthorizationHandler(apiSettings.IntegrationKey,
                                                                  apiSettings.IntegrationPassword);

                    client = RestService.For<IOpayoClient>(apiSettings.BaseUrl, refitSettings);
                }
                
                return client;
            });

            builder.Services.AddTransient<IChargeService, ChargeService>();
        }
    }
}