
namespace CodeGator.Templates;

/// <summary>
/// This interface represents an object that transforms data using a template.
/// </summary>
public interface ITemplateService
{
    /// <summary>
    /// This method replaces template token placeholders with supplied values.
    /// </summary>
    /// <param name="template">The template text containing tokens to replace.</param>
    /// <param name="tokens">Replacement tokens (name and value pairs).</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The template after substitutions.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="template"/> is null or empty, or
    /// <paramref name="tokens"/> is null.
    /// </exception>
    Task<string> TransformAsync(
        [NotNull] string template,
        [NotNull] IEnumerable<TemplateToken> tokens,
        CancellationToken cancellationToken = default 
        );
}
