<!-- TABLE OF CONTENTS -->
## Table of Contents

* [About the Project](#about-the-project)
* [Built With](#built-with)
* [Roadmap](#roadmap)


<!-- ABOUT THE PROJECT -->
## About The Project

OneStopRentals is a N-Tier layered architecture with a MVC frontend framework. It was my first independent project implementing all patterns and frameworks with a user focused webpage deployed to the Azure cloud. This was done with support from Eleven Fifty Academy's software development program Jan-April 2020.

My project is an property management software focusing on developing support for landlords or developers. Currently, it is an internal service with the intention to expand on the level of services. The software will bring together multiple tenets with the convenience of actionable insights and transparency with the goal to maintain good standing tenets and mitigate outstanding payables. 



## Built With

* [.Net Framework]()
* [Bootstrap]()
* [Razor Pages]()


## Roadmap

Migrations
There is already an object named 'IdentityRole' in the database.
Solution: Go to WebConfig and check the CatalogName, another project listed

Either the parameter @objname is ambiguous or the claimed @objtype (COLUMN) is wrong.
Solution: Go to WebConfig and check the CatalogName, another project listed

Could not drop object 'dbo.FloorPlan' because it is referenced by a FOREIGN KEY constraint.
Solution: Check the Data.cs probably still renamed compare with changed namespace 

The project 'OneStopRentals.WebMVC' failed to build.
Solution: Check SQL Server probably need to refresh DB list and delete old DB

Cannot find the object "dbo.Maintenance" because it does not exist or do not have permissions.
Solution: Deleted only part of DBO, should delete entire DB and re-migrate

Services
system.invalidoperationexception sequence contains no elements
Solution: In Services must list .SingleOrDefault to allow empty Views IPO .Single or .First

System.NullReferenceException: 'Object reference not set to an instance of an object.
Solution: Missing an ID body reference in Get section of Service layer

Views
System.ArgumentNullException: Value cannot be null. Parameter name:input
Solution: Guid cannot be null, must seed Db by register user

Unable to cast object of type 'System.Int32' to type 'System.String'.
Solution: Data annotation is a string type while property is an int

The parameters dictionary contains a null entry for parameter 'id' of non-nullable type 'System.Int32' for method 'System.Threading.Tasks.Task`1[System.Web.Mvc.ActionResult] Edit(Int32)' in 'OneStopRentals.WebMVC.Controllers.MaintenanceController'. An optional parameter must be a reference type, a nullable type, or be declared as an optional parameter.
Parameter name: parameters
Solution: @Html.ActionLink

Foreign Keys
https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application

Bootstrap/CSS
https://www.linkedin.com/learning/css-essential-training-3/introduction-to-responsive-design?u=2748652
https://www.linkedin.com/learning/bootstrap-4-essential-training/welcome?u=2748652
