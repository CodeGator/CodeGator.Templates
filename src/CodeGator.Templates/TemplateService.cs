
using CodeGator.Templates.Options;

namespace CodeGator.Templates;

/// <summary>
/// This class is the default <see cref="ITemplateService"/> implementation.
/// </summary>
/// <remarks>
/// This constructor initializes a new instance of the <see cref="TemplateService"/>
/// class.
/// </remarks>
/// <param name="templateServiceOptions">Bound options for delimiter and related
/// settings.</param>
/// <param name="logger">Logger for diagnostic output from this service.</param>
internal sealed class TemplateService(
    IOptions<TemplateServiceOptions> templateServiceOptions,
    ILogger<TemplateService> logger
    ) : ITemplateService
{
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

}
