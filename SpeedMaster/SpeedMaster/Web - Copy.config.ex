﻿﻿<?xml version="1.0" encoding="utf-8"?>
<!--
  For more information on how to configure your ASP.NET application, please visit
  https://go.microsoft.com/fwlink/?LinkId=169433
    agora
  -->
<configuration>

	<system.web>
		<compilation debug="true" targetFramework="4.7.2" />
		<httpRuntime targetFramework="4.7.2" />
	</system.web>
	<appSettings>
		<add key="ValidationSettings:UnobtrusiveValidationMode" value="None" />
		<add key="SMTP_HOST" value="smtp.office365.com" />
		<add key="SMTP_PORT" value="587" />
		<add key="SMTP_USER" value="aqui poem o vosso email" />
		<add key="SMTP_PASS" value="aqui poem a vossa password" />
	</appSettings>
	<system.codedom>
		<compilers>
			<compiler language="c#;cs;csharp" extension=".cs" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:default /nowarn:1659;1699;1701" />
			<compiler language="vb;vbs;visualbasic;vbscript" extension=".vb" type="Microsoft.CodeDom.Providers.DotNetCompilerPlatform.VBCodeProvider, Microsoft.CodeDom.Providers.DotNetCompilerPlatform, Version=2.0.1.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" warningLevel="4" compilerOptions="/langversion:default /nowarn:41008 /define:_MYTYPE=\&quot;Web\&quot; /optionInfer+" />
		</compilers>
	</system.codedom>
</configuration>