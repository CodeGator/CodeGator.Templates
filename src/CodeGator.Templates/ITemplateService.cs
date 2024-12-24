
namespace CodeGator.Templates;

/// <summary>
/// This interface represents an object that transforms data using a template.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// This method transforms the given template text using zero or more
    /// replacement tokens.
    /// </summary>
    /// <param name="template">The template to use for the operation.</param>
    /// <param name="tokens">The collection of replacement tokens to use
    /// for the operation.</param>
    /// <param name="cancellationToken">A cancellation token that is monitored
    /// for a cancellation request throughout the lifetime of the method.</param>
    /// <returns>The transformed template, with tokens replaced by values.</returns>
    Task<string> TransformAsync(
        [NotNull] string template,
        [NotNull] IEnumerable<TemplateToken> tokens,
        CancellationToken cancellationToken = default 
        );
}
