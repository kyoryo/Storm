using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Storm")]
[assembly: AssemblyDescription("Modding API for Stardew Valley")]
[assembly: AssemblyInformationalVersion(AssemblyInfo.NICE_VERSION)]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("Storm")]
[assembly: AssemblyCopyright("Copyright © Storm 2016")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
[assembly: Guid(AssemblyInfo.GUID)]
[assembly: AssemblyVersion(AssemblyInfo.VERSION)]
[assembly: AssemblyFileVersion(AssemblyInfo.VERSION)]

internal static class AssemblyInfo
{
    public const string GUID = "3ae6190c-1cc7-4fa4-b859-5eabc8ec0614";
    public const string VERSION = "0.1.1";

    public const string NICE_VERSION = "Storm " + "v" + VERSION;
}