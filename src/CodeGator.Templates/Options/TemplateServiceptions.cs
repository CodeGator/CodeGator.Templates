
namespace CodeGator.Templates.Options;

/// <summary>
/// This class contains configuration settings for the <see cref="ITemplateService"/>
/// service.
/// </summary>
public class TemplateServiceOptions
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the path to these setting in the configuration.
    /// </summary>
    public const string SectionPath = "Services:Template";

    #endregion

    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the character(s) that delimit a template token.
    /// </summary>
    public string TokenDelimiter { get; set; } = "%%";

    #endregion
}
