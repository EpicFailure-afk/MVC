/*
  1) Install package Identity
    - pre requirement pkgs: (EF-Core.SqlServer, EF-Core.Tools)
  2) create class ApplicationUser: IdentityUser --> (create it even if it will be empty) 
    - create in Model 
  3) Edit Context --> Context: IdentityDbContext<ApplicationUser>
  4) add-migration
  5) update-database
*/