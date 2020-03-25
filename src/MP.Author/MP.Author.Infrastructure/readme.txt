Gen init dbcontext 
1. dotnet ef migrations add InitialIdentity --context AppDbContext
2. dotnet ef migrations add InitialIdentity --context AppIdentityDbContext

format: dotnet ef migrations add {part name file gen} --context {name dbcontext}

Update DbContext
1. dotnet ef database update --context AppIdentityDbContext
2. dotnet ef database update --context AppDbContext

format: dotnet ef database update --context {name dbcontext}
