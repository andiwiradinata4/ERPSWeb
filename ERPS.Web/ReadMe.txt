== create project .NET Core in cmd ==
1. run "dotnet new webapi -o [project_name]"

== run project .NET Core in cmd ==
1. cd -> Project Path
2. run "dotnet watch run"

== Extension Helper in VS Code ==
1. C#
2. C# Dev Kit
3. .Net Extension Pack
4. .Net Install Tool
5. Nuget Gallery
6. Prettier
7. Extension Pack By JosKreativ
8. Microsoft.AspNetCore.Mvc.NewtonsoftJs

== Models ==
1. Create Folder "Models" in project API
2. Right Click Folder "Models" -> New C# -> Class

== Install Nuget Packages for use Entity Framework (ORM)==
1. Open Nuget Gallery: CTRL + R -> Nuget Gallery
2. Install Microsoft.EntityFrameworkCore.SqlServer -> Version same with netCore Version
3. Install Microsoft.EntityFrameworkCore.Tools -> Version same with netCore Version
4. Install Microsoft.EntityFrameworkCore.Design -> Version same with netCore Version
5. Create folder "Data" in project API for file DBContext
6. Right Click Folder "Data" -> New C# -> Class -> "ApplicationDBContext"

== Migrate Models ==
1. run "dotnet ef migrations add init" -> add-migration "First Migrate" -Context AppDBContext -> dotnet ef migrations add InitialCreate --project ../ERPS.Infrastructure --startup-project ../ERPS.Web
2. run "dotnet ef database update" -> update-database -Context AppDBContext -> dotnet ef database update --project ../ERPS.Infrastructure --startup-project ../ERPS.Web

== Using Identity JWT ==
1. Open Nuget Gallery: CTRL + R -> Nuget Gallery
2. Install Microsoft.EntityFrameworkCore.SqlServer -> Version same with netCore Version
3. Install Microsoft.Extensions.Identity.Core
4. Install Microsoft.AspNetCore.Identity.EntityFrameworkCore
5. Install Microsoft.AspNetCore.Authentication.JwtBearer