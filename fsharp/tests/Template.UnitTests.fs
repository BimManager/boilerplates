<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
    <OutputType>Library</OutputType>
    <AssemblyName>Template.UnitTests</AssemblyName>
    <OutputPath>bin\Debug</OutputPath>
    <PlatformTarget>x64</PlatformTarget>
    <DebugSymbols>True</DebugSymbols>
    <DebugType>Full</DebugType>
    <Optimize>False</Optimize>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="NUnit" Version="3.13.2" />
    <PackageReference Include="NUnit.ConsoleRunner" Version="3.15.0"
                      GeneratePathProperty="true" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="../src/Template.fsproj" />
  </ItemGroup>
  
  <ItemGroup>
    <Reference Include="FSharp.Core"
               HintPath="C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\FSharp\FSharp.Core.dll" />
  </ItemGroup>

  <ItemGroup>
    <Compile Include="Ex00Tests.fs" />
  </ItemGroup>

  <Target Name="ShowMessage">
    <Message Text="$(Win)" />
  </Target>

  <Target Name="RunTests" AfterTargets="Build" >
    <Exec Command="$(PkgNUnit_ConsoleRunner)\tools\nunit3-console.exe $(OutputPath)$(AssemblyName).dll" />
  </Target>

  <ItemGroup>
    <Logs Include="$(ProjectDir)*.log" />
    <TestResult Include="$(ProjectDir)TestResult.xml" />
  </ItemGroup>

  <Target Name="DeleteResult" AfterTargets="Build">
    <Delete Files="@(TestResult)" />
  </Target>

  <Target Name="DeleteLogs" AfterTargets="Build">
    <Delete Files="@(Logs)" />
  </Target>
  
  <Import Project="$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v$(VisualStudioVersion)\FSharp\Microsoft.FSharp.targets" />
</Project>
