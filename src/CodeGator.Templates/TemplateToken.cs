
namespace CodeGator.Templates;

/// <summary>
/// This class models a single named token and its replacement text.
/// </summary>
public class TemplateToken
{
    /// <summary>
    /// This property holds the token name between delimiter pairs in the template.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// This property holds the text inserted for the token, or null for empty.
    /// </summary>
    public string? Value { get; set; }
}
