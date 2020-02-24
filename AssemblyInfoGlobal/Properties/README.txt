PM-8856 Create a global assembly version information file to hold common assembly properties

This folder contains global assembly files that are referenced from projects. The following assembly information are defined in this file:

AssemblyConfiguration
AssemblyCompany
AssemblyCopyRight
AssemblyTrademark
AssemblyCulture
AssemblyVersion
AssemblyFileVersion

To reference this file in a project, perform the following:

1. Click on the Properties folder of the project to add the link to.
2. Select Project > Add Existing Item from the Visual Studio menu.
3. Traverse and select to the AssemblyInfoGlobal\Properties\AssemblyInfo.Global.cs (or AssemblyInfoGlobal\Properties\AssemblyInfo.Global.vb) file
4. Click on the Add button to reveal the Add As Link option.
5. Move the AssemblyInfo.Global.cs link into the project's Properties folder.

Note that there is a file for C# and VB.