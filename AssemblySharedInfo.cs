using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Retail")]
#endif
[assembly: AssemblyCompany("Just Think®")]
[assembly: AssemblyProduct("Pyton in Excel")]
[assembly: AssemblyCopyright("Copyright (c) 2011 Emiya. All rights reserved.")]
[assembly: AssemblyTrademark("pyExcel is a trademark of Just Think")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion("1.0.0.0")]

[assembly: ComVisible(false)]

[assembly: NeutralResourcesLanguage("en")]
