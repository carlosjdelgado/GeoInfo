using System.Reflection;
using System.Runtime.InteropServices;
using System.Web;
using Microsoft.Practices.Unity;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("GeoInfo")]
[assembly: AssemblyDescription("Powerful geo political data library")]
[assembly: AssemblyCompany("Carlos Jiménez Delgado [www.carlosjdelgado.com]")]
[assembly: AssemblyProduct("GeoInfo")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f8ef5b67-f477-4908-bba0-348747e89175")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
#if DEBUG
[assembly: AssemblyInformationalVersion("0.1.0-rc1")]
#else
[assembly: AssemblyInformationalVersion("0.1.0")]
#endif
[assembly: AssemblyVersion("0.1.0")]
[assembly: AssemblyFileVersion("0.1.0")]


[assembly: PreApplicationStartMethod(typeof(GeoInfo.Properties.Startup), "Start")]
namespace GeoInfo.Properties
{
    public class Startup
    {
        private static IUnityContainer _container;
        public static void Start()
        {
            _container = UnityConfig.SetDependencyResolverAndReturnContainer();
        }
    }
}