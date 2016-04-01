This is a test application that implements the CRUD operations based on a Employees Repository. Two different models Employee and Department has been created with the aim of having a model relation. The CRUD operations applied to the Employee entity only. The code first approach has been used so that the database tables are automatically created from the entities. When the application runs for first time it will check if the database exists. If the database does not exist it will create and populate it with some sample data.

A repository pattern has be created in order to decouple the DAL layer from the controller. This helps making the different layers more reusable and easy to tests. In order to inject the dependencies the Dependency Pattern has been used. 


The next libraries has been utilised:
- Microsoft Asp Net to implement the MVC pattern.
- Entity Framework to access the SQL Server
- Ninject 
- Bootstrap

All packages are managed using Nuget. 



Additionally a test project has been added in order to test the controller layer. Note that only some test mothods has been added to demonstrate the use of some of the extrategies, technologies and framework for testing and mocking.