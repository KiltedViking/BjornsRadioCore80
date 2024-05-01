# BjornsRadioCore80

This is my "learning project" that I've used for 30+ years to learn new languages and frameworks in development. Björn's Radio is a ficticious radio for persons called Björn (bear in Swedish) and living in my house/flat. ;-)

## Set up project

These steps where taken to set up this project before starting writing any C# code.

1. Add user secrets to project - right-click project and select Manage User Secrets.
2. Add connection string (`BjornsRadioDb` in my case).

```
"ConnectionStrings": {
    "BjornsRadioDb-ADD-TO-USER-SECRETS": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=YOUR-DATABASE;Integrated Security=True"
  }
```

3. Add NuGet package `Microsoft.EntityFrameworkCore.Tools`, which in its turn will add `Microsoft.EntityFrameworkCore.Design` - right-click project and selecte Manage NuGet Packages....
4. Add NuGet package for database (`Microsoft.EntityFrameworkCore.SqlServer` in my case).

## Creating data model and DbContext class

Here there is a choice of using code first (no existing database) or database first (database exists).

### Code first (alternative 1)

This involves creating model classes and DbContext classes first, and then use migrations to create database.

[TO DO]

### Reverse engineer database (alternative 2)

If database already exists (as in my case), perform steps below to genereate model classes and DbContext class from tables in database.
 
a. Open Package Manager Console (or command prompt, if want to use CLI tools ;-)).
b. Run `Scaffold-DbContext` command (in EF Tools, i.e. `dotnet ef dbcontext scaffold ...` if using CLI), supplying name of connection string (`BjornsRadioDb` in my case), output directory for model classes (`Models` in my case), "context directory" (optional; `Data` in my case) and name of DbContext class (optional; `BjornsRadioDbContext` in my case).

```
Scaffold-DbContext "Name=BjornsRadioDb" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Models" -ContextDir "Data" -Context "BjornsRadioDbContext"
```

c. Verify that DbContext class and model classes were created correctly.

## Scaffold controllers for Web API

With project set up, model classes and DbContext classes, it is time to scaffold (generate) controllers for enpoints in API.

