using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// This file contains common AssemblyVersion data to be shared across all projects in this solution.

[assembly: AssemblyCompany("Frank Refol")]
[assembly: AssemblyCopyright("©2020 Copyright Frank Refol. All rights reserved.")]
[assembly: AssemblyProduct("Relativity Script Viewer")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

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
[assembly: AssemblyVersion("$VERSION$")]
[assembly: AssemblyFileVersion("$VERSION$")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif