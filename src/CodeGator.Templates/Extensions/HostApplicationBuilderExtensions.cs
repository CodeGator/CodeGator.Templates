
#pragma warning disable IDE0130 // Namespace does not match folder structure
using CodeGator.Templates;
using CodeGator.Templates.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// This class adds <see cref="IHostApplicationBuilder"/> extension methods.
/// </summary>
public static partial class HostApplicationBuilderExtensions
{
    /// <summary>
    /// This method registers CodeGator template services with the host builder.
    /// </summary>
    /// <typeparam name="TBuilder">The concrete host application builder type.</typeparam>
    /// <param name="hostApplicationBuilder">The builder whose services are configured.</param>
    /// <param name="bootstrapLogger">Optional logger for registration diagnostics.</param>
    /// <returns>The same builder instance for fluent chaining.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown when <paramref name="hostApplicationBuilder"/> is null.
    /// </exception>
    public static TBuilder AddCodeGatorTemplates<TBuilder>(
        [NotNull] this TBuilder hostApplicationBuilder,
        [AllowNull] ILogger? bootstrapLogger = null
        ) where TBuilder : IHostApplicationBuilder
    {
        Guard.Instance().ThrowIfNull(hostApplicationBuilder, nameof(hostApplicationBuilder));

        bootstrapLogger?.LogDebug(
            "Registering the CodeGator template service options"
            );

        hostApplicationBuilder.Services.AddOptions<TemplateServiceOptions>()
            .BindConfiguration(TemplateServiceOptions.SectionPath)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        bootstrapLogger?.LogDebug(
            "Registering the CodeGator template services"
            );

        hostApplicationBuilder.Services.AddScoped<ITemplateService, TemplateService>();

        return hostApplicationBuilder;
    }
}
