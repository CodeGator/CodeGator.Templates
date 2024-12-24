
using CodeGator.Templates.Options;

namespace CodeGator.Templates;

/// <summary>
/// This class is a default implementation of the <see cref="ITemplateService"/>
/// interface.
/// </summary>
/// <param name="templateServiceOptions">The options to use with this service.</param>
/// <param name="logger">The logger to use with this service.</param>
internal sealed class TemplateService(
    IOptions<TemplateServiceOptions> templateServiceOptions,
    ILogger<TemplateService> logger
    ) : ITemplateService
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <inheritdoc/>
    public Task<string> TransformAsync(
        [NotNull] string template,
        [NotNull] IEnumerable<TemplateToken> tokens,
        CancellationToken cancellationToken = default
        )
    {
        Guard.Instance().ThrowIfNullOrEmpty(template, nameof(template))
            .ThrowIfNull(tokens, nameof(tokens));

        logger.LogDebug(
            "The '{t1}' service is transforming a template with '{t2}' " +
            "characters using '{t3}' replacement tokens",
            nameof(TemplateService),
            template.Length,
            tokens.Count()
            );

        var tokenDelimiter = templateServiceOptions.Value.TokenDelimiter.Trim();
        if (string.IsNullOrEmpty(tokenDelimiter))
        {
            tokenDelimiter  = "%%";
        }

        var sb = new StringBuilder(template);

        foreach (var token in tokens)
        {
            var tokenName = $"{tokenDelimiter}{token.Name}{tokenDelimiter}";

            sb.Replace(
                tokenName, 
                token.Value ?? ""
                );
        }

        var transformed = sb.ToString();
        return Task.FromResult(transformed);
    }

    #endregion

}
