# C# ASP.NET Web API - Proof of Concept project

## Purpose
> To create a solution on Visual Studio to run a simple CRUD web application using:
 * Multitier architecture:
   * Data layer (Entity Framework)
   * Business layer
   * Service  layer (WCF)
   * Presentation layer (Web API + MVC/jquery/datatables)
 * [Dependency Injection (DI)](#dependency-injection) with Unity to enable the decoupling of each individual layer
 * [Test-Driven Development (TDD)](#unit-test) with an example of Unit Test project for the presentation layer

## Solution Structure and Layer Division
> After creating the projects and setting their dependencies, the code map for the solution is:
![](https://github.com/rembertmagri/web_api/blob/master/images/architecture%20code%20map.png?raw=true)

## Web API
> The Web API logic was created using the tutorial below. After successfully completing the tutorial, a Web Application was created and the TodoItemController was transfered to the PresentationWebAPI project. All CRUD operations for the Todo Items were tested using Postman:
LIST
![](https://github.com/rembertmagri/web_api/blob/master/images/api_postman_l.png?raw=true)
CREATE
![](https://github.com/rembertmagri/web_api/blob/master/images/api_postman_c.png?raw=true)
READ
![](https://github.com/rembertmagri/web_api/blob/master/images/api_postman_r.png?raw=true)
UDPADE
![](https://github.com/rembertmagri/web_api/blob/master/images/api_postman_u.png?raw=true)
DELETE
![](https://github.com/rembertmagri/web_api/blob/master/images/api_postman_d.png?raw=true)

For GET requests, the browser can also be used:
![](https://github.com/rembertmagri/web_api/blob/master/images/api_browser_l.png?raw=true)

Useful references:
* [Create a Web API with ASP.NET Core and Visual Studio](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.1)

## MVC + jQuery + Datatables

> For the "MVC + jQuery + Datatables" part of the project, the main javascript library used were jQuery, Datatables and jQueryUI (for the modals). In this case, the main visual part of the 'logic' is concentrated in the script Presentation_WebAPI\Scripts\TodoItem\DataTable.js

LIST
![](https://github.com/rembertmagri/web_api/blob/master/images/jquery_list.png?raw=true)
CREATE
![](https://github.com/rembertmagri/web_api/blob/master/images/jquery_create.png?raw=true)
READ
![](https://github.com/rembertmagri/web_api/blob/master/images/jquery_read.png?raw=true)
UPDATE
![](https://github.com/rembertmagri/web_api/blob/master/images/jquery_update.png?raw=true)
DELETE
![](https://github.com/rembertmagri/web_api/blob/master/images/jquery_delete.png?raw=true)

Useful references:
* [jQuery](https://jquery.com/)
* [jQueryUI](https://jqueryui.com/)
* [DataTables](https://datatables.net/)

## Dependency Injection

> To allow the execution of unit tests on each layer, the Unity library was added to the Presentation project. Dependency injection (aka Inversion of Control) allows the presentation layer (controllers) to use registered services in runtime, thus enabling the tester to easily decouple the service layer from the presentation layer and use a mock service to reduce the scope of the unit tests.

> First, Unity was installed via NuGet:
![](https://github.com/rembertmagri/web_api/blob/master/images/unity_nuget.png?raw=true)

> UnityConfig class was created. This class is responsible for registering the interfaces of the services that will be used by the controllers (in their constructors). The binding is done automatically in runtime by the Unity.Mvc5 library. The Global.asax file was to be changed to include UnityConfig.RegisterComponents() method inside Application_Start. The controllers (API and MVC) had to be changed to require the ITodoItemService in their constructors. The service will be inserted by Unity (in production environment) or programmatically/manually in the unit tests.

Useful references:
* [Dependency Injection with Unity](https://www.c-sharpcorner.com/article/dependency-injection-in-asp-net-mvc-5/)

## Unit Test

> In order to approximate this project even further with a real-world scenario, a new project was created to allow the execution of unit tests and thus simulate a Test-Driven Development methodology, commonly used amongst IT departments in the industry today. Presentation_WebAPI.Tests project was created inside the solution, and references the presentation layer project and to the Common library were added.
![](https://github.com/rembertmagri/web_csharp/blob/master/images/test_references.png?raw=true)

> Then, a MockTodoItemService implementing the ITodoItemService was created. This is the mock service that would be used during the tests instead of using the real service implementation (WCF) injected by Unity.
![](https://github.com/rembertmagri/web_csharp/blob/master/images/test_mock.png?raw=true)

> Finally, some unit tests were implemented using the 'AAA' unit test pattern (Arrange, Act, Assert).
![](https://github.com/rembertmagri/web_csharp/blob/master/images/test_impl.png?raw=true)

> The results of the tests can be seen in the Test Explorer tab.
![](https://github.com/rembertmagri/web_csharp/blob/master/images/test_results.png?raw=true)

Useful references:
* [TDD - Test-Driven Development](https://msdn.microsoft.com/en-us/library/ff847525(v=vs.100).aspx)

## Conclusion

This project demonstrated the differences when using MVC only to develop the presentation layer of a web application and when using some of the most popular javascript libraries, such as jQuery with Datatables and AngularJS. Additionally, some of the most common practices used in software development departments today were showcased, such as unit tests and dependency injection.
