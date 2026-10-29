Create a simple resource manager backend using the .NET stack. 

The software must be separated to the following layers/projects:

Data layer

Data to handle:
·         Resources

·         unique name

·         maximum usages

·         ResourceUsages

·         used resource

·         timestamp of usage

Use Entity Framework Core with 'code first' approach.
Optimize database performance for the current application scope.
·         You can use database server features (e.g. indexes).

·         You may add fields to the tables.

·         Don't use stored procedures!

Bonus: Prepare for the use of EF migrations.
Bonus: Create database automatically if it doesn't exist.
Business layer

Create a service class that consists the following method:

UseResource
·         Uses the data layer above for data persistence.

·         Finds any resource that has any usage left.

·         If no such resource available, then creates a new one with a generated name and maximum usages of 3.

·         "Uses" the resource: creates a new ResourceUsage attached to the selected/created resource.

·         Returns the resource name and the number of usages left.

·         Bonus: Considers concurrency. (On the data level. Not thread-safety!)

 

Create a unit test! (Testing concurrency handling is not a requirement.)

 

API layer

Create the API layer with a current technology you are comfortable with, e.g. ASP.NET Web API, gRPC.
API must offer one action named UseResource. Calls UseResource from business layer.
Create as a console application that hosts the API!

 

Technologies to be used:

.NET 8
Microsoft SQL Server
C# with nullable features enabled
IoC pattern
 

Bonus task: create a simple frontend that has one button. Pressing the button makes a call to the API action and displays the used resource name and number of usages left.
Use whatever frontend technology you are comforable with (some web technology preferred).
