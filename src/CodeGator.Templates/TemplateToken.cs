
namespace CodeGator.Templates;

/// <summary>
/// This class represents a replaceable template token.
/// </summary>
public class TemplateToken
{
    // *******************************************************************
    // Properties.
    // *******************************************************************

    #region Properties

    /// <summary>
    /// This property contains the name for the token.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// This property contains the replacement value for the token.
    /// </summary>
    public string? Value { get; set; }

    #endregion
}
