/*
  1) Install package Identity
    - pre requirement pkgs: (EF-Core.SqlServer, EF-Core.Tools)
  2) create class ApplicationUser: IdentityUser --> (create it even if it will be empty) 
    - create in Model 
  3) Edit Context --> Context: IdentityDbContext<ApplicationUser>
  4) add-migration & update-database
  5) create AccountController
  6) create RegisterViewModel
  7) Register Action 
  8) register Identity Service at Program Calss
*/