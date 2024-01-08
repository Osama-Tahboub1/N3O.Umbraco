using Microsoft.Extensions.DependencyInjection;
using N3O.Umbraco.Attributes;
using N3O.Umbraco.Utilities;
using NJsonSchema.Generation;
using NSwag.Generation.AspNetCore;
using NSwag.Generation.Processors;
using System;
using System.Linq;
using System.Reflection;

namespace N3O.Umbraco.Extensions;

public static class ServiceCollectionExtensions {
    public static IServiceCollection AddOpenApiDocument(this IServiceCollection services, string name) {
        if (OpenApi.IsEnabled()) {
            services.AddOpenApiDocument(opt => {
                opt.Title = name;
                opt.DocumentName = name;
                opt.SchemaSettings.FlattenInheritanceHierarchy  = true;

                AddSchemaProcessors(opt);
                AddOperationProcessors(opt);
                AddOperationFilters(opt, name);
            });
        }

        return services;
    }
    
    private static void AddSchemaProcessors(AspNetCoreOpenApiDocumentGeneratorSettings opt) {
        var schemaProcessors = OurAssemblies.GetTypes(t => t.IsConcreteClass() &&
                                                           t.ImplementsInterface<ISchemaProcessor>() &&
                                                           t.HasParameterlessConstructor())
                                            .Select(t => (ISchemaProcessor) Activator.CreateInstance(t))
                                            .ToList();
        
        schemaProcessors.Do(opt.SchemaSettings.SchemaProcessors.Add);
    }
    
    private static void AddOperationProcessors(AspNetCoreOpenApiDocumentGeneratorSettings opt) {
        var operationProcessors = OurAssemblies.GetTypes(t => t.IsConcreteClass() &&
                                                           t.ImplementsInterface<IOperationProcessor>() &&
                                                           t.HasParameterlessConstructor())
                                            .Select(t => (IOperationProcessor) Activator.CreateInstance(t))
                                            .ToList();
        
        operationProcessors.Do(opt.OperationProcessors.Add);
    }

    private static void AddOperationFilters(AspNetCoreOpenApiDocumentGeneratorSettings opt, string name) {
        opt.AddOperationFilter(ctx => {
            if (name.EqualsInvariant(ctx.ControllerType.GetCustomAttribute<ApiDocumentAttribute>()?.ApiName)) {
                return true;
            } else {
                return false;
            }
        });
    }
}
