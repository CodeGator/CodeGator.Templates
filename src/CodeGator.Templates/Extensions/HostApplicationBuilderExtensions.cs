
#pragma warning disable IDE0130 // Namespace does not match folder structure
using CodeGator.Templates;
using CodeGator.Templates.Options;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.Extensions.Hosting;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// This class utility contains extension methods for the <see cref="IHostApplicationBuilder"/> 
/// interface.
/// </summary>
public static partial class HostApplicationBuilderExtensions
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This methods add the abstractions required to support the CodeGator
    /// template service to the specified <see cref="IHostApplicationBuilder"/>   
    /// </summary>
    /// <typeparam name="TBuilder">The type of associated host builder.</typeparam>
    /// <param name="hostApplicationBuilder">The host application builder to 
    /// use for the operation.</param>
    /// <param name="bootstrapLogger">An optional bootstrap logger to use 
    /// for the operation.</param>
    /// <returns>The value of the <paramref name="hostApplicationBuilder"/> parameter,
    /// for chaining method calls together, Fluent style.</returns>
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

    #endregion
}
