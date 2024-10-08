/Controllers              - Folder for controllers
  /EmployeeController.cs     - Employee CRUD
  /HomeController.cs         - Navigation to Index/Privacy
  /ProductController.cs      - Product CRUD
  /SupplierController.cs     - Supplier CRUD
/Data
  /EFConfigurations        - Contains all ef core configurations
    /CivilStatusConfiguration.cs
    /EmployeeConfiguration.cs
    /GenderConfiguration.cs
    /PositionConfiguration.cs
    /ProductConfiguration.cs
    /SupplierConfiguration.cs
  /DataContext.cs
/Models                     - contains business models
  /CivilStatus.cs
  /Employee.cs
  /ErrorViewModel.cs
  /Gender.cs
  /Position.cs
  /Product.cs
  /Supplier.cs
/Pages
  /_ValidationScriptsPartial.cshtml
/Services
  /Interfaces   - contains interfaces for repository
    /ICivilStatusRepository.cs
    /IEmployeeRepository.cs
    /IGenderRepository.cs
    /IPositionRepository.cs
    /IProductRepository.cs
    /ISupplierRepository.cs
  /CivilStatusRepository.cs
  /EmployeeRepository.cs
  /GenderRepository.cs
  /PositionRepository.cs
  /ProductRepository.cs
  /SupplierRepository.cs
/ViewModels
  /EmployeeVM    - employee view models
    /EmployeeCRUDVM.cs
    /EmployeeReadVM.cs
    /EmployeeSearchViewModel.cs
  /ProductVM     - product view models
    /OrderPostVM.cs
/Views
  /Employee      - Employee views
    /Create.cshtml
    /Delete.cshtml
    /Details.cshtml
    /Edit.cshtml
    /Index.cshtml
  /Home           - Home views
    /Index.cshtml
    /Privacy.cshtml
  /Product        - Product views
    /Create.cshtml
    /Delete.cshtml
    /Details.cshtml
    /Edit.cshtml
    /Index.cshtml
  /Suppliers       - Suppliers views
    /Create.cshtml
    /Delete.cshtml
    /Details.cshtml
    /Edit.cshtml
    /Index.cshtml
  /_ViewImports.cshtml
  /_ViewStart.cshtml
/appsettings.json  - contains connection string
/Program.cs - program's entry point
/StartupWebApplication.cs - contains services and pipelines.
