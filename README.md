CREATE TABLE [dbo].[Equipes] (
    [RefEquipe] INT           IDENTITY (1, 1) NOT NULL,
    [Nom]       NVARCHAR (50) NULL,
    [Ville]     NVARCHAR (50) NULL,
    [Budget]    MONEY         NULL,
    [Coach]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([RefEquipe] ASC)
);


CREATE TABLE [dbo].[Joueurs] (
    [RefJoueur]   INT           IDENTITY (1, 1) NOT NULL,
    [Nom]         NVARCHAR (50) NULL,
    [Poste]       NVARCHAR (50) NULL,
    [Salaire]     MONEY         NULL,
    [Naissance]   DATETIME      NULL,
    [ReferEquipe] INT           NULL,
    PRIMARY KEY CLUSTERED ([RefJoueur] ASC),
    CONSTRAINT [FK_Joueurs_Equipes] FOREIGN KEY ([ReferEquipe]) REFERENCES [dbo].[Equipes] ([RefEquipe])
);


if need:
<?xml version="1.0" encoding="utf-8"?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  https://go.microsoft.com/fwlink/?LinkId=169433
  -->
<configuration>
  <configSections>
    <!-- For more information on Entity Framework configuration, visit http://go.microsoft.com/fwlink/?LinkID=237468 -->
    <section name="entityFramework" type="System.Data.Entity.Internal.ConfigFile.EntityFrameworkSection, EntityFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" requirePermission="false" />
  </configSections>
  <system.web>
    <compilation debug="true" targetFramework="4.7.2" />
    <httpRuntime targetFramework="4.7.2" />
  </system.web>
  <system.codedom>
    <compilers>
      <compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:default /nowarn:1659;1699;1701" />
      <compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.VBCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:default /nowarn:41008 /define:_MYTYPE=\&quot;Web\&quot; /optionInfer+" />
    </compilers>
  </system.codedom>
  <connectionStrings>
    <add name="DBSportEntities" connectionString="metadata=res://*/ModelSport.csdl|res://*/ModelSport.ssdl|res://*/ModelSport.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(localdb)\MSSQLLocalDB;initial catalog=DBSport;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    <!--<add name="DBSportEntities1" connectionString="metadata=res://*/ModelSport.csdl|res://*/ModelSport.ssdl|res://*/ModelSport.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(localdb)\MSSQLLocalDB;initial catalog=DBSport;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />-->
	<add name="DBSportEntities1" connectionString="metadata=res://*/ModelSport.csdl|res://*/ModelSport.ssdl|res://*/ModelSport.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(localdb)\MSSQLLocalDB;initial catalog=DBSport;AttachDbFilename=C:\Users\ivanj\Desktop\v6\prjWebCsEntityFrameworkAdo\prjWebCsEntityFrameworkAdo\App_Data\DBSport.mdf;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
  <entityFramework>
    <defaultConnectionFactory type="System.Data.Entity.Infrastructure.LocalDbConnectionFactory, EntityFramework">
      <parameters>
        <parameter value="mssqllocaldb" />
      </parameters>
    </defaultConnectionFactory>
    <providers>
      <provider invariantName="System.Data.SqlClient" type="System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer" />
    </providers>
  </entityFramework>
</configuration>
