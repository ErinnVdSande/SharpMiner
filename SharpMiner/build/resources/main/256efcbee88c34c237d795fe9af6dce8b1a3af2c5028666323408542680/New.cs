﻿<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>    
    <TargetFramework>netcoreapp2.0</TargetFramework>
  </PropertyGroup>
  
  <ItemGroup>
    <PackageReference Include="xunit" Version="2.4.1" />
  </ItemGroup>
  
  <ItemGroup>
    <Content Include="Data\PrimesDocument_10K.csv">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </Content>
  </ItemGroup>

  <ItemGroup>
    <None Update="Data\PrimesDocument_10K.csv">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
  </ItemGroup>
</Project>