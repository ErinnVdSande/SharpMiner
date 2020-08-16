﻿<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="12.0" DefaultTargets="Build" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <Configuration Condition=" '$(Configuration)' == '' ">Debug</Configuration>
    <Platform Condition=" '$(Platform)' == '' ">AnyCPU</Platform>
    <ProjectGuid>{F512620C-C953-4993-B698-13539F8F9366}</ProjectGuid>
    <OutputType>Library</OutputType>
    <AppDesignerFolder>Properties</AppDesignerFolder>
    <RootNamespace>AlgorithmsTests</RootNamespace>
    <AssemblyName>AlgorithmsTests</AssemblyName>
    <TargetFrameworkVersion>v4.5</TargetFrameworkVersion>
    <FileAlignment>512</FileAlignment>
    <ProjectTypeGuids>{3AC096D0-A1C2-E12C-1390-A8335801FDAB};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>
    <VisualStudioVersion Condition="'$(VisualStudioVersion)' == ''">10.0</VisualStudioVersion>
    <VSToolsPath Condition="'$(VSToolsPath)' == ''">$(MSBuildExtensionsPath32)\Microsoft\VisualStudio\v$(VisualStudioVersion)</VSToolsPath>
    <ReferencePath>$(ProgramFiles)\Common Files\microsoft shared\VSTT\$(VisualStudioVersion)\UITestExtensionPackages</ReferencePath>
    <IsCodedUITest>False</IsCodedUITest>
    <TestProjectType>UnitTest</TestProjectType>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
    <DebugSymbols>true</DebugSymbols>
    <DebugType>full</DebugType>
    <Optimize>false</Optimize>
    <OutputPath>bin\Debug\</OutputPath>
    <DefineConstants>DEBUG;TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ">
    <DebugType>pdbonly</DebugType>
    <Optimize>true</Optimize>
    <OutputPath>bin\Release\</OutputPath>
    <DefineConstants>TRACE</DefineConstants>
    <ErrorReport>prompt</ErrorReport>
    <WarningLevel>4</WarningLevel>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="nunit.framework, Version=2.6.2.12296, Culture=neutral, PublicKeyToken=96d09a1eb7f44a77, processorArchitecture=MSIL">
      <SpecificVersion>False</SpecificVersion>
      <HintPath>..\packages\NUnit.2.6.2\lib\nunit.framework.dll</HintPath>
    </Reference>
    <Reference Include="System" />
  </ItemGroup>
  <Choose>
    <When Condition="('$(VisualStudioVersion)' == '10.0' or '$(VisualStudioVersion)' == '') and '$(TargetFrameworkVersion)' == 'v3.5'">
      <ItemGroup>
        <Reference Include="Microsoft.VisualStudio.QualityTools.UnitTestFramework, Version=10.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL" />
      </ItemGroup>
    </When>
    <Otherwise />
  </Choose>
  <ItemGroup>
    <Compile Include="Properties\AssemblyInfo.cs" />
    <Compile Include="Sorting\BubbleSorterTests.cs" />
    <Compile Include="Sorting\BucketSorterTests.cs" />
    <Compile Include="Sorting\CombSorterTests.cs" />
    <Compile Include="Sorting\CountingSorterTests.cs" />
    <Compile Include="Sorting\CycleSorterTests.cs" />
    <Compile Include="Sorting\ValuesProvider\ISortingValuesProvider.cs" />
    <Compile Include="Sorting\AllSortTests.cs" />
    <Compile Include="Sorting\ValuesProvider\SortingStringValuesProvider.cs" />
    <Compile Include="Sorting\ValuesProvider\SortingIntValuesProvider.cs" />
    <Compile Include="Sorting\ValuesProvider\SortingValuesProvider.cs" />
  </ItemGroup>
  <ItemGroup>
    <None Include="packages.config" />
  </ItemGroup>
  <ItemGroup>
    <ProjectReference Include="..\Algorithms\Algorithms.csproj">
      <Project>{8F59D573-A1B8-438F-A67A-A7F11FACF201}</Project>
      <Name>Algorithms</Name>
    </ProjectReference>
    <ProjectReference Include="..\DataStructures\DataStructures.csproj">
      <Project>{464251a0-3667-42ba-a3d5-0581d65c442b}</Project>
      <Name>DataStructures</Name>
    </ProjectReference>
  </ItemGroup>
  <Choose>
    <When Condition="'$(VisualStudioVersion)' == '10.0' And '$(IsCodedUITest)' == 'True'">
      <ItemGroup>
        <Reference Include="Microsoft.VisualStudio.QualityTools.CodedUITestFramework, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
          <Private>False</Private>
        </Reference>
        <Reference Include="Microsoft.VisualStudio.TestTools.UITest.Common, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
          <Private>False</Private>
        </Reference>
        <Reference Include="Microsoft.VisualStudio.TestTools.UITest.Extension, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
          <Private>False</Private>
        </Reference>
        <Reference Include="Microsoft.VisualStudio.TestTools.UITesting, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a, processorArchitecture=MSIL">
          <Private>False</Private>
        </Reference>
      </ItemGroup>
    </When>
  </Choose>
  <Import Project="$(VSToolsPath)\TeamTest\Microsoft.TestTools.targets" Condition="Exists('$(VSToolsPath)\TeamTest\Microsoft.TestTools.targets')" />
  <Import Project="$(MSBuildToolsPath)\Microsoft.CSharp.targets" />
  <!-- To modify your build process, add your task inside one of the targets below and uncomment it. 
       Other similar extension points exist, see Microsoft.Common.targets.
  <Target Name="BeforeBuild">
  </Target>
  <Target Name="AfterBuild">
  </Target>
  -->
</Project>