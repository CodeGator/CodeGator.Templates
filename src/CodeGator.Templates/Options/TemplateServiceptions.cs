
namespace CodeGator.Templates.Options;

/// <summary>
/// This class holds configuration for <see cref="ITemplateService"/>.
/// </summary>
public class TemplateServiceOptions
{
    /// <summary>
    /// The configuration section path for binding <see cref="TemplateServiceOptions"/>.
    /// </summary>
    public const string SectionPath = "Services:Template";

    /// <summary>
    /// This property defines the delimiter that wraps token names in templates.
    /// </summary>
    public string TokenDelimiter { get; set; } = "%%";
}
