using System.Reflection;
[assembly: AssemblyVersion(_ThisAssemblyVersionInfo.BaseVersion)]
[assembly: AssemblyFileVersion(_ThisAssemblyVersionInfo.VersionNumber)]
[assembly: AssemblyInformationalVersion(_ThisAssemblyVersionInfo.VersionNumber + " ($REVID$)")]

[assembly: AssemblyCompany(_ThisAssemblyVersionInfo.CompanyName)]
[assembly: AssemblyCopyright("\xA9 " + _ThisAssemblyVersionInfo.CopyrightYear + " " + _ThisAssemblyVersionInfo.CompanyName)]

internal static class _ThisAssemblyVersionInfo
{
    public const string BaseVersion = "1.0";
    public const string VersionNumber = BaseVersion + ".$REVNUM$.$DIRTY$";
    public const string CompanyName = "Xamasoft";
    public const string CopyrightYear = "2013";
}
