namespace ContactManagementSolution.Shared.Constants;

using System.Text.RegularExpressions;

public static partial class Constants
{
    [GeneratedRegex(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$")]
    public static partial Regex ValidPhoneNumber();
}